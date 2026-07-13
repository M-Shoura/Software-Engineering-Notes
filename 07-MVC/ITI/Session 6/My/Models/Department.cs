using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.Models
{
    [Table("Department")]
    public class Department
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual IEnumerable<Student>? Students { get; set; }
    }
}
