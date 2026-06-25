using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Abstraction
{
	internal class Triangle : Shape
	{
        public decimal Dim03 { get; set; }

        public Triangle(decimal _Dim01 , decimal _Dim02 , decimal _Dim03) : base(_Dim01 , _Dim02)
        {
			Dim03 = _Dim03;    
        }
        public override decimal Perimeter
		{
			get { return 111111 ; }
		}

		public override decimal CalcArea()
		{
			return 111111 ;
		}
	}
}
