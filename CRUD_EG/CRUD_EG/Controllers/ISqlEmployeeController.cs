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
    public class ISqlEmployeeController : ControllerBase
    {
        private readonly IEmployeeData _employeeData;
        public ISqlEmployeeController(IEmployeeData employeeData)
        {
            _employeeData = employeeData;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public IActionResult GetEmployees()
        {
            return Ok(_employeeData.GetEmployees());
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult AddEmployee(Employee employee)
        {
            _employeeData.AddEmployee(employee);
            return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + employee.Id, employee);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public IActionResult GetEmployee(Guid id)
        {
            return Ok(_employeeData.GetEmployee(id));
        }

        [HttpPut]
        [Route("api/[controller]/{id}")]
        public IActionResult Edit(Guid id,Employee employee)
        {
            var existingData = _employeeData.GetEmployee(id);
            if(existingData != null)
            {
                employee.Id = existingData.Id;
                _employeeData.EditEmployee(employee);
            }
            return Ok(employee);
        }
        [HttpDelete]
        [Route("api/[controller]")]
        public IActionResult Delete(Employee employee)
        {
            _employeeData.DeleteEmployee(employee);
            return Ok("Deleted Successfully!!!");
        }
    }
}
