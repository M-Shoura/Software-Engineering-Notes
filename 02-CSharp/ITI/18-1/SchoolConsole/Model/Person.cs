using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolConsole.Model
{
    internal abstract class Person
    {
        public int Id { get; set; }

        [MaxLength(150)]
        public string Name { get; set; }

        public byte IsEnroller { get; set; } = 1;
    }
    internal class FullTimeStudent : Person
    {
        [Range(1,12)]
        public byte Grade { get; set; }
        public DateOnly EnrollmentDate { get; set; }

        public FullTimeStudent() => IsEnroller = 2;
    }
    internal class WalkInStudent : Person
    {
        [StringLength(10,MinimumLength =2)]
        public string CourseCode { get; set; }
        public WalkInStudent() => IsEnroller = 3;

    }
}
