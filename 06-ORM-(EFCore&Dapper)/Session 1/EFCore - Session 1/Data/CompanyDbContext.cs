using EFCore___Session_1.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_1.Data
{
	internal class CompanyDbContext : DbContext
	{
        // Make a property of type DbSet for every table and view ....

		// By convention (The next line) it's for a table , if we want it to be for a view we must use another way 
        public DbSet<Employee> Employees { get; set; }
		// public DbSet<Department> Departments { get; set; }         // deleted on migration number 4 
        public DbSet<Project> Projects { get; set; }
        public DbSet<Product> Products { get; set; }
	
        public DbSet<EmployeeDataAnnotation> Employee2 { get; set; }
        // By Convention the table name in the database is the same name of the property of type DbSet , To change this we can use any of
        // the other ways 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// method used to configure the connection string 

			// Old : 
			// optionsBuilder.UseSqlServer("Data Source = . ; Initial Catalog = CompanyNasr01 ; Integrated Security = true");

			// New : 
			// optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr01 ; Trusted_Connection = true");

			// New starting from .net 7.0 :
			// optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr01 ; Trusted_Connection = true ; Encrypt = false");  // default before .net 7
			// or
			optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr01 ; Trusted_Connection = true ; Encrypt = true ; TrustServerCertificate = true");
			// or 
			// Install a valid certificate. (maybe paid) ==> Used when making the production 

		}
	}
}
