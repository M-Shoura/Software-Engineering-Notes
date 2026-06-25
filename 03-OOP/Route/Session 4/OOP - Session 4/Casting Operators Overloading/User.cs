using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Casting_Operators_Overloading
{
	// Model : A class that represents a table existed in the Database 
	class User
	{
		public int Id { get; set; }
		public string? FullName { get; set; }
		public string? Email { get; set; }
		public string? Password { get; set; }
		public Guid SecurityStmp { get; set; }

	}
}
