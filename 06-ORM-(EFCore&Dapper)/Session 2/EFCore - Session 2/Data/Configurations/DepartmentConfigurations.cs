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
	internal class DepartmentConfigurations : IEntityTypeConfiguration<Department>
	{
		public void Configure(EntityTypeBuilder<Department> builder)
		{
			builder.ToTable("Deps");
			builder.HasKey(d => d.DeptId);
            builder.Property(d=>d.DeptId).UseIdentityColumn(10,10);     
			builder.Property(d => d.CreationPlace).HasDefaultValue("Cairo");
			builder.Property(d => d.CreationDate).HasComputedColumnSql("Cast(GETDATE() as Date)"); 
			builder.Property(d => d.Name).HasAnnotation("MaxLength" , 50);
			
			
			builder.Property(d => d.Name)
				.HasColumnName("DeptName")
				.HasColumnType("varchar")
				.HasMaxLength(100);


			builder
				.HasMany(d => d.Employees)                   
				.WithOne(e => e.Department)                  
				.HasForeignKey(e => e.DepartmentDeptId)      
				.OnDelete(DeleteBehavior.SetNull);

		}
	}
}
