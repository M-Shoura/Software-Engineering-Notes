using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace My.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        [ForeignKey("Cntry")]                        // Name of the Nav property here
        public int cID { get; set; }
        public virtual Country Cntry { get; set; }        // Virtual for enabling the Lazy Loading , how ? Self study
    }
}
