using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_1.Data.Models
{
	// will represent the structure of table Employees in the database 
	// 1 - By Convention way of mapping
	internal class Employee
	{
		public int Id { get; set; }  // Public Numeric Property "Id" or "EmployeeId" --> PK [identity(1,1)]         [DOESN'T Allow Null]
		public string? Name { get; set; }    // Optional because it's Nullable string , required if it's a string   [Allows Null]
		public int? Age { get; set; }        // Optional because it's Nullable int                                  [Allows Null]
		public double Salary { get; set; }   // Required because it's not a nullable double                         [DOESN'T Allow Null]
		                                     // By Convention it's float in the database , because we don't have double as a type there 
	}
}
