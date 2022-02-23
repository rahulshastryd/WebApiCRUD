using CRUD_EG.EmployeeData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace CRUD_EG.Models
{
    public class MockEmployeeData : IEmployeeData
    {
        private List<Employee> employees = new List<Employee>
        {
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee One"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee Two"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee Three"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee Four"
            },
            new Employee
            {
                Id = Guid.NewGuid(),
                Name = "Employee Five"
            }
        };

        public Employee AddEmployee(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            employees.Add(employee);
            return employee;
        }

        public void DeleteEmployee(Employee employee)
        {
            employees.Remove(employee);
        }

        public Employee EditEmployee(Employee employee)
        {
            var existingEmployee = GetEmployee(employee.Id);
            existingEmployee.Name = employee.Name;
            return existingEmployee;
        }

        public Employee GetEmployee(Guid id)
        {
            return employees.FirstOrDefault(x => x.Id == id);
        }

        public List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
