using Microsoft.EntityFrameworkCore;
using My.Models;

namespace My.Models
{
    public class StdDbContext : DbContext
    {
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Std_Dept_Demo6_DB;User=sa;password=123;Trust Server Certificate=True;");   // changed for hosting
        }
        public DbSet<My.Models.Employee> Employee { get; set; } = default!;
    }
}
