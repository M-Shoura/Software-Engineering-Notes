using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models
{
	// [Owned]             // will be owned for every type .. but if we want it to be owned for some types then make it through Fluent APIs
	internal class Address
	{
		public int BlockNumber { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? Country { get; set; }

	}
}
