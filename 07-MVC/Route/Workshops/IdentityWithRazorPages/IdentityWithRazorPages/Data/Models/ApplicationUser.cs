using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentityWithRazorPages.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required , MaxLength (50)]
        public string FirstName { get; set; }

        [Required, MaxLength(50)]
        public string LastName { get; set; }

        public byte[]? ProfilePicture { get; set; }      // Adding the image as a image in the database not storing the path of it (bad way)
    }
}
