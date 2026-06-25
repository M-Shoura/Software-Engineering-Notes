using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Abstraction
{
	internal abstract class RectBase : Shape
	{
        protected RectBase(decimal _Dim01, decimal _Dim02) : base(_Dim01 , _Dim02)
        {
            
        }
        public override decimal CalcArea()           // abstract methods are Overriden by "override" keyword
		{
			return Dim01 * Dim02;
		}
	}
}
