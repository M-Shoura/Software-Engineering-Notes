using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolConsole.Model
{
    internal class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public virtual ICollection<Teacher> Teachers { get; set; } = new HashSet<Teacher>();
    }
}
