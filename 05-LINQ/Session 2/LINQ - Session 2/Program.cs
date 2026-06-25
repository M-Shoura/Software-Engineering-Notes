using System.Diagnostics.CodeAnalysis;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
using static LINQ___Session_2.ListGenerator;
namespace LINQ___Session_2
{
	class ProductIdEqualityComparer : IEqualityComparer<Product>
	{
		public bool Equals(Product? x, Product? y)
		{
			return x?.ProductID.Equals(y?.ProductID) ?? (y is null ? true : false);
		}

		public int GetHashCode([DisallowNull] Product obj)
		{
			return obj.ProductID.GetHashCode();
		}
	}
	class StringEqualityComparer : IEqualityComparer<String>
	{
		public bool Equals(string? x, string? y)
		{
			return x?.ToLower().Equals(y?.ToLower()) ?? (y is null ? true : false);
		}

		public int GetHashCode([DisallowNull] string obj)
		{
			return obj.ToLower().GetHashCode();
		}
	}
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// CountBy , AggregateBy , Link : https://borakasmer.medium.com/linq-query-features-with-net-9-alpha-d8f74de93f4f
			// links : https://blog.nimblepros.com/blogs/new-linq-apis/
			// links : https://code-maze.com/linq-performance-dotnet7/
			// links : https://pvs-studio.com/en/blog/posts/csharp/1011/

			// casting operators : ToLookUp , ToFrozenDictionary , ToFrozenSet , ToImmutable Family 

			// IEquatable interface 

			// What is a Tuple in C# ?

			// What is LINQPad ? ==> search it's a desktop application ...  

			/* End ******************************************************************************************************************/

			#endregion


			#region Element Operators (Immediate Execution)

			/* Start *****************************************************************************************************************/

			// // Note : Valid Only with Fluent Syntax (We can use Hybrid Syntax discussed in this Region ... )
			// // (First , Last , FirstOrDefault , LastOrDefault , ElementAt , ElementAtOrDefault , Single , SingleOrDefault ,  )
			// 
			// // *************************** First (2 Overloads) *****************************************
			// 
			// var Result = ProductList.First();
			// // Returns the First element in the sequence , and if the sequence is empty then Throw Exception
			// 
			// Result = ProductList.First(p => p.UnitsInStock == 0);
			// // Returns the First element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Throw Exception
			// 
			// 
			// 
			// // *************************** Last (2 Overloads) *****************************************
			// 
			// Result = ProductList.Last();
			// // Returns the Last element in the sequence , and if the sequence is empty then Throw Exception
			// 
			// Result = ProductList.Last(p => p.UnitsInStock == 0);
			// // Returns the Last element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Throw Exception
			// 
			// 
			// 
			// // *************************** FirstOrDefault (4 Overloads) *****************************************
			// 
			// Result = ProductList.FirstOrDefault();
			// // Returns the First element in the sequence , if the sequence is empty then Return default value of the Type of the sequence (ex: null for ref types , 0 for int ,..) 
			// 
			// Result = ProductList.FirstOrDefault(new Product { ProductID = 999 , ProductName = "Default"});
			// // Returns the First element in the sequence , if the sequence is empty then Return the object given as a default ... 
			// 
			// Result = ProductList.FirstOrDefault(p => p.UnitsInStock == 0);
			// // Returns the First element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Return default value of the Type of the sequence (ex: null for ref types , 0 for int ,..) 
			// 
			// Result = ProductList.FirstOrDefault(p => p.UnitsInStock == 0 , new Product { ProductID = 999, ProductName = "Default" });
			// // Returns the First element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Return the object given as a default ... 
			// 
			// 
			// 
			// // *************************** LastOrDefault (4 Overloads) *****************************************
			// 
			// Result = ProductList.LastOrDefault();
			// // Returns the Last element in the sequence , if the sequence is empty then Return default value of the Type of the sequence (ex: null for ref types , 0 for int ,..) 
			// 
			// Result = ProductList.LastOrDefault(new Product { ProductID = 999, ProductName = "Default" });
			// // Returns the Last element in the sequence , if the sequence is empty then Return the object given as a default ... 
			// 
			// Result = ProductList.LastOrDefault(p => p.UnitsInStock == 0);
			// // Returns the Last element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Return default value of the Type of the sequence (ex: null for ref types , 0 for int ,..) 
			// 
			// Result = ProductList.FirstOrDefault(p => p.UnitsInStock == 0, new Product { ProductID = 999, ProductName = "Default" });
			// // Returns the Last element that satisfies a specific condition, and if there is no element that satisfies the condition
			// // (or the sequence is Empty) then Return the object given as a default ... 
			// 
			// 
			// 
			// // *************************** ElementAt (2 Overloads) *****************************************
			// 
			// Result = ProductList.ElementAt(9);
			// // Returns the Element at specific position , and if the position not exist (more than the size) then Throw Exception 
			// 
			// Result = ProductList.ElementAt(new Index (9 , false /*True*/));
			// // Returns the Element at specific position FROM First Of the sequence (index from start) , if the position not exist (more than the size) 
			// // then throw Exception. if it was True then  Returns the Element at this specific position FROM Last Of the sequence (index from last)
			// 
			// // Note : to get a specific element from the last also you can :
			// Result = ProductList.ElementAt(^9);
			// 
			// 
			// 
			// // *************************** ElementAtOrDefault (2 Overloads) *****************************************
			// 
			// Result = ProductList.ElementAtOrDefault(9);
			// // Returns the Element at specific position , and if the position not exist (more than the size) then Return default value of the Type of
			// // the sequence (ex: null for ref types , 0 for int ,..) 
			// 
			// Result = ProductList.ElementAtOrDefault(new Index(9, false /*True*/));
			// // Returns the Element at specific position FROM First Of the sequence (index from start) , if the position not exist (more than the size) 
			// // then Return default value of the Type of the sequence (ex: null for ref types , 0 for int ,..) . if it was True then  Returns the Element
			// // at this specific position FROM Last Of the sequence (index from last)
			// 
			// // Note : to get a specific element from the last also you can :
			// Result = ProductList.ElementAtOrDefault(^9);
			// 
			// 
			// 
			// // *************************** Single (2 Overloads) *****************************************
			// 
			// Result = ProductList.Single();
			// // If Sequence contains ONLY one element then will return that element , else if the sequence contains more than one element or contains
			// // Zero elements (size != 1) then Throw Exception
			// 
			// Result = ProductList.Single(p => p.UnitsInStock == 0); // returns element with UnitsInStock = 0 and if multiple elements(or zero) -> Exception
			// // If Sequence contains ONLY one element that satisfies a specific condition then will return that element , else if the sequence contains
			// // more than one element that satisfies a specific condition or contains Zero elements that satisfies a specific condition (size != 1)
			// // then Throw Exception
			// 
			// 
			// 
			// // *************************** SingleOrDefault (4 Overloads) *****************************************
			// 
			// Result = ProductList.SingleOrDefault();
			// // If Sequence contains ONLY one element then will return that element , else if the sequence contains Zero elements then Return default value
			// // of the Type of the sequence (ex: null for ref types , 0 for int ,..) . and if the sequence contains more than one element then Throws
			// // Exception (violates the meaning of "Single")
			// 
			// Result = ProductList.SingleOrDefault(new Product { ProductID = 999, ProductName = "Default" });
			// // If Sequence contains ONLY one element then will return that element , else if the sequence contains Zero elements then Return the
			// // object given as a default. if the sequence contains more than one element then Throws Exception (violates the meaning of "Single")
			// 
			// Result = ProductList.SingleOrDefault(p => p.UnitsInStock == 0);
			// // If Sequence contains ONLY one element that satisfies a specific condition then will return that element , else if the sequence contains
			// // Zero elements that satisfies a specific condition then Return default value of the Type of the sequence (ex: null for ref types, 0 for int, ..)
			// // and if the sequence contains more than one element that satisfies a specific condition then Throw Exception (violates meaning of "Single")
			// 
			// Result = ProductList.SingleOrDefault(p => p.UnitsInStock == 0 , new Product { ProductID = 999, ProductName = "Default" });
			// // If Sequence contains ONLY one element that satisfies a specific condition then will return that element , else if the sequence contains
			// // Zero elements that satisfies a specific condition then Return the object given as a default . and if the sequence contains more than
			// // one element that satisfies a specific condition then Throw Exception (violates meaning of "Single")
			// 
			// 
			// 
			// // Important : FirstOrDefault VS SingleOrDefault   (Interview Question)
			// // FirstOrDefault  after Convertint to SQL ==> select top(1) from ProductList where id = 1
			// // SingleOrDefault after Convertint to SQL ==> select top(2) from ProductList where id = 1 , Why top(2) ???
			// // because in case we got more than one --> Return Exception .. 
			// 
			// // so we can use the SingleOrDefault with Columns that have unique values to ensure that uniqueness .. 
			// 
			// 
			// // Hybrid Syntax : (QuerySyntax).FluentSyntax
			// // Find the first product out of stock by Query Syntax (Not valid , must write Hybrid Syntax) ==>
			// 
			// var test = ( from p in ProductList
			// 		     where p.UnitsInStock == 0
			// 		     select p ) . FirstOrDefault();
			// 
			// // Note : After using the Element operator FirstOrDefault , this query now is immediate Execution 
			// //        Before using it it was Differed Execution

			/* End ******************************************************************************************************************/

			#endregion


			#region Aggregation Operators (Immediate Execution)

			/* Start *****************************************************************************************************************/

			// // ( Count , TryGetNonEnumeratedCount , Sum , Average , Max , Min , MaxBy , MinBy , Aggregate )
			// // Note : (CountBy , AggregateBy) "Self-Study" from .Net 9
			// 
			// // *************************** Count (2 Overloads) *****************************************
			// 
			// 
			// var Result = ProductList.Count();
			// // Returns the number of elements in the sequence
			// 
			// Result = ProductList.Count;
			// // This is the property .. it's better to use the property (if found) better than using the Extension method because the property
			// // now has the count inside it , but the Extension method will Enumerate and loop to find the count 
			// // ---> The property is not found in all Sequences (Ex: IEnumerable) , so if found it's better to use it 
			// 
			// Result = ProductList.Where(p => p.UnitsInStock == 0).Count();
			// // here we return the count of the out of stock items , and here we don't have the property count so we must use the Extension method
			// // Or we can use the Second overload of Count Extension method
			// 
			// Result = ProductList.Count(p => p.UnitsInStock == 0);
			// 
			// 
			// // [Dot Net 6.0 Feature], there is a new function : TryGetNonEnumeratedCount
			// bool flag = ProductList.TryGetNonEnumeratedCount(out Result);
			// // Returns true if we got the count without Enumerating and looping and successfully returned in the output parameter , and false if 
			// // we couldn't ... How we couldn't ? this function tries to get the count without Enumerating and looping through the sequence , tries 
			// // to take constant time as in the properties .. Works perfect with (ICollection [generic & non-generic] , IIListProvider [Generic])
			// 
			// 
			// 
			// // *************************** Sum (10 Overloads) *****************************************
			// 
			// // The 10 overloads are almost the same , changing only the numeric datatype (int , int? , float , float? , .... )
			// // The types that we can use "Sum" with : (int , int? , long , long? , float , float? , double , double? , decimal , decimal?)
			// 
			// var Result2 = ProductList.Sum(p=>p.UnitPrice);
			// // Returns the sum of the values of the selected attribute or column (ex: in database)
			// 
			// 
			// 
			// // *************************** Average (2 Overloads) *****************************************
			// 
			// // The 10 overloads are almost the same , changing only the numeric datatype (int , int? , float , float? , .... )
			// // The types that we can use "Average" with : (int , int? , long , long? , float , float? , double , double? , decimal , decimal?)
			// 
			// Result2 = ProductList.Average(p => p.UnitPrice);
			// // Returns the average of the values of the selected attribute or column (ex: in database)
			// 
			// 
			// 
			// // *************************** Max (13 Overloads) *****************************************
			// 
			// var MaxElement = ProductList.Max();
			// // Returns the max element (Product) in the sequence , using this overload uses the CompareTo function so we must implement the IComparable
			// // interface (may through exception if there is no default comparer [don't implement IComparable interface in the class])
			// 
			// MaxElement = ProductList.Max(new ProductComparer());
			// 
			// // Returns the max element (Product) in the sequence , using this overload uses the logic in Compare function that is in the object of class
			// // implements IComparer class (PComparer class)
			// 
			// // The next 10 overloads are almost the same , changing only the numeric datatype (int , int? , float , float? , .... )
			// // The types that we can use "Max" with : (int , int? , long , long? , float , float? , double , double? , decimal , decimal?)
			// 
			// var MaxNumber = ProductList.Max(p => p.UnitPrice);
			// // Returns the max value of the selector (unit price only) , example output : 250 
			// 
			// 
			// var MaxName = ProductList.Max(p => p.ProductName);
			// // The last overload is equivilant to the previous 10 overloads because the type is not numerical , but a generic type that can be anything
			// // in our example will return the max name , by using the default comparer with strings (lexicographical order) (ex: name strarting with 'z')
			// 
			// 
			// 
			// // *************************** Min (13 Overloads) *****************************************
			// 
			// var MinElement = ProductList.Min();
			// // Returns the min element (Product) in the sequence , using this overload uses the CompareTo function so we must implement the IComparable
			// // interface (may through exception if there is no default comparer [don't implement IComparable interface in the class])
			// 
			// MinElement = ProductList.Min(new ProductComparer());
			// 
			// // Returns the min element (Product) in the sequence , using this overload uses the logic in Compare function that is in the object of class
			// // implements IComparer class (ProductComparer class)
			// 
			// // The next 10 overloads are almost the same , changing only the numeric datatype (int , int? , float , float? , .... )
			// // The types that we can use "Min" with : (int , int? , long , long? , float , float? , double , double? , decimal , decimal?)
			// 
			// var MinNumber = ProductList.Min(p=>p.UnitPrice);
			// // Returns the min value of the selector (unit price only) , example output : 0 
			// 
			// 
			// var MinName = ProductList.Min(p=>p.ProductName);
			// // The last overload is equivilant to the previous 10 overloads because the type is not numerical , but a generic type that can be anything
			// // in our example will return the min name , by using the default comparer with strings (lexicographical order) (ex: name strarting with 'a')
			// 
			// 
			// 
			// // *************************** MaxBy (2 Overloads) *****************************************
			// 
			// // .Net 6.0 Feature ..... 
			// 
			// // instead of using the first and second overloads of "Max" Extension method , that enforce us to implement the IComparable or
			// // IComparer interfaces ... we could use this : 
			// MaxElement = ProductList.OrderByDescending(p => p.UnitPrice).FirstOrDefault();
			// 
			// // Starting from .net 6 we don't have to implement any interfaces ... 
			// 
			// MaxElement = ProductList.MaxBy(p=>p.UnitPrice);
			// // returns the max element based on the given selector (The selector must implement the IComparable) 
			// 
			// 
			// // Second Overload : 
			// MaxElement = ProductList.MaxBy(p => p.Category , new CategoryComparer ());
			// // Returns the max element (Product) based on the given selector , and the criteria for choosing the max element is given in the class object 
			// // that implements the IComparer interface ... 
			// 
			// 
			// 
			// // *************************** MinBy (2 Overloads) *****************************************
			// 
			// // .Net 6.0 Feature ..... 
			// 
			// // instead of using the first and second overloads of "Min" Extension method , that enforce us to implement the IComparable or
			// // IComparer interfaces ... we could use this : 
			// MinElement = ProductList.OrderBy(p => p.UnitPrice).FirstOrDefault();
			// 
			// // Starting from .net 6 we don't have to implement any interfaces ... 
			// 
			// MinElement = ProductList.MinBy(p => p.UnitPrice);
			// // returns the min element based on the given selector (The selector must implement the IComparable) 
			// 
			// 
			// // Second Overload : 
			// MinElement = ProductList.MinBy(p => p.Category, new CategoryComparer());
			// // Returns the min element (Product) based on the given selector , and the criteria for choosing the min element is given in the class object 
			// // that implements the IComparer interface ... 
			// 
			// 
			// 
			// // *************************** Aggregate (3 Overloads) *****************************************
			// 
			// // our own aggregation function ... 
			// // Maybe now we don't undersand why we need "Aggregate" but it will be more clear when we discuss the "Specification" design pattern
			// // later in the API Course
			// 
			// var names = new List<string> {"Mahmoud","Ahmed","Shoura"};
			// string FullName = names.Aggregate((str1 , str2) => $"{str1} {str2}");  // --> Mahmoud Ahmed Shoura
			// // Applies an accumulator function over a sequence 
			// 
			// 
			// // The second overload is same as the previous one but takes a seed (start value to accumulate on .. )
			// FullName = names.Aggregate("Hello" , (str1 , str2) => $"{str1} {str2}");
			// 
			// 
			// // The third overload is same as the previous one but i can change in the result by any way i want
			// // Ex: replace spaces with '_' , or make the result Lower case .. 
			// FullName = names.Aggregate("Hello", (str1, str2) => $"{str1} {str2}" , (res) => res.Replace(' ','_'));
			// 
			// 
			// // Note : Starting from Dot Net 9.0 , we will have (CountBy , AggregateBy) "Self-Study"

			/* End ******************************************************************************************************************/

			#endregion


			#region Casting (Conversion) Operators (Immediate Execution)

			/* Start *****************************************************************************************************************/

			// // ( ToList , ToArray , ToDictionary , ToHashSet ,.... )
			// 
			// // *************************** ToList (1 Overload) *****************************************
			// 
			// var Result = ProductList.Where(p=>p.UnitsInStock == 0).ToList();
			// // before .ToList() we don't have an actual object in the heap because "Where" is differed execution ... after .ToList() 
			// // we then have an actual object in the heap and we casted the "IEnumerable" to "List" 
			// 
			// 
			// 
			// // *************************** ToArray (1 Overload) *****************************************
			// 
			// Product[] ResultArr = ProductList.Where(p => p.UnitsInStock == 0).ToArray();
			// // Returns an array of products 
			// 
			// 
			// 
			// // *************************** ToDictionary (4 Overloads) *****************************************
			// 
			// Dictionary<long, Product> Dictionary = ProductList.Where(p => p.UnitsInStock == 0).ToDictionary(p => p.ProductID);
			// // First overload returns a dictionary with a specified Key (Selected as ProductId in our example)
			// 
			// 
			// Dictionary<long, Product> Dictionary2 = ProductList.Where(p => p.UnitsInStock == 0)
			// 	                                               .ToDictionary(p => p.ProductID /*, new CustomEqualityComparer()*/);
			// // Second overload returns a dictionary with a specified Key (Selected as ProductId in our example) , with giving an object of a class that
			// // implements the IEqualityComparer That gives another implementation of "Equals" and "GetHashCode" methods for the "Key" --> "ProductId" 
			// // in our example ...
			// 
			// 
			// Dictionary<long, string> Dictionary3 = ProductList.Where(p => p.UnitsInStock == 0).ToDictionary(p => p.ProductID , p=>p.ProductName);
			// // Third overload returns a dictionary with a specified Key (Selected as ProductId in our example) , and a specified value
			// // (not all the object) but a part from it ... 
			// 
			// 
			// Dictionary<long, string> Dictionary4 = ProductList.Where(p => p.UnitsInStock == 0)
			// 												   .ToDictionary(p => p.ProductID , p => p.ProductName /*, new CustomEqualityComparer()*/);
			// // Fourth and last overload returns a dictionary with a specified Key (Selected as ProductId in our example) , and a specified value
			// // (not all the object) but a part from it ...  with giving an object of a class that implements the IEqualityComparer That gives another
			// // implementation of "Equals" and "GetHashCode" methods for the "Key" --> "ProductId" in our example ...
			// 
			// 
			// 
			// // *************************** ToHashSet (2 Overloads) *****************************************
			// 
			// HashSet<Product> HashSet = ProductList.Where(p=>p.UnitsInStock == 0).ToHashSet();
			// // First overload returns a Hash Set 
			// 
			// HashSet<Product> HashSet2 = ProductList.Where(p => p.UnitsInStock == 0).ToHashSet(/*, new CustomEqualityComparer()*/);
			// // Second overload returns a Hash Set , with a custom equality comparer That gives another implementation of "Equals" and "GetHashCode"
			// // methods
			// 
			// 
			// 
			// // *************************** ToImmutable Family *****************************************
			// 
			// var Test = ProductList.Where(p => p.UnitsInStock == 0).ToImmutableList();
			// Test.Add(new Product { ProductID = 1, ProductName = "Test" });
			// 
			// foreach(var x in Test)
			//     Console.WriteLine(x);
			// // We Will notice that the object we added is actually not added in the Immutable object , without any Exceptions .. 
			// 
			// 
			// 
			// // Note : If I will Enumerate only (foreach on the sequence) then it's not important to cast ... but if it's important to enumerate 
			// //        or send this object with a specific type then use the casting operators .

			/* End ******************************************************************************************************************/

			#endregion


			#region Generation Operators

			/* Start *****************************************************************************************************************/

			// // (Range , Repeat , Empty )
			// 
			// // Generation Operators : The only operators that must be called through the "Enumerable" class as Static Methods , that's because
			// //                        we don't have an input sequence ... , Also we cannot write it as a Query Expression 
			// 
			// // *************************** Enumerable.Range (1 Overload) *****************************************
			// 
			// var Result1 = Enumerable.Range(0 , 99);
			// // Takes the start and the count and returns an IEnumerable , (ex: 0 , 1 , 99) (Eorks with int only)
			// 
			// 
			// 
			// // *************************** Enumerable.Repeat (1 Overload) *****************************************
			// 
			// var Result2 = Enumerable.Repeat(new Product { ProductName = "Test" } , 100);
			// var Result3 = Enumerable.Repeat("Shoura", 100);
			// // Takes the object that we want to repeat and the number of Repeating it (The object can be any thing) and the return is an "IEnumerable"
			// // of that object 
			// 
			// 
			// 
			// // *************************** Enumerable.Empty (1 Overload) *****************************************
			// 
			// var Result4 = Enumerable.Empty<Product>();
			// // Returns an empty sequence of the given Type (And it's a must to give a type)

			/* End ******************************************************************************************************************/

			#endregion


			#region Set Operators ( Union Family Operators )

			/* Start *****************************************************************************************************************/

			// // (Union , UnionBy , Concat , Intersect , IntersectBy , Except , ExceptBy , Distinct "Filtration Operator" , DistinctBy "Filtration Operator" )
			// 
			// var Seq1 = Enumerable.Range(0, 100);     // 0...99
			// var Seq2 = Enumerable.Range(50, 100);    // 50...149
			// 
			// // *************************** Union (2 Overloads) *****************************************
			// 
			// var Result = Seq1.Union(Seq2);
			// // Merging with removing Duplicates      // 0..99..149 
			// 
			// 
			// // *************************** Concat (1 Overload) *****************************************
			// 
			// Result = Seq1.Concat(Seq2);
			// // Merging without removing Duplicates   // 0..99 50..149 
			// 
			// 
			// // *************************** Intersect (2 Overloads) *****************************************
			// 
			// Result = Seq1.Intersect(Seq2);
			// // The elements in both sequences        // 50..99
			// 
			// 
			// // *************************** Except (2 Overloads) *****************************************
			// 
			// Result = Seq1.Except(Seq2);
			// // Elements that are in Sequecne 1 and not in Sequence 2          // 0..49
			// 
			// 
			// // *************************** Distinct "Filtration Operator"  (2 Overloads) *****************************************
			// 
			// Result = Result.Distinct();
			// // Remove the Duplicates (Filteration Operator)
			// 
			// 
			// 
			// // Advanced Example : 
			// // using two lists of products : 
			// 
			// var Ex01 = new List<Product>()
			// {
			// 	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
			// 	new Product{ ProductID = 2, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10.0000M, UnitsInStock = 13 },
			// 	new Product{ ProductID = 3, ProductName = "Chef Anton's Cajun Seasoning", Category = "Condiments", UnitPrice = 22.0000M, UnitsInStock = 53 },
			// };
			// 
			// var Ex02 = new List<Product>()
			// {
			// 	new Product{ ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18.00M, UnitsInStock = 100},
			// 	new Product{ ProductID = 2, ProductName = "Uncle Bob's Organic Dried Pears", Category = "Produce", UnitPrice = 30.0000M, UnitsInStock = 15 },
			// 	new Product{ ProductID = 3, ProductName = "Northwoods Cranberry Sauce", Category = "Condiments", UnitPrice = 40.0000M, UnitsInStock = 6 },
			// 	new Product{ ProductID = 4, ProductName = "Mishi Kobe Niku", Category = "Meat/Poultry", UnitPrice = 97.0000M, UnitsInStock = 29 },
			// };
			// 
			// // *************************** Union (2 Overloads) *****************************************
			// 
			// // First Overload : 
			// var Res = Ex01.Union(Ex02);
			// // Merging with removing the duplicates 
			// // but how we know that this two products are the same ?? We've overrided the "Equals" and "GetHashCode" methods inside the 
			// // Product class .. so the products are the same if they have the same values inside . But If the functions are not overriden then
			// // it will compare based on the reference of the objects which is not accurate in our case 
			// 
			// 
			// // Second Overload : 
			// Res = Ex01.Union(Ex02 , new ProductIdEqualityComparer() );
			// // Takes Object from class that implements the IEqualityComparer interface , to provide another way for knowing if the products are the
			// // same or not .. in the ProductIdEqualityComparer , the products are the same if they have the same id ... 
			// 
			// 
			// 
			// // *************************** UnionBy (2 Overloads) *****************************************
			// 
			// 
			// // Note : We can achieve the same result as the second overload without making a class that implements the IEqualityComparer , by 
			// //        using "UnionBy" ===> 
			// 
			// Res = Ex01.UnionBy(Ex02, p => p.ProductID);
			// // The products are the same if they have the same ProductID only (KeySelector)
			// 
			// Res = Ex01.UnionBy(Ex02, p => new { p.ProductID, p.ProductName });
			// // The products are the same if they have the same ProductID and ProductName (KeySelectors)
			// 
			// // What will happen if the KeySelector is another type that don't override the "Equals" and "GetHashCode" methods or we want to
			// // provide another implementation for them ????
			// 
			// 
			// // Use the second overload of UnionBy : 
			// Res = Ex01.UnionBy(Ex02, p => p.Category /*, IEqualityComparer object*/ );
			// // The products are the same if they have the same category (KeySelectors) , and we know that the categories are Equal
			// // by the implementation written inside the class that we provided an object from "object"
			// 
			// 
			// // *************************** Intersect (2 Overloads) *****************************************
			// 
			// 
			// Res = Ex01.Intersect(Ex02);
			// // Get the intersect (same products in the two sequences) , but how they are the same ??
			// // By using the Equal and GetHashCode that are overriden in the class (in our case the products are the same if they
			// // have the same state or values inside)
			// 
			// Res = Ex01.Intersect(Ex02 /*, IEqualityComparer object*/ );
			// // Get the intersect (same products in the two sequences) , but how they are the same ??
			// // By using the implementation for "Equals" and "GetHashCode" written inside the class that we provided an object from "object"
			// // ex : We can make intersect based on the same price , so "Res" will contain ONE of the products that have the same price in the
			// // two sequences .. because we intersect based on the price ... (Not a Real example)
			// 
			// 
			// // *************************** IntersectBy (2 Overloads) *****************************************
			// 
			// 
			// // Note : We can achieve the same result as the second overload without making a class that implements the IEqualityComparer , by 
			// //        using "IntersectBy" ===> 
			// 
			// Res = Ex01.IntersectBy(Ex02.Select(x => x.UnitPrice) , p=>p.UnitPrice);
			// // Very important note : it will not work as in UnionBy !! because it's more flexible here , the "p=>p.UnitPrice" is for the first sequence
			// // "Ex01" , and we must determine the property for the other Sequence "Ex02" .. this is flexible because we can determine that the products 
			// // are the same by different properties .... (Maybe Not a Real example)
			// 
			// // Second Overload 
			// Res = Ex01.IntersectBy(Ex02.Select(x => x.UnitPrice), p => p.UnitPrice /*, IEqualityComparer object*/);
			// 
			// 
			// 
			// // *************************** Except (2 Overloads) *****************************************
			// 
			// Res = Ex01.Except(Ex02);
			// // using the implementation of "Equals" and "GetHashCode" that are default or imlemented inside the class
			// 
			// // Second Overload 
			// Res = Ex01.Except(Ex02 /*, IEqualityComparer object*/ );
			// // using the implementation of "Equals" and "GetHashCode" that are in the object given from a class implementes IEqualityComparer
			// 
			// 
			// 
			// // *************************** ExceptBy (2 Overloads) *****************************************
			// 
			// Res = Ex01.ExceptBy(Ex02.Select(x => x.UnitPrice) , p=>p.UnitPrice);
			// 
			// // Second Overload 
			// Res = Ex01.ExceptBy(Ex02.Select(x => x.UnitPrice), p => p.UnitPrice /*, IEqualityComparer object */);
			// 
			// 
			// // *************************** Distinct "Filtration Operator"  (2 Overloads) *****************************************
			// 
			// Res = Ex01.Distinct();
			// 
			// // Second Overload 
			// Res = Ex01.Distinct( /* IEqualityComparer object */ );
			// 
			// 
			// 
			// // *************************** DistinctBy "Filtration Operator"  (2 Overloads) *****************************************
			// 
			// Res = Ex01.DistinctBy(p=>p.ProductID);
			// // returns the distict elements , but only distinct by the "ProductID" , Ex: if we have 5 products with the same productID but with
			// // different values in other fields , then only one of them will appear .. but if we use the Distinct first overload the all 5
			// // Products will appear because NOT all values are the same and they have different states 
			//
			// // Second Overload 
			// Res = Ex01.DistinctBy(p => p.ProductID /* IEqualityComparer object */ );

			/* End ******************************************************************************************************************/

			#endregion


			#region Quantifier Operators - Return Boolean Value

			/* Start *****************************************************************************************************************/

			// // (Any , All , Contains , SequenceEqual , )
			// 
			// // *************************** Any (2 Overloads) *****************************************
			// 
			// Console.WriteLine(ProductList.Any());
			// // Determines if the sequence has any element or not (length >=1) ==> true , else ==> Flase
			// 
			// 
			// Console.WriteLine(ProductList.Any(p=>p.ProductID == 100));
			// // Determines if the sequence has any element satisfied the condition or not (Matching Element)
			// 
			// // Note : The last overload of "Any" is the same as "Exists" method in the list methods , It's a must to use "Any" if the Sequence
			// //        is remote (Database) because "Any" is translated to SQL , but if it's a local sequence then we can use both of them
			// 
			// 
			// 
			// // *************************** All (1 Overload) *****************************************
			// 
			// Console.WriteLine(ProductList.All(p=>p.UnitPrice >= 1000));
			// // Determines if All the sequence elements satisfies the condition or not 
			// 
			// // Note : "All" is the same as "TrueForAll" method in the list methods , It's a must to use "All" if the Sequence is remote (Database)
			// //         because "All" is translated to SQL , but if it's a local sequence then we can use both of them
			// 
			// 
			// 
			// // *************************** Contains (2 Overloads) *****************************************
			// 
			// // First overload is the method in the list , it's the same as the second overload which is the first extension method overload .. 
			// Console.WriteLine(ProductList.Contains(new Product { ProductID = 5 , ProductName = "SearchTest"}));
			// // Determines if the sequence contains that element or not 
			// 
			// // third overload : 
			// Console.WriteLine(ProductList.Contains(new Product { ProductID = 5, ProductName = "SearchTest" } /* , IEqualityComparer object */));
			// // Determines if the sequence contains that element or not , with an obejct of a class thet implements the IEqualityComparer with
			// // different implementation for the "Equal" and "GetHashCode" methods ... 
			// 
			// 
			// 
			// // *************************** SequenceEqual (2 Overloads) *****************************************
			// 
			// var Seq01 = Enumerable.Range(0, 100);
			// var Seq02 = Enumerable.Range(0, 100);
			// 
			// Console.WriteLine(Seq01.SequenceEqual(Seq02));         // True because they are the same now 
			// 
			// // if the two sequences are of type "Product" for example , then the default equality comparer is checking the reference 
			// // but if we provided a new implementation for the "Equal" and "GetHashCode" methods then we will use them .. or we can 
			// // use the Second overload of SequenceEqual , providing an object of a class thet implements the IEqualityComparer with
			// // different implementation for the "Equal" and "GetHashCode" methods ... 
			// 
			// Console.WriteLine(Seq01.SequenceEqual(Seq02/* , IEqualityComparer object */ ));

			/* End ******************************************************************************************************************/

			#endregion


			#region Transformation Operators - Zip (Continued from last session)

			/* Start *****************************************************************************************************************/

			// *************************** Zip (3 Overloads) *****************************************

			// var words = new string[] { "Ten", "Twenty", "Thirty" };
			// var numbers = new List<int> { 10 , 20 , 30 , 40 };
			// 
			// var Result = numbers.Zip(words);
			// // Returns an IEnumerable of Tuple with a length of the smallest Sequence ==> (10,Ten)
			// //                                                            (20,Twenty)
			// //                                                            (30,Thirty)
			// 
			// // Note : Result has the smallest length .. so number "40" is declined 
			// 
			// 
			// // The second overload : The same as the first but with another sequence 
			// var Result2 = numbers.Zip(words , new string[] { "V" , "VI" } );
			// // Note : Result2 has the smallest length between the Sequences .. 
			// 
			// 
			// // The Third overload : same as the first one but with choosing the result as we want (not a tuple but as we want .. )
			// var Result3 = numbers.Zip(words , (num , word) => $"Number : {num} = Word : {word}");

			/* End ******************************************************************************************************************/

			#endregion


			#region Grouping Operators - GroupBy

			/* Start *****************************************************************************************************************/

			// // ( GroupBy , Chunk)
			// 
			// // Grouping may be easier when written in Query syntax :)
			// // Query Syntax :
			// var result = from P in ProductList
			// 			 group P by P.Category;
			// 
			// 
			// // Fluent Syntax :
			// result = ProductList.GroupBy(p => p.Category);
			// 
			// // Result now --> IEnumerable of IGrouping
			// 
			// foreach (var group in result)
			// {
			// 	Console.WriteLine(group.Key);        // Categories
			// 	foreach (var product in group)
			// 	{
			// 		Console.WriteLine($".... {product}");
			// 	}
			// }
			// Console.WriteLine("\n");
			// 
			// // Another Example :
			// // Query Syntax : 
			// var Result = from P in ProductList
			// 			 where P.UnitsInStock > 0
			// 			 group P by P.Category
			// 			 into PrdGroup
			// 			 where PrdGroup.Count() > 10         // This where is translated to Sql as "Having" 
			// 			 select new { Category = PrdGroup.Key, cnt = PrdGroup.Count() };
			// 
			// 
			// // Fluent Syntax :
			// Result = ProductList.Where(p => p.UnitsInStock > 0).GroupBy(p => p.Category).Where(PrdGroup => PrdGroup.Count() > 10)
			// 					.Select(PrdGroup => new { Category = PrdGroup.Key, cnt = PrdGroup.Count() });
			// 
			// 
			// foreach (var item in Result)
			// {
			// 	Console.WriteLine(item);
			// }
			//
			// 
			// // *************************** GroupBy (8 Overloads) *****************************************
			// 
			// 
			// var Result01 = ProductList.GroupBy(p => p.Category);
			// // Grouped by the Key Selector (ex: Category here in the example) , uses the default equality comparer 
			// 
			// var Result02 = ProductList.GroupBy(p => p.Category, new StringEqualityComparer());
			// // Grouped by the Key Selector , with different implementation for "Equal" and "GetHashCode" methods , given in the object 
			// // from class StringEqualityComparer which implements the IEqualityComparer interface .. in this implementation we will group 
			// // the elements of the same group , and we are not Case Sensitive (Ex: "Drinks" and "drinks" are in the same category)
			// 
			// var Result03 = ProductList.GroupBy(p => p.Category, p => new { p.ProductID, p.ProductName });
			// // Takes a Key Selector (default equality comparer) and an Element Selector (Choose what elements we want from the Product .. )
			// 
			// var Result04 = ProductList.GroupBy(p => p.Category, (category , product) => $"{category} : {product.Count()}");
			// // Takes a Key Selector (default equality comparer) and a Result Selector (Choose what is the result we want to be shown)
			// 
			// var Result05 = ProductList.GroupBy(p=>p.Category , p=>new {p.ProductID, p.ProductName} , new StringEqualityComparer());
			// // Takes a Key Selector (with different implementation for "Equal" and "GetHashCode" methods , given in the object 
			// // from class StringEqualityComparer which implements the IEqualityComparer interface) and an Element Selector
			// // (Choose what elements we want from the Product .. )
			// 
			// var Result06 = ProductList.GroupBy(p => p.Category, (category, product) => $"{category} : {product.Count()}", new StringEqualityComparer());
			// // Takes a Key Selector (with different implementation for "Equal" and "GetHashCode" methods , given in the object 
			// // from class StringEqualityComparer which implements the IEqualityComparer interface) and a Result Selector
			// // (Choose what is the result we want to be shown)
			// 
			// var Result07 = ProductList.GroupBy(p => p.Category, p => new { p.ProductID, p.ProductName },
			// 									(category, product) => $"{category} : {product.Count()}");
			// // Takes a key selector , element selector ( Choose what elements we want from the Product .. ) ,
			// // and a result selector ( Choose what is the result we want to be shown )
			// 
			// var Result08 = ProductList.GroupBy(p => p.Category, p => new { p.ProductID, p.ProductName },
			// 									(key, products) => new { category = key , product = products } , new StringEqualityComparer());
			// // Takes a key selector (with different implementation for "Equal" and "GetHashCode" methods ,
			// // given in the object from class StringEqualityComparer which implements the IEqualityComparer interface) ,
			// // element selector ( Choose what elements we want from the Product .. ) ,
			// // and a result selector ( Choose what is the result we want to be shown )
			// 
			// foreach (var item in Result08)
			// {
			// 	 Console.WriteLine($"{item.category} : {item.product.Count()}" );
			// 
			// 	// Console.WriteLine($"{item} : {item.Count()}");
			// 	foreach(var x in item.product)
			// 	{
			//         Console.WriteLine($"... {x}");
			//     }
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Grouping Operators - Chunk

			/* Start *****************************************************************************************************************/

			// // it's a .NET 6.0 Feature 
			// 
			// // *************************** Chunk (1 Overload) *****************************************
			// 
			// var Fruits = new string[] { "Banana", "Pear", "Apple", "Orange", "Plum", "Lemon", "Grapes" };
			// var chunks = Fruits.Chunk(3);           // Max size of the chunk is 3
			// 
			// foreach (var chunk in chunks)
			// {
			// 	foreach (var item in chunk)
			//         Console.Write($"{item}\t");
			// 	Console.WriteLine();
			// }

			/* End ******************************************************************************************************************/

			#endregion


			#region Partitioning Operators

			/* Start *****************************************************************************************************************/

			// // (Take , TakeLast , Skip , SkipLast , TakeWhile , SkipWhile)
			// 
			// // Partitioning Operators are mainly used in Pagination , (ex: showing some products only in the page of an E-Commerce app)
			// 
			// 
			// // *************************** Take (2 Overloads) *****************************************
			// 
			// var Result = ProductList.Where(p => p.UnitsInStock > 0).Take(3);
			// // Takes the first 3 of the products in Stock 
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).Take(new Range(0,5));   // Object from Range struct
			// // Takes a range of the products in Stock , starting from index 0 to 5 
			// 
			// 
			// 
			// // *************************** TakeLast (1 Overload) *****************************************
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).TakeLast(3);
			// // Takes the Last 3 of the products in Stock 
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).Take(^3..);      
			// // Take last 3 only , same as "TakeLast"
			// 
			// 
			// 
			// // *************************** Skip (1 Overload) *****************************************
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).Skip(3);      // All the products without the first 3 
			// // Skips the first 3 and takes after them till the end (fromm index 2 to the last index of products that are in stock)
			// 
			// 
			// 
			// // *************************** SkipLast (1 Overload) *****************************************
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).SkipLast(3);  // All the products without the last 3 
			// 																  // Takes from the first till the last 3 , skip them .. (from index 0 to index = length - 3)
			// 
			// 
			// // *************************** TakeWhile (2 Overloads) *****************************************
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).TakeWhile(p => p.UnitPrice <= 100);
			// // Takes until we find a product that UnitPrice is > 100 , it's not included in the result ... 
			// 
			// 
			// // Second overload : Indexed TakeWhile
			// 
			// List <int> Test1 = new List<int>() { 5 , 4 , 1 , 3 , 9 , 6 , 7 , 2 , 12 };
			// var TestRes1 = Test1.TakeWhile((p, index) => p > index);
			// // it will take 5 because 5 is greater than index 0 , and will take 4 because 4 is greater than 1 ,
			// // and will stop here because 1 is less than index 2
			// 
			// 
			// 
			// // *************************** SkipWhile (2 Overloads) *****************************************
			// 
			// Result = ProductList.Where(p => p.UnitsInStock > 0).SkipWhile(p => p.UnitPrice <= 100);
			// // Starts taking all , when we find a product with UnitPrice > 100 
			// 
			// // Second overload : Indexed SkipWhile
			// List<int> Test2 = new List<int>() { 5, 4, 1, 3, 9, 6, 7, 2, 12 };
			// var TestRes2 = Test2.SkipWhile((p, index) => p % (index+1) == 0);
			// // it will skip 5 because 5%1 == 0 , and will skip 4 because 4%2 ==0 , and will start taking from 1 because 1%3 != 0 , and will take
			// // to the end of the list regardless the modulus operation ... 
			// 
			// 
			// 
			// 
			// // Important Example : 
			// var Numbers = Enumerable.Range(1, 100);
			// 
			// int PageSize = 10 , PageNumer = 4;
			// 
			// var ViewToUser = Numbers.Skip((PageNumer - 1) * PageSize).Take(PageSize);
			// 
			// foreach(var item in ViewToUser)
			//     Console.WriteLine(item);

			/* End ******************************************************************************************************************/

			#endregion


			#region Let & Into in Query Syntax

			/* Start *****************************************************************************************************************/

			// // Let and Into are used to solve the problem in writing the Query Expression , what is the problem ??
			// // The query ends by a "select" or by a "group by" , what if we want to continue ?
			// 
			// // Ex : we have a list of names and we want to edit the names and remove the "Vowel" characters ==> aeiouAEIOU 
			// //      and then print the names that have length more than 3 only
			// 
			// List<string> names = new List<string>() { "Ali" , "Mahmoud" , "Ahmed" , "Nady"};
			// 
			// // Query Syntax : Using into
			// var Result = from N in names
			// 			 select Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
			// 			 // where           // we cannot write where again here !!
			// 			 // Restarting the Query with introducing New Range Variable "NewNamesWithoutVowel"
			// 			 into NewNamesWithoutVowel
			// 			 where NewNamesWithoutVowel.Length > 3
			// 			 select NewNamesWithoutVowel;
			// 
			// // Query Syntax : Using let
			// Result = from N in names
			// 			 let NewNamesWithoutVowel = Regex.Replace(N, "[aeiouAEIOU]", string.Empty)
			// 		     // Continue the Query with Added Range variable "NewNamesWithoutVowel" 
			// 		     where NewNamesWithoutVowel.Length > 3
			// 		     select NewNamesWithoutVowel;
			// 
			// // It's the same with Group by ... Ex =>
			// 
			// var Res = from p in ProductList
			// 		  group p by p.Category
			// 		  into newTable
			// 		  select new { key = newTable.Key, count = newTable.Count() };
			// 
			// 
			// 
			// 
			// // In Fluent Syntax :
			// Result = names.Select(n => Regex.Replace(n, "[aeiouAEIOU]", string.Empty)).Where(p=>p.Length>3);

			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
