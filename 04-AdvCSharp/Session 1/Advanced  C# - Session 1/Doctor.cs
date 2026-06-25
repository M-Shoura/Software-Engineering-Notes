using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal class Doctor : IComparable
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public double Salary { get; set; }

		public Doctor(int _Id, string _Name, double _Salary)
		{
			Id = _Id;
			Name = _Name;
			Salary = _Salary;
		}

		public override string ToString()
		{
			return $"{Id} :: {Name} :: {Salary:c}";
		}

		public int CompareTo(object? obj)
		{
			Doctor? other = (Doctor?) obj;
			if(other != null)
			{
				return this.Salary.CompareTo(other.Salary);
			}
			return 1;
		}
	}
}
