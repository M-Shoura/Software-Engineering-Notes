using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_2.Binding
{
	internal class Employee
	{
        public int Id { get; set; }
		public string? Name { get; set; }
        public int? Age { get; set; }

		public void MyFun01()
		{
            Console.WriteLine("I am Basic Employee");
        }
		public virtual void MyFun02()
		{
			Console.WriteLine($"Employee: Id = {Id}, Name = {Name}, Age = {Age}");
		}
	}
	internal class FullTimeEmployee : Employee
	{
        public decimal Salary { get; set; }

		public new void MyFun01()
		{
			Console.WriteLine("I am Full Time Employee");
		}
		public override void MyFun02()
		{
			Console.WriteLine($"Employee: Id = {Id}, Name = {Name}, Age = {Age}, Salary = {Salary}");
		}
	}
	internal class PartTimeEmployee : Employee
	{
        public decimal HourRate { get; set; }
		public new void MyFun01()
		{
			Console.WriteLine("I am Part Time Employee");
		}
		public override void MyFun02()
		{
			Console.WriteLine($"Employee: Id = {Id}, Name = {Name}, Age = {Age}, HourRate = {HourRate}");
		}

	}
	internal class EmployeeHelper
	{
		// // Not the best practice , the functions logic is the same !! 
		// // instead use binding 

		// public static void ProcessEmployee(FullTimeEmployee emp)
		// {
		// 	if (emp != null)
		// 	{
		// 		emp.MyFun01();      
		// 		emp.MyFun02();      
		// 	}
		// }
		// public static void ProcessEmployee(PartTimeEmployee emp)
		// {
		// 	if (emp != null)
		// 	{
		// 		emp.MyFun01();       
		// 		emp.MyFun02();       
		// 	}
		// }

		
		// Binding =>
		public static void ProcessEmployee(Employee emp)   // The parameter means that i will have object from employee , 
		{                                                  // or object from any type that inherits from employee class
			if (emp != null)                               // ex : FullTimeEmployee or PartTimeEmployee 
			{
				emp.MyFun01();    // Static binded method , with new keyword 
				emp.MyFun02();    // Dynamic binded method , with virtual & override keyword
			}
		}
	}
}
