using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models.EmployeesModels
{
	internal class PartTimeEmployee : BasicEmployee
	{
        public decimal HourRate { get; set; }
        public int CountOfHours { get; set; }
    }
}
