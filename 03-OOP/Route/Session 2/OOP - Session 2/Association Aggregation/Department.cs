using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_2.Association_Aggregation
{
	internal class Department
	{
        // Association Aggregation Relationship ( Has a )
        // Department has Employees (Department can exist without employees .. )
        public int Id { get; set; }
        public string Name { get; set; }
        public Employee[]? Employees { get; set; }


		// To make an object of type Department , you can send array of Employees OR NOT (use any of the two constructors) 
		// So it's not a must to make an Department object to make an array of Employees (has a relationship) (Optional ==> Aggregation)

		public Department(string name)
        {
            Name = name;
        }
		public Department(string name , Employee[] employees)
		{
			Name = name;
			Employees = employees;
		}
	}
}
