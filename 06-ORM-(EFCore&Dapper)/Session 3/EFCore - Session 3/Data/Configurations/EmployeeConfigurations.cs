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
	internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.HasKey(e=>e.Code);
			builder.Property(e => e.Code).UseIdentityColumn(10, 10);
			builder.Property(e=>e.Name).HasColumnType("varchar").HasMaxLength(50);
			builder.Property(e => e.Salary).HasColumnType("decimal(12,2)"); 
			builder.Property(e => e.Address).HasColumnType("varchar").HasMaxLength(50).IsRequired(false);


			builder.HasOne(e => e.Department)
				.WithMany(d => d.Employees)
				.HasForeignKey(e=>e.DepartmentId);

			builder.HasOne(e => e.ManagedDepartment)
				.WithOne(d => d.Manager)
				.HasForeignKey<Department>(d=>d.ManagerId);

			builder.OwnsOne(e => e.DetailedAddress , Address => Address.WithOwner());
		}
	}
}
