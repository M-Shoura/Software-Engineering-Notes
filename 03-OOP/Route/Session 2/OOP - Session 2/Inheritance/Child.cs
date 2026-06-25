namespace OOP___Session_2.Inheritance
{
	internal class Child : Parent
	{
		public override int Salary 
		{
			get { return base.Salary; } // can be "return salary" if was "private protected" in the parent (work directly with the attribute not the property)
			set { base.Salary = value + 10000; }
		}
		public int Z { get; set; }

		// Important Note : When having inheritance relationship , any constructor inside the child class BY DEFAULT chain on the
		//                  Empty Parameterless constructor of the base type (Parent) ... We can change this be choosing the wanted
		//                  constructor as done in Child class (Explicitly)		

		public Child(int _X, int _Y, int _Z) : base(_X, _Y)         // if not written , the default is --> : base()
		{                                                           // if it's not found in the parent then we will have an error 
			Z = _Z; 
		}

		public override int TestVirtual()
		{
			Console.WriteLine("Iam Child , TestVirtual");
			// Return random value between 1 and 100
			Random rnd = new Random();
			return rnd.Next(1, 100);
		}

		// Static Binded Method 
		public new int TestNew()
		{
			Console.WriteLine("Iam Child , TestNew");
			// return base.TestNew() * 8 * 9 * 10;
			return 5 * 6 * 7 * 8 * 9 * 10;
		}

		// Dynamic Binded Method
		public override string ToString()
		{
			// return $"X: {X} \nY: {Y} \nZ: {Z}";
			return $"{base.ToString()} \nZ: {Z}";
		}

		public void OnlyInChild()
		{
            Console.WriteLine("Hi , Only in Child");
        }

		// -------------------------------------------------------------

		public override void Test1()
		{
            Console.WriteLine("Hello from child , Test 1");
        }

		public new void Test2()
		{
			Console.WriteLine("Hello from child , Test 2");
		}
		public new void Test3()
		{
			Console.WriteLine("Hello from child , Test 3");
		}
	}
}
