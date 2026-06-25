using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_2
{
	// it's a struct because we want the object life-time to be small as possible + we will not use the inheritance here + fast access in the stack
	internal struct Location
	{
		public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }

		public Location(int x, int y, int z)
		{
			X = x;
			Y = y;
			Z = z;
		}

		public override string ToString()
		{
			return $"( {X}, {Y}, {Z} )";
		}

	}
}
