using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Advanced_C____Session_2
{
	internal class Program
	{
		class EmployeeEqualityComparer : IEqualityComparer
		{
			public new bool Equals(object? x, object? y)
			{
				string? s1 = x as string;
				string? s2 = y as string;

				return s1?.ToLower().Equals(s2?.ToLower()) ?? s2 is null ? true : false;
			}

			public int GetHashCode(object obj)
			{
				string? s = obj as string;

				return s?.ToLower().GetHashCode() ?? 0;
			}
		}

		class GenericEmployeeEqualityComparer : IEqualityComparer<string>
		{
			public bool Equals(string? x, string? y)
			{
				return x?.ToLower().Equals(y?.ToLower()) ?? y is null ? true : false;
			}

			public int GetHashCode([DisallowNull] string obj)
			{
				return obj?.ToLower().GetHashCode() ?? 0;
			}
		}

		class StringComparer : IComparer<string>
		{
			// To sort descending 
			public int Compare(string? x, string? y)
			{
				return y?.CompareTo(x) ?? (x is null ? 0 : 1);
			}
		}

		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// Links : https://medium.com/@priyanshuparate/what-is-use-of-gethashcode-and-why-we-should-give-the-correct-implementation-to-it-in-c-2187654a3927
			//         https://medium.com/@lifei.8886196/sorted-data-structure-in-c-an-introduction-to-sorteddictionary-sortedlist-and-sortedset-19a69fe184e0


			/* End ******************************************************************************************************************/

			#endregion


			#region Non-Generic Collections [Hash Tables --> Hash Table]

			/* Start *****************************************************************************************************************/

			// // Hash Table : A collection of key - value pairs , organized with the HashCode of the key (key must be unique)
			// // ex: Remember the Phone book example when discussing the indexer in OOP , it could be implemented with a hash table !
			// //     key ==> Name , value ==> phone number
			// 
			// // A Hash table is found in System.Collections , it's Non-Generic .. The Generic version is called ==> Dictionary (discussed next region)
			// // The Hashtable is internally ==> Number of buckets , every bucket holds some key - value pairs
			// // This helps in retrieving , adding , deleting because we don't search among all the pairs but the specific bucket which contains at maximum 
			// // five (5) key - value pairs .. so it's O(1)
			// 
			// Hashtable Note = new Hashtable() { { "xyz", 0000 }, { "abc", 111 } };
			// // Note.Add( /* object , object? */ );      // use objects , it's before generics !  also the key cannot be null , but the value can be null
			// Note.Add("Mahmoud", 123);                   // 123 --> boxing into an object 
			// Note.Add("Ahmed", 456);
			// Note.Add("Shoura", 789);
			// 
			// 
			// // Adding : 
			// // Note.Add("Shoura", 00000);               // So this is UnSafe code and may throw exception
			// 
			// if (!Note.ContainsKey("Shoura"))            // This is Safe code
			// 	Note.Add("Shoura", 00000);
			// else
			// 	Note["Shoura"] = 00000;                  // updating
			// 
			// 
			// // Getting : 
			// // We have an indexer in the hash table :
			// Console.WriteLine(Note["Shoura"]);        // 789
			// Console.WriteLine(Note["Ali"]);           // Null (in the generic version "Dictionary" it throws exception)
			// 
			// if (Note.ContainsKey("Ali"))
			// 	Console.WriteLine(Note["Ali"]);
			// 
			// 
			// 
			// foreach (DictionaryEntry d in Note)
			// 	Console.WriteLine($"{d.Key} :: {d.Value}");
			// 
			// foreach(string a in Note.Keys)
			//     Console.WriteLine(a);
			// 
			// foreach (int b in Note.Values)
			// 	Console.WriteLine(b);
			// 
			// // Important note : When runnig the program multiple times , we notice that the hash table elements are not displayed by the same ordering every 
			// // time .. That's because when adding a new key - value pair in the hash table , the CLR uses the GetHashCode method of the (Key) which is a
			// // string in our case , the GetHashCode of the strings geenrates a value based on the address (the place the object is stored in the memory) 
			// // ofcourse in multiple runs of the program the string will not be in the same address at the memory , so the GetHashCode method every time
			// // generates a different hash code for every key in the hash table .. (in Int class , the GetHashCode method is overrifen to generate a hash code
			// // based on the value , but the default implementation in "Object" class is to generate a hash code based on the address in the memory)
			// 
			// 
			// // Note.Add("Shoura", 9999);          // Exception , Item has already been added .. because the key is present in the hash table now
			// // important : if we have string s1 = "Shoura" , s2 = "Shoura" ; then the two references s1 and s2 will reference the same address at the memory
			// // so GetHashCode method for the two references will generate the same hash code , and because the key must be unique then we couldn't add the
			// // two references in the hash table 
			// // here : if (NewAdded.Equals(AnyOfLastAdded) == true) throw exception;  
			// // Equals method internally uses the GetHashCode method , remember last sessions when we discusses overriding Equals method , the CLR generated
			// // a warning to override the GetHashCode method also ....
			// 
			// // To sum up , the Hash Table relies on [ Equals() and GetHashCode() ] methods , for the Type of the Key , so if the key is a user defined class
			// // or struct then we must override these two methods to ensure that they work properly and produces the wanted results 
			// 
			// // From the documentation of the class : Objects used as keys in a hashtable must implement the GetHashCode and Equals methods
			// // (or they can rely on the default implementations inherited from Object if key equality is simply reference equality).
			// 
			// // Ex: if the key of the hash table is Employee class for example , then we must override the Equals and GetHashCode methods of this class 
			// //     to ensure that no multiple keys with the same data [values] exist in the hash table .. (uniquness)
			// 
			// // From the documentation of the class : the GetHashCode and Equals methods of a key object must produce the same results given the 
			// // same parameters for the entire time the key is present in the hashtable. In practical terms, this means that key objects should be 
			// // immutable, at least for the time they are used as keys in a hashtable.
			// 
			// // Means that we must not change in the key by any way at least for the time they are used as keys in a hashtable , to ensure that if we want 
			// // the value stored in the hash table of that key we can use the key (which we have not changed ... )
			// 
			// Note.Add("shoura",0000);
			// // Will not throw exception , because the key that is stored in the hash table is "Shoura" so we could add "shoura" with small letter "s"
			// // that's because they produce different hash codes , because thay are stored in different addresses in the memory ("Shoura" and "shoura"
			// // are not identical) ... so how to solve this problem ?? ==> We will find that the constrictor of the Add() method has 15 overloads , one of
			// // them takes an object of "IEqualityComparer" .. implement the Equals and GetHashCode as you want now
			// 
			// Hashtable hashtable = new Hashtable(new Program.EmployeeEqualityComparer());
			// hashtable.Add("shoura",000);
			// // hashtable.Add("Shoura",999);      // Will Throw exception 

			/* End ******************************************************************************************************************/

			#endregion


			#region Generic Collections [Hash Tables --> Dictionary]

			/* Start *****************************************************************************************************************/

			// // The dictionary is the Generic version of the Hash Table (collection of key - value pairs) , so we can choose key and value type
			// // same as the Hash table , the dictionary uses the Equals and the GetHashCode methods .. 
			// // The dictionary is internally an Array of "Entry" , each entry is a (TKey , TValue) 
			// // The struct Entry is defined inside the class "Dictionary", so we can make a type inside a type (Nested Types => ex: struct inside a class)
			// 
			// Dictionary<string, int> Note = new Dictionary<string, int>() { { "abc",000} , {"xyz",999 } };
			// 
			// Note.Add("Mahmoud", 123);
			// Note.Add("Ahmed", 456);
			// Note.Add("Shoura", 789);
			// 
			// 
			// // Adding :
			// // Unsafe code , Error ! the key must be unique [may throws exception]
			// // Note.Add("Ahmed", 00000);  
			// 
			// // Protective code 
			// if (!Note.ContainsKey("Ahmed"))
			// 	Note.Add("Ahmed", 00000);
			// else
			// 	Note["Ahmed"] = 00000;         // Updating 
			// 
			// // Other protective code 
			// bool bo = Note.TryAdd("Ahmed", 00000);      // True if added and false if not
			// if(!bo)
			// 	Note["Ahmed"] = 00000;         // Updating 
			// 
			// 
			// // Getting : 
			// // Unsafe code ,[may throws exception]
			// // Console.WriteLine(Note["Bro"]);        // in Dictionary it Throws Exception , in hash table it returns null without exception
			// 
			// // Protective Code :
			// if (Note.ContainsKey("Bro"))
			// 	Console.WriteLine(Note["Bro"]);
			// 
			// // Other protective code 
			// bool flag = Note.TryGetValue("Bro", out int val);
			// 
			// 
			// 
			// foreach (KeyValuePair<string,int> person in Note)
			// 	Console.WriteLine($"{person.Key} :: {person.Value}");
			// 
			// foreach(string a in Note.Keys)
			// 	Console.WriteLine(a);
			// 
			// foreach (int b in Note.Values)
			// 	Console.WriteLine(b);
			// 
			// 
			// // We have 8 Constructors in the dictionary , the main of them : 
			// // The parameterless constructor : initializes the capacity with Zero 0 , and The CLR uses the default implementation of Equals and GetHashCode
			// //                                 methods (default equality comparer) of the Keys
			// // Ctor that takes a number to initialize the capacity with 
			// // Ctor that takes an object from Equality Comparer (the generic version)
			// // Ctor that takes a IDictionary <Tkey,Tvalue> to copy the elements in it inside the new dictionary (hash table , dictionary , ... )
			// // Ctor that takes a IEnumerable <KeyValuePair<Tkey,Tvalue>> to copy the elements in it inside the new dictionary (list , array , ... )
			// 
			// Note.Add("ahmed", 8989);       
			// // Will be added, because "Ahmed" and "ahmed" are not the same , to solve this problem : use the ctor that takes an object from Equality Comparer 
			// // (the generic version) :
			// Dictionary<string,int> dictionary = new Dictionary<string, int>(new Program.GenericEmployeeEqualityComparer());
			// dictionary.Add("ahmed", 000);
			// // dictionary.Add("Ahmed", 000);   // Throws Exception because we used the GenericEmployeeEqualityComparer class 
			// 
			// int cnt = Note.Count();
			// Note.Clear();                              // Removes all the keys and values from the dictionary
			// Note.ContainsKey("Shoura");                // True if found and false otherwise 
			// Note.ContainsValue(0000);                  // True if found and false otherwise 
			// Note.Remove("Ahmed");                      // Removes the given key from the dictionary
			// Note.Remove("Ahmed", out int value);       // Removes the given key from the dictionary and gives the value of it to the output parameter
			// // And other ...

			/* End ******************************************************************************************************************/

			#endregion


			#region Generic Collections --> Sorted Dictionary [BST]

			/* Start *****************************************************************************************************************/

			// // The sorted dictionary is internally a Binary Search Tree , so the key - value pairs are ordered by the Key (on't use Hashing)
			// // To insert or remove it takes : O(log n)
			// // Sorted Dictionary --> Key - Value pair as any dictionary , keys MUST be unique
			// // When to use the Sorted Dictionary ? when we want the key - value pairs to be ordered based on the Key
			// 
			// SortedDictionary<string, int> Note = new SortedDictionary<string, int>() { { "xyz", 0000 } };
			// Note.Add("Mahmoud", 123);
			// Note.Add("Ahmed", 456);
			// Note.Add("Shoura", 789);
			// 
			// 
			// foreach (KeyValuePair<string, int> person in Note)
			// 	Console.WriteLine($"{person.Key} :: {person.Value}");
			// 
			// foreach (string a in Note.Keys)
			// 	Console.WriteLine(a);
			// 
			// foreach (int b in Note.Values)
			// 	Console.WriteLine(b);
			// 
			// 
			// // We will notice that the elements inside the sorted dictionary are sorted based on the key , which is a string .. and the ordering is
			// // ascending because the default implementation for CompareTo Function is to sort ascending .. To change the ordering : make a class that will
			// // implement the IComparer interface and will have it's own implementation of Compare function .. 
			// 
			// SortedDictionary<string, int> Dict = new SortedDictionary<string, int>(new StringComparer()) { {"abc",111 }, { "xyz", 0000 } , { "fgh",123} };
			// foreach (KeyValuePair<string, int> v in Dict)
			// 	Console.WriteLine($"{v.Key} :: {v.Value}");
			// 
			// 
			// // What if the key is a user-defined type ?
			// // if we used the parameterless ctor , then the CLR will use the default implementation of IComparer (which is not implemented in the class)
			// // we must first implement the IComparable interface and implement the CompareTo function 
			// SortedDictionary<Employee, int> Employees = new SortedDictionary<Employee, int>() 
			// {
			// 	{new Employee(1,"Ali",500) , 012510},
			// 	{new Employee(2,"Mahmoud",1_000) , 0115757 },
			// 	{new Employee(3,"Shoura",10_000) , 0115570 },
			// };
            // Console.WriteLine("Ordering based on the salary , Descending");
            // foreach (KeyValuePair<Employee, int> Employee in Employees)
			// 	Console.WriteLine($"{Employee.Key} :: {Employee.Value}");
			// 
			// // Given a Class that implements the IComparer to compare with a different way
			// Employees = new SortedDictionary<Employee, int>(new EmployeeComparer())
			// {
			// 	{new Employee(1,"Ali",500) , 012510},
			// 	{new Employee(2,"Mahmoud",1_000) , 0115757 },
			// 	{new Employee(3,"Shoura",10_000) , 0115570 },
			// };
			// 
			// Console.WriteLine("Ordering based on the name , ascending");
			// foreach (KeyValuePair<Employee, int> Employee in Employees)
			// 	Console.WriteLine($"{Employee.Key} :: {Employee.Value}");
			// 
			// 
			// // another overload for the ctor : takes a IDictionary and copies the elements in the new sorted dictionary and sorts the key-value pairs
			// 
			// // Note : don't forget to review the methods , they almost are the same methods in the Dictionary 

			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
