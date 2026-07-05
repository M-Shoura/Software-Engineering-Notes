using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using SchoolConsole.Migrations;
using SchoolConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolConsole.ConfigurationClasses
{
    internal class PersonConfigurationClass : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            // What if i don't want the EFCore to make a Discriminator and i want to make my own ? 
            // builder.HasDiscriminator(p => p.IsEnroller).HasValue<Person>(1)
            //                                            .HasValue<FullTimeStudent>(2)
            //                                            .HasValue<WalkInStudent>(3);

            // For TPCC (Table Per Concrete Class) , called here TPC (2 classes for 1 abstract class and 2 concrete classes)
            // builder.UseTpcMappingStrategy(); 

            // For TPC (Table Per Class) , called here TPT (3 classes for 1 abstract class and 2 concrete classes , even if the abstract
            //                                              is concrete they will be 3 classes) (not used with abstract classes ! )
            builder.UseTptMappingStrategy();

        }
    }
    internal class WalkInStudentConfigurationClass : IEntityTypeConfiguration<WalkInStudent>
    {
        public void Configure(EntityTypeBuilder<WalkInStudent> builder)
        {
            // MUST - if we have one DBSet and want to work with TPH
            // builder.HasBaseType<Person>();
        }
    }
    internal class FullTimeStudentConfigurationClass : IEntityTypeConfiguration<FullTimeStudent>
    {
        public void Configure(EntityTypeBuilder<FullTimeStudent> builder)
        {
            // MUST - if we have one DBSet and want to work with TPH
            // builder.HasBaseType<Person>();
        }
    }
}
