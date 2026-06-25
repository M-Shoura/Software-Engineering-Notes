using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_3.Data.Models
{
	internal class Address
	{
		public int BlockNumber { get; set; }
		public string? Street { get; set; }
		public string? City { get; set; }
		public string? Country { get; set; }
	}
}
