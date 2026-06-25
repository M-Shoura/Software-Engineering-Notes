using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models.EmployeesModels
{
	internal class FullTimeEmployee : BasicEmployee
	{
        public decimal Salary { get; set; }
        public DateTime StartDate { get; set; }
    }
}
