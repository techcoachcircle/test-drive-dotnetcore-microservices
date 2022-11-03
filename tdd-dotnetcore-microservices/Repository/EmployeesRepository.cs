using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Repository.Interfaces;

namespace tdd_dotnetcore_microservices.Repository
{
    public class EmployeesRepository : IEmployeesRepository
    {
        public IEnumerable<Employee> GetAllEmployees()
        {
            return null;
        }
    }
}
