using IKIA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.DTOs.Departments
{
    public class DepartmentToReturnDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        
        [Display(Name ="Date of Creation")]   // this data annotation for viewing this name other than the name of the property in the View
        public DateOnly CreationDate { get; set; }

        // recaping the point of casting operator , that we discussed in OOP session 4 
        public static explicit operator DepartmentToReturnDTO(Department department)
        {
            return new DepartmentToReturnDTO()
            {
                Id = department.Id,
                Name = department.Name,
                Code = department.Code,
                CreationDate = department.CreationDate,
            };
        }

    }
}
