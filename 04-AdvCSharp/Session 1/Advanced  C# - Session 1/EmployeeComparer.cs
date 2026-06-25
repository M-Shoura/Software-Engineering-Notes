using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal class EmployeeComparer : IComparer<Employee?>
	{
		public int Compare(Employee? x, Employee? y)
		{
			return x?.Id .CompareTo(y?.Id) ?? (y is null ? 0 : -1);
		}
	}
}
