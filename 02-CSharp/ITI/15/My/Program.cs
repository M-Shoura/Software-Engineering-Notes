using System.Diagnostics;
using System.Numerics;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace My
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Entity Framework : Microsoft's ORM (object relational mapper)

            // We have 2 ends
            //  - Storage model (Database => Tables , Stored Procedures , Views , Functions)
            //  - Conceptual model (Designing of the application and classes and business objects , inheritance , ... )

            // with EFCore , if we have one end we can generate the other one ! 

            // we query the models (classes) in the application using L2EF (Linq to Entity Framework)

            // Design Time : 
            // - EF Design Tools 
            //    - ex: EFCore power tools , and other things .. 

            // versions : 
            // before EF we had the first mapper for .Net => L2SQL
            // EF 6.4.X => .Net Framework (much difference than today's EFCore)
            // EFCore   => .NET Core V10 , target in our course. "Installed from Nuget.org"

            // Model First    => legacy and very old
            // DataBase First => I have the DB and I will GENERATE the model (C# code => Classes , Enums) from DB
            // Code ONLY      => I have the classes and I will GENERATE the DB

            // The most updated EFCore documents is Microsoft's Documentation , books are not released every year with EF


            // How to map a class to a table ? 
            // Each Table to a class (TPC => Table Per Class / TPT => Table Per Type)
            // - incase of inheritance , map the hierarchy in one class (TPH => Table Per Hierarchy)
            // - incase of inheritance and the parent is an abstract class , map only concrete classes (TPCC => Table Per Concrete Class)
            // - EFCore takes the most optimal descision when mapping (and we can change the way of mapping it used if we want)

            // Note : TPH is the Default in EFCore


            // ---------------------------------------------------------------------


            // Ex1 : 
            // table "Employees" => ID , Name , Address , Salary , HireDate 
            // - in case of using TPT or TPC => One Class 


            // Ex2:
            // class "Employee" => ID , Name , Address
            // class "PartTimeEmployees" => ID , HrRate , MaxHrsPerWeek, EmpID
            // class "FullTimeEmployees" => ID , HireDate , Salary , EmpID
            // - in case of using TPT or TPC => Three Tables (as they are in the Classes)
            // - in case of using TPH  => One Table =>
            //        - "Employees" => ID , Name , Address, HireDate , Salary , HourRate , MaxHrsPerWeek,ObjectType
            // - in case of using TPCC => Two tables , one for each concrete class (as the base type Employee will be abstract class)
            //        - "FullTimeEmployees" => ID , Name , Address , HireDate , Salary
            //        - "PartTimeEmployees" => ID , Name , Address , HourRate , MaxHrsPerWeek


            // Notes : 
            //  - in TPT or TPC , this is following to normalization rules but makes an overhead because of the joining when selecting
            //    or updating or deleting from PartTimeEmployees or FullTimeEmployees tables. And we know that storage is cheaper than 
            //    processing power , so this is not a good option for power optimization.
            //  - in TPH , this is better because when selecting or updating or deleting from PartTimeEmployees or FullTimeEmployees tables
            //    actually we are working with only one table but we have many nulls and this is not normalized to the third normal form,
            //    how we will know that this is a PartTimeEmployees or FullTimeEmployee ? by one of these two ways :
            //       1 - seeing what is null in the record so we will know the employee type (2 out of 4 columns must have data)
            //       2 - having a new column "discriminator" to know the object type
            //  - in TPCC , this is not a valid when having an abstract class in the hierarchy , 


            // ---------------------------------

            // What about mapping relationships (PK-FK relationship) :
            // Ex: 1-m relationship (employee and department) 
            // tables in DB : Uni-directional Relationship (DeptId is in the employee but the empId is not in department)  
            //   - table "Employees"   => EmpID , FullName , Salary , DeptID
            //   - table "Departments" => DeptID , Name , CreationDate
            // TWO Classes : could be Bi-directional Relationship if we want
            //    class Employee
            //    { 
            //         public int EmpID {get;set;}
            //         public string FullName {get;set;} 
            //         publis double Salary {get;set;}
            //         public int DeptID {get;set;}                // can be deleted if we want
            //         public Department Department {get;set;}     // Navigational Property
            //    }
            //    class Department
            //    { 
            //         public int DeptID {get;set;}
            //         public string Name {get;set;}
            //         public Datetime CreationDate {get;set;}
            //         public HashSet<Employee> Employees {get;set;}   // Navigational Property
            //    }


            // when using navigational properties this is better in the flexability and designing with OOP , as this is association
            // or aggregation. So now we can navigate from employees to their departments , and also from the department to the employees 
            // in that department 

            // The representation of the navigational properties in the database is only the FK in employee table, other cases of 1-1 , 
            // m-m , or having attributes on relationship , all these will be discussed later

            // next session : Lazy Loading (EF works with this) , Eager Loading , explicit loading ".include()" ... better to know the
            //                wanted data when writing the query , to minimize the numbers of querying the database.


            // Now where are Stored Procedures ? 
            // they were supported heavily in .Net framework efcore v6.4 
            // and new versions of EFCore also support them and also better with "EF Power Tools" (discussed later)
            // other ORMs may not support SPs



            // --------------------------------------------------------------------------------------------------



            // Runtime 
            // - EF Runtime : L2EF now is optimized SQL Statements , executed and then return raw results , then the EF will map these 
            //                results to business objects 

            // EFCore also has the state tracking , shows if the version OFFLINE in the memory has been changed or not and what it's state

            // Here we have a class usually called "DbContext" that has the connection string , and also specify what tables the app will 
            // deal with and use .. so this is the class that we use to interact with the database "it's the same as Data Adaptor in ADO" 


            // EF Query Life Cycle : 
            // - Query Initiation The Service/ Controller initiates a query to fetch players using LINQ.
            // - DbContext Processing DbContext checks if the query is cached or if tracking is needed.If not cached, it translates LINQ
            //   to SQL.The query is compiled if necessary.
            // - Database Query Execution DbContext sends the SQL query to the Database.The Database executes the query and returns results.
            // - Hydration & Change Tracking DbContext hydrates the raw query results into Player Entity objects.If tracking is enabled,
            //   the DbContext attaches the entities to theChange Tracker.
            // - Returning Results The DbContext sends the hydrated Player collection back to the Service / Controller.
            // - Resource Cleanup The Service processes the data.The DbContext is disposed to release resources

            // EFCore best practices (discussed later) : 
            // - when we will not change the data (ex: shown in a grid only without changing) , then it's better to stop the state tracker 
            //   or the change tracker in this case. "AsNoTracking()"
            // - search in the local cache first , before going to the database again. (may be not updated !!!) (.Find( PK ))


            // ---------------------------------------------------------

            // starting with "Code Only" approach : 
            // - We MUST have a class "DbContext" , and the entities that will be mapped to tables in DB
            // - The name of the class should be BusinessNameDbContext , ex: SchoolDbContext , this class must inherit from the 
            //   "DbContext" class , and this class is in the "Microsoft.EntityFrameworkCore.DatabaseProvider" library or dll or package
            //   from Nuget.org , and because we will work with sqlServer then it will be "Microsoft.EntityFrameworkCore.SqlServer" , we 
            //   can install it from the Nuget or write the command in the Package manager console using this command : 
            //       install-package Microsoft.EntityFrameworkCore.SqlServer
            // - this class must contain the connection string , this connection string will be specified in the overriden function 
            //   "OnConfiguring" (see the SchoolDbContext class file here in this project)
            // - Take care with class naming to avoid naming problems ! 
            //      - Table      : plural 
            //      - Collection : plural 
            //      - Class      : singular
            // after making the classes , and confiruging the connection string , also in the DbContext class we will add "DbSets" for 
            // the classes that we want to make for it tables in the database. 
            // ex : DbSet<Teacher> Teachers {get; set;}

            // Note : DbSet can represent a view in the database , not only a table 


            // -------------------------------------------------------------------------------------------------------------------------

            // Part 2 : 

            // in any case , code first or database first , the developer must make the "DbContext Class"

            // mapping ways : 
            // 1 - Default action (EF conventions) : some things cannot be done with this.
            //       - Teacher class name => Teachers table name
            //       - ID/ClassNameID => PK + Identity (we shouldn't give value to it)
            //       - cannot specify the length of the string , it's always nvarchar(max) in DB
            //       - PK - FK relationship => Bi-directional nav property works with lazy loading 
            //       - cannot make "field in class but not in table"
            //       - nullable data types to make it as optional / allows Null 
            //       - keyword required or without nullable datatypes to make it not null , ex: public required string name {get; set;}
            //         ex: see what will happen if string vs required string , is there any diff ? 
            // 
            // 2 - Data Annotations : using attributes , also somethings cannot be done with this 
            //       - MUST HAVE THE SOURCE CODE OF THE CLASS , hainv the C# code not the IL. 
            //
            // 3 - Fluent APIs : can do everything with fluent apis , and it's not a must to have the C# code like data annotations
            //       - Written in the DbContext class in the OnModelCreating Function
            //      
            // 4 - Configuration Classes : fluent apis in an organized way
            //       - bad to write many fluent apis in the OnModelCreating Function , organize them in Configuration Classes , 
            //         each class has some specific configurations and fluent apis for a specific type.


            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///




            // To tell the database that this class will be a table in DB (in case code first) ,
            //
            // //////////////////////////////////////////////// or this table will be a class in the 
            // //////////////////////////////////////////////// application (in case DB first) , then we must put it as a DbSet in the
            // DbContext class. Also this DbSet can be "virtual"
            // as we can inherit from this class later and make what we want 


            // now to deal with the database , we must create an object from the DbContext class , and because this class encapsulates
            // unmanaged resource DbConnection , then after we finish using the database we must delete this connection manually because
            // it's not deleted as the normal C# code by the garbage collector.


            // this is done by 3 ways : 

            // 1 - 
            // SchoolDbContext context = new SchoolDbContext();
            // ....
            // context.Dispose();

            // 1.1 - (better to use try finally with it) 
            //
            // SchoolDbContext context = new SchoolDbContext();
            // try
            // {
            //      ....
            // }
            // finally 
            // {
            //      context.Dispose();
            // }

            // 2 - generate try finally and call dispose in the finally (syntax sugar)
            //
            // using (SchoolDbContext context = new SchoolDbContext()){ ... }

            // 3 - generate try finally and call dispose in the finally (syntax sugar)
            // using SchoolDbContext context = new SchoolDbContext();

            // Note : "using" keyword is used in two places , when using or importing a namespace , and the other is when using any 
            //        object that implements the IDisposable interface , so it will be try finally and the function of the interface 
            //        IDisposable that is called "Dispose" will be called in the finally 


            // using SchoolDbContext context = new SchoolDbContext();
            // SchoolDbContext.Database.EnsureCreated();            // if DB not created then create it (connection string)
            // SchoolDbContext.Teachers.Add(new Teacher(){...});    // add to the local copy
            // OR
            // SchoolDbContext.Add(new Teacher(){...});             // add to the local copy , will know automatically the datatype DbSet
            // int res = context.SaveChanges();                     // commit changes to the database and return num of rows affected

            // when doing the previous code , when running the application , each time the database will be dropped and re-created , 
            // so this will make us loose the data ! so we will use "Migrations" so we will keep tracking what changes have been done 
            // and update the database with these changes only.

            // self study : who exactly populates the Id when it's identity (auto increment) in case of EFCore ? and when ? when adding 
            //              to the local copy or when done to the database or the change tracker ? 

            // var result = SchoolDbContext.Teachers.Where(t=>t.salary<50_000).ToList();
            // for(.....){ result[i].salary = 100_000; }    // update LOCALLY 
            // SchoolDbContext.SaveChanges();               // commit changes to the database


            // Delete : deleted from the local copy
            // SchoolDbContext.Teachers.Remove(obj);                      
            // OR                                                         
            // SchoolDbContext.Remove(obj);                               
            // OR
            // SchoolDbContext.Entry(obj).State = EntityState.Deleted;    
            // Note : will be still in the DB until SaveChanges();


            // To know the state of the object , must use the "DbContext.Entry(obj).State" , cannot get it directly using the obj , and 
            // obj must be an object not a collection here 


            // Data Annotations : 

            // [Key] => PK + Identity
            // [Table("TableNameInDB")] => to give the table name instead of the name of the class 
            // [Required] => this field is required (NOT NULL)
            // [StringLength(40)] => specify the max length of the string 
            // [NotMapped] => this field will not be in the database , same as a calculated field or derived attribute in DB

            // ex: 
            // [NotMapped]
            // public DataTime TimeStamp { get; } = DateTime.Now;
            // 
            // public virtual ICollection <Teacher> Teachers {get; set;} = new HashSet<Teacher>();

            // why virtual ? OLD => to be Lazy loading by default 
            //               NOW => to apply the OOP rules if we want to override it (NOT a must)


            // Now if we try to add the new table to DB (putting a new DbSet in the DbContext class) , and trying to add objects to this
            // DbSet in the main function , we will have an exception because no table with this name , that's because if we want to 
            // add the new table to the database so we must drop the database and re-create it again ! this is the problem when not 
            // working with "Migrations"  !!! 

            // SchoolDbContext.Database.EnsureDeleted();  // delete the old database not containing the new added table
            // SchoolDbContext.Database.EnsureCreated();  // create the database with the new table ! 
            // continue working ... 

        }
    }
}
