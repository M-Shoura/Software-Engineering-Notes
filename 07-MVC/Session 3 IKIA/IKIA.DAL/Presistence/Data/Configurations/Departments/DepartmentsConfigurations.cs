using IKIA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Data.Configurations.Departments
{
    internal class DepartmentsConfigurations : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.Property(d=>d.Id).UseIdentityColumn(10,10);
            builder.Property(d => d.Name).HasColumnType("varchar(50)").IsRequired();
            builder.Property(d => d.Code).HasColumnType("varchar(20)").IsRequired();
            builder.Property(d => d.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(d => d.LastModifiedOn).HasComputedColumnSql("GETDATE()");

            // HasComputedColumnSQL : this value is updated if any column in the row is updated , so it's used in the LastModifiedOn 
            // HasDefaultValueSql   : this value is not updated unless we updated it

        }
    }
}
