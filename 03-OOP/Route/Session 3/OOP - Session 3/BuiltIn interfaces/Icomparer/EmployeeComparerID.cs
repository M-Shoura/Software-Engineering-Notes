using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.BuiltIn_interfaces.Icomparer
{
	class EmployeeComparerID : IComparer
	{
		public int Compare(object? x, object? y)
		{
			Employee? emp01 = (Employee?)x;
			Employee? emp02 = (Employee?)y;

			return emp01?.Id.CompareTo(emp02?.Id) ?? (emp02 == null ? 0 : -1);

			// means that : if emp01 is null then it will not propagate , and will go to the ternary operator .. it the emp02 is null
			// also then we will return 0 as they are the same , but it emp02 is not null then (emp01 is less then emp02) becaue
			// null is less than any thing ==> returns -1;
		}
	}
}
