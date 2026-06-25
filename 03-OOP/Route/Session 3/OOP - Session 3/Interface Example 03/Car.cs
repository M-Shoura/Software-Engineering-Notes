using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_03
{
	class Car : Vehicle, IMovable
	{
		public void Forward()
		{
			Console.WriteLine("Car , Forward");
		}
		public void Backward()
		{
			Console.WriteLine("Car , Backward");
		}

		public void Left()
		{
			Console.WriteLine("Car , Left");
		}

		public void Right()
		{
			Console.WriteLine("Car , Right");
		}
	}
}
