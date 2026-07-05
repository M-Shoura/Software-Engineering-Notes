using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolConsole.ConfigurationClasses
{
    internal class DepartmentConfigurationClass : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            builder.Property(d => d.Location).HasMaxLength(200).IsUnicode();
        }
    }
}
