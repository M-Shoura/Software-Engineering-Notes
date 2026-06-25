using EFCore___Session_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_3.Data.Configurations
{
	internal class EmployeesDepartmentsConfigurations : IEntityTypeConfiguration<EmployeesDepartments>
	{
		public void Configure(EntityTypeBuilder<EmployeesDepartments> builder)
		{
			builder.ToView("EmployeeDepartmentsView").HasNoKey();
		}
	}
}
