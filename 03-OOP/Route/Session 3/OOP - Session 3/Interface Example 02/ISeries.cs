using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_02
{
	interface ISeries
	{
		public int Current {  get; set; }

		public void GetNext();
		
		// default implemented method , to use it we must refer by a reference of this interface (see the arguments of the Helper function)
		public void Reset()
		{
			Current = 0;
		}
    }
}
