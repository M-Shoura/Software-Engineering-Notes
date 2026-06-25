using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Abstraction
{
	// Concrete Class --> fully implemented 
	internal class Rect : RectBase               // ":" means inherit and implement 
	{
        public Rect(decimal _Dim01, decimal _Dim02) : base(_Dim01, _Dim02)
        {
            
        }
        public override decimal Perimeter 
		{
			// Important note : unlike interface , if the abstract class has a property that has (get and set) then when impelementing the property
			// we must implement the (get and set) .. and if the abstract class has a property that has (get only) then when impelementing the property
			// we must implement the (get only) and same with set .. 

			get { return (Dim01 + Dim02) * 2; } 
			
		}

		
	}
}
