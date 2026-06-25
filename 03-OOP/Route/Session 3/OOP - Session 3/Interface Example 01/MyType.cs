using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_01
{
	internal class MyType : IMyType
	{
		// Implementing the property and it's signature :
		// 1 - We had only the property .. so we must implement it like this and also if it's a full property make the attribute of it 
		// 2 - If we wanted it as an automatic property , the backing field in there 
		
		// 1 - 
		private int salary;
		public int Salary { 
			get { return salary; } 
			set { salary = value; }
		}

		// 2 - 
		// public int Salary { get; set; }

		// Note : if the property in the interface has (get & set) then when implementing it we must implement (get & set)
		//        but if the property in the interface has (get only) then if we want to have (set) also we can implement it in the 
		//        class or struct without any problem with implementing the interface

		public void MyFun()
		{
            Console.WriteLine("Hello World");
        }
	}
}
