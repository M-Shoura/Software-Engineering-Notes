using EFCore___Session_3.Data;
using EFCore___Session_3.Data.DataSeed;
using EFCore___Session_3.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace EFCore___Session_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// Reading Data with File class 
			// Using JsonSerializer Class
			// Cross Apply (inner join) and Outer Apply (outer join) in SQL 

			/* End ******************************************************************************************************************/

			#endregion


			#region Data Seeding

			/* Start *****************************************************************************************************************/

			// We need Data Seeding to test our code , if it works properly as we want or not .. 
			// We seed some dummy data inside the database to test it

			// in our case we will use 2 JSON files , "Department" and "Employees" that contains some data we will use in the Session ...

			using CompanyDbContext dbContext = new CompanyDbContext();
			CompanyDbContextSeed.Seed(dbContext);

			/* End ******************************************************************************************************************/

			#endregion


			#region Navigational Propperties are not by Default Loaded

			/* Start *****************************************************************************************************************/

			// Data of the Nav_properties are not loaded Because they are Related Data , Example : 

			// For local Sequece the Linq Operators are Extension Methods for IEnumerable
			// For Remote Sequece the Linq Operators are Extension Methods for IQueryable

			// // Example 1 : 
			// var Emp1 = ( from Emp in dbContext.Employees
			// 		   where Emp.Code == 10
			// 		   select Emp ).FirstOrDefault();
			// 
			// if (Emp1 != null)
			// {
			//     Console.WriteLine($"{Emp1.Name} :: {Emp1.Department?.Name ?? "No Department"}");
			//     // we will notice that it will print "No Department" , that's because the Nav_property data is not by default loaded
			// }


			// // Example 2 : 
			// var Deps = (from D in dbContext.Departments
			// 			where D.DeptId == 10
			// 			select D).FirstOrDefault();
			// 
			// if (Deps != null)
			// {
			// 	Console.WriteLine($"{Deps.Name}");
			// 	foreach(var employee in Deps.Employees)
			// 	{
			// 		Console.WriteLine($"{employee.Name} , {employee.Code}");
			//      // we will notice that the name of the department only will be printed "Sales" , and no employees will be printed ...
			//     }
			// }

			// So to load the Data of a Navigational Property , we must use one of the 3 ways : 
			// 1 - Explicit Loading
			// 2 - Eager Loading
			// 3 - Lazy Loading

			/* End ******************************************************************************************************************/

			#endregion


			#region Explicit Loading

			/* Start *****************************************************************************************************************/

			// // The data is not loaded until I load it manually ... Two requests , one request for the actual data and another request for the
			// //                                                     navigational property data
			// // 1 - Reference with One Side (Example 1)
			// // 2 - Collection with Many Side (Example 2)
			// 
			// // Example 1 : 
			// var Emp1 = (from Emp in dbContext.Employees
			// 			where Emp.Code == 10
			// 			select Emp).FirstOrDefault();
			// 
			// Emp1 = dbContext.Employees.Where(e=>e.Code == 10).FirstOrDefault();       // Fluent Syntax (Method Syntax)
			// 
			// if (Emp1 != null)
			// {
			// 	dbContext.Entry(Emp1).Reference(nameof(Employee.Department)).Load();      // or Reference("Department") or Reference (e=>e.Department)
			// 	Console.WriteLine($"{Emp1.Name} :: {Emp1.Department?.Name ?? "No Department"}");    // will print the department name "Sales"
			// }
			// 
			// 
			// // Example 2 : 
			// var Deps = (from D in dbContext.Departments
			// 			where D.DeptId == 10
			// 			select D).FirstOrDefault();
			// 
			// Deps = dbContext.Departments.Where(d=>d.DeptId == 10).FirstOrDefault();       // Fluent Syntax (Method Syntax) 
			// 
			// if (Deps != null)
			// {
			// 	Console.WriteLine($"{Deps.Name}");
			// 	dbContext.Entry(Deps).Collection(nameof(Department.Employees)).Load();   // or Collection(d=>d.Employees) or Collection("Employees")
			// 	
			// 	foreach (var employee in Deps.Employees)
			// 	{
			// 		Console.WriteLine($"{employee.Name} , {employee.Code}");
			// 		// will print the employees in the department
			// 	}
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Eager Loading

			/* Start *****************************************************************************************************************/

			// // Getting the Data and the Related Data (nav_property data) in the same time and the same Request (One Request)
			// // Eager loading is a Concept , can be achieved by writing a query that makes Join and Gets the Related Data , and can also by 
			// // achieved through using the "Include" method of the EFCore found in (using Microsoft.EntityFrameworkCore)
			// 
			// // use :
			// // 1 - Include 
			// // 2 - ThenInclude
			// 
			// // Example 1 : 
			// var Emp1 = (from Emp in dbContext.Employees.Include(emp=>emp.Department)    // or Include(nameof(Employee.Department))  or  Include("Department")
			// 			where Emp.Code == 10
			// 			select Emp).FirstOrDefault();
			// 
			// Emp1 = dbContext.Employees.Include(emp => emp.Department).Where(e=>e.Code == 10).FirstOrDefault();     // Fluent Syntax (Method Syntax) 
			// 
			// // The SQL Profiler shows the Query done on the database , it's a left join Query , Why ???
			// // Query : Select FROM [Employees] AS [e] LEFT JOIN[Deps] AS[d] ON[e].[DepartmentId] = [d].[DeptId] WHERE[e].[Code] = 10
			// // -- That's because we want the data of employee with Code = 10 , inner join will get the employees that work in departments only , so if
			// //    the employee works in a department then the query is right but if the employee don't work in a department then no employee with Code = 10
			// //    will be retrieved (We want the employee in all cases if he works in a Department or Not , and if works then include the Data of Dep)
			// 
			// if (Emp1 != null)
			// {
			// 	Console.WriteLine($"{Emp1.Name} :: {Emp1.Department?.Name ?? "No Department"}");  // will print the department name "Sales"
			// }
			// 
			// // suppose we have another navigational property inside the Department Class , called "Project" (property of type "Project" class)
			// // then to include it also : use "ThenInclude" .. means go inside the current nav_property to include any other wanted Related Data
			// // Ex:
			// // var Emp1 = (from Emp in dbContext.Employees.Include(emp => emp.Department).ThenInclude(dept=>dept.Project)  
			// // 			   where Emp.Code == 10
			// // 			   select Emp).FirstOrDefault();
			// 
			// // Also we can have multiple includes from the same class : 
			// // var Emp1 = (from Emp in dbContext.Employees.Include(emp => emp.Department).ThenInclude(dept=>dept.Project).Include(emp=>emp.XYZ)  
			// // 			   where Emp.Code == 10
			// // 			   select Emp).FirstOrDefault();
			// 
			// 
			// 
			// 
			// // Example 2 : 
			// var Deps = (from D in dbContext.Departments.Include(d=>d.Employees)
			// 			where D.DeptId == 10
			// 			select D).FirstOrDefault();
			// 
			// Deps = dbContext.Departments.Include(d=>d.Employees).Where(d=>d.DeptId == 10).FirstOrDefault();     // Fluent Syntax (Method Syntax) 
			// 
			// // The SQL Profiler shows the Query done on the database :
			// // Query : Select FROM (
			// //                 SELECT TOP(1) [d].[DeptId], [d].[CreationDate], [d].[ManagerId], [d].[DeptName]
			// //                 FROM[Deps] AS[d]
			// //                 WHERE[d].[DeptId] = 10 ) AS[t]
			// //                        LEFT JOIN[Employees] AS[e]
			// //                        ON[t].[DeptId] = [e].[DepartmentId]
			// 
			// // This is not the best Query !! , a Better Query could be : 
			// // Select from Deps D left join Employees E on D.DeptId = E.DepartmentId where DeptId = 10
			// 
			// // we will get all the departments , having employees or not ... and then pick the one having Id = 10 , and we've got the data of
			// // employee already .. so it's important to see the code that is executed in the database incase we can improve it :)
			// 
			// if (Deps != null)
			// {
			// 	Console.WriteLine($"{Deps.Name}");
			// 	foreach (var employee in Deps.Employees)
			// 	{
			// 		Console.WriteLine($"{employee.Name} , {employee.Code}");
			// 		// will print the employees in the department
			// 	}
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Lazy Loading

			/* Start *****************************************************************************************************************/

			// // Lazy Loading is a concept that is in the Software , found also in Angular 
			// // Lazy Loading is same as Explicit Loading but done Implicitly 
			// 
			// // To use Lazy Loading : 
			// // 1 - First Install a Package called "Microsoft.EntityFrameworkCore.Proxies" (Proxies)
			// // 2 - OnConfiguring method , we must write ".UseLazyLoadingProxies()" (Extension method after installing the package)
			// //     what does this method do ? Overrides all the navigational properties .. override to use the overriden Get method
			// //     rather than the default Get method that is with Null (because by default related data is not loaded)
			// // 3 - To allow the method to override the navigational properties , ALL OF THEM MUST by "virtual"
			// // 4 - All classes must be Public or Internal but with writing "[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]" above the namespace
			// //     of the class to allow it to be seen ... to use it we must write "using System.Runtime.CompilerServices;" in the usings
			// 
			// // internally , for each and every model .. a Proxy class will be generated then override the navigational properties .. so the 
			// // classes also must be unsealed 
			// 
			// 
			// // Example 1 : 
			// var Emp1 = (from Emp in dbContext.Employees
			// 			where Emp.Code == 10
			// 			select Emp).FirstOrDefault();
			// 
			// Emp1 = dbContext.Employees.Where(e=>e.Code == 10).FirstOrDefault();       // Fluent Syntax (Method Syntax) 
			// 
			// if (Emp1 != null)
			// {
			// 	Console.WriteLine($"{Emp1.Name} :: {Emp1.Department?.Name ?? "No Department"}");    // will print the department name "Sales"
			// }
			// 
			// 
			// 
			// // Example 2 : 
			// var Deps = (from D in dbContext.Departments
			// 			where D.DeptId == 10
			// 			select D).FirstOrDefault();
			// 
			// Deps = dbContext.Departments.Where(d=>d.DeptId == 10).FirstOrDefault();       // Fluent Syntax (Method Syntax) 
			// 
			// if (Deps != null)
			// {
			// 	Console.WriteLine($"{Deps.Name}");
			// 	foreach (var employee in Deps.Employees)
			// 	{
			// 		Console.WriteLine($"{employee.Name} , {employee.Code}");
			// 		// will print the employees in the department
			// 	}
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Explicit Loading VS Eager Loading VS Lazy Loading

			/* Start *****************************************************************************************************************/

			// Lazy loading is like the Explicit Loading but done implicitly , so it's not recommended to use the Explicit Loading
			// so when to use the Eager Loading and when to use the Lazy Loading ?

			// use the Eager Loading in two cases : 
			// 1 - The navigational Proeprty is ONE (Same as Example 1) not a big overhead on the processor or the memory
			// 2 - The navigational Proeprty is Many but the relationship is Association Composition (ex: order and order items ,
			//     it's not usual to get the order without the order items)

			// use the Lazy Loading in one case : 
			// 1 - The navigational Proeprty is Many but the relationship is Association Aggregation (Same as Example 2) not in all cases we will 
			//     want the related data , so if we wanted it then it will be retrieved in another Reauest

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ - Join Operators [Join , GroupJoin]

			/* Start *****************************************************************************************************************/

			// Join : used to make Inner joins only
			// GroupJoin : used to make inner join then grouping , also can be used to make left outer join 

			// Note : we can use the Join then GroupBy and we will have the same result of GroupJoin

			// Note : A usecase for Join operators => Eager loading .. sometimes the Include function doesn't translate the code to the best
			//        optimal solution for the query we want , so we will use join to ensure that this is the best query that achieves the result 
			//        we want .

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ - Join

			/* Start *****************************************************************************************************************/

			// var Result = from E in dbContext.Employees
			// 			 join D in dbContext.Departments
			// 			 on E.DepartmentId equals D.DeptId
			// 			 select new
			// 			 {
			// 				 EmpName = E.Name,
			// 				 EmpCode = E.Code,
			// 				 DeptId = D.DeptId,
			// 				 DeptName = D.Name
			// 			 };
			// 
			// // Note : If we started with the foreign key entity then in the "on" condition we must start with it also .. in our example we 
			// //        started with the Employee entity (FK entity) then we started with it after the "on" keyword [ on E.DepartmentId equals D.DeptId ]
			// 
			// //                 outer              inner                                        E => Employee , D => Department
			// Result = dbContext.Employees.Join(dbContext.Departments, E => E.DepartmentId, D => D.DeptId, (E, D) => new
			// 																									    {
			// 																									    	EmpName = E.Name,
			// 																									    	EmpCode = E.Code,
			// 																									    	DeptId = D.DeptId,
			// 																									    	DeptName = D.Name
			// 																									    });
			// 
			// 
			// foreach( var E in Result)
			// {
			//     Console.WriteLine($"{E.EmpCode} => {E.EmpName} :: {E.DeptId} => {E.DeptName}");
			// }


			// we have another overload for Join ... it's the same as the first one but having one more parameter of type IEqualityComparer , 
			// so we can provide an object of a class that implements the IEqualityComparer interface to provide a new implementation for "Equals" 
			// and GetHashCode methods rather than the default implementation for them 

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ - GroupJoin

			/* Start *****************************************************************************************************************/

			// // until EFCore 6.0 , the GroupJoin was not translated to SQL (Exception) .. was only used as a C# method .. works only on Local 
			// // sequences , Remote sequences throws an exception
			// 
			// // Starting from EFCore 7.0 it's supported and can be translated to SQL without any Exceptions 
			// 
			// // Example 1 : 
			// 
			// //                      outer                       inner                                 D => Department , E => IEnumerable<Employee>
			// var Result = dbContext.Departments.GroupJoin(dbContext.Employees, d => d.DeptId, e => e.DepartmentId, (D, E) => new
			// {
			// 	DeptName = D.Name,
			// 	DeptId = D.DeptId,
			// 	EmployeesList = E
			// }).Where( x => x.EmployeesList.Count() > 0);
			// 
			// // We must start with the Entity that we will make groups with ... group based on department then start with department entity 
			// // if we skipped the Where condition then we will get all the departments (containing and not containing employees) 
			// 
			// 
			// Result = (from D in dbContext.Departments                      // Query Syntax
			// 		  join E in dbContext.Employees
			// 		  on D.DeptId equals E.DepartmentId
			// 		  into Employees
			// 		  select new
			// 		  {
			// 			  DeptName = D.Name,
			// 			  DeptId = D.DeptId,
			// 			  EmployeesList = Employees
			// 		  }).Where(x => x.EmployeesList.Count() > 0);        // or select new { } into x where x.EmployeesList.Count() > 0 select x
			// 
			// foreach(var result in Result)
			// {
			//     Console.WriteLine($"{result.DeptId} => {result.DeptName}");
			// 	foreach(var emp in result.EmployeesList)
			//         Console.WriteLine($"....{emp.Code} :: {emp.Name} :: {emp.Salary}");
			// }


			// // Example 2 : 
			// 
			// // what if we want to group based on employees ? meaning less now but try to understand it !
			// 
			// //                      outer                       inner                                   E => Employee, D => IEnumerabl<Department> 
			// var Result2 = dbContext.Employees.GroupJoin(dbContext.Departments, e => e.DepartmentId , d => d.DeptId, (E, D) => new
			// {
			// 	EmployeeName = E.Name,
			// 	EmployeeCode = E.Code,
			// 	DepartmentsList = D
			// });
			// 
			// 
			// Result2 = (from E in dbContext.Employees                            // Query Syntax
			// 		  join D in dbContext.Departments
			// 		  on E.DepartmentId equals D.DeptId
			// 		  into Departments
			// 		  select new
			// 		  {
			// 			  EmployeeName = E.Name,
			// 			  EmployeeCode = E.Code,
			// 			  DepartmentsList = Departments
			// 		  }).Where(x => x.DepartmentsList.Count() > 0);        // or select new { } into x where x.EmployeesList.Count() > 0 select x
			// 
			// 
			// 
			// foreach (var result in Result2)
			// {
			// 	Console.WriteLine($"{result.EmployeeCode} :: {result.EmployeeName}");
			// 	foreach (var dept in result.DepartmentsList)
			//         Console.WriteLine($"....{dept.DeptId} , {dept.Name}");
			// }


			// we have another overload for GroupJoin ... it's the same as the first one but having one more parameter of type IEqualityComparer , 
			// so we can provide an object of a class that implements the IEqualityComparer interface to provide a new implementation for "Equals" 
			// and GetHashCode methods rather than the default implementation for them 

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ - GroupJoin (Left Outer Join)

			/* Start *****************************************************************************************************************/

			// // Example 1 : get all the departments , having employees and not having employees 
			// 
			// var Result = dbContext.Departments.GroupJoin(dbContext.Employees, d => d.DeptId, e => e.DepartmentId,
			// 	(dep, emp) => new
			// 	{
			// 		Department = dep,
			// 		Employees = emp.DefaultIfEmpty()           // First time to use
			// 	}).SelectMany(x=>x.Employees , (a,emp)=>new {a.Department , emp});
			// 
			// // DefaultIfEmpty() => used here to help us to show the departments that has no employees .. to implement the outer join as we know it
			// 
			// 
			// Result = from D in dbContext.Departments
			// 			  join E in dbContext.Employees
			// 			  on D.DeptId equals E.DepartmentId
			// 			  into Employees
			// 			  select new
			// 			  {
			// 				  Department = D,
			// 				  Employees = Employees.DefaultIfEmpty()
			// 			  } into a
			// 			  from emp in a.Employees
			// 			  select new
			// 			  {
			// 				  a.Department,
			// 				  emp
			// 			  };
			// 
			// foreach (var res in Result)
			// {
			// 	Console.WriteLine($"{res.Department.Name} , {res.emp?.Name??"No employee"}");
			// }



			// // Example 2 : get all employees , work in department or don't work in department
			// 
			// var Result2 = dbContext.Employees.GroupJoin(dbContext.Departments, e => e.DepartmentId, d => d.DeptId, (emp, deps) => new
			// {
			// 	employee = emp,
			// 	Departments = deps.DefaultIfEmpty()
			// }).SelectMany(x => x.Departments, (x, Department) => new
			// {
			// 	x.employee,
			// 	Department
			// });
			// 
			// 
			// Result2 = from E in dbContext.Employees
			// 			   join D in dbContext.Departments
			// 			   on E.DepartmentId equals D.DeptId
			// 			   into Departments
			// 			   select new
			// 			   {
			// 				   employee = E,
			// 				   Departments = Departments.DefaultIfEmpty(),
			// 			   }into nw 
			// 			   from r in nw.Departments
			// 			   select new
			// 			   {
			// 				   nw.employee,
			// 				   Department = r
			// 			   };
			// 
			// 
			// 
			// foreach (var res in Result2)
			// {
			// 	Console.WriteLine($"{res.employee.Name} : {res.Department?.Name ?? "No Dept"}");
			// }


			/* End ******************************************************************************************************************/

			#endregion


			#region Cross Join

			/* Start *****************************************************************************************************************/

			// // We won't use Join or GroupJoin here !! 
			// // We will use double Select .. 
			// 
			// // Why we want cross join ? if we want to know all the combinations of the data in tables .. or to make a large dataset of data
			// // that we want to use in our program 
			// 
			// var Result = from E in dbContext.Employees
			// 			 from D in dbContext.Departments
			// 			 select new
			// 			 {
			// 				 E,
			// 				 D
			// 			 };
			// 
			// Result = dbContext.Employees.SelectMany(E => dbContext.Departments.Select(D => new
			// {
			// 	E,
			// 	D
			// }));
			// 
			// foreach (var res in Result)
			// {
			// 	Console.WriteLine($"{res.E.Name} :: {res.D.Name}");
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Mapping the View

			/* Start *****************************************************************************************************************/

			// // By convention any DbSet is mapped to a table in the database , so how to associate the view in the database with a DbSet ? 
			// // we cannot map a model to a View by the C# code as we do with Database tables .. we first must have a view in the database 
			// // and then associate it to the DbSet and write the configurations of it
			// 
			// // 1 - Make an Empty migration , and in the Up method put the SQL code that generates the View (can be done also in SQL Server 
			// //     application but because we are working with code first approach then it's better to do everything away from SQL Server )
			// //     - See the migrations called "EmployeeDepartmentsView"  
			// 
			// // 2 - Make a model (class) that represents the shape of the data in the view (with the same naming)
			// //     - See the Model called "EmployeesDepartments"
			// 
			// // 3 - Make a DbSet in the DbContext class , and then configure it that it's a view 
			// //     - See the DbSet called "EmployeesDepartmentsView" and the configuration class called "EmployeesDepartmentsConfigurations"
			// 
			// var Result = dbContext.EmployeeDepartmentsView;
			// 
			// foreach (var item in Result)
			// {
			// 	Console.WriteLine($"{item.EmployeeName} : {item.DepartmentName ?? "No DEPTTT"}");
			// }

			// // if we opened the SQL Profiler we will notice that we select from the view we created .. 

			/* End ******************************************************************************************************************/

			#endregion


			#region Tracking Vs NoTracking

			/* Start *****************************************************************************************************************/

			// // We've discussed this topic in Session 2 EFCore .. More over :
			// 
			// // The change tracker is tracking the object state .. 
			// 
			// 
			// // Example 1 :
			// 
			// var employee = ( from E in dbContext.Employees
			// 			   where E.Code == 10
			// 			   select E ) .FirstOrDefault();
			// 
            // Console.WriteLine(dbContext.Entry(employee).State);               // Unchanged
			// 
			// employee.Name = "Hamada"; // this change is done locally , to apply the change ==> dbContext.SaveChanges(); but it's state must change !!
			// 
			// Console.WriteLine(dbContext.Entry(employee).State);               // Modified
			// 
			// dbContext.SaveChanges(); // EFCore asks the change tracker about objects that it's state has changed, to change it actually in database
			// 
			// 
			// // Example 2 : AsNoTracking() ==> used when we know that this object will be read only object and we don't want to track it's change 
			// 
			// var employee2 = (from E in dbContext.Employees
			// 				where E.Code == 20
			// 				select E).AsNoTracking().FirstOrDefault();
			// 
			// Console.WriteLine(dbContext.Entry(employee2).State);               // Detached
			// 
			// employee2.Name = "ZZZZZZ"; // this change is done locally , to apply the change ==> dbContext.SaveChanges(); but it's state must change !!
			// 
			// Console.WriteLine(dbContext.Entry(employee2).State);               // Detached
			// 
			// dbContext.SaveChanges(); // EFCore asks the change tracker about objects that it's state has changed, to change it actually in database
			// 
			// // In this case , no states changed so no change on the data in database 
			// 
			// 
			// 
			// // Note : the default of EFCore that it's Tracking , to make the default as No Tracking : 
			// // dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.TrackAll;    // Default
			// dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}