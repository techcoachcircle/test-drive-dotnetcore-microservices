using System.Collections.Generic;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Repository.Interfaces;
using tdd_dotnetcore_microservices.Services.Interfaces;

namespace tdd_dotnetcore_microservices.Services
{
    public class EmployeesService : IEmployeesService
    {
        private readonly IEmployeesRepository _employeeRepository;
        public EmployeesService(IEmployeesRepository employeesRepository)
        {
            this._employeeRepository = employeesRepository;
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeRepository.GetAllEmployees();
        }
    }
}
