using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_02
{
	internal class SeriesByFour : ISeries
	{
		public int Current { get; set; }

		public void GetNext()
		{
			Current += 4;
		}
	}
}
