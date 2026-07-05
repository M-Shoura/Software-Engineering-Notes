using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyHospitalApp.Entities
{
    [Table("Specializations")]
    public class Department
    {
        public int Id { get; set; }
        
        // [MinLength(3)]
        // [MaxLength(100)]
        // OR in one step 
        [StringLength(100,MinimumLength = 3)]
        public string Name { get; set; }
        
        // why virtual ? old EF => to make it Lazy Loading by default , nowadays => if we will inherit in the future and override 
        public virtual ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
