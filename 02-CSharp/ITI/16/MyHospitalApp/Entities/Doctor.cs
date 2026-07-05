using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace MyHospitalApp.Entities
{
    public class Doctor
    {
        [Key]
        public int DocId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FullName { get; set; }

        [Column(TypeName ="Money")]
        public decimal Salary { get; set; }

        [Range(18,99)]
        public byte Age { get; set; }

        [NotMapped]
        public DateTime CreatedOn { get; } = DateTime.Now;

        // why virtual ? old EF => to make it Lazy Loading by default , nowadays => if we will inherit in the future and override.
        public virtual Department Department { get; set; }
    }
}
