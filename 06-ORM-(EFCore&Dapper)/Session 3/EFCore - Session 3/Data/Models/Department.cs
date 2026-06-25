using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]                   // instead of making the class Public

namespace EFCore___Session_3.Data.Models
{
	internal class Department
	{
		public int DeptId { get; set; }
		public string Name { get; set; }
		public DateOnly CreationDate { get; set; }




		public virtual ICollection<Employee>? Employees { get; set; } = new HashSet<Employee>();     // virtual to use the Lazy Loading ...

		public virtual Employee? Manager { get; set; }                                               // virtual to use the Lazy Loading ...

		public int? ManagerId { get; set; }

	}
}
