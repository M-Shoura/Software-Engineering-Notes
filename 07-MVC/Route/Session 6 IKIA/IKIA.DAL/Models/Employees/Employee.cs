using IKIA.DAL.Common.Enums;
using IKIA.DAL.Models.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Models.Employees
{
    public class Employee : ModelBase
    {
        // Note : we don't put validations here, validations will be in Configuration classes (fluent apis) or in the DTOs or ViewModels

        public string Name { get; set; } = null!;
        public int? Age { get; set; }
        public string? Address { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly HiringDate { get; set; }
        public Gender Gender { get; set; }
        public EmployeeType EmployeeType { get; set; }


        // We must make a property for the foreign key
        public int? DepartmentId { get; set; }
        
        // Navigational Property [One]
        public virtual Department? Department { get; set; }
    }
}
