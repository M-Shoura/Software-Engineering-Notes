using EFCore___Session_2.Data.Models.SchoolModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data
{
    internal class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Course> Courses { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr02_School ; Trusted_Connection = true ; Encrypt = true ; TrustServerCertificate = true");
        }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<StudentCourse>().
                HasKey(c => new { c.StudentId, c.CourseId });

            modelBuilder.Entity<Student>()
                .HasMany(s => s.StudentCourses)
                .WithOne()
                .IsRequired()
                .OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Course>()
			   .HasMany(c => c.CoursesStudent)
			   .WithOne()
			   .IsRequired()
			   .OnDelete(DeleteBehavior.Cascade);

            // note : On Delete Cascade means that when deleting the PK Entity (student) or (Course) then delete all the records of that student or
            //        course from the third table

		}
	}
}
