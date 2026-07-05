using Dapper;
using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace NorthWindDapperTrail
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Dapper handles the execution , it doesn't make as EFCore (mapping the other side from one side)

            // Dapper is almost the same speed as ADO (1.1 - 1.3 X ADO speed) ,
            // EFCore (2 - 2.5 X ADO speed if no tracking) but (4 X ADO speed with tracking)
            // Dapper is very usefull when selecting (Note that objects are not tracked !!)
            // We have a paid version of Dapper that has the tracking capability (now use EFCore better as it's free !)

            // Speed difference is shown if the data is large 

            // Recommendation : we can use Dapper for selecting but insert, update, delete use EFCore because objects are tracked 



            // First of all we must install Dapper from the Nuget packages "Dapper" , What is "Dapper" ? 
            // Some extension methods for any object of type Database Connection 

            DbConnection CN = new SqlConnection("Data Source=.;Initial Catalog=Northwind;Integrated Security=True;Encrypt=false");
            // Note : if we have a project that we use in it "EFCore" and "Dapper" then we could get the connection string using 
            //        context.Database.GetDbConnection. Otherwise we will use SqlConnection so we must install the "Microsoft.Data.SqlClient"


            // Dapper Extension methods : 
            // CN.Execute;     // Executes SQL Query and return int (number of rows affected)
            // CN.Query;       // Executes SQL Query and return IEnumerable<T> to get data 
            // CN.QueryFirst;   CN.QueryFirstOrDefault;  // Same as .First or .FirstOrDefault of LINQ
            // CN.QuerySingle;  CN.QuerySingleOrDefault // Same as .Single or .SingleOrDefault of LINQ (but here works with PK)
            // And many others ... 

            // Parameters sent to dapper query can be : 
            // - Anonymous type 
            // - Dynamic Keyword
            // - List 
            // - string 

            // Search about : AsList() vs ToList();

            // See the full implementation in the ProductManager class : 

            ProductManager pm = new();
            bool x = pm.Add(new Product() { ProductName = "Test PRD", Discontinued = false });
            Console.WriteLine($"Adding => {x}");

            var prd = pm.GetById(1);
            Console.WriteLine(prd);
            prd.ProductName = "New New Name";

            var prds = pm.GetAll();
            Console.WriteLine($"Count = {prds.Count()}");

            bool d = pm.Delete(80);
            Console.WriteLine($"Deleting => {d}");

            bool u = pm.Update(prd);
            Console.WriteLine($"Updating prd id = 1 => {x} , See P prd id = 1 => ");
            prd = pm.GetById(1);
            Console.WriteLine(prd);
        }
    }
}
