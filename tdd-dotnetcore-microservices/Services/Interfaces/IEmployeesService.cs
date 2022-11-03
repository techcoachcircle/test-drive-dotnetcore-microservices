using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tdd_dotnetcore_microservices.Models;

namespace tdd_dotnetcore_microservices.Services.Interfaces
{
    public interface IEmployeesService
    {
        public IEnumerable<Employee> GetAllEmployees();


    }
}
