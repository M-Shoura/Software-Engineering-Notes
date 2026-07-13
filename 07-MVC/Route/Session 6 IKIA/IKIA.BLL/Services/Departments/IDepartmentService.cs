using IKIA.BLL.DTOs.Departments;
using IKIA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.Services.Departments
{
    public interface IDepartmentService
    {
        IEnumerable<DepartmentToReturnDTO> GetAllDepartments();
        DepartmentDetailsToReturnDTO? GetDepartmentById(int departmentId);
        int CreateDepartment(CreatedDepartmentDTO departmentDTO);
        int UpdateDepartment(UpdatedDepartmentDTO departmentDTO);
        bool DeleteDepartment(int departmentId);
    }
}
