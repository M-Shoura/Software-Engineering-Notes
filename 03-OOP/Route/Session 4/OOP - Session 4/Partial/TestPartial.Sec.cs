using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Partial
{
	internal partial class TestPartial : Parent    // inheriting in the two partial classes means that it's ONLY ONE inheritance , but can be
												   // written in the two or more filed to help the different developers that this class inherits
												   // from another class
	{
		public decimal Salary { get; set; }
    }
}
