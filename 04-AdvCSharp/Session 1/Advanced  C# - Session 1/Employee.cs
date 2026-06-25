using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal struct Employee 
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Salary { get; set; }

		public Employee(int _Id, string _Name, double _Salary)
		{
			Id = _Id;
			Name = _Name;
			Salary = _Salary;
		}

		public override string ToString()
		{
			return $"{Id} :: {Name} :: {Salary:c}";
		}


		// Implement the == operator
		public static bool operator == (Employee left, Employee? right)
		{
			return (left.Id == right?.Id) && (left.Name == right?.Name) && (left.Salary == right?.Salary);
			// with id and salary as structs , the == is implemented by default in them 
			// what about the name ? it's a string (reference types) and the == in reference types checks if they reference the same thing in the memory
			// so in this case we might say that (left.Name == right?.Name) will always be false unless we've sent the same object in left and right ...
			// but in strings it's a bit confusing , ex: string s1 = "Shoura" , s2 = "Shoura";  they now are two references that reference the same place 
			// at the memory ... if this was any other reference type they will reference different places at the memory but this is a special case 
			// with strings


			return left.Equals(right);
			// or we can use the "Equals" method that is inherited from the Object class (parent type for them all)
			// but there is small thing to notice here :
			// Equals method in "Object" class compares reference by a reference , and it's inherited as it is in all the reference types .. as we discussed
			// before that : Reference Types => Class and interface (inherit from Object directly)
			// in Value Types => Struct and Enum (inherit from Object indirectly) .. class ValueType inherits the "Equals" function from "Object" class
			// and overrides it to make it compare the value by the other value , not the references with each other (also ValueType class overrides the 
			// GetHashCode method inherited from Object ) 
		}

		public static bool operator != (Employee left, Employee? right)
		{
			return !(left == right) ;
			// or
			return (left.Id != right?.Id) || (left.Name != right?.Name) || (left.Salary != right?.Salary);
			// or
			return !left.Equals(right);

		}

	}
}
