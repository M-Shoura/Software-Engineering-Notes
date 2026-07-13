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
        // Note : in the Repo , delete returns an int , and here it's bool ... we always make the repo as generic as we can , but in the
        //        service we do what the business want . in this case we want only to know if the dept is deleted or not (boolean)
    }
}
