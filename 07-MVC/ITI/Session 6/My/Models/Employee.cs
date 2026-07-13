using System.ComponentModel.DataAnnotations;

namespace My.Models
{
    public class Employee
    {
        public int ID { get; set; }
        
        [Required]
        public string Name { get; set; }

        [Required]
        [MinAgeValidation(21)]                        // our custom data annotation
        public int Age { get; set; }

    }
}
