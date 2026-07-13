using IKIA.BLL.DTOs.Departments;
using IKIA.BLL.DTOs.Employees;
using IKIA.DAL.Models.Employees;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Services.Employees
{
    public interface IEmployeeService
    {
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync(string search);
        Task<EmployeeDetailsDTO?> GetEmployeeByIdAsync(int employeeId);
        Task<int> CreateEmployeeAsync(CreateEmployeeDTO employee);
        Task<int> UpdateEmployeeAsync(UpdateEmployeeDTO employee);
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}
