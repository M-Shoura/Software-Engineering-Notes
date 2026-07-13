using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.BLL.DTOs.Departments
{
    public class CreatedDepartmentDTO
    {
        // data annotation for changing the error message when showing it in the view , it's shown in the Span in the view
        [Required(ErrorMessage = "Code is Required Ya Hamada !!")]
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }

        [Display(Name = "Date of Creationnnnnnn")]
        public DateOnly CreationDate { get; set; }
    }
}
