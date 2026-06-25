using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal class Teacher
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Salary { get; set; }

		public Teacher(int _Id, string _Name, double _Salary)
		{
			Id = _Id;
			Name = _Name;
			Salary = _Salary;
		}

		public override string ToString()
		{
			return $"{Id} :: {Name} :: {Salary:c}";
		}
		public override bool Equals(object? obj)
		{
			Teacher? other = (Teacher?)obj;              // Explicit casting (Unsafe and may throw exception)
			
			if(other == null) 
				return false;
			
			return this.Id == other.Id && this.Name == other.Name && this.Salary == other.Salary;
		}
		public override int GetHashCode()
		{
			// return this.Id.GetHashCode() + this.Name?.GetHashCode() ?? default(int) + this.Salary.GetHashCode();
			// // or use the Xor for faster processing : 
			// return this.Id.GetHashCode() ^ this.Name?.GetHashCode() ?? default(int) ^ this.Salary.GetHashCode();
			// 
			// // but this code is not always right nad may produce collision : 
			// // Teacher t1 = new Teacher(6_000, "Mahmoud", 10);           // same values but in different attributes
			// // Teacher t2 = new Teacher(10, "Mahmoud", 6_000);			// same values but in different attributes
			// // These two objects now don't have the same values but they will return the same hashcode and this is wrong !!
			// // so we must use Prime Numbers in generating the hashcode to ensure that we will not have any collision in the future

			// // Prime Number way : 
			// int hashValue = 7;      // any prime number , ex: 7
			// hashValue = (hashValue * 11 ) + this.Id.GetHashCode();                            // Any prime number , ex: 11
			// hashValue = (hashValue * 11 ) + this.Name?.GetHashCode() ?? default(int);		  // Any prime number , ex: 11
			// hashValue = (hashValue * 11 ) + this.Salary.GetHashCode();						  // Any prime number , ex: 11
			// return hashValue;


			// Starting from .net 8.0 , we have a struct that we can use to generate the same code above !
			return HashCode.Combine(this.Id.GetHashCode(), this.Name?.GetHashCode() ?? default(int), this.Salary.GetHashCode());
		}
	}
}
