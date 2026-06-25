using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models
{
	internal class Employee
	{
		#region Properties 
		
		[Key]                                                 
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Code { get; set; }


		[Column(TypeName = "varchar")]                 
		[StringLength(50, MinimumLength = 10)]                                     
		[Required(ErrorMessage = "Name Required")]     
														
		public string? Name { get; set; }


		[Column(TypeName = "decimal(12,2)")]
		[DataType(DataType.Currency)]                   
		public double Salary { get; set; }


		[Range(22, 60, ErrorMessage = "Age 22-60")]		
		[AllowedValues(25, 30, 35, 40)]            
		[DeniedValues(25, 30, 35, 40)]             
		public int? Age { get; set; }


		[EmailAddress]                                  
		[DataType(DataType.EmailAddress)]               
		public string? Email { get; set; }


		[Phone]                                         
		[DataType(DataType.PhoneNumber)]                
		public string? PhoneNumber { get; set; }


		[DataType(DataType.Password)]
		[RegularExpression("")]                       
		public string? Password { get; set; }


		[NotMapped]                                 
		public double NetSalary { get => Salary * 0.8; }




        // Adding address as a proeprty here after making it as a shadow column in the database ...
        // to access the shadow property and add a value for it when adding objects to the database 
		// note : the migration named with "TestAddingAddressProperty" will be empty because the column is already in the database 
        public string Address { get; set; }

		#endregion


		// Now we will start making the reltionships : 

		// Navigational Property [One]
		
		// [InverseProperty("Employees")]      // Employees => the name of the property that is in the other class 
		// or 
		[InverseProperty(nameof(Models.Department.Employees))]
		// [ForeignKey("DepartmentDeptId")]                         // can be put here or down above the foreign key itself
		public Department? Department { get; set; }
		// total Participation from the employee side , if we want it as a partial (optional) participation then make it Nullable Department
		// "Department? department" if it's total participation like here , when adding the database column in table , when deleting a department
		// then the employees that work in this department will be deleted also "onDelete: ReferentialAction.Cascade); [from migration file]" ...
		// if it was partial (optional) participation then make it Nullable Department "Department? department" then it will be
		// "onDelete: ReferentialAction.NoAction); [default and will not be written in migration file]"


		// if we commented the property here and kept it in the other side "Many Side" , then by convention it will be knows as a 1 to many relationship 
		// but it will be optional (partial) participation .. same as "Department? department"


		// [ForeignKey("Department")]
		// or
		[ForeignKey(nameof(Employee.Department))]
		public int? DepartmentDeptId { get; set; }
		// It's important to put the foreign key here in this class , to be able to add it when adding a new employee in the table of the database ,
		// because we cannot access the navigational property , the naming of the foreign key must be (by convention):
		// DepartmentId "ClassNameId"
		// or
		// DepartmentDeptId "ClassNamePKName" as in our case 
		// Note : This can be changed by the [ForeignKey()] Data annotation 


		// Second Relationship (one to one)

		[InverseProperty(nameof(Models.Department.Manager))]
        public Department? ManagedDepartment { get; set; }







		// One to One relationship total from 2 sides : Employee has an address
		public Address DetailedAddress { get; set; } = null!;


    }
}