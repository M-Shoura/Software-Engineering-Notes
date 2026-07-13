using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace My.Models
{
    [Table("StudentInfo")]
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        [Required(ErrorMessage ="U have to enter a name")]
        [MaxLength(30,ErrorMessage ="Name muse be less than 30 chars")]
        [Display(Name ="StudentName")]
        public string Name { get; set; }

        [Required(ErrorMessage = "U have to enter a Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required, DataType(DataType.Date)]             // when taking the input , then it's data only , NOT Date Time (this is a validation on user input)
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}")]          // search for more formats
        public DateTime BirthDate { get; set; }

        [Required, Range(0,10,ErrorMessage ="Must be from 0 to 10")]
        public int Marks { get; set; }

        [Required]
        [EmailAddress]                                           // use one of these three 
        // [DataType(DataType.EmailAddress)]                     // use one of these three 
        // [RegularExpression("Pattern")]                        // use one of these three 
        [UniqueEmailValidation]                         // our custom data annotation
        public string Email { get; set; }

        [Required]
        [Compare("Email",ErrorMessage ="Email and Confirmed Email must be equal")]
        public string ConfirmEmail { get; set; }

        [Required]
        [EnumDataType(typeof(Gender))]         // check the user input that is entered that must be a type of the enum (dicussed in the controller and views)
        public Gender Gender { get; set; }
        public int Age { get; set; }

        [DataType(DataType.PhoneNumber)]
        public string Mobile { get; set; }
        public string Address { get; set; }
        public bool IsActive { get; set; }

        [ForeignKey("Department")]
        public int DeptID { get; set; }
        public virtual Department? Department { get; set; }
    }
    public enum Gender
    {
        Male, Female,
    }
}