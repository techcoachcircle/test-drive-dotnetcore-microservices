using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using Newtonsoft.Json;
using NUnit.Framework;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection.Extensions;
using tdd_dotnetcore_microservices.Services.Interfaces;

namespace tdd_dotnetcore_microservices.Test.Controllers
{
    public class EmployeesControllerTest
    {
        private readonly HttpClient _client;

        Mock<IEmployeesService> mockEmployeeService = new Mock<IEmployeesService>();

        public EmployeesControllerTest()
        {
              var application = new WebApplicationFactory<Program>()
                                    .WithWebHostBuilder(builder =>
                                    {
                                        builder.ConfigureServices(services =>
                                        {
                                            // set up services
                                            services.Replace(ServiceDescriptor.Scoped(typeof(IEmployeesService), _ => mockEmployeeService.Object));
                                        });
                                    });

            _client = application.CreateClient();
        }

        [SetUp]
        public void Setup()
        {
            //arrange
            mockEmployeeService.Setup(e => e.GetAllEmployees()).Returns(EmployeesTestData.SeedData());
        }


        [Test]
        public async Task GetEmployees_ReturnsEmployeesAsync()
        {
            HttpResponseMessage response = await _client.GetAsync("/employees");

            response.EnsureSuccessStatusCode();

            string result = response.Content.ReadAsStringAsync().Result;

            //act & assert
            Assert.That(result,Is.EqualTo("[{\"Id\":1,\"Name\":\"John Doe\",\"Age\":30},{\"Id\":2,\"Name\":\"Jane Doe\",\"Age\":25},{\"Id\":3,\"Name\":\"Will Doe\",\"Age\":30}]"));
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
        }
    }
}
