namespace EFCore___Session_1
{
    internal class Program
	{
		static void Main(string[] args)
		{
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // Dapper vs Entity Framework Core vs ADO.NET:
            //        https://www.c-sharpcorner.com/article/dapper-vs-entity-framework-core-vs-ado-net-which-one-should-you-choose/

            // entity framework core 7 connection certificate :
            // https://stackoverflow.com/questions/74467642/entity-framework-core-7-connection-certificate-trust-exception

            // DataBaseGeneratedOption Enum and it's values (used with DatabaseGenerated data annotation) :
            // https://dotnettutorials.net/lesson/databasegenerated-attribute-in-entity-framework-core/


            //  scaffolding in ASP.NET Core = auto-generate controllers + auto-generate views from your EF Core models.
            // Advanced Data Annotations : 
            // [ConcurrencyCheck]	      
            // [Timestamp] / [RowVersion]

            /* End ******************************************************************************************************************/

            #endregion


            #region General Discussion 

            /* Start *****************************************************************************************************************/

            // First of all , in this discussion we may not understand every thing, but all topics will be understood while we dive through
            // the EFCore in the 4 Sessions.

            // Before having the ORM , we used the "ADO.Net"
            // ADO.Net : classes and interfaces that are part of .net Framework , same as the LINQ is a part from the .net Framework
            // ADO.Net was used to Query (select , insert , update , delete) from the Database in the C# Code 
            // The developer builds the database , and builds the application , and to use the database in the application then use ADO.Net

            // After the ADO.Net the concept of ORM was introduced 
            // ORM : Object Relational Mapper
            // With the ORM , it's not important to build the two sides (database and application) , but the developer can build one side and the
            // ORM builds the other side (Map one side to the another side)

            // The ORM connects the object and the relation (the object is the business object which is in the application) , (the relation is
            // the table which is in the database)

            // The ( Business objects ) or ( Domain models ) ==> class that represents the structure of a table or a view , Ex: Employee class 
            // The ( View models ) ==> class that represents data in a view , Ex: it's not a must to show all the employee data in the
            //                         HTML page , so we hide some properties and the other are in the view model and can be shown 

            // Code First : The developer make the domain model and use the ORM to generate that table or view in the database 
            // Database First : The developer develop the database tables, views and use the ORM to generate the domain model + DB Context class

            // What is the DB Context class ?
            // inside this class we can find any thing related to the database , we can find a property for each and every table in the database , 
            // and a proeprty for each and every view in the database , this property is ofType "DBSet" . When we want to query the database then
            // we will make an object from this class. Now we opened a connection with the database and we can write Linq against a sequence 
            // (L2EF ==> Linq to Entity Framework) . Note : Any property inside the database table or view is a Remote Sequence 

            // Some resources are not under the control of the CLR (UnManaged Resources) , example for that : Connection of a server or a database , 
            // to close the connection that is not under the control of the CLR we must use "Try Finally" and close the connection in the "Finally" ,
            // or use "using" block which is a syntax sugar for "Try Finally"

            // We can find ORM for most backend technologies , with Microsoft and C# The main ORM is the "Entity Framework" (Entity Framework with
            // ASP.Net Framework and Entity Framework Core with ASP.Net Core ) , We also have "Dapper" which is a micro ORM , designed to make 
            // specific tasks and is very fast in these tasks , We also have "Hibernate" , We also have other Paid ORMs  


            // How to know that using this ORM is faster than the other ? by using the Benchmark Package and querying the database by for example
            // EFCore and Dapper , we will find that Dapper is faster than EFCore by a small difference (noticed in large databases and datasets) 


            // How to make the database (Sql server in our course) and the Application (C# in our course) interact with each other ?
            // 1 - Using ADO.Net (Old Way)
            // 2 - Using one of the ORMs (we will focus on EFCore and Dapper)

            // In Entity Framework Core , we roughly have all the features we want .. Also it's an intelligent ORM , sometimes it takes decisions ,
            // decisions are called by Convension (will be discussed later , ex: the primary key of the table if we don't specify it then it will be
            // the property named with Id or ClassNameId .. another example : if the type of the property in C# is string then in the database the type
            // will be nvarchar(max) .. ) . Note : This Convension can be changed as we want 
            //
            // 1 - Mapping : develop only one side (database or application) and the EFCore will generate the other side 
            //               This feature is ONLY found in Entity Framework Core (Also called Automatic Schema Migration)
            //               1 - Code First : From Code (Classes => [ DBContext & Domain Models ]) then Generate Database (Tables)
            //                                Ex: Employee class and Department class , generate Employee table and Department table , properties
            //                                    inside emp class are columns inside emp table (Not a must , we can choose some columns only)
            // 
            //               2 - Database First : From Database (Tables) then Generate Code (Classes => [ DBContext & Domain Models ])
            //                                    called also ==> "Reverse Engineering"
            //
            //               Most Used Approach : Code first , it's easier and focus on C# code (later making APIs for example .. )
            // 
            // 2 - L2EF Core : Linq To Entity Framework Core , we can write raw SQL without problems but it's better to write Linq to be 
            //                 translated to the syntax of SQL provider we use and not to be tightly coupled with a database provider syntax 
            //                 So we : Query Object Model , where the object model is a Row in the table of the database (CRUD Operations)
            //                 If we want to insert or update or delete data then we must retrieve the data from the database first (currently
            //                 the "state" is "UnChanged" ) , if we changed this data or updated it then the "state" is "Modified" , if
            //                 we removed the data then the "state" is "Deleted" , if we add an object the " state " will be changed from
            //                 "DeAttached" to "Added" After all the Queries , we will use the DBContext functionality called "SaveChanges" ,
            //                 that makes the "Change Tracker" modify the data in the database now by generating SQL scripts to manipulate the
            //                 data ... Note : The "Change Tracker" is found ONLY in Entity Framework Core .. Here we have an important note ,
            //                 if the data is retrieved only for reading not updating or deleting , then we have to use "AddNoTracking" to save
            //                 resources and don't track the status of these data.
            // 
            //                 In Dapper , all the features are for Querying Object Model (No mapping , No Change Tracker , No Linq Write Raw SQL,
            //                 so tightly coupled with a database provider )
            // 
            //                 So To Sum Up : We will use "EFCore" for mapping , then we will use the "EFCore" for Insert , Update , Delete
            //                                Operations to use the Change Tracker , BUT When Retrieving and Reading data only here we will
            //                                compare the speed of EFCore VS Dapper using the Benchmark Package , But take care of Tightly
            //                                Coupled Syntax with a database provider with Dapper  
            //
            // Note : Internally , Dapper and EFCore use ADO.Net 

            /* End ******************************************************************************************************************/

            #endregion


            #region Dapper vs Entity Framework Core vs ADO.NET  

            /* Start *****************************************************************************************************************/

            // Copy and Paste from the Link in the "Self Study and Notes" region , check the link if you want to see an actual code for 
            // the three examples ...

            // ADO.NET : 
            //     ADO.NET is a database access technology that is part of the .NET Framework. It provides a set of classes and interfaces
            //     that allow .NET applications to interact with databases. ADO.NET has been around for a long time and is widely used in .NET
            //     applications that has been around for a long time (Legacy systems). ADO.NET is a low-level tool, which means that it provides
            //     fine-grained control over database operations. However, this also means that developers have to write a lot of code to interact
            //     with databases.


            // Entity Framework Core : 
            //     Entity Framework Core (EF Core) is a high-level ORM (Object-Relational Mapping) tool that allows .NET applications to interact with
            //     databases. It provides a set of classes and APIs (Fluent APIs not the APIs or Endpoints) that abstract the database operations,
            //     making it easier for developers to work with databases. EF Core is built on top of ADO.NET, which means it uses ADO.NET internally
            //     to interact with databases. EF Core supports several database providers, including SQL Server, MySQL, SQLite, and PostgreSQL. It
            //     provides several features, such as automatic schema migration (mapping), query translation (to the syntax we installed the database
            //     provider), and change tracking. EF Core also supports LINQ, which allows developers to write queries in C# instead of SQL.
            //     
            //     Ex : If we use the SQL Server Database , then we will install Microsoft.EntityFrameworkCore.SQLServer and the database will be mapped
            //          to the same database provider (if we use Code First Approach)


            // Dapper : 
            //     Dapper is a micro ORM that was developed by the StackOverflow team. It provides a lightweight and fast way to work with databases.
            //     Dapper is built on top of ADO.NET and provides a simple API for database operations. Dapper is designed to be fast and efficient,
            //     which means that it doesn't have some of the features provided by EF Core (No mapping , no LINQ , no different DB Providers only
            //     raw SQL, No Change Tracker). Also we can write insert , update , delete statements but we will use EFCore because it provides a
            //     "Change Tracker".  Dapper is ideal for scenarios where performance is critical and developers want fine - grained control over
            //     the database operations. Dapper is also easy to learn and use, providing a small set of APIs covering most of the database operations.




            // Comparison Entity Framework Core VS Dapper VS ADO.NET :
            // 			
            // 
            // Performance :
            //     Dapper is often considered faster than ADO.NET in certain scenarios due to its lightweight and optimized design for data access. EFCore
            //     is slower than Dapper because it has a lot of features, which means it has more overhead. ADO.NET and Dapper generally offer better
            //     performance compared to EF Core due to their lightweight nature and reduced overhead. ADO.NET offers more control over the performance
            //     of queries as it allows developers to write SQL queries directly.
            // 
            // Ease of Use :	
            //     Regarding ease of use, EF Core is the clear winner. EF Core provides a high - level API that abstracts the database operations,
            //     making it easier for developers to work with databases. EF Core also supports LINQ, which allows developers to write queries
            //     in C# instead of SQL. Dapper is also easy to use but requires developers to write SQL queries.
            // 
            // Features :
            //     When it comes to features, EF Core is the clear winner. EF Core provides a lot of features, such as automatic schema migration,
            //     query translation, and change tracking. Dapper doesn't provide all of these features, which means that developers have to implement
            //     them themselves. ADO.NET is a low-level tool and doesn't provide as many features as EF Core.
            // 
            // Flexibility :
            //     Dapper is the most flexible tool among the three because it allows developers to write SQL queries and map the results to any
            //     class or structure. EF Core is less flexible than Dapper because it requires developers to define classes that map to database
            //     tables (or define the database tables that will be classes later) (Must work with DB first or Code first). ADO.NET is also less
            //     flexible than Dapper because it requires developers to write more code to map the results to classes or structures.
            // 		
            // Which Tool Should We Use?
            //     The choice of tool depends on the requirements of your project. If you need a lightweight and fast tool for database operations, Dapper
            //     is a good choice. If you need a tool that provides a high-level API and many features, EF Core is a good choice.If you need fine-grained
            //     control over database operations, ADO.NET is a good choice.

            /* End ******************************************************************************************************************/

            #endregion


            #region What is a Migration ? 

            /* Start *****************************************************************************************************************/

            // Migration : A versioned set of instructions (C# code + metadata) that tells EF Core how to evolve the database schema to match
            //             your current model (your entity classes and configurations). It’s EF Core’s way of managing schema changes over
            //             time — without manually writing SQL. 
            // 
            // Steps:
            // - You add migrations
            // - EF generates code showing how to move forward (apply migration) and how to move backward (rollback).
            // - You apply the code in migrations


            // What it Contains ? 
            // Each migration is a C# partial class with two methods:
            // - Up() → What happens to the database when you apply the migration.
            // - Down() → What happens to the database if you rollback. 


            // If we change the model, then we must make a new migration , Ex : 
            // - Add a property to an entity? EF notices.
            // - Add a new entity? EF notices.
            // - Change relationships? EF notices.

            // EF Core creates a special table in the database called : __EFMigrationsHistory
            // - Stores which migrations have been applied.
            // - Prevents re-applying the same migration.


            // Note : A migration can be applied forward, rolled back, or scripted for production deployment. 
            // Note : We can make migrations to have a Version history of our schema.
            // Note : One of the migration problems that it can generate inefficient SQL (ex: full table rebuilds , ...)


            // Types of Migrations Usage
            // 1 - When working with code first approach : Changes are applied through migrations (Changes in C# app => changes in database)
            //                                             We can apply migrations through the "Package Manager Console" and write commands 
            //                                             or use the Extension "EF Core Power Tool"
            //
            // 2 - When working with Database first approach : Also called reverse engineering. we are going to generate classes, this process is
            //                                                 called "Scafolding", So we scafold The DBContext Class and Scafold the Domain
            //                                                 Models We can apply scafolding through the "Package Manager Console" and write
            //                                                 commands or use the Extension "EF Core Power Tool"

            // We will work with the "Package Manager Console" and write commands , and in the last session we will use the "Package Manager
            // Console" but we must first use commands to know how internally the things work.



            // Advanced Topics : 
            // 1 - Seeding with migrations : EF Core supports HasData() inside OnModelCreating, Ex:
            //                                    modelBuilder.Entity<Product>().HasData(
            //                                        new Product { Id = 1, Name = "Laptop", Price = 1200 }
            //                                    );
            //
            //                                    So when you add a migration, EF generates INSERT SQL.

            // 2 - Generating SQL scripts : For CI/CD, you don’t want EF applying migrations automatically (The migration script can be
            //                              reviewed, approved, and run on production DB safely). So generate SQL script with command : 
            //      - dotnet ef migrations script -o migration.sql

            /* End ******************************************************************************************************************/

            #endregion


            #region Why Partial class with Migrations ? 

            /* Start *****************************************************************************************************************/

            // Any added migration will be inside a partial class , because : 

            // 1 - Separation of Concerns : 
            // EF Core actually generates two files per migration:
            //   - YYYYMMDDHHMMSS_MigrationName.cs            => contains the migration logic (Up / Down)
            //   - YYYYMMDDHHMMSS_MigrationName.Designer.cs   => contains metadata
            //                                                   Ex: BuildTargetModel method (snapshot of how your model looked at this migration)
            //                                                       Annotations
            //                                                       Target EF Core version
            //
            // Both declare the same partial class => compiler merges them into one.


            // 2 - Maintainability :
            // Your Up/Down file = human-friendly, often edited manually. But The .Designer.cs = machine-generated, usually not edited.


            // 3 - Metadata & Reverse Engineering :
            // The .Designer.cs file holds the snapshot of your model at the time of migration.
            // 
            // EF Core uses this snapshot to:
            // - Compare current model vs previous snapshot.
            // - Decide what schema changes to generate in the next migration.
            // So Without snapshots, EF wouldn’t know what changed since the last migration.


            // 4 - Extensibility :
            // Partial classes allow developers to extend migrations without touching EF-generated code (Making our own class).
            // 
            // Ex: In your own file:
            // public partial class AddOrdersTable
            // {
            //     private void LogMigrationStart()
            //     {
            //         Console.WriteLine("Running AddOrdersTable migration...");
            //     }
            // }
            // At runtime, EF will see the merged class (your code + EF generated code). This avoids “generated code vs developer edits” conflict



            // Why you don’t see .Designer.cs files anymore ?
            //
            // In Entity Framework 6 (the old .NET Framework EF), every migration had two files:
            // 
            // - YYYYMMDD_AddX.cs → the logic (Up/Down).
            // - YYYYMMDD_AddX.Designer.cs → metadata and model snapshot.
            // 
            // In Entity Framework Core (>= EF Core 2.0), Microsoft simplified this:
            // 
            // - Each migration now has just ONE .cs file (with Up/Down).
            // - The model snapshot is centralized into a single file called <DbContextName>ModelSnapshot.cs
            //   Example: CompanyDbContextModelSnapshot.cs
            // 
            // So you will not find .Designer.cs files in EF Core projects.
            // 
            // What EF Core does instead ?
            // Instead of keeping a per-migration snapshot (.Designer.cs), EF Core:
            // - Stores a global model snapshot in CompanyDbContextModelSnapshot.cs
            // - Every time you add a migration:
            //      - EF Core compares your current model => with the last ModelSnapshot.
            //      - Generates a new migration based on the difference.
            //      - Updates the ModelSnapshot file to reflect the new state.
            // 
            // So:
            // 
            // - Migration file (.cs) = schema change instructions (Up/Down).
            // - ModelSnapshot.cs = “latest full model definition”.
            // 
            // Why This Change?
            // - No extra .Designer.cs files per migration.
            // - Single source of truth — one snapshot file keeps the canonical latest model.
            // - Simpler diffs — EF just compares ModelSnapshot with current model classes to know what’s changed.


            // Note (Will be discussed later) : partial classes are used when DbContext scaffolding (when reverse engineering from existing DB).

            /* End ******************************************************************************************************************/

            #endregion


            #region First Of All

            /* Start *****************************************************************************************************************/

            // First Example , Will be code first and we will start with "Automatic Schema Migration" (Mapping)

            // First of all , we make a folder called "Data" in out project , that contains 3 things :
            // 1 - DBContext Class
            // 2 - Domain Models (Entities or Poco classes or models)
            // 3 - Migrations ==> Done by the EFCore but we must write the commands or use the "Package Manager Console"

            // inside the "Data" Folder , we are going to make a folder called "Models" or "Domain Models" , which will contain 
            // the classes (Models) that represent data inside tables or views in the database. This folder also can be named as "Poco classes"   
            // which means : Plain Old C# Object , a class that has no methods , each property is a column in our database table

            // EFCore supports 4 ways for Mapping Classes (DBContext , Domain Models) to Database (Tables , Views)
            // 1 - By Convension : because the EFCore is an intelligent ORM , it has default behaviour "By Convension"
            //                     ex: any property of type string is mapped in the DB to a column of type "nvarchar(max)"
            //                     ex: public numeric property "id" or "ClassNameId" is the primary key in the DB table + identity (1,1)
            //
            // 2 - Data Annotation 
            // 
            // 3 - Fluent APIs 
            // 
            // 4 - Configuration Classes

            // We don't use a specific way, we use the way that helps us to reach our wanted result ... 

            // Important Note : if the datatype is nullable , then it's not required [optional] in the table of the database , and the 
            //                  non-nullable datatypes regardless it's a reference type or value type , DON'T allow Null ....
            //                  Before .net 6 , [ public string Name { get; set; } ] is mapped in the database to Optional because it's a
            //                  reference type that by default can hold null , but later after .net 6 it's a must to be nullable string as
            //                  this [public string? Name { get; set; }]

            /* End ******************************************************************************************************************/

            #endregion


            #region DBContext Class

            /* Start *****************************************************************************************************************/

            // // This class (as a naming convention) Should be named with DatabaseNameDbContext ... 
            // // This class is added to the Data Folder we created before 
            // 
            // // We want some properties and methods to be in this class , So we inherit them from class "DbContext" , this class is found in 
            // // a Package called "Microsoft.EntityFrameworkCore.[DatabaseProvider]" , database provider ex: SqlServer , MySql , ... 
            // 
            // // So first we must install this package through one of the two ways : 
            // // 1 - Using the Package Manager Console and writing commands 
            // //        - to show this window , View - Other Windows - Package Manager Console
            // //        - Note : use Tab button for auto completing , arrow up and down for the previous and next commands written 
            // //        - to download a package : Install-Package "Microsoft.EntityFrameworkCore.SqlServer"
            // //        - to download a package with a specific version : Install-Package "Microsoft.EntityFrameworkCore.SqlServer" -V "8.0.10"
            // //
            // // 2 - Using the NuGet Package Manager 
            // 
            // // Note : The packages are installed in one project only .. so if there is more than one project in the solution then we must install the
            // //        wanted packages inside each project (OR make project references "discussed later .. ")
            // 
            // 
            // // so now we can start a connection with the database , but how ?
            // // 1 - using "try finally" block 
            // // 2 - using "using" block
            // // 3 - using the syntax sugar for "using" block
            // 
            // // 1 - 
            // CompanyDbContext context1= new CompanyDbContext();         // start the connection
            // try
            // {
            // 	// Code
            // }
            // finally
            // {
            // 	context1.Dispose();                                     // close the connection
            // }
            // 
            // 
            // // 2 - 
            // using(CompanyDbContext context2 = new CompanyDbContext())
            // {
            // 	// code and after finishing the code then the connection will be closed automatically
            // }
            // 
            // 
            // // 3 - 
            // using CompanyDbContext context = new CompanyDbContext();
            // // Note : any code that is related to the DbContext will be virtually put in the brackets of the using block here ... 
            // 
            // 
            // 
            // 
            // 
            // // The first and most important function inherited from the DbContext class ==> OnConfiguring , why ?
            // // because we can configure the connection string here in this function , How ?
            // // first: the empty parameterless constructor " new CompanyDbContext(); " chains on the empty parameterless constructor of class 
            // // DbContext , the empty parameterless constructor of DbContext chains on another constructor in the same class that takes a
            // // object of type "DbContextOptions<DbContext>" (empty object and we must build it through the OnConfiguring function), the
            // // constuctor ==> DbContext() : this(new DbContextOptions<DbContext>()){ } calls a method "OnConfiguring" (virtual method) ,
            // // that is by default empty and does nothing .. so we must override this function and provide the connection string inside it  
            // 
            // 
            // // Note : What if we want to use the object of CompanyDbContext in X places ? make X numbers of objects ????
            // //        in this case it's better to use the Dependency Injection and define the lifetime of the object we
            // //        want ... (Discussed later ...) 
            // 
            // 
            // // Linq to EFCore : 
            // var employees = context.Employees.Where(e => e.Salary >= 1000);
            // // This is of type "IQueryable" , NOT IEnumerable .. The difference discussed later 

            /* End ******************************************************************************************************************/

            #endregion


            #region Migrations

            /* Start *****************************************************************************************************************/

            // Now we want to apply all the changes in the code to the database , means that we want to make the classes (property of
            // type DbSet) as tables in the database , this is done by the Migrations 

            // When building the classes in code first approach , we make a migration .. 
            // if we want to make a change in the current code then we must make another migration ..
            // until we finish the changes then we will apply migrations that are not applied 


            // How to add a migration ? 

            // First we must install a package called : Microsoft.EntityFrameworkCore.Tools
            // we can install this package through the Nuget Packages , or through the command in the package manager console : 
            // command ==> Install-Package "Microsoft.EntityFrameworkCore.Tools"
            // this package is used to generate migrations or scafold the DbContext and the domain models (in database first approach)
            // then :
            // in the package manager console : Add-Migration "InitialCreate" -Context "CompanyDbContext" -Output "Data/Migrations"
            // Note : the output folder is by default in the project , then creating a folder named "Migrations" .. but in our case we wanted to
            //        change the path of the folder to be inside the Data Folder . Also we can specify the database that will be applied on it 
            //        as our example .. but it's not nessisary here because we have only one database ! 

            // Add-Migration "InitialCreate" -Output "Data/Migrations"

            // Then .. with the first migration , the folder we specified it's location will contain 2 files :
            // 1 - file with the time stamp and the name of the migration "InitialCreate" , which is a partial class
            //     this file contains two methods : Up and Down 
            //     1 - Up function is applied when we want to apply the changes of the migration 
            //     2 - Down functions is applied when we want to roleback the changes of the migration if we applied it 
            //  
            // 
            // 2 - file called the "CompanyDbContextModelSnapshot" snapshot , that contains a snapshot of the code at last migration (It's updated
            //     based on the latest migration) .. this snapshot is used later when we want to make another migration so we see the differences
            //     between the current code and the snapshot stored .. so it's used to detect the changes done.


            // Important note : the up method will not contain create database method because before applying any migration a function called 
            //                  "DatabaseEnsureCreated" is executed and if there was not a database with the name then create it first
            //                  --- Creating the database is done out any migration .. That's why we cannot delete the database by rolling back the
            //                      migration .. there is a command called "Drop-Database" used to drop the database 


            // Note : WE DON'T DELETE THE MIGRATION FROM THE MIGRATION FOLDER DIRECTLY !!
            // Before the applying of the migration we can remove it by the command "Remove-Migration" , this will do 2 things :
            //     1 - remove the last migration generated and not applied from the Migrations Folder 
            //     2 - update the code of the snapshot to the previous migration 
            // if the migration is applied then we must Revert the migration and then remove it (discussed next region)


            // To apply migration : command "Update-Database" -Context "CompanyDbContext" (can write only "Update-Database" because we have only one context)

            // What happens when the command "Update-Database" is executed through the package manager console ?
            // 1 - using CompanyDbContext dbContext = new CompanyDbContext();  ==> Creates an object from the DbContext class
            // 2 - dbContext.Database.Migrate(); ===> Create database if it doesn't exist then applies any pending migrations to the database 

            // So if we write the command then we don't have to write these 2 lines of code , but in production phase we don't have the package manager
            // console to write the commands so we must then write the previous 2 lines and run the project..

            // To see the queries that are applied to the database , open the SQL Server Profiler

            /* End ******************************************************************************************************************/

            #endregion


            #region Second Migration

            /* Start *****************************************************************************************************************/

            // what will happen if we changed the property name "Name" to "EmpName" ?
            // Now the application is not migrated with the database , because the property is "EmpName" and the database column name is "Name"
            // then we must make another migration and name it with a meaningfull name ... 

            // command : Add-Migration "RenameNameColumnInEmployee"

            // Now the CLR knows the differences between the snapshot (last migration code) and the current code and make the migration class with
            // the Up and Down methods based on the changes detected ...


            // what will happen if we write the command : Remove-Migration ?
            // Error ! the last migration is applied to the database , we must Revert it (Roll Back it) then remove it 

            // How to revert the migration ? 
            // Update-Database -Migration "Previous_Migration" , in our case , command => Update-Database -Migration "InitialCreate"
            // now the Down function of the second migration that we want to revert "RenameNameColumnInEmployee" will be executed , and if there 
            // is next migrations also the down method will be executed .. means if we have migration 1 and 2 and 3 and 4 and 5 , if we want to revert
            // the last three migrations and be on migration number 2 (in the database) then ==> Update-Database -Migration "2" and the down methods 
            // for migrations 3 and 4 and 5 will be reverted and then we can Remove them from the migrations folder (don't forget to change the code to
            // it's state in migration number 2 to avoid problems when retrieving data from database and dealing with it in the program )


            // How to revert the Fifth migration (last one) ? 
            // command => Update-Database - Migration "4"


            // How to revert the first migration (or revert all the migrations)? 
            // command => Update-Database 0 
            // This Doesn't delete the database , but the database now has 0 Objects !! 
            // Note : the migrations in the migration folder are there .. to remove them then use the Remove-Migration command , one time for each
            //        migration that we want to delete .


            // How to drop the database ?
            // command => Drop-Database
            // 

            // So what if we want to revert migration number 2 ONLY ???
            // Make a new migration with the changes you want to do , ex : if migration number 2 we added a new domain model and this model is added 
            // as a table in the database , so to revert this migration only then delete this domain model and delete the DbSet property of it ...
            // then add a new migration .. this is better than reverting migration 2 and 3 and 4 and 5 by command update-database -Migration "1" ...


            // After reverting a migration , if we don't want it then removing it (deleting it) to avoid any problems or applying them by accident 

            /* End ******************************************************************************************************************/

            #endregion


            #region Data Annotations 

            /* Start *****************************************************************************************************************/

            // EF Core supports 4 ways for mapping classes to database ==>
            // First way that we discussed at all the previous regions : By Convention (the default of Entity Framework)
            // The second way : Data Annotations

            // See Class "EmployeeDataAnnotation" for more info ....

            // Data Annotations: Attributes (decorators) in C# that you put on your model classes and properties that are used for validation,
            //                   schema mapping, and UI metadata. EF Core reads these annotations (via reflection) and uses them to configure
            //                   the model, alongside conventions and Fluent API. In short: Data Annotations = “configuration by attributes”.
            // 
            //
            // These attributes use the behaviour of the "Decorator Design Pattern" (Not implement the design pattern), for example :
            // if we have an object and we want to provide it a new function .. then it's better to give it a new behaviour rather than making a 
            // new type (class) of objects with the new behaviour 
            // Rule: Fluent API > Data Annotations > Conventions.
            //
            // The 3 main categories of Data Annotations :
            //
            // 1 - Validation Attributes
            // 2 - Schema / Mapping Attributes (EF Core specific)
            // 3 - UI & Display Attributes


            // 1 - Validation Attributes : Used in ASP.NET Core MVC / Razor Pages to validate input automatically.
            // 
            // EF Core doesn’t enforce them in the database, but they are used during model validation.
            // 
            // Attribute	                                        Usage	                                  
            // [Required]	                  Marks property as non-nullable (also creates NOT NULL column in EF Core)
            // [StringLength(100)]	          Restricts length (max in DB + UI validation)
            // [MaxLength(100)]	              Sets only max length in DB
            // [MinLength(5)]	              Validation only, NOT DB
            // [Range(1,100)]	              Validation only, NOT DB
            // [RegularExpression("regex")]	  Enforces regex validation (ex: [RegularExpression(@"^[0-9]+$")] public string Phone { get; set; } )
            // [Compare("OtherProperty")]	  Used for validation in forms (ex: [Compare("Password")] public string ConfirmPassword { get; set; })


            // 2 - Schema/Mapping Attributes (EF Core specific) : These affect how EF Core maps classes to database schema.
            // 
            // Attribute	                                            Usage	Example
            // [Key]	                                                Marks property as Primary Key	
            // [DatabaseGenerated(DatabaseGeneratedOption.XXXXXXXX)]	Tells EFCore how a column’s value is generated in the database.
            //   ex: [DatabaseGenerated(DatabaseGeneratedOption.Identity)]  On Insert only. Most use with Primary Keys ex: identity(1,1) in SQL 
            //   ex: [DatabaseGenerated(DatabaseGeneratedOption.Computed)]  On insert or update. The database computes the value ex: GetDate()
            //   ex: [DatabaseGenerated(DatabaseGeneratedOption.None)]      EF Core MUST provide the value, not the database.
            // [ForeignKey("NavPropertyName")]    	                    Explicitly defines foreign key
            // [InverseProperty("OtherNavProp")]	                    Disambiguates multiple relationships between same entities
            // [Table("Users")]	                                        Maps class to table name (written above the class)
            // [Column("FullName", TypeName = "varchar(200)")]	        Maps property to column with name/type
            // [NotMapped]	                                            Excludes property from EF mapping (used with derived attributes)
            // [Owned]	                                                Marks a class as an Owned Entity Type (also known as Value Object in DDD)
            //                                                          So doesn’t have its own table, its fields are stored in the owner’s table
            //                                                          ex: class User {int Id; string Name; Address UserAddress}
            //                                                              [Owned] class Address {string Street; string City}
            //                                                              Note : will be owned for every type .. but if we want it to be owned
            //                                                              for some types then make it through Fluent APIs.


            // 3 - UI & Display Attributes : These don’t affect EF Core database mapping, but are used in ASP.NET Core MVC / Razor views to tell 
            //                               the UI (views, forms, scaffolding) how to display a property
            // 
            // Attributes Examples:
            // 
            // [Display(Name = "Full Name")]
            // public string Name { get; set; }
            // - DB column still = Name
            // - But in UI forms / labels → "Full Name" instead of "Name".
            //
            //
            // [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
            // public DateTime BirthDate { get; set; }
            // - DB column = datetime
            // - UI shows 1998-03-15 instead of 3/15/1998 12:00:00 AM.   //
            //
            //
            // [ScaffoldColumn(false)]
            // public string SecretCode { get; set; }
            // - DB column exists.
            // - But scaffolding tools don’t generate a field for it in UI forms (search : Scaffold EFCore models in views)
            //  
            //
            // [DataType(DataType.Password)]
            // public string Password { get; set; }
            // - DB column = Password (string)
            // - UI form field = password input (<input type="password" />)


            // Data Annotations vs Fluent API :
            //     - Data Annotations: simple, inline, quick for common configurations.
            //     - Fluent API (OnModelCreating or Configuration classes) : powerful, supports everything, overrides Data Annotations.


            // Important :
            // - We can Combining Attributes , put them above each other and they will work !
            // - Data Annotations will not work with console applications .. but will work with Asp.Net Core apps or web apps only.
            // - Not all EF Core configurations are possible with Data Annotations. (Ex: Composite keys => must be defined in Fluent API)
            // - application validations can also be used with the frontend .. by using some plugins that will help us to use the validations
            //   with the frontend also .. but using another validations in the frontend code will minimize the number of bad requests 
            //   that don't satisfy the requirements !! 

            /* End ******************************************************************************************************************/

            #endregion



            #region Chat GPT (EFCore)

            /* Start *****************************************************************************************************************/

            // Entity Framework Core (EF Core): Microsoft’s modern Object-Relational Mapper (ORM) for .NET. It sits between your C# domain
            //                                  models (classes) and the database (SQL Server, PostgreSQL, SQLite, etc.)
            // 
            // - You write LINQ in C# => EF Core turns it into optimized SQL => sends it to DB.
            // - DB returns rows => EF Core materializes them into C# objects.
            // - You modify objects => EF Core tracks changes and generates SQL INSERT, UPDATE, DELETE for these objects.


            // 1 - DbContext
            // Central class => represents a session with the database.
            // 
            // Responsible for:
            // - Change tracking (knows which entities are new/modified/deleted).
            // - LINQ query translation → SQL generation.
            // - Database connection management.
            // - SaveChanges() → persists changes atomically.



            // 2 - Entity classes (Models)
            // Your plain C# classes (POCOs) => EF Core maps them to tables or views.
            // EF Core maps:
            // - Class => Table 
            // - Property => Column
            // - Navigation properties => Foreign keys / relationships


            // 3 - Change Tracker
            // EF Core keeps an in-memory graph of all loaded entities.
            // 
            // When you call SaveChanges(), it checks entity states(Added , Modified , Deleted , Unchanged , Detached***):
            // - Added => INSERT
            // - Modified => UPDATE
            // - Deleted => DELETE
            // - Unchanged => no SQL generated


            // 4 - Providers
            // EF Core is database-agnostic.
            // Core is generic => specific providers implement dialects:
            // - Microsoft.EntityFrameworkCore.SqlServer
            // - Npgsql.EntityFrameworkCore.PostgreSQL
            // - Pomelo.EntityFrameworkCore.MySql
            // - Sqlite, CosmosDB, Oracle, etc.
            // 
            // Note : You swap DBs with minimal code changes (Not tightly coupled with a database provider), (except provider-specific features).


            // Advantages
            // ✅ Strongly typed queries (compile-time safety).
            // ✅ Productivity: less SQL boilerplate.
            // ✅ Cross-database portability.
            // ✅ Built-in migrations, seeding, lazy/eager loading.
            // ✅ Extensible with interceptors, logging, custom conventions.
            // 
            // Limitations
            // ❌ Performance overhead vs hand-written SQL (but can be tuned).
            // ❌ Not all LINQ translates → some queries fallback to client eval (dangerous).
            // ❌ Steeper learning curve for advanced scenarios (bulk ops, concurrency).
            // ❌ Schema drift issues if migrations mismanaged.
            // 

            // Summary :
            // - EF Core is a lightweight, extensible ORM for .NET that lets you work with databases using C# objects and LINQ, hiding most
            //   SQL, but still giving you escape hatches when needed.

            /* End ******************************************************************************************************************/

            #endregion

            #region Chat GPT (DbContext)

            /* Start *****************************************************************************************************************/

            // DbContext : the primary class you derive from in your project.
            // 
            // It represents:
            // 
            // - A session with the database (like a lightweight unit of work).
            // - An API surface for querying, saving, transactions.
            // - A bridge between your domain models and EF Core’s change tracker + database provider.
            // 

            // In your project you create a class inheriting from DbContext (Your Custom Context) :

            // 
            // public class AppDbContext : DbContext
            // {
            //     // Constructor – options injected via DI
            //     public AppDbContext(DbContextOptions<AppDbContext> options)
            //         : base(options) { }
            // 
            //     // DbSets = Tables 
            //     public DbSet<Product> Products { get; set; }
            //     public DbSet<Order> Orders { get; set; }
            // 
            //     // Fluent API configuration
            //     protected override void OnModelCreating(ModelBuilder modelBuilder)
            //     {
            //         base.OnModelCreating(modelBuilder);
            // 
            //         // Example: configure Product entity
            //         modelBuilder.Entity<Product>(entity =>
            //         {
            //             entity.HasKey(p => p.Id);
            //             entity.Property(p => p.Name).IsRequired().HasMaxLength(100);
            //             entity.Property(p => p.Price).HasColumnType("decimal(18,2)");
            //         });
            // 
            //         // Apply configurations automatically
            //         modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
            //     }
            // }


            // Main Components of DbContext : 
            // 1 - DbSet<TEntity> : Represents a table (or view) in the database.
            // 
            // - Exposes LINQ operations (Where, Include, FirstOrDefaultAsync) ex: AppContext.Products.Where(x=>x.salary>100)
            // - Also handles Add / Update / Remove. ex: AppContext.Products.Add(new Product { Name = "Keyboard", Price = 30 })


            // 2 - Configuration : 
            // Context is configured in Program.cs / Startup.cs:
            // 
            // services.AddDbContext<AppDbContext>(options =>
            //     options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            //
            // Options include:
            // - Provider (UseSqlServer, UseNpgsql, UseSqlite).
            // - Lazy loading proxies.
            // - Logging (LogTo(Console.WriteLine)).
            // - Query tracking behavior defaults.

            // 3 - OnModelCreating (Fluent API)
            // Used for advanced configurations:
            // 
            // - Table/column mapping.
            // - Relationships (1–many, many–many).
            // - Shadow properties.
            // - Seed data.
            // 
            // Note : Fluent APIs are more powerful than Data Annotations.

            // 4 - Lifecycle & Scope : 
            // DbContext is NOT thread-safe.
            // 
            // Typical lifetimes:
            // - Scoped in ASP.NET Core (one context per HTTP request).
            // - Transient for short-lived operations.
            // - Pooled (AddDbContextPool) for high-performance web APIs.
            // 
            // Example:
            // 
            // services.AddDbContextPool<AppDbContext>(options =>
            //     options.UseSqlServer("connectionString"));
            // Pooling reuses contexts but requires careful use (no long-lived state inside).

            // 5 - Change Tracking :
            // Context tracks loaded entities, When you modify entities .. SaveChanges() generates the right SQL.
            // 
            // You can control tracking behavior globally or per query:
            // 
            // options.UseQueryTrackingBehavior (QueryTrackingBehavior.NoTracking);
            // 
            // var product = await context.Products.AsNoTracking().FirstAsync();

            // 6 - Transactions :
            // Each SaveChanges() call runs inside a transaction.
            // 
            // For multiple operations:
            // 
            // using var transaction = await context.Database.BeginTransactionAsync();
            // 
            // try
            // {
            //     context.Products.Add(new Product { Name = "Phone", Price = 500 });
            //     await context.SaveChangesAsync();
            // 
            //     context.Orders.Add(new Order { ProductId = 1, Quantity = 2 });
            //     await context.SaveChangesAsync();
            // 
            //     await transaction.CommitAsync();
            // }
            // catch
            // {
            //     await transaction.RollbackAsync();
            // }

            // 7. Intercepting / Extending :
            // You can plug into DbContext:
            // 
            // SaveChangesInterceptor (audit logs).
            // 
            // DbCommandInterceptor (modify SQL before execution).
            // 
            // IDbContextFactory (create contexts on demand for background jobs).

            // Best Practices for Your Project
            // 
            // Use DI properly
            // Always inject via constructor, don’t new it manually.
            // Avoid long-lived contexts
            // Dispose at end of request. Long-lived contexts = memory leaks + stale tracking.
            // Prefer Fluent API
            // For complex configs, prefer OnModelCreating or separate IEntityTypeConfiguration<TEntity> classes (Configuration Classes).
            // Monitor generated SQL

            // Enable logging:
            // 
            // options.LogTo(Console.WriteLine, LogLevel.Information);


            // ✅ Summary
            // Your custom DbContext =
            // - Unit of Work => groups operations into a single transaction.
            // - Repository => DbSet<TEntity> gives CRUD + LINQ query APIs.
            // - Configuration hub => defines model mappings & behaviors.

            /* End ******************************************************************************************************************/


            #endregion
        }
    }
}