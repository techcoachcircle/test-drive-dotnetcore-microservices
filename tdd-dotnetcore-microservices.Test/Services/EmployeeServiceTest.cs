using Moq;
using NUnit.Framework;
using System.Linq;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Repository.Interfaces;
using tdd_dotnetcore_microservices.Services;
using tdd_dotnetcore_microservices.Services.Interfaces;

namespace tdd_dotnetcore_microservices.Test.Services
{
    class EmployeesServiceTest
    {
        Mock<IEmployeesRepository> mockEmployeeRepository = new Mock<IEmployeesRepository>();

        [Test]
        public void GetEmployees_ReturnsEmployees()
        {
            //arrange
            mockEmployeeRepository.Setup(m => m.GetAllEmployees()).Returns(EmployeesTestData.SeedData());

            IEmployeesService employeesService = new EmployeesService(mockEmployeeRepository.Object);

            var employees = employeesService.GetAllEmployees().ToList();

            //act & assert
            Assert.That(3 == employees.Count(), Is.True, "Should contain 3 employees");

            Employee firstReturnedEmployee = employees[0];
            Assert.True(firstReturnedEmployee.Id == EmployeesTestData.SeedData()[0].Id);
            Assert.True(firstReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[0].Name));
            Assert.True(firstReturnedEmployee.Age == EmployeesTestData.SeedData()[0].Age);

            Employee secondReturnedEmployee = employees[1];
            Assert.True(secondReturnedEmployee.Id == EmployeesTestData.SeedData()[1].Id);
            Assert.True(secondReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[1].Name));
            Assert.True(secondReturnedEmployee.Age == EmployeesTestData.SeedData()[1].Age);

            Employee thirdReturnedEmployee = employees[2];
            Assert.True(thirdReturnedEmployee.Id == EmployeesTestData.SeedData()[2].Id);
            Assert.True(thirdReturnedEmployee.Name.Equals(EmployeesTestData.SeedData()[2].Name));
            Assert.True(thirdReturnedEmployee.Age == EmployeesTestData.SeedData()[2].Age);
        }
    }
}
