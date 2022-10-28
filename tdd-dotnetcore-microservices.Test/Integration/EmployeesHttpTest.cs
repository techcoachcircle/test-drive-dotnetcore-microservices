using NUnit.Framework;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Hosting;
using tdd_dotnetcore_microservices.Repository;

namespace tdd_dotnetcore_microservices.Test.Integration
{
    public class EmployeesHttpTest
    {
        private readonly IHost _host;
        public EmployeesHttpTest()
        {
            _host = Host.CreateDefaultBuilder()
                                .ConfigureWebHostDefaults(builder =>
                                {
                                    // Use the test server and point to the application's startup
                                    builder.UseTestServer()
                                            .UseStartup<Startup>();
                                })
                                .ConfigureServices(services =>
                                {
                                    using (var serviceScope = services.BuildServiceProvider().CreateScope())
                                    {
                                        var repositoryContext = serviceScope.ServiceProvider.GetRequiredService<RepositoryContext>();

                                        repositoryContext.AddRange(EmployeesTestData.SeedData());
                                    }
                                })
                                .Build();
        }

        [Test]
        public async Task shouldReturnAllEmployeesWhenFindAllAsync()
        {
            await _host.StartAsync();

            var client = _host.GetTestClient();

            HttpResponseMessage response = await client.GetAsync("/employees");

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK, "Should respond with 200 OK");

            string body = response.Content.ReadAsStringAsync().Result;

            List<Employee> employees = JsonConvert.DeserializeObject<List<Employee>>(body);

            List<Employee> masterData = EmployeesTestData.SeedData();

            CollectionAssert.AreEquivalent(masterData, employees);

            _host.Dispose();
        }
    }
}