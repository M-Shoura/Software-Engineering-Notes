namespace EFCore___Session_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// https://learn.microsoft.com/en-us/ef/core/managing-schemas/scaffolding/?tabs=dotnet-core-cli

			/* End ******************************************************************************************************************/

			#endregion


			#region Database First (Reverse Engineering) - Using Package Manager Concole Commands

			/* Start *****************************************************************************************************************/

			// In this approach , we have the Database and we will use the EFCore to generate the DbContext class and the domain models 

			// We will use the "Northwind" database backup , and the generated DbContext and models will be in the other project in this
			// solution "Database_First_Approach" ... 

			// 1 - we will restore the database backup in SQL Server
			// 2 - Install the packages required "database provider (SQL Server)" & "Tools" packages 
			// 3 - Don't forget to make the project we will work with as a startup project (Right Click -> Set as StartUp project)
			// 4 - Now open the Package Manager Console and write the commands !

			// first command : 
			// Scaffold-DbContext -Connection "Server = .; Database = Northwind; Trusted_Connection = True; TrustServerCertificate = True;" -Provider "Microsoft.EntityFrameworkCore.SqlServer"
			// this generates the DbContext class named as [DatabaseNameContext] (Ex: NorthwindContext) and domain model for each and every table or view 

			// -Connection "Connection String" & -Provider "Provider Name" are the two required parameters .. there are many other parameters but are not required 
			// -Context "Hamada" ==> this will be the name of the DbContext rather than the default naming [DatabaseNameContext] (Ex: NorthwindContext)
			// -ContextDir "Data" => the folder will be generated [if not exists] and the DbContext class will be generated there 
			// -OutputDir "Data/Models" => the folder will be generated [if not exists] and the domain models classes will be generated there
			// -Tables Customers,CategoryView, ... ==> this generates domain model classes for selected database Tables and Views
			// -Schema Test ==> scaffold all tables and views from the selected schema
			// -DataAnnotations ==> use data annotations when possible , and when not possible then use the Fluent APIs in OnModelCreating function
			//                      as it's the default 


			// The final command I will write now : 

			// Scaffold-DbContext -Connection "Server = .; Database = Northwind; Trusted_Connection = True; TrustServerCertificate = True;" -Provider "Microsoft.EntityFrameworkCore.SqlServer"
			// -ContextDir "Data" -OutputDir "Data/Models" -Tables Products, Customers, Suppliers, Categories, "Products Above Average Price" -DataAnnotations

			// Note : We will notice that all the classes generated are partial classes , that's because if we want to edit this files then we must make
			//        another partial class with our own edits .. because if we re-generated the models then any edits in the generated files will be deleted


			/* End ******************************************************************************************************************/

			#endregion


			#region Database First (Reverse Engineering) - Using EFCore Power Tools Extension

			/* Start *****************************************************************************************************************/

			// We usually use this extension when using database first approach .. Easier than using commands and more powerfull 
			// Till EFCore 5.0 this extension was working for database first approach , starting from EFcore 6.0 it works with code first
			// and database first approaches 


			// 1 - Install the Extension : Extensions -> Manage Extensions -> EF Core Power Tools -> Install
			//     Note : after uninstalling or installing the extension , we must close any Visual Studio tab and launch it again ... 
			// 2 - After installing , Right click on the project , we will notice "EF Core Power Tools" .. Choose "Reverse Engineer"
			// 3 - Go Through the options .. Recommend to see the video "Part 02 Database First - EF Core Power Tools" 

			/* End ******************************************************************************************************************/

			#endregion


			#region Run SQL Queries 

			/* Start *****************************************************************************************************************/


			// Cannot execute the code .. written as comments 
			// using NorthwindContext dbContext = new NorthwindContext();

			// 1 - Writing SQL for Select :
			// Execute Select Statement ->
			//   - "FromSqlRaw()" : sending parameters using composite formating 
			//   - "FromSqlInterpolated()" : sending parameters using string interpolation

			// int Count = 4;
			// var Result = dbContext.Categories.FromSqlRaw("Select Top({0}) * from Categories",Count);
			// Result = dbContext.Categories.FromSqlInterpolated($"Select Top({Count}) * from Categories");

			// Note : dbContext.Categories.Local  ==> Gets the data from the local data in the DbSet (don't get data from database)


			// 2 - Writing SQL for Insert , Update , Delete :
			// Execute non-Select Statements (Insert , Update , Delete) ->
			//   - "ExecuteSqlRaw()" : sending parameters using composite formating 
			//   - "ExecuteSqlInterpolated()" : sending parameters using string interpolation


			// var CategoryId = 1;
			// dbContext.Database.ExecuteSqlRaw("Update Categories Set CategoryName = 'New' Where CategoryID = {0}",CategoryId);
			// dbContext.Database.ExecuteSqlInterpolated($"Update Categories Set CategoryName = 'New' Where CategoryID = {CategoryId}");


			// It's not recommended to write SQL code here , as we discussed before in the First Session EFCore .. it's better to use EFCore or Dapper
			// in these cases 

			/* End ******************************************************************************************************************/

			#endregion


			#region Calling Stored Procedure

			/* Start *****************************************************************************************************************/

			// Easier when using the EF Core Power Tools ...
			// Recommend to watch video "Part 04 Calling Stored Procedure" 

			/* End ******************************************************************************************************************/

			#endregion


			#region Notice => [There are other videos will be uploaded]

			/* Start *****************************************************************************************************************/



			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
