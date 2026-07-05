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
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDetailsDTO? GetEmployeeById(int employeeId);
        int CreateEmployee(CreateEmployeeDTO employee);
        int UpdateEmployee(UpdateEmployeeDTO employee);
        bool DeleteEmployee(int employeeId);
    }
}
