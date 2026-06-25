using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Runtime.CompilerServices;
 
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]                     // instead of making the class Public

namespace EFCore___Session_3.Data.Models
{
	internal class Employee
	{
		public int Code { get; set; }
		public string? Name { get; set; }
		public double Salary { get; set; }
		public int? Age { get; set; }
		public string? Email { get; set; }
		public string Address { get; set; }


        public virtual Department? Department { get; set; }               // virtual to use the Lazy Loading ...
																		 
        public virtual Department? ManagedDepartment { get; set; }		  // virtual to use the Lazy Loading ...

        public int? DepartmentId { get; set; }

        public Address? DetailedAddress { get; set; }        // Owned Entity , we don't use Lazy loading with it because it's not a related data

    }
}
