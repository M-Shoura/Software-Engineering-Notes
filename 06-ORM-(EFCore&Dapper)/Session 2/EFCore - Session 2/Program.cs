using EFCore___Session_2.Data;
using EFCore___Session_2.Data.Models;
using EFCore___Session_2.Data.Models.EmployeesModels;
using EFCore___Session_2.Data.Models.SchoolModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Xml.Linq;

namespace EFCore___Session_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // difference between HasDefaultValueSql and HasComputedColumnSql methods in Fluent APIs
            // What is Reflection in C# ?
            // difference between "IQueryable" and "IEnumerable"
            // difference between Build and Rebuild in visual studio 
            // why when using hashset and retrieving data from database it's not important to override Equals and GetHashCode methods ?

            /* End ******************************************************************************************************************/

            #endregion


            #region Revision

            /* Start *****************************************************************************************************************/

            // EFCore supports 4 ways for mapping classes (DbContext , Domain Models) to Database (Tables , Views)
            // 1 - By Convention (Default Behaviour)            (Discussed Last Session and will be discussed more in this session)
            // 2 - Data Annotations (Set of Attributes)         (Discussed Last Session)
            // 3 - Fluent APIs    
            // 4 - Configuration Classes

            // Any of the 4 ways are then translated to Fluent APIs in the Snapshot file .. 

            /* End ******************************************************************************************************************/

            #endregion


            #region Fluent APIs

            /* Start *****************************************************************************************************************/

            // Fluent APIs : Third way for mapping classes (DbContext , Domain Models) to Database (Tables , Views). Some methods , called
            //               in the DbContext class , inside the "OnModelCreating" function (after overriding it) , or take Fluent APIs for 
            //               an entity and put them inside a Configuration class (Forth way for mapping classes to Database).
            // Fluent API = full power. Data Annotations = quick/simple.


            // "OnModelCreating" ==> When the model is mapped to table or associated with a view , what do we mean by associated with a view ?
            //                       means that the view must be there and implemented in the database (by opening the SQL Server and making the
            //                       view or by making an empty migration and in the Up method create that view ) ... but with tables the DbSet
            //                       will be mapped to a table in the database


            // We will use the third way (Fluent APIs) in two scenarios :
            // 1 - If we couldn't do the same thing with the previous two ways (Ex: composite PK , default value for a column , Shadow property
            //                                                                      DbSet associated with view , ... )
            // 2 - If we don't have the source code to write Data Annotations in the source code (if we have the IL file as a project reference)
            //     so the source code is external and locked and we cannot edit the code because it's actually not the source code but the VS 
            //     decompiles the IL code to be C# code. 


            // Important Notes in the CompanyDbContext class ..
            // see the notes in OnModelCreating function in DBContext class , Second Region : Relationships
            // and see the DepartmentConfigurations and EmployeeConfigurations also 







            // Fluent API : C# code-based configuration for your EF Core models.
            // 
            // Located inside your DbContext.OnModelCreating(ModelBuilder modelBuilder).
            // 
            // It’s called "fluent" because it uses method chaining.
            // 
            // Rules priority in EF Core:
            // Fluent API (highest precedence) > Data Annotations > Conventions (default rules EF applies automatically)
            // So if there’s a conflict → Fluent API wins.


            // Fluent API Configuration Areas, let’s go step by step:


            // 1 - Entity Configuration : You tell EF Core how to map a class to a table.
            // 
            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.ToTable("tbl_Users");        // Table name
            //     entity.HasKey(u => u.Id);           // Primary key
            // });


            // 2 - Property Configuration : You configure individual properties inside a specific Entity.
            // 
            // modelBuilder.Entity<User>(entity =>
            // {
            //     entity.Property(u => u.Name)
            //         .HasColumnName("FullName")        // Column name
            //         .HasColumnType("nvarchar(100)")   // Column type
            //         .IsRequired()                     // NOT NULL
            //         .HasMaxLength(100);               // Max length
            // });
            // Other useful methods:
            // 
            // .HasDefaultValue("N/A")                              => default value
            // .HasDefaultValueSql("GETDATE()")                     => SQL default expression
            // .ValueGeneratedOnAdd() / .ValueGeneratedOnUpdate()   => matches [DatabaseGenerated]


            // 3 - Primary Keys & Composite Keys (Composite Keys cannot be done with Data Annotations, only Fluent API)
            // 
            // modelBuilder.Entity<Order>()
            //     .HasKey(o => new { o.OrderId, o.ProductId });



            // 4 - Relationships : Fluent API is most powerful here (Discussed below in depth, and also inside other classes in the project ..)
            // 
            //    4.1 - One-to-One
            // 
            //          modelBuilder.Entity<User>()
            //              .HasOne(u => u.Profile)
            //              .WithOne(p => p.User)
            //              .HasForeignKey<UserProfile>(p => p.UserId);
            //
            //
            //    4.2 - One-to-Many
            // 
            //          modelBuilder.Entity<Order>()
            //              .HasOne(o => o.Customer)             // each order has one customer
            //              .WithMany(c => c.Orders)             // each customer has many orders
            //              .HasForeignKey(o => o.CustomerId);
            //
            //
            //    4.3 - Many-to-Many (EF Core 5+)
            // 
            //          modelBuilder.Entity<Student>()
            //              .HasMany(s => s.Courses)
            //              .WithMany(c => c.Students)
            //              .UsingEntity<Enrollment>(
            //                  j => j.HasOne(e => e.Course).WithMany(),
            //                  j => j.HasOne(e => e.Student).WithMany()
            //              );


            // 5 - Indexes & Constraints : 
            //
            // modelBuilder.Entity<User>()
            //     .HasIndex(u => u.Email)
            //     .IsUnique();                // unique constraint



            // 6 - Owned Entity Types : 
            // 
            // modelBuilder.Entity<User>()
            //     .OwnsOne(u => u.Address, a =>
            //     {
            //         a.Property(p => p.City).HasColumnName("City");
            //         a.Property(p => p.Street).HasColumnName("Street");
            //     });


            // 7 - Table Splitting : Multiple entities share the same table.
            // 
            // modelBuilder.Entity<User>()
            //     .ToTable("Users");
            // 
            // modelBuilder.Entity<UserProfile>()
            //     .ToTable("Users");          // same table as User


            // 8 - Query Filters (Global filters) (ex: Implementing soft delete) :
            //
            // modelBuilder.Entity<User>()
            //     .HasQueryFilter(u => !u.IsDeleted);       // soft delete
            // Note : Automatically applies to all queries, unless explicitly ignored.


            // 9 - Ignoring Properties or Entities(Classes) :
            //
            // modelBuilder.Entity<User>()
            //     .Ignore(u => u.TempField);      // like [NotMapped] data annotation
            // 
            // modelBuilder.Ignore<SomeClass>();   // ignore whole class


            // 10 - Default Schema :
            //
            // modelBuilder.HasDefaultSchema("app");


            // Fluent API vs Data Annotations
            // Feature	Data Annotations	Fluent API
            // Column name/type	✅	✅
            // Length / Required	✅	✅
            // Relationships (complex)	Limited	✅
            // Owned Types	Limited	✅
            // Table Splitting	❌	✅
            // Default value	❌	✅
            // Global Filters	❌	✅
            // Composite Keys	❌	✅



            // 🔹 Summary
            // Fluent API is the most powerful way to configure EF Core models.
            // Defined in OnModelCreating(ModelBuilder).
            // Can configure:
            // Entities → tables
            // Properties → columns
            // Keys, indexes, constraints
            // Relationships (1:1, 1:n, n:n)
            // Owned entities, table splitting
            // Query filters
            // Concurrency
            //
            //
            // ...  Fluent API overrides everything else.



            //  .OnDelete(DeleteBehavior.Cascade);


            // 6 - Concurrency & Row Version :
            // 
            // modelBuilder.Entity<User>()
            //     .Property(u => u.RowVersion)
            //     .IsRowVersion(); // maps to SQL rowversion
            // Or use:
            // 
            // modelBuilder.Entity<User>()
            //     .Property(u => u.Email)
            //     .IsConcurrencyToken();


            /* End ******************************************************************************************************************/

            #endregion


            #region Configuration Classes

            /* Start *****************************************************************************************************************/

            // The 4th and last way for mapping classes (DbContext , Domain Models) to Database (Tables , Views). Organizing the 3rd way , each 
            // model has a configuration class 

            // Actually we don't use the Fluent APIs in OnModelCreating function in AppDBContext class , because it will have much code , so we 
            // use a Configuration Classe containing Fluent APIs of each model.

            // First inside the Data Folder , we make a new folder called "Configurations" , and inside this folder we will create class for
            // each model we have. Each class must implement interface "IEntityTypeConfiguration<>" ,the generic one and with specifying the
            // type that we will work with .. then use the object of class EntityTypeBuilder<> to build the configurations and Fluent APIs.

            /* End ******************************************************************************************************************/

            #endregion


            #region Query Object Model (L2EF) - Inserting

            /* Start *****************************************************************************************************************/

            // // Execute the database operations through the application 
            // 
            // // While using the EF Core , we will use the Change Tracker ...
            // 
            // // remember : connecting to a database is unmanaged by the CLR , so when opening the connection we must also close it . this
            // //            can be applicable through : 
            // //            1 - try {} finally {}
            // //            2 - using() {}
            // //            3 - using
            // 
            // 
            // // we will use the last way : 
            // using CompanyDbContext dbContext = new CompanyDbContext();
            // 
            // Employee e1 = new Employee() { Name = "Mahmoud", Age = 22, Salary = 5_000, Email = "mahmoud@gmail.com", Address = "Alex" };
            // Employee e2 = new Employee() { Name = "Shoura", Age = 100, Salary = 150_000, Email = "shoura@gmail.com" };
            // 
            // 
            // // to know the state of the objects : 
            // Console.WriteLine(dbContext.Entry(e1).State);
            // Console.WriteLine(dbContext.Entry(e2).State);
            // 
            // state method returns a "EntityState" which is a Enum containing : 
            // // 1 - Detached    ==> not being tracked by the context
            // // 2 - Unchanged   ==> tracked by the context and exists in the database. Its property values have not changed from the values in the database
            // // 3 - Deleted     ==> tracked by the context and exists in the database. It has been marked for deletion
            // // 4 - Modified    ==> tracked by the context and exists in the database. Some or all of its property values have been modified
            // // 5 - Added       ==> The entity is being tracked by the context but does not yet exist in the database.
            // 
            // 
            // // To write insert statement we can write SQL Queries (not recommended) or use the Change Tracker offered by the EFCore 
            // 
            // dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;
            // // this is the default ==> TrackAll
            // // dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.NoTracking;
            // // we can change it to NoTracking but this is not the way we work !! this stops tracking for all the objects , we can do the same
            // // thing but with specifying the objects we want to stop tracking (using "AsNoTracking" function)
            // 
            // // we can add the object by 4 ways : 
            //
            // dbContext.Employees.Add(e1);
            // // dbContext.Add(e1);
            // // dbContext.Entry(e1).State = Microsoft.EntityFrameworkCore.EntityState.Added;
            // // dbContext.Set<Employee>().Add(e1);
            // // last way is used when we don't have a DbSet property for that type (but actually we have a table in the database because we 
            // // configured that using Fluent APIs " .ToTable("Deps") ")
            // 
            // // any way of these 4 ways makes the state of the objects from "Detached" to "Added" , that means that the objects are not yet
            // // added in the database but if we write "dbContext.SaveChanges()" then all objects that have a state "Added" will be added to database
            // 
            // 
            // dbContext.Employees.Add(e2);
            // dbContext.SaveChanges();
            // 
            // // the state after "dbContext.SaveChanges()" will be "Unchanged" because they are already in the database and not changed by any way
            // 
            // 
            // // Note : if we set the tracking to "NoTracking" , and we added an object to the database .. it's state ("Detached" to "Added")
            // //        this is because we can stop tracking only the objects retrieved from the database (not objects added to the database),
            // //        but if we retrieved an object and then updated it , the state will not change "unchanged" although updating it 
            // //        (that's because we updated the trackingsettings to "NoTracking" to the objects inside the database)

            /* End ******************************************************************************************************************/

            #endregion


            #region Selecting (Retrieving)

            /* Start *****************************************************************************************************************/

            // using CompanyDbContext dbContext = new CompanyDbContext();
            // dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;     // Default
            // 
            // 
            // // To Retrieve some data from the table : 
            // 
            // var employees = from E in dbContext.Employees
            // 				where E.Code == 1
            // 				select E;
            // 
            // // The type of "employees" is IQueryable , that's because "Employees" is a remote sequece that actually doesn't contain data ,
            // // so when working against a remote sequence the result is IQueryable
            // 
            // // use element operators for immediate execution,
            // // Remember the difference between "SingleOrDefault" [select top 2 in SQL] and "FirstOrDefault" [select top 1 in SQL]
            // // use first or default if we are sure that this is PK column , and single or default if we want to ensure that this is the 
            // // PK Column or when wanting to throw exception if more than one element matches the criteria 
            // var emp = ( from E in dbContext.Employees
            // 		   where E.Code == 1
            // 		   select E ).SingleOrDefault();
            // 
            // if (emp is not null)
            // {
            // 	Console.WriteLine(dbContext.Entry(emp).State);   // if (TrackAll) => Unchanged , if(NoTracking) => "Detached" 
            // 	Console.WriteLine($"{emp.Code} :: {emp.Name} :: {emp.Salary}");
            // }
            // 
            // // Note : if we know that we won't change that object (update) or delete .. then it's better to use "AsNoTracking" as below :
            // 
            // emp = ( from E in dbContext.Employees
            // 	   where E.Code == 1
            // 	   select E ).AsNoTracking().SingleOrDefault();

            /* End ******************************************************************************************************************/

            #endregion


            #region Updating

            /* Start *****************************************************************************************************************/

            // using CompanyDbContext dbContext = new CompanyDbContext();
            // dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;   // Default
            // 
            // var emp = (from E in dbContext.Employees
            // 		   where E.Code == 1
            // 		   select E).FirstOrDefault();
            // 
            // if (emp is not null)
            // {
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // unchanged
            // 
            // 	emp.Name = "hamada";
            // 
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // modified
            // 
            // 	// still it's not updated in the database , it will be updated after "dbContext.SaveChanges()"
            // 
            // 	dbContext.SaveChanges();
            // 
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // unchanged
            // 
            // 	// Note : If we used "AsNoTracking" for emp , or changed the default behaviour (QueryTrackingBehavior.NoTracking) , then all
            // 	// the states above will be "Detached" .. because we stoped tracking this object
            // 
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Deleting

            /* Start *****************************************************************************************************************/

            // using CompanyDbContext dbContext = new CompanyDbContext();
            // dbContext.ChangeTracker.QueryTrackingBehavior = Microsoft.EntityFrameworkCore.QueryTrackingBehavior.TrackAll;   // Default
            // 
            // var emp = ( from E in dbContext.Employees
            // 		  where E.Code == 2 
            // 		  select E ).FirstOrDefault();
            // 
            // if (emp is not null)
            // {
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // unchanged 
            // 
            // 
            // 	// we can delete this object by the same 4 ways for inserting an object : 
            // 
            // 	dbContext.Employees.Remove(emp);
            // 	// dbContext.Remove(emp);
            // 	// dbContext.Entry(emp).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
            // 	// dbContext.Set<Employee>().Remove(emp);
            // 	// // last way is used when we don't have a DbSet property for that type (but actually we have a table in the database because we 
            // 	// // configured that using Fluent APIs " .ToTable("Deps") ")
            // 
            // 
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // deleted 
            // 
            // 	dbContext.SaveChanges();
            // 
            // 	Console.WriteLine(dbContext.Entry(emp).State);          // Detached
            // 
            // 	// Note : If we used "AsNoTracking" for emp , or changed the default behaviour (QueryTrackingBehavior.NoTracking) , then all
            // 	// the states above will be "Detached" .. because we stoped tracking this object
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Relationships Mapping

            /* Start *****************************************************************************************************************/

            // Making a relationship between relations in the database in SQL Server is totally different than making the same relationship
            // in the C# application code


            // ex : Employee and Department classes, employee has Id , Name , Salary , int DepartmentId 
            //                                       department has Id , Name 
            //
            // The last way the EFCore will not detect that there is a relationship here By convention , we must use Navigational properties
            // and it will be one direction (we can know the employee is in which department but we cannot know this department, who work in it)

            // ex : Employee and Department classes, employee has Id , Name , Salary , Department department (navigational property)
            //                                       department has Id , Name , list<Employee> employees (navigational property)
            // now this relationship is in the two directions (we know the employee is in which department and know this department, who work in it)

            // by convention now the EFCore knows that there is a relationship between the two classes and will be mapped to the database , making
            // the navigational property in the two sides makes the relationship in two directions ...

            // Note : Navigational Property (called Related Data) is by default not populated with data (will be not loaded by default), but can
            // be loaded by 3 ways (Discussed next Session) :
            // 1 - Explicit loading
            // 2 - Eager Loading
            // 3 - Lazy Loading (same as Explicit loading but done implicitly)


            // In one to one relationships , put a navigtional property in each sides 
            // In one to many relationships , we can put navigational property in each sides OR put it in one side 
            // In many to many relationships , put navigational property in each sides (will generate a new class by convention) , but if we have
            // an attribute on relation then we must make a class and has 2 navigational properties and the attribute on relationship 

            /* End ******************************************************************************************************************/

            #endregion


            #region One to Many Relationships By Convention

            /* Start *****************************************************************************************************************/

            // We can put the navigational property in one side only OR in the two sides .. any case will be recognized as a 1 to Many Relatioship
            // but if we want to use the navigational property then we must put it in that side 

            // Many employees work in One department (1 to many)
            // One Employee is manager for One department 

            // Note : If we faced an error => "the alter table statement conflicts with the foreign key constraint" then there is data inside the table
            //        in the database and we cannot apply the change while this data is there 

            /* End ******************************************************************************************************************/

            #endregion


            #region One to One Relationships By Data Annotations & Convention

            /* Start *****************************************************************************************************************/

            // By Convention we must put the navigational property in the two sides to recognize it as a 1 to 1 relationship

            // Manage Relationship between employee and department (a department must be managed by one employee)

            // in our case , we have more that one relationship between our classes , if we have only one relationship then we can work without
            // specifying the inverse property for each property as shown by Data Annotations .. but here we have two relationships then we must 
            // specify the property and it's inverse property in the other class (this can be done using Data Annotations or Fluent APIs)

            // Also if we have a foreign key we must specify the property and relationship that it's used for ... Using the ForeignKey() data annotation

            // data annotations : 
            // [InverseProperty(nameof(Employee.Department))] or [InverseProperty("Employees")]
            // [ForeignKey(nameof(Employee.Department))]      or [ForeignKey("Department")]

            // note : [ForeignKey()] data annotation can be above the foreign key itself and having the name of the navigational property , or above the 
            //        navigational property and having the name of the foreign key

            /* End ******************************************************************************************************************/

            #endregion


            #region One To One Total Participation from the two sides 

            /* Start *****************************************************************************************************************/

            // Ex: Every Employee has a Detailed Address 

            // in this case , we must not have a PK for table address , because it's "Owned By" the Employee

            // this can be done through Fluent APIs or Data Annotations 

            // in application : Employee has DetailedAddress , and the DetailedAddress has the properties (Street , BlockNumber , ...	)
            // in the database: Table has all the Employee attributes and the Address attributes  

            /* End ******************************************************************************************************************/

            #endregion


            #region Many To Many Relationships

            /* Start *****************************************************************************************************************/

            // We will use another DbContext and Another classes : Student and Course Classes with the SchoolDbContext 

            // Command for using another DbContext :
            // Add-Migration "Test" -Context "SchoolDbContext" -Output "Data/Migrations/School"
            // Update-Database -Context "SchoolDbContext"
            // update-database 0 -Context "SchoolDbContext"
            // Remove-Migration -Context "SchoolDbContext"

            // if we have 2 nav_proeprties then it's the same as writing this in the Fluent API (starting from any side) :
            // note : a third table is automatically generated having a composite PK of the two FK taken from the two tables in the relationship

            // modelBuilder.Entity<Student>()
            // 	.HasMany(s => s.Courses)
            // 	.WithMany(c => c.Students);
            // 
            // modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Students)
            //    .WithMany(s => s.Courses);


            // if we have 1 nav_property then we can start the Fluent API with the entity that has the Nav_proeprty and then don't write 
            // the other side (because we don't have a nav_property) : 

            // if the nav_property is in Student Class:
            //
            // modelBuilder.Entity<Student>()
            // 	.HasMany(s => s.Courses)
            // 	.WithMany();

            // if the nav_property is in Course Class:
            //
            // modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Students)
            //    .WithMany();


            // So the previous ways .. we cannot use them to configure the relationship , because the many to many relationship is mapped in the
            // database as a new table having two foreign keys from the two tables ... so we will make the third table in two cases : 
            // 1 - Configuring the Relationship between the two tables 
            // 2 - Adding an attribute on the relationship 


            // so if we have 2 nav_properties inside the two classes .. it's not importnat to put this code inside the OnModelCreating function 
            // because this is the same thing that happened :

            // modelBuilder.Entity<Course>()
            //    .HasMany(c => c.Students)
            //    .WithMany(s => s.Courses);


            // Now if we want to Configuring the Relationship between the two tables or Adding an attribute on the relationship then we will make a
            // new class named with "StudentCourse" having two properties "StudentId" and "CourseId" and "Grade" as a attribute on relationship .. then
            // we will comment the two nav_properties in the two classes and make another two nav_properties for interacting with the new third class

            // important note : It's not important to make a DbSet for the third table because by convention it's known that it's a table .. that's 
            //                  because we have a nav_property between class student and the StudentCourse class then there is s relationship then 
            //                  automatically make a table in the Database 

            // now we can configure the relationship between the three classes , and the attribute on relationship will be added in the database table 

            /* End ******************************************************************************************************************/

            #endregion


            #region Inheritance Mapping

            /* Start *****************************************************************************************************************/

            // // We will work with new classes : BasicEmployee , FullTimeEmployee , PartTimeEmployee and NetflixDbContext
            // 
            // // Our Classes =>
            // 
            // // Employee has : Id , Name , Age , Address
            // // FullTime Employee has : StartDate , Salary
            // // PartTime Employee has : HourRate , CountOfHours
            // 
            // 
            // // We have 3 ways for mapping these classes : 
            // // 1 - Table Per Class (TPC) / Table Per Type (TPT)           (Not Discussed , bad because when retrieving we must join between many tables)
            // // 2 - Table Per Hierarchy (TPH)                              (Discussed)
            // // 3 - Table Per Concrete Class (TPCC)                        (Discussed & Recommended and the Best Solution)
            // 
            // // The first migration we worked with "TPCC" , and made 2 DbSets "FullTimeEmp" and "PartTimeEmp" , so there are actually 2 tables in the 
            // // database and we can easily do CRUD operations on them 
            // 
            // // Table Per Hierarchy (TPH) : having only one table for the Hierarchy , this causes large number of Null values in this table .. also 
            // //                             we have a column called "Discriminator" that has a type "nvarchar(max)" to differentiate between the types.
            // 
            // // To use this way we must use "Fluent APIs" (it's the only way) : 
            // 
            // // in "OnModelCreating" function : 
            // 
            // // modelBuilder.Entity<FullTimeEmployee>()
            // // 	.HasBaseType<BasicEmployee>();
            // // 
            // // modelBuilder.Entity<PartTimeEmployee>()
            // // 	.HasBaseType<BasicEmployee>();
            // 
            // // now if we added a migration we will notice that we have one table only in the database ... called BasicEmployee
            // 
            // // To retrieve the FullTimeEmployees : 
            // // var FTE = from Emps in Net_DbContext.FullTimeEmployees
            // //           select Emps;
            // 
            // // To retrieve the PartTimeEmployees : 
            // // var PTE = from Emps in Net_DbContext.PartTimeEmployees
            // //           select Emps;
            // 
            // using NetflixDbContext Net_DbContext = new NetflixDbContext();
            // 
            // FullTimeEmployee emp1 = new FullTimeEmployee() { Name = "Mahmoud" , Address = "Cairo" , Age = 22 , Salary = 100000};
            // PartTimeEmployee emp2 = new PartTimeEmployee() { Name = "Shoura" , Address = "Egp" , Age = 66 , CountOfHours = 100 , HourRate = 500};
            // 
            // // note : Here we can interact with the DB table by 2 ways : By the table called BasicEmployee (we don't have a  DbSet for it) , or with the 
            // //        (FullTimeEmployees or PartTimeEmployees DbSets we have in the Net_DbContext)
            // 
            // // Net_DbContext.FullTimeEmployees.Add(emp1);
            // // Net_DbContext.PartTimeEmployees.Add(emp2);
            // // 
            // // // or
            // // 
            // // Net_DbContext.Set<BasicEmployee>().Add(emp1);         // using Set<>() because we don't have an actual DbSet in the Net_DbContext class
            // // Net_DbContext.Set<BasicEmployee>().Add(emp2);
            // 
            // 
            // // Now if we added a new DbSet in the class Net_DbContext that will represent the only one table at the database "BasicEmployee"
            // // that can be used to add or retrieve (use the discriminator for adding and retrieving) : 
            // 
            // // To Add : 
            // // Net_DbContext.BasicEmployee.Add(emp1);
            // // Net_DbContext.BasicEmployee.Add(emp2);
            // 
            // Net_DbContext.SaveChanges();
            // 
            // // To retrieve from the database , we can use any of the two ways : 
            // 
            // var FTE = from Emps in Net_DbContext.FullTimeEmployees 
            // 		  select Emps;
            // // or 
            // 
            // FTE = from Emps in Net_DbContext.BasicEmployee.OfType<FullTimeEmployee>() 
            // 	  select Emps;
            // 
            // 
            // foreach (var Emps in FTE) 
            // {
            // 	Console.WriteLine($"{Emps.Name} :: {Emps.Salary}"); 
            // }
            // 
            // Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            // 
            // var PTE = from Emps in Net_DbContext.PartTimeEmployees
            // 		  select Emps;
            // // or
            // 
            // PTE = from Emps in Net_DbContext.BasicEmployee.OfType<PartTimeEmployee>()
            // 	  select Emps;
            // 
            // 
            // foreach (var Emps in PTE)
            // {
            // 	Console.WriteLine($"{Emps.Name} :: {Emps.HourRate}");
            // }
            // 
            // 
            // Console.WriteLine("+++++++++++++++++++++++++++++++++++++++++++++++++++++");
            // 
            // var All = from Emps in Net_DbContext.BasicEmployee
            // 	      select Emps;
            // 
            // foreach (var Emps in All)
            // {
            // 	Console.WriteLine($"{Emps.Name} :: {Emps.Age}");
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region How to DownGrade / Upgrade the .NET Targeted framework , packages versions , ... ?

            /* Start *****************************************************************************************************************/

            // open the .csproj find in the solution explorer , and change the Targeted framework , packages versions with the specific 
            // version we want .. to know the versions we can use the NuGet Packages and see the versions of the packages we installed 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}