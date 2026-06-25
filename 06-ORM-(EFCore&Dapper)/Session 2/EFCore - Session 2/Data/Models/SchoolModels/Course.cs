using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data.Models.SchoolModels
{
	internal class Course
	{
		public int Id { get; set; }
		public string Title { get; set; } = null!;

		// Navigational Property [Many] (course can be enrolled by many students)
		// public ICollection<Student> Students { get; set; } = new HashSet<Student>();


		public ICollection<StudentCourse> CoursesStudent { get; set; } = new HashSet<StudentCourse>();

    }
}
