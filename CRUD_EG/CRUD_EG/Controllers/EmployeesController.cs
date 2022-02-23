using CRUD_EG.EmployeeData;
using CRUD_EG.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUD_EG.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;

        public EmployeesController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            var employee = _employeeData.GetEmployee(id);
            if(employee!=null)
            {
                return Ok(_employeeData.GetEmployee(id));
            }
            else
            {
                return NotFound($"Employee with {id} not found!!!");
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id,employee);
        }
        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult DeleteEmployee(Employee employee)
        {
            _employeeData.DeleteEmployee(employee);
            return Ok("Deleted Successfully!!!");
        }

        [HttpPatch]
        [Route("api/[controller]")]
        public IActionResult Edit(Guid id, Employee employee)
        {
            var existingEmployee = _employeeData.GetEmployee(id);
            if(existingEmployee !=null)
            {
                employee.Id = existingEmployee.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
    }
}
