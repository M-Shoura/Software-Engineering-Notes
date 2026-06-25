using EFCore___Session_2.Data.Models.EmployeesModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data
{
	internal class NetflixDbContext : DbContext
	{
        public DbSet<PartTimeEmployee> PartTimeEmployees { get; set; }
        public DbSet<FullTimeEmployee> FullTimeEmployees { get; set; }

        public DbSet<BasicEmployee> BasicEmployee { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr02_Netflix ; Trusted_Connection = true ; Encrypt = true ; TrustServerCertificate = true");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// TPH 
			modelBuilder.Entity<FullTimeEmployee>()
				.HasBaseType<BasicEmployee>();

			modelBuilder.Entity<PartTimeEmployee>()
				.HasBaseType<BasicEmployee>();

		}
	}
}
