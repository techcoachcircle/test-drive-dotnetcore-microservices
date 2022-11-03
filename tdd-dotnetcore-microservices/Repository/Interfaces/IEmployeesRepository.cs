using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;

namespace tdd_dotnetcore_microservices.Repository.Interfaces
{
    public interface IEmployeesRepository
    {
        IEnumerable<Employee> GetAllEmployees();
    }
}
