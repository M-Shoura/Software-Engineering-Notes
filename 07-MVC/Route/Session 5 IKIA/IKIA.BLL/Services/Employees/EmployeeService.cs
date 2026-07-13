using IKIA.BLL.DTOs.Employees;
using IKIA.DAL.Models.Employees;
using IKIA.DAL.Presistence.Repositories.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Services.Employees
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }
        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeRepository.GetAllAsIQueryable().Select(e=> new EmployeeDTO()
            {
                Id = e.Id,
                Name = e.Name,
                Age = e.Age,
                Email = e.Email, 
                IsActive = e.IsActive,
                Salary = e.Salary,
                EmployeeType = e.EmployeeType.ToString(),  
                Gender = e.Gender.ToString()                  
            });
        }
        public EmployeeDetailsDTO? GetEmployeeById(int employeeId)
        {
            var employee = _employeeRepository.Get(employeeId);

            if (employee == null)
                return null;
            return new EmployeeDetailsDTO()
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Email = employee.Email,
                IsActive = employee.IsActive,
                Salary = employee.Salary,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                PhoneNumber = employee.PhoneNumber  
            };
        }
        public int CreateEmployee(CreateEmployeeDTO employee)
        {
            var emp = new Employee()
            {
                Name = employee.Name,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Email = employee.Email,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };

            return _employeeRepository.Add(emp);
        }
        public int UpdateEmployee(UpdateEmployeeDTO employee)
        {
            var emp = new Employee()
            {
                Id = employee.Id,
                Name = employee.Name,
                EmployeeType = employee.EmployeeType,
                Gender = employee.Gender,
                Email = employee.Email,
                IsActive = employee.IsActive,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                CreatedBy = 1,
                LastModifiedBy = 1,
                LastModifiedOn = DateTime.Now,
            };

            return _employeeRepository.Update(emp);
        }
        public bool DeleteEmployee(int employeeId)
        {
            var emp = _employeeRepository.Get(employeeId);
            if (emp is { })
                return _employeeRepository.Delete(emp) > 0;
            return false;
        }
    }
}
