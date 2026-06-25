using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_2
{
	class EmployeeComparer : IComparer<Employee>
	{
		public int Compare(Employee? x, Employee? y)
		{
			// compares based on the name , ascending
			return x?.Name.CompareTo(y?.Name) ?? (y is null ? 0 : -1) ;
		}
	}
	internal class Employee : IComparable<Employee>
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

		public int CompareTo(Employee? other)
		{
			// Compare based on the salary , Descending
			return - this.Salary.CompareTo(other?.Salary);
		}
	}
}
