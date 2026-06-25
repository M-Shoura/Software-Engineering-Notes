using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_2.Inheritance
{
	internal class Parent
	{
        public int X { get; set; }
        public int Y { get; set; }

		// virtual property :
		private int salary;

		public virtual int Salary
		{
			get { return salary; }
			set { salary = value; }
		}


		public Parent(int _X , int _Y)
        {
            X = _X;
            Y = _Y;
        }

		public int Product()
		{
			return X*Y;
		}

		public void TestInheritance()
		{
            Console.WriteLine("Hi from parent! , Test Inheritance");
        }
		public virtual int TestVirtual()
		{
            Console.WriteLine("Iam Parent , TestVirtual");
            // Return random value between 1 and 5
            Random rnd = new Random();
			return rnd.Next(1,5) ;
		}

		public int TestNew()
		{
			Console.WriteLine("Iam Parent , TestNew");
			return 5 * 6 * 7;
		}

		public override string ToString()
		{
			return $"X: {X} \nY: {Y}";
		}

		// ----------------------------------------------------------------------

		public virtual void Test1()
		{
			Console.WriteLine("Hello from Parent , Test 1");

		}
		public virtual void Test2()
		{
			Console.WriteLine("Hello from Parent , Test 2");

		}
		public void Test3()
		{
			Console.WriteLine("Hello from Parent , Test 3");

		}

	}
}
