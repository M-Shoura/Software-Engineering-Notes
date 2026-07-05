using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolConsole.Model
{
    internal class Teacher
    {
        public int TID { get; set; }
        // public string FName { get; set; }
        // public string LName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public decimal Salary { get; set; }
        public int Age { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public Department Department { get; set; }
    }
}
