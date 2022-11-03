using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tdd_dotnetcore_microservices.Models;
using tdd_dotnetcore_microservices.Services.Interfaces;

namespace tdd_dotnetcore_microservices.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly IEmployeesService _employeeService;

        public EmployeesController(IEmployeesService employeeService, ILogger<EmployeesController> logger)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<Employee>> GetAll()
        {
                return _employeeService.GetAllEmployees()?.ToList();
        }
    }
}
