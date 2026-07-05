using IKIA.DAL.Common.Enums;
using IKIA.DAL.Models.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Data.Configurations.Employees
{
    public class EmployeeConfigurations : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(e => e.Address).HasColumnType("varchar(100)");
            builder.Property(e => e.Salary).HasColumnType("decimal(8,2)");
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");            // or "GETUTCDATE()" for UTC time

            // we want to save the Enum as a string in the database, ex: "Male" or "Female" stored in the database not "1" or "2"
            // and when retrieved it's retrieved as a gender value "1" or "2"

            builder.Property(e => e.Gender)
                .HasConversion
                (
                    (gender) => gender.ToString(),                               // saved in the DB
                    (gender) => (Gender)Enum.Parse(typeof(Gender), gender)      // When retrieving from DB
                );

            builder.Property(e => e.EmployeeType)
                .HasConversion
                (
                    (emp) => emp.ToString(),
                    (emp) => (EmployeeType)Enum.Parse(typeof(EmployeeType), emp)
                );
        }
    }
}
