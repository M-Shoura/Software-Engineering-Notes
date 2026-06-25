using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models.SchoolModels
{
	internal class Student
	{
        public int Id { get; set; }
		public string Name { get; set; } = null!;
        public int? Age { get; set; }
		public string? Address { get; set; }

		// Navigational Property [Many] (student can enroll many courses)
		// public ICollection<Course> Courses { get; set; } = new HashSet<Course>();


		public ICollection<StudentCourse> StudentCourses { get; set; } = new HashSet<StudentCourse>();
		// one student can have more than one record in the new table ... so it's a many here

	}
}
