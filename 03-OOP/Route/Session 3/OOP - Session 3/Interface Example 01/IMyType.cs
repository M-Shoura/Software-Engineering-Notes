using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_01
{
	internal interface IMyType
	{
		// The default access modifier inside the interface --> Public
		
		// 1 - Signature for property:
		// Note : if this is written inside a class or struct then it's named as automatic property which has a backing field 
		//        but here it's a Signature for property , unknown get and set implementations 
		int Salary {  get; set; }

		// 2 - Signature for Method
		void MyFun();

		// 3 - Default Implemented Method C# 8.0 (.net core 3.1 2019)
		// Methods that will have the same implementation anywhere it's used ... so make it as a default Implemented Method
		void Print()
		{
			string s = HelperMethod();

			Console.WriteLine($"{s} / Hi , Default Implemented Method ");
        }
		
		// can be private 
		private string HelperMethod()
		{
			return " .... Helper .... ";
		}

		// Default Implemented Property : it's not different that the default implemented method , and we cannot have set only get ... 
		// string SayHello
		// {
		// 	get { return "Hello"; }
		// }
	}
}
