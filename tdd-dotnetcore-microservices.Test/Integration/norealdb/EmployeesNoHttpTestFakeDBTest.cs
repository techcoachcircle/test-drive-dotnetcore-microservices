using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Repository;

namespace tdd_dotnetcore_microservices.Test.Integration.Nohttp.Norealdb
{
    public class EmployeesNoHttpTestFakeDBTest
    {
        private readonly HttpClient _client;
        public EmployeesNoHttpTestFakeDBTest()
        {
            var applicationFactory = new WebApplicationFactory<Startup>()
                                        .WithWebHostBuilder(builder =>
                                        {
                                            builder.ConfigureServices(services =>
                                            {
                                                services.RemoveAll(typeof(RepositoryContext));
                                                services.AddDbContext<RepositoryContext>(options =>
                                                {
                                                    options.UseInMemoryDatabase("TestEmployeeManagementDb");
                                                });

                                            });
                                        });

            using (var serviceScope = applicationFactory.Services.CreateScope())
            {
                var repositoryContext = serviceScope.ServiceProvider.GetRequiredService<RepositoryContext>();

                repositoryContext.AddRange(EmployeesTestData.SeedData());
            }

            _client = applicationFactory.CreateClient();
        }

        [Test]
        public async Task shouldReturnAllEmployeesWhenFindAllAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/employees");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            string body = response.Content.ReadAsStringAsync().Result;

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(body);

            List<Employee> masterData = EmployeesTestData.SeedData();

            CollectionAssert.AreEquivalent(masterData, employees);
        }
    }
}