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
	internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.ToTable("Deps");
			builder.HasKey(d=>d.DeptId);
			builder.Property(d => d.DeptId).UseIdentityColumn(10, 10);
			builder.Property(d => d.CreationDate).HasComputedColumnSql("Cast(GETDATE() as Date)");


			builder.Property(d => d.Name)
				.HasColumnName("DeptName")
				.HasColumnType("varchar")
				.HasMaxLength(50);
		
			
		}
	}
}
