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
        Task<IEnumerable<DepartmentToReturnDTO>> GetAllDepartmentsAsync();
        Task<DepartmentDetailsToReturnDTO?> GetDepartmentByIdAsync(int departmentId);
        Task<int> CreateDepartmentAsync(CreatedDepartmentDTO departmentDTO);
        Task<int> UpdateDepartmentAsync(UpdatedDepartmentDTO departmentDTO);
        Task<bool> DeleteDepartmentAsync(int departmentId);
    }
}
