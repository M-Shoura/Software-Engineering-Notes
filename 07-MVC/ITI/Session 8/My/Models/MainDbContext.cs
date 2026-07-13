using Microsoft.EntityFrameworkCore;
using My.ViewModels;

namespace My.Models
{
    public class MainDbContext : DbContext
    {
        // next means : when making DbContext object then we request to have object from DbContextOptions , so we must add this class in the DI container
        public MainDbContext(DbContextOptions<MainDbContext> options) : base(options)
        {
            
        }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Department> Departments  { get; set; }
        public DbSet<My.ViewModels.StdDeptCrsLst_ViewModel> StdDeptCrsLst_ViewModel { get; set; } = default!;
    }
}
