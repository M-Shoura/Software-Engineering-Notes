using System.ComponentModel.DataAnnotations;
using System.Net.Security;
using System.Numerics;
using static LINQ___Session_1.ListGenerator;
namespace LINQ___Session_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// "yield" keyword 
			// Read data from files
			// Read data from XML file


			// https://learn.microsoft.com/en-us/dotnet/csharp/linq/
			// https://learn.microsoft.com/en-us/dotnet/csharp/linq/standard-query-operators/

			/* End ******************************************************************************************************************/

			#endregion


			#region Implicitly-typed local variable (var & dynamic)

			/* Start *****************************************************************************************************************/

			// // var & dynamic : can be used with local variables ONLY ( NOT function return type , function parameter, ... )
			// 
			// // Local variable   : Variable declared inside two curly brackets (if condition , loop , ... ) and cannot be used outside these curly brackets
			// // Implicitly-typed : The compiler can detect it's type implicitly based on the initial value
			// 
			// // To make a Implicitly-typed local variable we can use one of the two ways :
			// 
			// // 1 - var keyword :
			// // A C# keyword [C# 3.0 Feature]
			// // Starting from C# 10.0 it can reference a delegate
			// // Compiler can detect the type of the variable based on its initial value at the compilation time 
			// // Can't be initialized with Null , but after initialization can hold null
			// // After initialization, we can't change the variable datatype 
			// // It's type safe and don't affect the performance
			// // we use it for in two reasons : 
			// //    1 - When we don't want to specify the type and writing it (ex: the type is too complicated or large [later in MVC])
			// //    2 - When we want to make an object from Anonymous Type (discussed in next region)
			// 
			// var departmant = "IT";         // automatically knows the type "string"
			// departmant = null;             // Accepted
			// // departmant = 10;            // Error ! cannot change the type after initialization
			// // var departmant = null;      // Error ! must be non-null value in the initialization
			// // var age;                    // Error ! must be initialized with a value  
			// 
			// // starting from C# 10.0 , we can use var with delegates :
			// var Predicate = (int num) =>  num > 0;                  // automatically knows the type "Func<int,bool>" it's the same as Predicate
			// var Action = () => Console.WriteLine("Hello World!");   // automatically knows the type "Action" 
			// 
			// 
			// 
			// 
			// // 2 - dynamic keyword : 
			// // A C# keyword [C# 4.0 Feature]
			// // it's same as var keyword in JavaScript
			// // It's not a must to initialize it
			// // Can be initialized with Null 
			// // It's not type safe , may throw exceptions (because the compiler will skip type checking)
			// // Before the dynamic the C# was strong type language , but with dynamic it may be weakly type language       
			// // Using dynamic keyword affect the performance in a bad way
			// // Compiler will skip the type checking at compilation time 
			// // CLR will resolve the actual type of a dynamic type variable at runtime and will be change based on the assigned value 
			// // After initialization we can change it's datatype 
			// // used in one case : the View Bag (discussed in MVC) to support holding data of different types
			// // Important : why not to use object rather than dynamic ? because this reference will se only the 4 methods of object 
			// //             ex: object emp = new Employee();
			// //             emp.Id = 10;       // Error ! because the reference is from type object
			// //             emp.Name = "Ali";  // Error ! because the reference is from type object
			// //             emp.GetHashCode(); // Accepted 
			// 
			// 
			// dynamic Data;
			// Data = "Shoura";
			// Data = 10;
			// Data = 'a';
			// 
			// 
			// // To sum up : we use the var in most cases because it's type safe and also don't affect the performance
			// 
			// // Example 1 : var vs dynamic
			// // var obj1 = null;           // compilation error , will not run
			// 
			// dynamic obj = null;
			// Console.WriteLine(obj);       // Will throw exception
			// 
			// 
			// 
			// // Example 2 : var vs dynamic (Anonymous Type : Next Region)
			// var emp = new { id = 1, name = "Shoura", salary = 5000 };
			// // emp is of type (`a) ==> anonymous type 
			// Console.WriteLine(emp.id);                // Accepted
			// // Console.WriteLine(emp.age);            // Error ! using var is type safe
			// 
			// dynamic emp2 = new { id = 1, name = "Shoura", salary = 5000 };
			// Console.WriteLine(emp2.id);                // Accepted
			// Console.WriteLine(emp2.age);               // Accepted and will throw exceptions in the runtime

			/* End ******************************************************************************************************************/

			#endregion


			#region Anonymous Type

			/* Start *****************************************************************************************************************/

			// // if we want to make an object from a type that will be used only one time (or small number of times that it's not importnat
			// // to make it as a standalone class or struct), then we will make it as an anonymous type
			// // It is generated in the IL code 
			// 
			// // object Employee = new { id = 1, name = "Shoura", salary = 5000 };
			// // // Console.WriteLine(Employee.id);        // Error ! because the reference is from an object
			// // Console.WriteLine(Employee.ToString());   // Accepted
			// 
			// var Employee1 = new { id = 1, name = "Shoura", salary = 5000 };
			// // can also be dynamic but var is better (type safety & don't affect the performance)
			// // here Employee is (`a) ==> anonymous type of int id , string name , int salary
			// // why salary is int ? if salary = 5000.0 ; then it will be double .. 
			// 
			// Console.WriteLine(Employee1.id);
			// Console.WriteLine(Employee1.GetType());    // AnonymousType0`3     ==> number 0 (first one) and have 3 properties(id , name , salary)
			// Console.WriteLine(Employee1.ToString());   // overriden ==> { id = 1, name = Shoura, salary = 5000 }
			// // means that this is an actual type that is generated and inherits from Object class the 4 methods
			//  
			// // if we reviewed the IL code (by the IL Spy) then we will find that the (id , name , salary) are generic , that's because if we 
			// // created another employee but with a float salary not int as "Employee1" above
			// 
			// var Employee2 = new { id = 1, name = "Shoura", salary = 5000F };
			// Console.WriteLine(Employee2.GetType());    // AnonymousType0`3  also because it has the same signature of the first object "Employee1"   
			// // We mean by the signature : 
			// // 1 - The naming of the properties (Case Sensitive)
			// // 2 - The ordering of the properties 
			// 
			// 
			// var Employee3 = new { Id = 1, name = "Shoura", salary = 5000F };
			// Console.WriteLine(Employee3.GetType());    // AnonymousType1`3    number 1 (second one) because the signature changed (Id not id)
			// 
			// var Employee4 = new { name = "Shoura", Id = 1,  salary = 5000F };
			// Console.WriteLine(Employee4.GetType());    // AnonymousType2`3    number 2 (third one) because the signature changed (different order)
			// 
			// 
			// // The object that will be created from anonymous type is Immutable object (cannot be changed) 
			// // so how to change it ?
			// Employee1 = new { id = 20, name = Employee1.name, salary = Employee1.salary };      // we changed only the id
			// Employee1 = Employee1 with { id = 100 };                     // Syntax Sugar (C# 10.0 Feature)

			/* End ******************************************************************************************************************/

			#endregion


			#region Extension Method

			/* Start *****************************************************************************************************************/

			// // How to provide a new method or behaviour or functionality for a type that I don't have the source code of it ???
			// // ==> Make the method or behaviour or functionality as an Extension for this type :
			// // the parameter will be "this" 
			// // Extension methods can be contained only in Static Classes That are NOT GENERIC
			// 
			// // Ex: IntegerExtensions Class
			// 
			// int x = 12345;
			// 
			// int y = IntegerExtensions.Reverse(x);         // Called as a Static Method
			// y = x.Reverse();                              // Called as a Extension Method
			// 
			// Console.WriteLine(y);
			// 
			// 
			// // Another use case for Extension methods ==> Providing a new method or behaviour or functionality for Many Types not one type
			// // the method can be extension method for a class / interface that these classes inherit / implement 
			// // Ex: LINQ Methods : (Internally are foreach , each method with it's different implementation)
			// //     LINQ Methods can be used with any type that implements the IEnumerable interface

			/* End ******************************************************************************************************************/

			#endregion


			#region What is LINQ ?

			/* Start *****************************************************************************************************************/

			// // First of all : if we are working with a Remote Sequence ==> Linq are Extension methods for IQueryable interface
			// //                if we are working with a Local Sequence ==> Linq are Extension methods for IEnumerable interface

			// // LINQ : Stands for Language-Integrated Query
			// // LINQ : +40 Extension Methods for built-in interface "IEnumerable" because each of the methods is internally a foreach , each with
			// //        a different implementation , methods are named as "LINQ Operators" Existed in "Enumerable" class [Partial Class] , which is found 
			// //        in System.Linq , methods are catigorized in 13 Category (10 Differed , 3 Immediate [discussed in LINQ Execution Ways Region])
			// 
			// // Every select statement in Sql has a statmenet in LINQ
			// 
			// // It's not professional to write SQL code inside C# code because the SQL code is written in one syntax provider (MS sql , My sql , oracle ,..)
			// // so if we changed the database provider then we must re-write All the Sql queries inside the project to follow the syntax of the provider
			// // (tightly-coupled with a database provider)
			// 
			// // We use a ORM to convert our LINQ queries to SQL (To a specific SQL Syntax ==> which EF core package for which provider)
			// // Ex : EFcore.Mysql  ==> Linq to mysql  syntax
			// //      EFcore.Oracle ==> Linq to oracle syntax
			// 
			// // Use Linq operators against Data (Stored in Sequence) , Regardless Data Store (File , Database provider [oracle , Sql server , MySql , .. ])
			// // Sequence : is an object from class that implements "IEnumerable" Interface (Ex: List , HashSet , ArrayList , Dictionary , ... )
			// // We have 2 different  types of sequences : 
			// // 1 - Local Sequence  : Data is static in out application 
			// //                       Linq to Object [L2O] , Linq to XML [L2XML] ==> not converted to SQL  
			// // 2 - Remote Sequence : Data from remote connection (Ex: database) .. will be discussed in Entity Framework later >>>>>> 
			// //                       Linq to Entity Framework [L2EF]  ==> Converted to SQL              
			// 
			// // Ex : Local sequence : 
			// List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			// 
			// List<int> Odds = Numbers.Where((x) => x % 2 == 1).ToList();
			// 
			// foreach (int x in Odds)
			// 	Console.Write($"{x}  ");        
			// 
			// 
			// // Note : in the previous example , the input sequence was "Numbers" List , and the output sequence is "Odds" List 
			// //        Some times we don't have an input sequence , one of the 13 category (Generation operators [Range]) don't have an input sequence
			// //        but provides an output sequence
			// List<int> test = Enumerable.Range(100, 100).ToList();

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ Syntax (Fluent Syntax , Query Syntax)

			/* Start *****************************************************************************************************************/

			// List<int> numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			// 
			// 
			// // 1 - Fluent Syntax (Like C# code Style) : we can call the Linq operator as a static method or an Extension method 
			// 
			// // 1.1 - Call as a Static method through "Enumerable" Class : 
			// var Odds = Enumerable.Where(numbers, (n) => n % 2 == 1);
			// 
			// // 1.2 - Call as an Extension Method [Recommended] : 
			// Odds = numbers.Where((n) => n % 2 == 1);
			// 
			// 
			// 
			// // 2 - Query Syntax  ( Query Expression [Like SQL Server Style] ) : more readable with complex queries
			// //     - Starting with Keyword "from"
			// //     - Introducing range variable "N" : Representing each and every element in the Input sequence 
			// //     - Ends with "select" or "group by" Keywords
			// Odds = from N in numbers
			// 	   where N%2==1
			// 	   select N;

			/* End ******************************************************************************************************************/

			#endregion


			#region LINQ Execution Ways

			/* Start *****************************************************************************************************************/

			// List<int> Numbers = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			// 
			// /*IEnumerable<int>*/ var Odds = Numbers.Where((x) => x % 2 == 1).ToList();
			// Numbers.AddRange(new int[] { 11, 12, 13, 14 });
			// 
			// foreach (int x in Odds)
			// 	Console.Write($"{x}  ");         // 1 3 5 7 9 , without the new added items 
			// Console.WriteLine();
			// 
			// 
			// /*IEnumerable<int>*/ var Evens = Numbers.Where((x) => x % 2 == 0);
			// Numbers.AddRange(new int[] { 15, 16, 17, 18, 19, 20 });
			// 
			// foreach (int x in Evens)
			// 	Console.Write($"{x}  ");         // 2 4 6 8 10 12 14 16 18 20 , with the new added items !!
			// Console.WriteLine();
			// 
			// 
			// // We have 2 types of execution with Linq Operators 
			// // 1 - Differed  : Will NOT Be executed now , Executed when you want to use the output sequence [ IEnumerable type (list , ArrayList , .. )]
			// //                 - Working with the latest version of the data
			// //                 - 10 Categories of the 13 Category are working with Differed Execution
			// // 2 - Immediate : will be executed now , The 3 categories are (Element Operators , Casting Operators , Aggregate Operators)
			// //                 - 3 Categories of the 13 Category are working with Immediate Execution
			// 
			// // If i wanted to use the differd as immediate then use with differed immidiate
			// // (Ex : previous example ==> where (filtration [differed]) with ToList (Casting [immediate]))

			/* End ******************************************************************************************************************/

			#endregion


			#region Data Setup

			/* Start *****************************************************************************************************************/

			// // We will work on a local sequence :
			// // ListGenerator.cs containing : Pre-made
			// // 1 - Product Class 
			// // 2 - Customer Class
			// // 3 - ListGenerator Class ==> has 2 lists (ProductList and CustomerList) , initializes them with data
			// //     - data of ProductList is added manually
			// //     - data of CustomerList is added from a XML file (Customers.xml)
			// 
			// // Important note with XML file : we can put it in any location and then provide the path, or we can put it in the default path of the 
			// //                                project, which is in the "bin" --> "Debug" --> "net7.0 [or the current version]" folder.
			// 
			// // using static LINQ___Session_1.ListGenerator;   // in the first line to avoid writing ex "ListGenerator.ProductList[0]" only "ProductList[0]"
			// 
			// // Testing that the files are working :
			// Console.WriteLine(ProductList[0]);
			// Console.WriteLine(CustomerList[0]);

			/* End ******************************************************************************************************************/

			#endregion


			#region Filtration (Restriction) Operators (Where & OfType)

			/* Start *****************************************************************************************************************/

			// (Where , OfType)

			// *************************** Where (2 Overloads) *****************************************

			// // 1.1 - First Overload that takes Func < T , bool > 
			// 
			// // Ex01 : Get items that are out of stock 
			// // Fluent Syntax:
			// var Result1 = ProductList.Where((p) => p.UnitsInStock == 0); 
			// 
			// // Query Syntax:
			// Result1 = from p in ProductList
			// 		  where p.UnitsInStock == 0
			// 		  select p;
			// 
			// 
			// // Ex02 : Get items that are out of stock and in category "Meat/Poultry"
			// // Fluent Syntax:
			// var Result2 = ProductList.Where((p) => p.UnitsInStock == 0 && p.Category == "Meat/Poultry");
			// 
			// // Query Syntax:
			// Result2 = from p in ProductList
			// 		  where p.UnitsInStock == 0 && p.Category == "Meat/Poultry"
			// 		  select p;
			// 
			// 
			// // 1.2 - Second Overload (Indexed Where) that takes Func < T , int , bool >  ==> Valid only with Fluent syntax
			// 
			// // Ex03 : Get items that are out of stock that are in the first 10 elements ONLY 
			// // Fluent Syntax:
			// var Result3 = ProductList.Where((p,i) => p.UnitsInStock == 0 && i<10);
			// 
			// // Query Syntax: Cannot be done with Query syntax !!
			// 
			// 
			// 
			// // *************************** OfType (1 Overload) *****************************************
			//
			// // 2 - OfType : Valid only with Fluent syntax
			// // it's used when we want to get the elements of a specific type , for example :
			// // if we have a classes Employee , PartTimeEmployee , FullTimeEmployee and we have a List<Employee> AllTypeEmployees; that contains the 3 
			// // types (Employees "Which is the base class" , PartTimeEmployee , FullTimeEmployee), we can use the OfType operator with this list 
			// // "AllTypeEmployees" to get ONLY the FullTimeEmployee
			// // Ex: var result = AllTypeEmployees.OfType<FullTimeEmployee>();
			//
			// // General Note : We have an Operator called "Distinct" , it's categorized as a Filtration Operator , but we will discuss it in the 
			// //                Union Family operators (Set Operators)

			/* End ******************************************************************************************************************/

			#endregion


			#region Transformation (Projection) Operators

			/* Start *****************************************************************************************************************/

			// // (Select , SelectMany , Zip (will be discussed Next Session))
			// 
			// // *************************** Select (2 Overloads) *****************************************
			// 
			// // Select : select only a portion of the input , Ex01 : Input sequence => list of products , output sequence => list of product names
			// // We have 2 overloads , select and the second is Indexed Select 
			// 
			// // First overload : Func < T , TResult >            // TResult because we can return any type 
			// 
			// // Fluent syntax:
			// var Result = ProductList.Select(p => p.ProductName);
			// 
			// 
			// // Query syntax: 
			// Result = from p in ProductList
			// 		 select p.ProductName;
			// 
			// 
			// // Ex02 : select the Id and Name of the products that are in stock only
			// // Note : Take care about the ordering of the operators .... 
			// // Fluent syntax:
			// var Result2 = ProductList.Where(p => p.UnitsInStock > 0)
			// 	                     .Select(p => new { p.ProductID, p.ProductName });          // anonymous type 
			// 
			// // or select it as a string 
			// var Result3 = ProductList.Where(p => p.UnitsInStock > 0)
			// 						 .Select(p => $"{p.ProductID} :: {p.ProductName}");         // string
			// 
			// 
			// // Query syntax: 
			// Result2 = from p in ProductList
			// 		  where p.UnitsInStock > 0
			// 		  select new {p.ProductID , p.ProductName };                                // anonymous type 
			// 
			// // or select it as a string 
			// 
			// Result3 = from p in ProductList
			// 		  where p.UnitsInStock > 0
			// 		  select $"{p.ProductID} :: {p.ProductName}";                               // string
			// 
			// 
			// // Ex03 : select the id and name and price after discount 20% of products that are in stock (don't change in the real data in the list)
			// // Fluent syntax :
			// var Result4 = ProductList.Where(p=>p.UnitsInStock > 0)
			// 	                     .Select(p => new
			// 						 {
			// 							 p.ProductID,
			// 							 p.ProductName,
			// 							 NewPrice = p.UnitPrice * 0.8m,
			// 
			// 						 });
			// 
			// // Query syntax: 
			// Result4 = from p in ProductList
			// 		  where p.UnitsInStock > 0
			// 		  select new
			// 		  {
			// 			  p.ProductID,
			// 			  p.ProductName,
			// 			  NewPrice = p.UnitPrice * 0.8m
			// 		  };
			// 
			// 
			// // Second Overload of Select (Indexed Select) : Func < T , int , TResult >  (Valid only with fluent syntax)
			// 
			// // Ex04 : select the index and the name of the products as an anonymous type
			// 
			// var Result5 = ProductList.Select((p, i) => new
			//                          {
			//                          	index = i,
			//                          	p.ProductName
			//                          });
			// 
			// 
			// // *************************** SelectMany (4 Overload) *****************************************
			// 
			// // SelectMany : we have 4 overloads (first and third will be discussed now , second and forth will be discussed later ... )
			// 
			// // First overload of SelectMany : Func <T , IEnumerable<TResult>> 
			// 
			// // Ex02 : Select the orders of the customers
			// var result1 = CustomerList.Select(c => c.Orders);
			// // Wrong !! , Printed on the console : 
			// // LINQ___Session_1.Order[]
			// // LINQ___Session_1.Order[]
			// //           .
			// //           .
			// // LINQ___Session_1.Order[]
			// 
			// 
			// // so we want to select the orders of the customers as if we select an order ... 
			// // Fluent syntax :
			// var result2 = CustomerList.SelectMany(c => c.Orders);
			// 
			// // Order Id: 10643, Date: 25-Aug-97, Total: 814.50
			// // Order Id: 10692, Date: 03 - Oct - 97, Total: 878.00
			// // Order Id: 10702, Date: 13 - Oct - 97, Total: 330.00
			// //                        .
			// //                        .
			// 
			// // Query syntax : 
			// result2 = from c in CustomerList
			// 		  from o in c.Orders
			// 		  select o;
			// 
			// 
			// // Third overload of SelectMany : Func <T , Enumerable<>> , Func<T , TCollection , TResult>
			// var result3 = CustomerList.SelectMany(c => c.Orders , (Customer, Order) => new { Customer , Order});

			/* End ******************************************************************************************************************/

			#endregion


			#region Ordering Operators (& Reverse)

			/* Start *****************************************************************************************************************/

			// // 1 - Order : use the default comparer (CompareTo function and implement the IComparable interface) or give an object from IComparer 
			// // 2 - OrderDescending : Same as Order
			// // 3 - OrderBy : Takes the column that we want to order by
			// // 4 - OrderByDescending :  Same as OrderBy
			// // 5 - ThenBy : Multiple ordering 
			// // 6 - ThenByDescending : Multiple ordering as the last but Descending
			// // 7 - Reverse 
			// 
			// // var result = ProductList.Order();       // have 2 overloads , use the defualt comparer in the class (Exception if there is not CompareTo)
			// // 									    // second overload : give an object from IComparer Interface
			// // result = ProductList.OrderDescending(); // Same as the previous .....
			// 
			// // Fluent Syntax : 
			// var Result = ProductList.OrderBy(p => p.UnitPrice);               // order by the UnitPrice Ascending
			// Result = ProductList.OrderByDescending(p => p.UnitPrice);         // order by the UnitPrice Descending
			// 
			// 
			// // Query Syntax : 
			// Result = from p in ProductList
			// 		 orderby p.UnitPrice                                      // Ascending
			// 		 select p;
			// 
			// Result = from p in ProductList
			// 		 orderby p.UnitPrice descending                           // Descending
			// 		 select p;
			// 
			// 
			// // What if we want to order based on more that one column ? Ex: if the UnitPrice is equal then order by the UnitsInStock
			// // OrderBy() . OrderBy() ==> wrong !!   ,,, OrderBy() . ThenBy() ==> Right  ... Note (ThenBy or ThenByDescending)
			// Result = ProductList.OrderBy(p => p.UnitPrice).ThenBy(p=>p.UnitsInStock);
			// Result = ProductList.OrderBy(p => p.UnitPrice).ThenByDescending(p=>p.UnitsInStock);
			// 
			// 
			// // Query Syntax : 
			// Result = from p in ProductList
			// 		 orderby p.UnitPrice , p.UnitsInStock                                 
			// 		 select p;
			// 
			// Result = from p in ProductList
			// 		 orderby p.UnitPrice ascending , p.UnitsInStock descending
			// 		 select p;
			// 
			// 
			// // Reversing : Not Valid in Query Expression
			// ProductList.Reverse();  // Returns void , reverse and replace in it's place
			// // With a condition : 
			// var Result1 = ProductList.Where(p => p.UnitsInStock == 0).Reverse();

			// To sum up , we usually use the OrderBy and OrderByDescending because they are more easier in using ... 

			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
