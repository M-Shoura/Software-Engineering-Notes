using EFCore___Session_2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Configurations
{
	internal class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
	{
		public void Configure(EntityTypeBuilder<Employee> builder)
		{
			builder.Property<string>("Address").HasColumnType("varchar").HasMaxLength(50).IsRequired(false);



			builder
				.HasOne(e => e.ManagedDepartment)
				.WithOne(d => d.Manager)
				.HasForeignKey<Department>(d => d.ManagerId)        
				.OnDelete(DeleteBehavior.SetNull);

			builder.OwnsOne(e => e.DetailedAddress, Address => Address.WithOwner());  
			// this is when using the Address with the Employee .. but if the address is used in other class we must configure it again 
			// if we used the [Owned] data annotation then at all times it's owned entity to any class 
		
		}
	}
}
