using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Sealed
{
	class TypeA
	{
		private int salary;

		public virtual int Salary
		{
			get { return salary; }
			set { salary = value; }
		}

		public virtual void Print()
		{
			Console.WriteLine("TypeA");
		}
	}
	class TypeB : TypeA
	{
		public sealed override int Salary
		{
			get { return base.Salary; }
			set { base.Salary = value < 5000 ? 5000 : value ; }
		}

		public sealed override void Print()
		{
			Console.WriteLine("TypeB");
		}
	}
	class TypeC : TypeB
	{
		// public override void Print()            
		// {                                         // It's sealed and cannot be overriden by "override" keyword
		//     Console.WriteLine("TypeC");
		// }

		public new void Print()
		{                                            // But can be overriden by keyword "new"	
			Console.WriteLine("TypeC");
		}

		// public override int Salary 
		// {                                         // It's sealed and cannot be overriden by "override" keyword
		// 	get { return base.Salary; }
		// 	set { base.Salary = value; }
		// }
		public new int Salary
		{                                                        // But can be overriden by keyword "new"
			get { return base.Salary; }
			set { base.Salary = value < 100_000 ? 100_000 : value; } 
		}
	}
}
