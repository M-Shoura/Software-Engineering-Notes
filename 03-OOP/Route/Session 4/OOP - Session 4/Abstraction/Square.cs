using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Abstraction
{
	internal class Square : RectBase
	{
		public Square(decimal dim) : base(dim , dim)
		{
			// Dim01 = Dim02 = dim;
		}

		public override decimal Perimeter
		{
			get { return Dim01 * 4; }
		} 

		
	}
}
