using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTOs
{
    public class AddressDTO
    {
        // Copy paste from the Address class , execluding the id and the navigational property and the foreign key

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Street { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Country { get; set; }

    }
}
