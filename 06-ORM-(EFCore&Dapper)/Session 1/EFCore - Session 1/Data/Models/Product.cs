using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFCore___Session_1.Data.Models
{
    internal class Product
    {
        [Key]                 // giving the property a new behaviour (To be a primary key) as it's not known by convention!
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]   // used if we want to add identity(1,1) to a column that is not by default ..
    

        public int Code { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

    }
}
