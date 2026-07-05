using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NorthwindConsoleApp.Context;
using NorthwindConsoleApp.Entities;

// This is an alias ! see how it's used below (can be done with any thing not only tuples)

namespace NorthwindConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // in this project we will work with database first BUT WITHOUT EFCore power tools as using it may be not allowed ! 
            // so we will use the PMC package manager console and write some commands 

            // don't miss installing the packages (sqlServer , tools , design)

            // command for scaffolding the database : 
            // scaffold-dbcontext "Data source=.;Initial catalog=Northwind;integrated security=true;encrypt=false;" Microsoft.Entityframeworkcore.sqlserver -Tables Products,Categories,Suppliers -DataAnnotations


            // Note : the DbContext class is a partial class so make another partial class with the same name and different fileName and 
            //        write your code that you want to add , take care also of the function name , as the OnModelCreating is a partial method
            //        so put it as a partial method also in the new partial class 

            // self study : what is the partial method ? 


            using NorthwindContext context = new();

            // soft deleting : not actual delete from the DB as we may need the entity again for any other purposes , so we have a field in 
            //                 the table (ex: discontinued or IsDeleted) that is bool , if true then it's deleted else it's not deleted

            // So it will be a very bad thing to write this .Where(x=>x.IsDeleted==false) in each retriving data from the DB ,
            // so we should put this in the "Global Query filter" , and also don't miss making EFCore Delete makes IsDeleted=true instead 
            // of deleting the product from DB as this is the default. 


            // Fluent APIs : written inside the "OnModelCreating" or in Configuration Classes. used when i don't have access to the source 
            //               code , and we use it to make the "Global Query Filter" (it's a must to use Fluent APIs)

            // Global Query Filter : defined in the "Fluent APIs" , as i defined in the partial class "NorthwindContext" , 
            //                       ex: modelBuilder.Entity<Product>().HasQueryFilter(p => p.Discontinued == false);
            //                       so for each query on Product table , we will add this filter also (p.Discontinued == false) implicitly.
            //                       ex: Context.Products.Take(10).ToList();                                             // query written 
            //                           Context.Products.Where(p => p.Discontinued == false).Take(10).ToList();         // query executed 
            //                       Note : We can neglect the global filters for a type if we want to get the real results , 
            //                              then we add .IgnoreQueryFilters() 
            //                              ex: Context.Products.IgnoreQueryFilters().Take(10).ToList();


            // Local Data Store : .Local and .Find()
            //
            // The default of the EFCore that all queries are executed in the DB. 
            // var res = Context.Products.Take(10).ToList();                        // queries the database , and put them in the local
            // var res = Context.Products.Local.Take(10).ToList();                  // queries the local that were retireved before 

            // var countDB = context.Products.Count();
            // Console.WriteLine(countDB);     // 60
            // var prds = context.Products.Take(10).ToList();
            // var countLocal = context.Products.Local.Count();
            // Console.WriteLine(countLocal);  // 10 

            // so we can query from the local ! but notice that the output may be different than querying the DB. 
            // Querying the local has an advantage => no extra querying from the DB , but may have non-valid data ... this depends on the
            // business and the type of query you are writing , see next example : 

            // if(context.Products.Local.Any(p=>p.UnitsInStock==0))          // Query local , no DB trips
            //     Console.WriteLine("Yes we have products out of stock");
            // else
            // {
            //     if(context.Products.Any(p => p.UnitsInStock == 0))
            //         Console.WriteLine("Yes we have products out of stock");
            //     else
            //         Console.WriteLine("No we don't have products out of stock !");
            // }

            // So in the previous code , we minimized the number of trips to the DB , as we check the local first and if found products out
            // of stock then that's OK we now have saved one trip to the DB , and if No then go and check the DB to ensure that all products
            // are not out of stock ! So this is better than the one-step querying the DB as we may have a local data that satisfy this
            // condition so save DB trips.


            // LINQ .Find() works with the approach of querying the local first , if not found then query the DB , it works with the PK and 
            // it's overload takes the PK or array params , why ? incase we have composote PK ! 

            // var prd = context.Products.Find(15);
            // Check local first , if found then return from the local without extra DB trips 
            // if not found in Local then query DB (Trip to DB) , if found return Obj and add it to the local ! 
            // if not found in the DB then return null and no exceptions

            // So this is the way that ".Find()" works with , and if we want to use this way with another functions then use "if else" as
            // the previous example with any function we want 

            // Note : if we want to clear the local , we can do this (context.Products.Local.Clear()) , not nessesary in most of business
            //        cases.



            // what if we want data to be shown only without any changes ? AND ANY CHANGES WILL NOT AFFECT THE DB DATA BECAUSE THE STATE
            // WILL REMAIN "Detached" (same as readonly) ? 
            // - Use ".AsNoTracking()"
            // var res = context.Products.AsNoTracking().ToList();
            // so any change to any object here will not be commited to the DB and the state will remain "Detached" in any situation.
            // Console.WriteLine(context.Entry(res[0]).State);    // Detached
            // res[0].UnitsInStock = 1000;
            // Console.WriteLine(context.Entry(res[0]).State);    // Detached
            // Console.WriteLine(context.SaveChanges());          // 0 rows affected in the DB



            // IQueryable VS IEnumerable : 
            // when we studied LINQ , we knew that not all operators have equavilant in SQL , ex: TakeLast()
            // var x = context.Products.TakeLast(10).ToList();      // Exception , TakeLast cannot be translated 
            // Note : we here are working with the remote sequence DB (IQueryable)


            // solved by getting the whole data then make this filter in the local data , this can be done with more than one way : 
            var y = context.Products.AsEnumerable().TakeLast(10).ToList();
            // now after using the "AsEnumerable" , we converted the "IQueryable" to "IEnumerable" , and all Products data is loaded in 
            // the memory and any filteration or projection will be handled in local memory of the application (Local Sequence NOT remote).

            // Note : this is very bad as we get the whole data from the DB table and make the filteration in the APP and local data.
            //        remember the execution of a query like this : 
            //        ex: context.Products.Where(x=>x.UnitPrice > 50).OrderBy(x=>x.UnitPrice).Take(3).Select(p=>new{p.name}).ToList();
            //        the previous query is executed in the DB , we built it in the app but executed in one query in the DB



            // Tuple in C# : 
            //
            // one of the most important operators in Linq is the "Select" , we can use it to transform the shape of the object to another 
            // shape , can transform to a mapped type or anonymous type of a perimitive datatype (int , string , .. )
            // 
            // so incase of the anonymous type or anonymous object , the "anonymous type is a Class so it's reference type" , it has 
            // disadvantage that we cannot make function return this anonymous type and also function cannot take this type as a parameter.
            // only we can use it in a "var" . so how to solve these disadvantages ? by using a Tuple

            // A Tuple is a "Value Type" that is used as a DTO (data transfer Object) , it doesn't hold methods or behaviours , so instead 
            // of using a reference type "anonymous type" , we can use the Tuple ... Tuple is an Immutable type , this can also be done 
            // using a "Record" .. both are discussed now

            // Tuple : used to store set of values (wihtout any methods or behaviours) , it's same as anonymous type but with the 
            //         advantage of being a
            //           1 - "Value Type"
            //           2 - passed to a function
            //           3 - returned from a function.

            // var Emp1 = ("Ahmed", 30);
            // Console.WriteLine(Emp1.GetType());    // System.ValueTuple`2[System.String,System.Int32]

            // if we see the IL we will NOT find a newly created class or struct , but we use one of the built-in datatypes , it's the 
            // System.ValueTuple`2<string,int>  
            // so we can find the base struct that represents the tuple in C# 
            // Note : we have a default ToString() for the tuple 


            // ----------------------------------------------------------------------------------------------------------------------


            // Part 2 : 

            // More Examples on Tuples : 

            // var Emp1 = ("Ahmed", 30);
            // Console.WriteLine(Emp1.GetType());       // System.ValueTuple`2[System.String,System.Int32]

            // Emp1.Item1     // this is the first , "Ahmed"
            // Emp1.Item2     // this is the second , 30

            // (string, int) Emp2 = ("Sally", 100);
            // 
            // if (Emp1.GetType() == Emp2.GetType())
            //     Console.WriteLine("Same DT");             // same DT
            // 
            // (string, int) Emp3 = ("Ahmed", 30);
            // if (Emp1 == Emp3)
            //     Console.WriteLine("Same Data");          // same Data

            // Example for returning a tuple from a function 
            // public static (string , int) TestTupleReturnType()
            // {
            //     return ("Mahmoud", 100);
            // }
            //
            // (string, int) test = TestTupleReturnType();


            // Example for taking a tuple as function paramter : 
            // public static void TestTupleInputParameter((string, int) temp)
            // {
            //     Console.WriteLine(temp.Item1 + " " + temp.Item2);
            // }
            // TestTupleInputParameter(("Mido",50));


            // Example for using tuples as a datatype for list , dictionary , IEnumerable , ... 
            // List<(string, int, decimal)> lst = new List<(string, int, decimal)>() { ("Mahmoud",100,2423), ("Shoura", 200, 25235)};
            // IEnumerable<(int, int)> IEnum = Enumerable.Empty<(int,int)>();
            // Dictionary<(Product, int), decimal> mp = new();

            // what can we do to name the parts of the tuple (instead of Item1 and Item2 and .... ) ? Give names to them ! 
            // (string Name, int Age) Emp4 = ("Mahmoud", 24);
            // Console.WriteLine(Emp4.Name);   
            // Console.WriteLine(Emp4.Age);
            // Console.WriteLine(Emp4.Item1);   // still works , the name and age is in the C# only not the IL 
            // Console.WriteLine(Emp4.Item2);   // still works , the name and age is in the C# only not the IL 


            // Names can be Infeered 
            // var Date = (DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Date);
            // Console.WriteLine(Date.Year);

            // Note : as long as we have the same datatypes with the same ordering then they all have the same datatypes. 


            // in the using secion in the file we can ma e an alias for the type: 
            // using Point3D = (int XPos, int YPos, int ZPos);
            // This is an alias ! see how it's used below (can be done with any thing not only tuples)
            // Self study more about this aliasing .. 

            // Point3D x = (1, 2, 3);
            // Console.WriteLine(x.XPos);


            // so now how to select a tuple from the DB with EFCore ? ===> use ValueTuple.Create()
            // var prds = context.Products.Select(p => ValueTuple.Create(p.ProductName, p.UnitPrice)).ToList();

            // so further more we can make an example for a function that returns that tuple : 
            // List<(string , decimal?)> GetProducts() => context.Products.select(p => ValueTuple.Create(p.ProductName, p.UnitPrice)).ToList();
            // var PrdList = GetProducts();    // list of tuple 

            // Very important : 
            // Tuple<string, int> T;       // Legacy class in the BCL System.Tuple , IT'S A CLASS (REFERENCE TYPE)
            // (string , int)              // ValueTuple


            // We know the Constructor , Destructor .... Now we will discuss the "Deconstructor"
            // Tuple supports the Deconstructor Pattern
            // - Constructor   : initialize objects 
            // - Destructor    : clean up memory from this object 
            // - Deconstructor : Deconstruct the object , same as making the object as parts or slices ! it gets the values back from fields
            //                   using "out" parameters

            // first of all the Deconstructor can be used without the Tuple , but one of it's uses is in the Tuple 
            // see esample in "Rectangle" class : 
            // it's a function that returns "void" and takes out parameters , it's name gives it an advantage ! 

            // Rectangle r = new(1,2);
            // r.Deconstruct(out double a, out double b);
            // Console.WriteLine($"{a},{b}");
            // 
            // // what about writing it in a better way ? 
            // (a, b) = r;      // will call the "Deconstruct" implicitly and fill the given variables with the returned values
            // Console.WriteLine($"{a},{b}");
            // 
            // // also can be written with var keyword : 
            // var (w, h) = r;      // will call the "Deconstruct" implicitly and fill the given variables with the returned values
            // Console.WriteLine($"{w},{h}");
            // 
            // // can use "discard" also to discard out parameters
            // var (x, _) = r;
            // Console.WriteLine(x);
            // 
            // // Note : notice the difference between the var(a,b) = r;         and (a,b) emp = Employee1;
            // //        this is the usage of Tuple with Deconstruct : 
            // 
            // (string, int) Employee1 = ("Shoura", 100);
            // var (_N, _A) = Employee1 ;
            // Console.WriteLine($"{_N}::{_A}");
            // // so this is what we mean by "Tuple" support Deconstruct pattern ! 

            // So To summerise : putting var before the (var1, var2, .. ) ====> Deconstruct
            //                   not putting var        (string, int) Emp = ("shoura", 100);     ====> Normal ValueTuple
            //                   or                     var Emp = ("shoura", 100);               ====> Normal ValueTuple

            // Last note : we can use the deconstruct to make a single line constructor (see class rectangle)


            // --------------------------

            // what about if we need a thing that is same as the ValueTuple but "Reference Type" , then use "Records" !
            // note : we didn't use the anonymous type as we cannot return it from a function or take it as function parameters 
            //        and also we will not use the Tuple class , as it's not used nowadays and it's old ! 

            // Record : used to make Classes or Structures with only one line of code. It works very well as a DTO and as an Immutable 
            //          datatypes (has some fields that doesn't change their values). 
            //          in C# 9.0  => Record
            //          in C# 10.0 => Struct Record


            // Note : we define records and struct records outside the functions (in the class or namespace) 
            // record Point { }           // Class (reference type)
            // record struct Pointt { }   // Struct (value type)

            // when seeing the IL code , and we see a version before C# 9.0 we will see that the compiler created a new class with the same 
            // name of the record , that inherits from IEqutable<RecordName>  .. and we will notice that some things are generated , ex: 
            // protected copy ctor , Clone , override (Equals , == , != , GetHashCode , ToString)
            // Note : iMMUTABLE TYPE.

            // Point p = new(10, 15);
            // Console.WriteLine(p.X + " " + p.Y);
            // Console.WriteLine(p);                  // Same as ToString()
            // // p.X++;                              // ERROR , as it's immutable type and we cannot edit values ! 

            // // Equalty is working with the "Value Equality" , means that it compares the values without references 
            // Point p1 = new(10, 15), p2 = new(10, 15);
            // Console.WriteLine(p1==p2);             // True
            // Console.WriteLine(p1.Equals(p2));      // True
            // Console.WriteLine(p1.GetHashCode() + " --- " + p2.GetHashCode());      // Same hash codes
            // 
            // 
            // // it also works with the non-mutation equality same as we discussed in the anonymous types : 
            // Point p3 = p1 with { X = 100 };        // new point with a new identity with the same Y but different X 

            // What about combining the Record with the Primary Constructor that we used with OOP to write less code ? 
            // - this will generate public init only properties , primary ctor , and all the above of the record (discussed above)


            // so using records is good if we want to use it as a function return type , function input parameter , declare a variable 
            // with this type 


            // ValueTuple VS Record Struct : 
            // - The tuple doesn't have a name of a type (ex: we cannot make a templete and give it a name , we must at every time put the
            //   whole signature of the type , ex: (string, int) Emp = ("shoura", 100);   )
            // - The record can be inistantiated with a specific templete shape and have many other advantages (functions inside it and
            //   overriden functions)



            // -------------------------------------------

            // writing SQL in the C# code using ORM or EFCore , SQL code can be : 
            //   - Plain SQL 
            //   - Calling SPs
            // the return can be :
            //  1 - mapped entity (product , supplier , caterogy , .... any type i have)
            //  2 - not mapped entity , ex: Scalar obj as aggregate functions 


            // -----------------------------------------------------------------
            // 1 - mapped entities: 

            // incase of a mapped entity : context.DbSetName.FromSql or FromSqlInterpolated (they are the same) or FromSqlRaw() 
            // then the return from the query MUST be the same structure as the DbSet and The return is an IQueryable , and it's
            // Tracked Entities , and I can then use LINQ over the return result. Also we can compose LINQ on top of FromSQL Queries



            // var minUnitInStock = 100;
            // var minUnitInStockSqlParameter = new SqlParameter("minUnitInStock",100);
            // var res = context.Products
            //               .FromSql($"select * from products").ToList();
            //               .FromSql($"exec spGetAllProducts").ToList();
            //               .FromSql($"select * from products where UnitsInStock > {minUnitInStock}").ToList(); 
            //               .FromSql($"select * from products where UnitsInStock > {minUnitInStockSqlParameter}").ToList();
            //               .FromSql($" exec spSelectAllProductsAbovePrice @p={100}").ToList();
            //               .FromSql($" exec spSelectAllProductsAbovePrice {100}").ToList();
            //               .FromSql($" exec spSelectAllProductsAbovePrice {minUnitInStockSqlParameter}").ToList();
            //               .FromSql($"select * from products").OrderByDescending(p=>p.UnitPrice).ToList();      // LINQ on top of SQL
            //               .FromSql($"exec spGetAllProducts").OrderByDescending(p => p.UnitPrice).ToList();     // WRONG , it's SP
            //               .FromSql($"exec spGetAllProducts").AsEnumerable().OrderByDescending(p => p.UnitPrice).ToList();  // Right 
            //               .FromSql($"select * from products").Include(p=>p.Category).ToList();
            //               .FromSql($"exec spGetAllProducts").Include(p=>p.Category).AsEnumerable().ToList();     // Error , it's SP


            // Note : incase of LINQ on top of SQL , it's executed as a ONE SQL Query in the DB , they are executed as SubQueries (this
            //        differs from working with SPs). So the FromSql is executed as the inner query and then the other Linq is in the 
            //        outer Query and we can see this in the SQL profiler. Incase of SP , we cannot put the SP inside a subquery (remember)
            //        so this will throw an error ! so we must first get the result of the SP in the local memory then continue making what
            //        we want on the data (It's tracked also) , but it differs that any linq is executed on the whole data that came locally
            //        without any filteration or any thing.

            // res[0].ProductName += " ,, ";        // update works because it's tracked
            // Console.WriteLine(context.SaveChanges());


            // What if we want more control on the query and specifying some things such as column names , .. 
            // then we will use FromSqlRaw

            // var prdName = new SqlParameter("ProductName", "PName");
            // var regex = new SqlParameter("regex", "a%");
            // var results = context.Products.FromSqlRaw($"select * from products where {prdName} like @regex", regex).ToList(); 
            // 
            // 
            // foreach (var x in results)
            // {
            //     Console.WriteLine(x.ProductName);
            // }

            // -----------------------------------------------------------------
            // 2 - not mapped entities : (ex: scalar , any agg function)
            //     now call from the Database directly and use 
            //     - ExecuteSql and ExecuteSqlInterpolated => return int , and they are the same as FromSql and FromSqlInterpolated
            //     - ExecuteSqlRaw for more flexible querying as the FromSqlRaw
            //     - SqlQuery => return TResult so return any thing not an int as ExecuteSql
            //     - SqlQueryRaw for more flexible querying as the FromSqlRaw and ExecuteSqlRaw

            var result = context.Database.SqlQuery<int>($"select count(*) from Products").ToList();
            Console.WriteLine(result.FirstOrDefault());

            var result2 = context.Database.SqlQuery<string>($"select ProductName from Products").ToList();
            Console.WriteLine(result2.Count());



            // What about "insert", "update", "delete" ?
            // USE ExecuteSql, ExecuteSqlRaw, ExecuteSqlInterpolated and they return an int 

            var name = new SqlParameter("nm", "New Name");
            var id = new SqlParameter("id", 1);
            var result3 = context.Database.ExecuteSql($"update Products set ProductName = {name} where ProductId = {id}");
            Console.WriteLine(result3);


            // For a not mapped object , make it in the fastest way using a Record ! 
            var result4 = context.Database.SqlQuery<TenMostExpensiveProductsResults>($"exec [Ten Most Expensive Products]").ToList();
            //Console.WriteLine(result4);
            foreach (var item in result4)
            {
                Console.WriteLine(item);
            }

        }
        record TenMostExpensiveProductsResults(string TenMostExpensiveProducts, decimal UnitPrice);

        // record with the difficult way (with no primary ctor)
        record Point
        {
            public double X { get; init; }
            public double Y { get; init; }
            public Point(int _x, int _y) => (X, Y) = (_x, _y);
        }

        // record with an easier way (with primary ctor)
        record Pointt(double X, double Y);


        // record struct , record but value type ! 
        record struct Pointtt
        {
        }
    }
}
