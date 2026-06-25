using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_1.Data.Models
{
	// 2 - Data Annotations way of mapping

	[Table("Advanced_Employee_DataAnnotation" ,Schema ="HR" )]  // giving a name different than the name of the DbSet property at the context class
	                                                            // and also providing the schema if we don't want the table to be in the default one 
	internal class EmployeeDataAnnotation
	{
		[Key]                                                   // giving the property a new behaviour (To be a primary key) as it's not known by convention!
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		// [DatabaseGenerated(DatabaseGeneratedOption.None)]    // used if it's by convention a PK and we don't want to have the identity(1,1) ..
		public int Code { get; set; }



		[Column(TypeName = "varchar" )]                  // if it's like this without a max length ==> varchar(1) means only one character
		[StringLength(50 , MinimumLength = 10)]          // MinimumLength is not mapped in the database , used for application validations
		[MaxLength(50)]                                  // Mapped in the database 
		[MinLength(10)]                                  // Not mapped in the database , used for application validations , EFCore 8.0 feature
		[Length(10 ,50)]                                 // Not mapped in the database , used for application validations , EFCore 8.0 feature
		[Required(ErrorMessage ="Name Required")]        // Mapped in the database , has more priority than the nullable string? so it's required now
														 // Error message is shown in the HTML .. and we can use the default error message also 
		public string? Name { get; set; }



		[Column(TypeName = "decimal(12,2)")] 
		[DataType(DataType.Currency)]                    // When showing it in the application it will appear as a currency (this is not validation)
		public double Salary { get; set; }


		[Range(22,60 , ErrorMessage = "Age 22-60")]      // Not mapped in the database , used for application validations
														 // Error message is shown in the HTML .. and we can use the default error message also 
		[AllowedValues(25 , 30 , 35 , 40 )]              // Not mapped in the database , used for application validations , EFCore 8.0 feature
		[DeniedValues (25 , 30 , 35 , 40 )]              // Not mapped in the database , used for application validations , EFCore 8.0 feature
		public int? Age { get; set; }



		[EmailAddress]                                   // Not mapped in the database , used for application validations 
		[DataType(DataType.EmailAddress)]                // When showing it in the application it will appear as an email address (this is not validation)
		public string? Email { get; set; }

		

		[Phone]                                          // Not mapped in the database , used for application validations 
		[DataType(DataType.PhoneNumber)]                 // When showing it in the application it will appear as a phone number (this is not validation)
		public string? PhoneNumber { get; set; }



        [DataType(DataType.Password)]
		[RegularExpression("")]                          // will be discussed later .. 
        public string? Password { get; set; }



        [NotMapped]                                     // Property that is not represented by a column in the table (ex: derived attribute) 
        public double NetSalary { get => Salary * 0.8; }
    }
}
