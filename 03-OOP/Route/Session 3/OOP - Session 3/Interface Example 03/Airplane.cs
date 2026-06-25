using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_03
{
	class Airplane : Vehicle, IMovable, IFlyable
	{
		// Here we will notice that the functions that are inside "IMovable" have the same names as the functions inside "IFlyable"
		// That means that if we want to implement these two interfaces then will we have 8 signatures that must be implemented ????
		// Here is the difference between (Implement Interface Explicitly & Implement Interface Implicitly)

		// Implement Interface Explicitly : 
		// ex: 2 out of 4 functions
		// Note : functions are PRIVATE , and can be used while referencing with a reference or a variable of type the interface Only !!!
		void IFlyable.Forward()
		{
            Console.WriteLine("Airplane , Different IMP. IFlyable.Forward");
        }

		void IMovable.Forward()
		{
			Console.WriteLine("Airplane , Different IMP. IMovable.Forward");
		}
		void IFlyable.Backward()
		{
			Console.WriteLine("Airplane , Different IMP. IFlyable.Backward");
		}

		void IMovable.Backward()
		{
			Console.WriteLine("Airplane , Different IMP. IMovable.Backward");
		}

		// Implement Interface Implicitly :
		// ex: 2 out of 4 functions
		// Note : functions are PUBLIC , and can be used by a reference from type class or interface 
		public void Left()
		{
			Console.WriteLine("Airplane , Same IMP. IFlyable & IMovable Left");
		}

		public void Right()
		{
			Console.WriteLine("Airplane , Same IMP. IFlyable & IMovable Right");
		}




		// We can choose to implement a function implicitly and others Explicitly , (ex : as the function of moving left and right is the same,
		// so we will have the same implementation and we will implement it implicitly)
	}
}
