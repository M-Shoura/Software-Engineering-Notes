using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_1
{
	internal struct Point
	{
		// Attributes
		private int X;
		public int Y;

        // Constructors:

        // Important note : in STRUCT .. By default "ALWAYS" the empty parameterless constructor is generated even if we have
        //                  another parameterized constructors . This constructor is used for initializing the attributes with the 
        //                  default values for each attribute datatype

        // public Point()
        // {
        //     // Before .net 7 if we have a constructor then we MUST initialize the attributes in it , but starting from .net 7 it's not
        //     // important to initialize all the attributes we have , The next code is written and generated implicitly for attributes we
        //     // have.
        //      
        //     X = default;
        //     Y = default;
        // }

        // Important note : in .net 5 and before (C# < 10) , we couldn't write the parameterless constructor explicitly as done above .. 

        public Point(int X , int Y)
        {
            // X = _X;
            // Y = _Y;

			// another way if you want to name the parameters with the same names of the attributes : "this" keyword
			// this.X = X;
			// this.Y = Y;
        }



        public override string ToString()
		{
			return $"X = {X}, Y = {Y}";
        }
	}
}
