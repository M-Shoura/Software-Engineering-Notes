using Microsoft.EntityFrameworkCore;

namespace My.Models
{
    public class CityDbContext : DbContext
    {
        // self study : see the two constructors of the DbContext class 

        public virtual DbSet<City> Cities { get; set; }               // why it's virtual ? self study ...
        public virtual DbSet<Country> Countries { get; set; }         // why it's virtual ? self study ...     
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=MVC_City_DB;Integrated Security=True;Trust Server Certificate=True;");
        }


    }
}
