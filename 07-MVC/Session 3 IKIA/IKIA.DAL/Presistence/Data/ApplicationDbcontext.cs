using IKIA.DAL.Models.Department;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKIA.DAL.Presistence.Data
{
    public class ApplicationDbcontext : DbContext
    {
        public DbSet<Department> Departments { get; set; }

        public ApplicationDbcontext(DbContextOptions<ApplicationDbcontext> options):base(options)
        {

        }

        // We don't need it now .....
        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("Server=. ; Database = IKIA ; Trusted_Connection = True ; TrustServerCertificate = True ;");
        //     // optionsBuilder.UseSqlServer("Server=. ; Database = IKIA ; Trusted_Connection = True ; TrustServerCertificate = True ; MultipleActiveResultSets = True");
        // }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(System.Reflection.Assembly.GetExecutingAssembly());
        }
    }
}
