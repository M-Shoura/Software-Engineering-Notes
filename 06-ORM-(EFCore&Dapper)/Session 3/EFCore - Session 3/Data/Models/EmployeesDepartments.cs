using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_3.Data.Models
{
    [Keyless]          // or with Fluent APIs .HasNoKey()
	public class EmployeesDepartments
	{
        public int EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
		public int? DepartmentId { get; set; }
        public string? DepartmentName { get; set; }
    }
}
