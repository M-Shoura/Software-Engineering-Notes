using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolConsole.Model;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace SchoolConsole.ConfigurationClasses
{
    internal class TeacherConfigurationClass : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
                builder.ToTable("SchoolWorkers").HasKey(x => x.TID);
                builder.Ignore(x => x.CreatedOn);

            // builder.Property(p => p.FName).HasMaxLength(100).IsRequired();
            builder.Property(p => p.FullName).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Salary).HasColumnName("MonthlySalary").HasColumnType("money");
                builder.Property(p => p.Age).HasDefaultValue(21);
                builder.Property(p => p.Address).IsUnicode(true);


                // in most cases it's not a must to make configurations for the relationships , as they follow the convention , but we 
                // can make configurations when we want to make it more readable and if we want to make custom configurations to it
                builder.HasOne(t => t.Department).WithMany(d => d.Teachers)
                                                 .HasForeignKey("DepartmentId" /* or d=>d.DepartmentId if we have*/)
                                                 .IsRequired()
                                                 .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
