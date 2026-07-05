using Microsoft.EntityFrameworkCore;
using SchoolConsole.ConfigurationClasses;
using SchoolConsole.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolConsole.Context
{
    internal class SchoolContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Department> Departments { get; set; }


        public DbSet<Person> People { get; set; }
        // public DbSet<WalkInStudent> WalkInStudents { get; set; }
        // public DbSet<FullTimeStudent> FullTimeStudents { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data source=.;Initial catalog=SchoolDB;Integrated security=true;Encrypt=false;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // notice the diff between the old and new way , it's better to write configurations in configuration classes to make it 
            // more structured 

            modelBuilder.ApplyConfiguration(new TeacherConfigurationClass());
            modelBuilder.ApplyConfiguration(new DepartmentConfigurationClass());
            modelBuilder.ApplyConfiguration(new PersonConfigurationClass());
            modelBuilder.ApplyConfiguration(new FullTimeStudentConfigurationClass());
            modelBuilder.ApplyConfiguration(new WalkInStudentConfigurationClass());


            // Old way : 
            //
            // modelBuilder.Entity<Teacher>().ToTable("SchoolWorkers");
            // modelBuilder.Entity<Teacher>().HasKey(x => x.TID);
            // modelBuilder.Entity<Teacher>().Ignore(x => x.CreatedOn);
            // 
            // modelBuilder.Entity<Teacher>().Property(p => p.FName).HasMaxLength(100);
            // modelBuilder.Entity<Teacher>().Property(p => p.FName).IsRequired();
            // modelBuilder.Entity<Teacher>().Property(p => p.Salary).HasColumnName("MonthlySalary");
            // modelBuilder.Entity<Teacher>().Property(p => p.Salary).HasColumnType("money");
            // modelBuilder.Entity<Teacher>().Property(p => p.Age).HasDefaultValue(21);
            // modelBuilder.Entity<Teacher>().Property(p => p.Address).IsUnicode(true);

            // New Way : 
            // modelBuilder.Entity<Teacher>(builder =>
            // {
            //     builder.ToTable("SchoolWorkers").HasKey(x => x.TID);
            //     builder.Ignore(x => x.CreatedOn);
            // 
            //     builder.Property(p => p.FName).HasMaxLength(100).IsRequired();
            //     builder.Property(p => p.Salary).HasColumnName("MonthlySalary").HasColumnType("money");
            //     builder.Property(p => p.Age).HasDefaultValue(21);
            //     builder.Property(p => p.Address).IsUnicode(true);
            // 
            // 
            //     // in most cases it's not a must to make configurations for the relationships , as they follow the convention , but we 
            //     // can make configurations when we want to make it more readable and if we want to make custom configurations to it
            //     builder.HasOne(t => t.Department).WithMany(d => d.Teachers)
            //                                      .HasForeignKey("DepartmentId" /* or d=>d.DepartmentId if we have*/)
            //                                      .IsRequired()
            //                                      .OnDelete(DeleteBehavior.Cascade);
            // });

            // modelBuilder.Entity<Department>(builder =>
            // {
            //     builder.Property(d => d.Name).IsRequired().HasMaxLength(50);
            //     builder.Property(d => d.Location).HasMaxLength(200).IsUnicode();
            // });


        }               
    }
}                       
                        
                        
                        
                        
                        