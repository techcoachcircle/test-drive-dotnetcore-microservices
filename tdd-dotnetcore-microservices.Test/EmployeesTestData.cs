using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;

namespace tdd_dotnetcore_microservices.Test
{
    public static class EmployeesTestData
    {
        public static List<Employee> SeedData() {
            return new List<Employee>() {
                new Employee
                {
                    Id =1,
                    Name = "John Doe",
                    Age = 30
                },
                new Employee
                {
                    Id = 2,
                    Name = "Jane Doe",
                    Age = 25
                },
                new Employee
                {
                    Id = 3,
                    Name = "Will Doe",
                    Age = 30
                }
            };
        }
    }
}
