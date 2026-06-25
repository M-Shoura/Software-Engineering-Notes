using EFCore___Session_2.Data.Configurations;
using EFCore___Session_2.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EFCore___Session_2.Data
{
	internal class CompanyDbContext : DbContext
	{
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("Server = . ; Database = CompanyNasr02 ; Trusted_Connection = true ; Encrypt = true ; TrustServerCertificate = true");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			#region First Part 

			// // base.OnModelCreating(modelBuilder);
			// // OnModelCreating function of the base class "DbContext" actually don't have any Fluent APIs , that's because we don't have 
			// // DbSets in the class "DbContext" to make Fluent APIs for them .. so OnModelCreating function of the base class "DbContext" is
			// // empty. This is not the case in class "IdentityDbContext" (child class , inherits from DbContext class) that we will use in
			// // Security module (sign in , ... ) , its OnModelCreating function has some Fluent APIs in it because the class "IdentityDbContext"
			// // has DbSets inside it 
			// 
			// // Note : modelBuilder uses the builder design pattern 
			// 
			//
			// // Fluent APIs here
			// 
			modelBuilder.Entity<Employee>().Property<string>(x => x.Address).HasColumnType<string>("varchar");
			// modelBuilder.Entity<Employee>().Property<string>("Address").HasColumnType("varchar").HasMaxLength(50).IsRequired(false /*default true*/);
			// // This is a column in the table that is not represented as a Property in the class (Shadow Property)
			// // Note : We here used the Property<>() (generic) because it's the first time to introduce this column which is not in the database , 
			// //        but when dealing with a column in the database we could use the non-genreric one "Property()"
			// 
			// // Property function can take the name of the column by 3 ways :
			// // 1 - modelBuilder.Entity<Employee>().Property("Address");
			// // 2 - modelBuilder.Entity<Employee>().Property(nameof(Employee.Address));  // Don't work with shadow property because they are not in the model
			// // 3 - modelBuilder.Entity<Employee>().Property<string>(e=>e.Address);	    // Don't work with shadow property because they are not in the model
			// 
			// 
			// 
			// // Change the default name of the table (default is the DbSet Property name) and can change the default Schema
			// modelBuilder.Entity<Department>().ToTable("Deps");
			// // modelBuilder.Entity<Department>().ToTable("Deps" , "HR");
			// // 
			// // // Associate it to a view (we must have a view with that neme in the database "Emps") and can specify the schema also 
			// // modelBuilder.Entity<Department>().ToView("Deps");
			// // modelBuilder.Entity<Department>().ToView("Deps" , "HR");
			// // 
			// // // map it to a function
			// // modelBuilder.Entity<Department>().ToFunction("ShowDeps");
			// 
			// 
			// 
			// // Specify the PK (By three ways) :
			// modelBuilder.Entity<Department>().HasKey(d => d.DeptId);
			// // modelBuilder.Entity<Department>().HasKey("DeptId");
			// // modelBuilder.Entity<Department>().HasKey(nameof(Department.DeptId));
			// 
			// // Make Composite PK (anonymous type)
			// // modelBuilder.Entity<Department>().HasKey(d => new { d.DeptId, d.Name });
			// 
			// 
			// 
			// // Column uses the Identity : 
			// modelBuilder.Entity<Department>().Property(d=>d.DeptId).UseIdentityColumn(10,10);      // seed = 10 , increment += 10
			// 
			// 
			// 
			// // change the property name at the table and it's type 
			// modelBuilder.Entity<Department>()
			// 	.Property(d => d.Name)
			// 	.HasColumnName("DeptName")
			// 	.HasColumnType("varchar")
			// 	.HasMaxLength(100);
			// 
			// 
			// // default value for a column
			// modelBuilder.Entity<Department>().Property(d => d.CreationPlace).HasDefaultValue("Cairo");
			// // modelBuilder.Entity<Department>().Property(d => d.CreationDate).HasDefaultValue( DateOnly.FromDateTime(DateTime.Now));   
			// // Wrong ! this will always have the value when the migration is created (not dynamic) 
			// 
			// modelBuilder.Entity<Department>().Property(d => d.CreationDate).HasDefaultValueSql("GETDATE()"); // Write SQL code to get the date
			// // or
			// modelBuilder.Entity<Department>().Property(d => d.CreationDate).HasComputedColumnSql("GETDATE()"); // Write SQL code to get the date
			// 
			// // in HasComputedColumnSql the column is disabled in SQL SERVER, but HasDefaultValueSql we can change the values of this column
			// 
			// // if I want to write a data annotation but I don't have the source code (meaningless example now)
			// modelBuilder.Entity<Department>().Property(d => d.Name).HasAnnotation("MaxLength" , 50);
			// 
			// 
			// 
			// // Starting from .net core 3.1 , we have a second overload for Entity<>() , to minimize code repeating :
			// modelBuilder.Entity<Department>(E =>
			// {
			// 	E.Property(d => d.Name)
			// 	.HasColumnName("DeptName")
			// 	.HasColumnType("varchar")
			// 	.HasMaxLength(100);
			// 
			// 	E.Property(d => d.CreationDate).HasComputedColumnSql("GETDATE()");
			// 
			// 	E.Property(d => d.Name).HasAnnotation("MaxLength", 50);
			// });




			// All the important code is written inside each configuration class (4th way)

			// now we must call the configurations , how ?
			// we can call each config class one by one :

			// modelBuilder.ApplyConfiguration(new EmployeeConfigurations());
			// modelBuilder.ApplyConfiguration(new DepartmentConfigurations());

			// or we can call all the configuration classes in one line :
			modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
			// ApplyConfigurationsFromAssembly ==> uses Reflection to find all the classes that implement the "IEntityTypeConfiguration" interface
			//                                     and calls them

			#endregion


			#region Second Part : Relationships

			// One to Many Relationship : -------------------------------------------------------------------------

			// here we can configure the relationships , using Fluent APIs ... 

			// But start with which entity ? 
			// if we have 2 navigational properties in the two sides then we can start with any one of them
			// else we will start with the Entity type that has a navigational property

			// put in the DepartmentConfigurations
			// modelBuilder.Entity<Department>()
			// 	.HasMany(d => d.Employees)                   // or HasMany("Employees")
			// 	.WithOne(e => e.Department)                  // or WithOne("Department")
			// 	.HasForeignKey(e => e.DepartmentDeptId)      // it knows that the FK is in the many side (employee has a department id that he works in)
			// 	.IsRequired()
			// 	.OnDelete(DeleteBehavior.Cascade);

			// use HasForeignKey when : 
			// 1 - We don't have a foreign key property inside the model it self and we want to name it manually
			// 2 - We have a foreign key property inside the model but with a name (not known by convention) and we didn't use data annotation
			// 3 - We have more than one relationship between the models and we don't use the data annotation 


			// Same as the previous but starting from the other side : 

			// modelBuilder.Entity<Employee>()
			// 	.HasOne(e => e.Department)
			// 	.WithMany(d => d.Employees)
			// 	.HasForeignKey(e => e.DepartmentDeptId)      
			// 	.IsRequired()
			// 	.OnDelete(DeleteBehavior.Cascade);


			// Now , we use which one ? we usually use the side that has the PK (in our case : department). so put the first code in DepartmentConfigurations




			// One to One Relationship : -------------------------------------------------------------------------

			// put in the EmployeeConfigurations
			// modelBuilder.Entity<Employee>()
			// 	.HasOne(e => e.ManagedDepartment)
			// 	.WithOne(d => d.Manager)
			// 	.HasForeignKey<Department>(d=>d.ManagerId)           // we must specify the type that will have the FK (because it's 1to1 Relationship)
			// 	.IsRequired()
			// 	.OnDelete(DeleteBehavior.SetNull);                   // when deleting the employee that manages the department then make the ManagerId = null


			// Same as the previous but starting from the other side : 
			
			modelBuilder.Entity<Department>()
				.HasOne(d => d.Manager)
				.WithOne(e => e.ManagedDepartment)
				.HasForeignKey<Department>(d => d.ManagerId)           
				.OnDelete(DeleteBehavior.SetNull);


			// important note : 
			// 1 - when making two nav_properties : 

			// modelBuilder.Entity<Employee>()
			// 	.HasOne(e => e.ManagedDepartment)
			// 	.WithOne(d => d.Manager)
			// 	.HasForeignKey<Department>(d => d.ManagerId)         
			// 	.IsRequired()
			// 	.OnDelete(DeleteBehavior.SetNull);                   
			// 
			// 
			// or 
			// 
			// modelBuilder.Entity<Department>()
			// 	.HasOne(d => d.Manager)
			// 	.WithOne(e => e.ManagedDepartment)
			// 	.HasForeignKey<Department>(d => d.ManagerId)
			// 	.OnDelete(DeleteBehavior.SetNull);


			// 2 - when making one nav_property at one side : (must have one relationship , if more that one we will have confusion as we discussed before)

			// modelBuilder.Entity<Employee>()
			// 	.HasOne(e => e.ManagedDepartment)
			// 	.WithOne()                                             // delete here , keep the side that has the nav_property and start with it
			// 	.HasForeignKey<Department>(d => d.ManagerId)         
			// 	.IsRequired()
			// 	.OnDelete(DeleteBehavior.SetNull);                   
			// 
			// 
			// or 
			// 
			// modelBuilder.Entity<Department>()
			// 	.HasOne(d => d.Manager)
			// 	.WithOne()                                            // delete here , keep the side that has the nav_property and start with it
			// 	.HasForeignKey<Department>(d => d.ManagerId)
			// 	.OnDelete(DeleteBehavior.SetNull);

			#endregion
		}
	}
}
