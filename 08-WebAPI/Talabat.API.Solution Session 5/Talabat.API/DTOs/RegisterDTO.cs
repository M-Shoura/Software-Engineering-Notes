using System.ComponentModel.DataAnnotations;

namespace Talabat.API.DTOs
{
    public class RegisterDTO
    {
        [Required]
        public string DisplayName { get; set; }
        
        [Required]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        [RegularExpression("(?=^.{6,10}$)(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\\s).*$" ,
            ErrorMessage = "Password must have 1 Uppercase , 1 Lowercase , 1 number , 1 non alphanumeric and at least 6 characters")]
        public string Password { get; set; }  // it's better to write a regular expression in the RegisterDTO so that the endpoint will not
                                              // be executed if the password doesn't match the REGEX
                                              // copy paste regix
    }
}
