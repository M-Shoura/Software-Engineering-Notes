using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Models.Department
{
    public class Department : ModelBase
    {
        // [Required(ErrorMessage ="Name is Required !!!")]    
        // by default string is required but we can edit the error message here 
        // Note : We don't edit the error message here , it's edited in the ViewModel (discussed later)
        public string Name { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Description { get; set; }
        public DateOnly CreationDate { get; set; }         // different than CreatedOn property that is in the ModelBase

    }
}
