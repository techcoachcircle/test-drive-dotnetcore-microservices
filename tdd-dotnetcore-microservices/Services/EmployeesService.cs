using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Services.Interfaces;

namespace tdd_dotnetcore_microservices.Services
{
    public class EmployeesService : IEmployeesService
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return null;
        }
    }
}
