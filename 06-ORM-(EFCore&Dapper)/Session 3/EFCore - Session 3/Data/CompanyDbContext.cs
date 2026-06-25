using EFCore___Session_3.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_3.Data
{
	internal class CompanyDbContext : DbContext
	{
        public DbSet<Employee> Employees { get; set; }
		public DbSet<Department> Departments { get; set; }
        public DbSet<EmployeesDepartments> EmployeeDepartmentsView { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer("Server = . ; Database = CompanyNasr03 ; Trusted_Connection = true ; Encrypt = true ; TrustServerCertificate = true");
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
		}
	}
}
