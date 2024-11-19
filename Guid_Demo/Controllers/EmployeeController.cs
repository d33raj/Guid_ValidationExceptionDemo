using Guid_Demo.Models;
using Guid_Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Guid_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices _services;

        public EmployeeController(IEmployeeServices services)
        {
            _services = services;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_services.GetAllEmployees());
        }

        [HttpGet("Id/{id}")]
        public IActionResult Get(Guid id)
        {
            return Ok(_services.GetEmployee(id));
        }

        [HttpPost]
        public IActionResult Add(Employee employee)
        {
            if(!ModelState.IsValid)
            {
                var errors= string.Join("; ",ModelState.Values
                    .SelectMany(v=> v.Errors)
                    .Select(e=> e.ErrorMessage));
                throw new ValidationException($"{errors}");
            }
            return Ok(_services.AddEmployee(employee));
        }

    }
}
