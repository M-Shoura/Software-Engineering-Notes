namespace Advanced__C____Session_1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/

			// Primary Constraints :
			// notnull ==> Self Study
			// Default ==> Self Study
			// Unmanaged ==> Self Study

			// List class member methods : Self Study

			// in binary seach method , when using a IComparer .. can we search based on more than one attribute or field ?

			/* End ******************************************************************************************************************/

			#endregion


			#region Generics + Example 01 : Swap 

			/* Start *****************************************************************************************************************/

			// // Generics in C++ and JAVA ==> Templetes
			// // Generics was introduced with C# 2.0
			// // Before Generics we were using "Objects" , which produces many problems (will be discussed in this session)
			// 
			// // Example for this region : Helper Class + Point Class
			// // This class will not be a datatype (we don't have to make objects from it ==> Static class)
			// 
			// // We have THREE examples here ==> 
			// 
			// // 1 - using Bad Overloading way : 
			// 
			// // Integers
			// int a = 1 , b = 2 ;
			// Console.WriteLine($"A = {a} , B = {b}");
			// Helper.Swap(ref a, ref b);
			// Console.WriteLine($"A = {a} , B = {b}");
			// 
			// // Doubles
			// double aa = 1.9999, bb = 2.543689;
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// Helper.Swap(ref aa, ref bb);
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// 
			// // Points
			// Point p1 = new Point(10,20), p2 = new Point(100,200);
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");
			// Helper.Swap(ref p1, ref p2);
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");
			// 
			// 
			// // Note : The "Object" is the parent type for all Types (user-defined or built-in , value type or reference type)
			// // Reference Types : Class and interface (inherit from Object directly)
			// // Value Types     : Struct and Enum (inherit from Object indirectly)
			// //                   Struct inherit from ValueType class and ValueType class inherit from Object
			// //                   Enum inherit from Enum Class and Enum Class inherit from ValueType class and ValueType class inherit from Object


			// // 2 - using Objects : 
			// // Problems : boxing and unboxing ==> bad for performance
			// //            compiler cannot enforce type safety (ex: casting the objects can throw runtime exceptions)
			// //            function parameters can take any objects (means almost every thing !!)
			// 
			// 
			// // Integers
			// object a = 1, b = 2;                                           // Boxing 
			// Console.WriteLine($"A = {a} , B = {b}");
			// Helper.Swap(ref a, ref b);
			// Console.WriteLine($"A = {a} , B = {b}");
			// 
			// // Doubles
			// object aa = 1.9999, bb = 2.543689;                             // Boxing 
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// Helper.Swap(ref aa, ref bb);
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// 
			// // Points
			// object p1 = new Point(10, 20), p2 = new Point(100, 200);       // Boxing 
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");
			// Helper.Swap(ref p1, ref p2);
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");



			// // 3 - using Generic Method (recommended) : 
			// // The method is generic when it uses a generic type , a generic class can heve both generic methods and non-generic methods
			// 
			// // Integers
			// int a = 1, b = 2;                                       
			// Console.WriteLine($"A = {a} , B = {b}");
			// Helper.Swap/*<int>*/(ref a, ref b);          
			// Console.WriteLine($"A = {a} , B = {b}");     
			// 
			// // Doubles
			// double aa = 1.9999, bb = 2.543689;                          
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// Helper.Swap/*<double>*/(ref aa, ref bb);
			// Console.WriteLine($"AA = {aa} , BB = {bb}");
			// 
			// // Points
			// Point p1 = new Point(10, 20), p2 = new Point(100, 200);     
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");
			// Helper.Swap/*<Point>*/(ref p1, ref p2);
			// Console.WriteLine($"P1 = {p1} , P2 = {p2}");
			// 
			// // Important Note :
			// // Compiler can detect the type of "T" based on the type of Method's input parameters
			// // In Case Generic type was "T" was declared on Method level , NOT [Class , Struct , Interface] Level
			// // But in case of "T" declared on [Class , Struct , Interface] Level , we must specify the type when using the class 
			// // ex: Helper<int>.Swap(ref a , ref b);


			/* End ******************************************************************************************************************/

			#endregion


			#region Example 02 : Search in array Example 

			/* Start *****************************************************************************************************************/

			// // Ex : Helper02 class and Employee struct
			// 
			// // int[] arr = { 1, 3, 5, 7, 2, 8, 4, 9, 10, 6 };
			// // int position = Helper02.SearchArray(arr, 10);
			// // Console.WriteLine($"Position : {position}");
			// 
			// 
			// // in the last example , the class was not generic
			// // what will happen if the class is generic ?
			// // Error in ==> if (arr[i] == value) , that's because the (==) operator is not implemented in all
			// //                                     types (only not implemented in user defined structs) , HOW ??
			// 
			// 
			// Employee e1 = new Employee(10, "Mahmoud", 6_000);
			// Employee e2 = new Employee(10, "Mahmoud", 6_000);
			// Employee e3 = new Employee(20, "Shoura", 8_000);
			// 
			// if ( /*e1 == e2 */  e1.Equals(e2)) Console.WriteLine("Equals");          // Error here , the == is not implemented in user defined structs
			// else Console.WriteLine("Not Equals");                                    // Check the notes in Employee class (Important)
			// 
			// // Equals function in reference types : compares the references
			// // == in reference types              : compares the reference also 
			// // Equals function in value types   : compares the state (values) 
			// // == in value types (built-in)     : compares the state (values) 
			// // == in value types (user-defined) : Not implemented
			// 
			// // So now we knew that the == operator is not implemented in user defined structs is because that we can use the "Equals" function 
			// // Now == and "Equals" function in reference types compares the reference , we usually override the "Equals" function to compare the
			// // states (values) and keep the == to compare the references ... So now we have the two types of comparing with reference types 
			// 
			// Employee[] employees = { e1, e2, e3 };
			// int position = Helper02<Employee>.SearchArray(employees, new Employee (20, "Shoura", 8_000));
			// Console.WriteLine($"Position : {position}");
			// 
			// 
			// // Important note : in generics , we don't have a "Operator constraint" means that we cannot put a constraint that the type must have (or override)
			// // a specific operator , the maximum that we can do is to put a constraint on the type , ex : public class X<T> where T : class  { ... }
			// // here we specified the T to be class type only not struct or interface or enum

			/* End ******************************************************************************************************************/

			#endregion


			#region Value Base Equality (data vs data) VS Reference Base Equality (reference vs reference)  & GetHashCode()

			/* Start *****************************************************************************************************************/

			// Ex: Teacher class

			// Teacher t1 = new Teacher(10, "Mahmoud", 6_000);
			// Teacher t2 = new Teacher(10, "Mahmoud", 6_000);
			// Teacher t3 = new Teacher(20, "Shoura", 8_000);
			// 
			// Console.WriteLine($"Teacher 1 HashCode : {t1.GetHashCode()}");           // different place at 
			// Console.WriteLine($"Teacher 2 HashCode : {t2.GetHashCode()}");           // the memory
			// // GetHashCode() : Generates a hashcode based on the address that the object in heap is located in
			// // t1 & t2 has the same object state (Data) but they have different hashcodes because they are located in different places at the memory
			// 
			// 
			// if (t1 == t2)                                         // == Compares reference by reference (Reference base equality)
			// 	Console.WriteLine("Equals");                      // Not Equals
			// else 
			// 	Console.WriteLine("Not Equals");
			// 
			// if (t1.Equals(t2))                                   // Equals method also Compares reference by reference (Reference base equality)
			// 	Console.WriteLine("Equals");                     
			// else
			// 	Console.WriteLine("Not Equals");
			// 
			// 
			// // so the two ( == and Equals method) are comparing reference base equality , we will override the "Equals" method to be Value base equality 
			// 
			// // Now after overriding "Equals" method in Teacher class : 
			// // == used for (Reference base equality)
			// // Equals method used for (Value base equality )
			// 
			// 
			// // But we will notice that when we override the "Equals" method , there is a warning in class Teacher .. "if you override Equals method then you
			// // have to override the GetHashCode method " (it's not an error it's not a must) ... that's becase "How the two objects have differenct hashcodes"
			// // but they are Equal to each other ? so override the GetHashCode method to generate the hashCode based on the values (Data) not the reference
			// // (later we will discuss the hash table , we must have unique key for storing the values , the unique key is the hashcode and if we have to
			// // store some teachers in this hash table , if we don't override the GetHashCode method then we will store all the object created even if they
			// // have the same data , so we have to override the GetHashCode method to generate the hash code based on the values so if there is different
			// // objects with the same data (values) they will not be stored multiple times in the hash table ... )
			// 
			// 
			// // notice that implementation of GetHashCode method inside the Teacher class .... 
			// 
			// // to sum up , now (==) compares the references (Reference base equality) , and (Equals method) compares the values (Value base equality) 
			// // and GetHashCode method is overriden to generate the hash code based on the values (data) inside the object of the class , insuring no collision
			// // and if we have different objects with same values but in different ordering in the object fields (check the notes inside the overriden method)
			// // it will produce different hash codes as wanted because they are not same objects 

			/* End ******************************************************************************************************************/

			#endregion


			#region Example 03 : Bubble Sort Algorithm for sorting

			/* Start *****************************************************************************************************************/

			// // Ex: Helper02 class , Doctor class
			// 
			// int[] arr = { 1, 5, 3, 6, 7, 2, 4, 9, 8, 10 };
			// Helper02<int>.BubbleSort(arr);
			// 
			// foreach (int i in arr)
			// {
			// 	Console.Write($"{i}   ");
			// }
			// 
			// Console.WriteLine();
			// 
			// // What if we want this function to work with class Doctor ?
			// Doctor[] doctors =
			// {
			// 	new Doctor(1,"Mahmoud",10_000),
			// 	new Doctor(2,"Ahmed",100_000),
			// 	new Doctor(3,"Shoura",5_000),
			// };
			// 
			// Helper02<Doctor>.BubbleSort(doctors);   // Doctor class must implement IComparable interface , next regions I will edit the Helper02 class
			// 										   //  and Doctor must implement the Generic IComparable interface to work properly and avoid casting 
			// 
			// foreach (Doctor doctor in doctors)
			//     Console.WriteLine(doctor);

			/* End ******************************************************************************************************************/

			#endregion


			#region is conditional operator & as casting operator when casting

			/* Start *****************************************************************************************************************/

			// object obj = new Point(1, 2);
			// 
			// // 1 - is conditional operator :
			// if (obj is Point pTest)
			// {
			// 	// is ==> returns True in 3 cases :
			// 	//           1 - if obj is null
			// 	//           2 - if obj is an object from Point class
			// 	//           3 - if obj is an object of class that inherits from Point class
			// }
			// 
			// // 2 - as casting operator : 
			// Point? p = obj as Point; 
			// // will succeed if and only if ==> obj is an object of class "Point"
			// // if casting failed , will return Null 
			// // No exceptions will be thrown 

			/* End ******************************************************************************************************************/

			#endregion


			#region IComparable GENERIC Interface

			/* Start *****************************************************************************************************************/

			// // Ex: Point class 
			// Point[] points =
			// {
			// 	new Point(1,2),
			// 	new Point(8,3),
			// 	new Point(1,1),
			// };
			// 
			// Helper02<Point>.BubbleSort(points);
			// 
			// foreach (Point point in points)
			// {
			// 	Console.WriteLine(point);
			// }

			// After introducing the generics in C# 2.0 , most Interfaces then had another copy which is generic
			// most of them not all (IClonable don't have a generic version , that's because there is no boxing and
			// unboxing inside it and no problem with the version that works with object inside it)

			/* End ******************************************************************************************************************/

			#endregion


			#region Generics constraints

			/* Start *****************************************************************************************************************/

			// what are the constraints that can be used with generic types ?
			// We have 3 Types of constraints :
			// 1 - Primary Constraints [0 : 1] (Written first) : 
			//      - General Primary Constraint : 
			//          * class     ==> T must be Class 
			//          * struct    ==> T must be Struct
			//          * notnull   ==> Self Study
			//          * Default   ==> Self Study
			//          * Unmanaged ==> Self Study
			//      - Special Primary constraint (user-defined class [Except Sealed]) (Written second , after the primary constraint if exists) :
			//          * Point  ==> T must be Point or another class Inherits from Point class
			//          * Enum   ==> T must be Enum (any inherits from Enum class) 
			// 
			// 2 - Secondary Constraint (Interface Constraint) [0 : M]
			//      - IComparable<T> : the class or struct must implement the IComparable<T> (generic version)
			// 
			// 3 - Parameterless Constructor Constraint [0 : 1] : 
			//      - T must be a datatype having accessable [non-private] Parameterless Constructor
			//      - Till C# 12.0 only one constructor constraint
			//      - Cannot use new() [constructor constraint] with struct [General Primary constraint] (because in structs there is always that ctor)

			// Examples : 
			// class Helper<T> where T : class , struct                  ==> Wrong , only one ...
			// class Helper<T> where T : IComparable                     ==> allows only classes and structs , as enums cannot implement interfaces
			// class Helper<T> where T : class , IComparable             ==> allows only classes that implement the IComparable interface
			// class Helper<T> where T : class , IComparable<T>          ==> allows only classes that implement the IComparable generic interface
			// class Helper<T> where T : class , IComparable<T> , new()  ==> allows only classes that implement the IComparable generic interface and have
			//                                                               a public parameterless ctor

			// We also can have more than one type T , ex:
			// class Helper<T1,T2> where T1 : class, IComparable<T> where T2 : struct

			// We also can have the constraint on T with the function : 
			// public static TResult Func< TResult , T > (T x , T y) where T : IComparable where TResult : class

			// Important note : No Operator Constraint in the Generics , Ex: we cannot make a constraint that the class must implement the (+) operator 
			//                  so we cannot use the (+), (>) , (<=) , (-) , ..... in generics

			/* End ******************************************************************************************************************/

			#endregion


			#region Non-Generic Collections [Lists --> ArrayList]

			/* Start *****************************************************************************************************************/

			// // Collections : data structures that are implemented in the .net , ex: stack , queue , list , linked list , ... 
			// // before the generics we used the non generic collections , that used the object as a type 
			// // with C# 2.0 microsoft re-implemented the collections to be based on Generics (to avoid boxing , unboxing , type safe , ... )
			// 
			// // Collections has 2 types : 
			// // 1 - Lists       ==> list , linked list , stack , queue , ... 
			// // 2 - Hash Tables ==> Dictionary , hash set , hash tables , ..
			// 
			// // The most used collection in the type "Lists" ==> ArrayList
			// // The most used collection in the type "Hash Tables" ==> hash table
			// 
			// // We will discuss the ArrayList in this region , as an example of the Non-Generic Collections to show the disadvantages of them
			// 
			// // ArrayList is based on the Array internally (array of object), but it's dynamic sized not fixed size as the array , taking the 
			// // advantage of the array of O(1) to get to a specific element of the array
			// 
			// // How it's dynamically sized ? when wanting an extra size , the CLR generated a new arraylist with (Double the size) and then copies the items
			// // in the old arraylist to the new arraylist with larger size .. and then makes the reference of arraylist references the new large one in the heap   
			// 
			// // ArrayList is found in : System.Collections
			// 
			// ArrayList arrayList = new ArrayList();
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");     // 	count: 0 , capacity: 0
			// // Count    ==> the number of elements inside the arraylist
			// // Capacity ==> the number of elements that the array can contain , before doubling it's size 
			// 
			// arrayList.Add(1);        
			// // When adding the first element , the CLR will allocate a new arraylist with default capacit (4) which is a constant inside the 
			// // implementation of theArrayList class 
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 1 , capacity: 4
			// 
			// arrayList.AddRange(new int[] { 2, 3, 4 });      // Takes ICollection Type 
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 4 , capacity: 4
			// 
			// arrayList.Add(5);
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 5 , capacity: 8  (double the last size = 4*2 )
			// 
			// arrayList.TrimToSize();    
			// // trims the array list to the actual used size (count) to save the memory and free or release or deallocate unused bytes
			// // free (12 bytes ==> 4sizeOfObject * 3Unused = 12 bytes)
			// 
			// //  how it's trimmed ? same as expanding the array .. making a new array with the count size and copying the items in it and then 
			// // making the reference of the arraylist refernce the new small sized array
			// 
			// 
			// arrayList = new ArrayList(5);
			// arrayList.AddRange(new int[] {1, 2, 3, 4 , 5 });     
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 5 , capacity: 5
			// 
			// arrayList.Add(6);
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 6 , capacity: 10  (double the last size = 5*2 )
			// 
			// 
			// arrayList = new ArrayList() { 1,2,3,4,5};
			// Console.WriteLine($"count : {arrayList.Count} , capacity : {arrayList.Capacity}");    // count: 5 , capacity: 8  (double the last size = 5*2 )
			// 
			// foreach(int i in arrayList)    // here we've done Unboxing
			// 	Console.WriteLine(i);
			// 
			// // we used "foreach" because the ArrayList class implements the "IList" interface , that implements the "IEnumerable" interface
			// 
			// // ArrayList has an indexer:
			// 
			// // Console.WriteLine( $"element : {arrayList[Z]}");                // use indexer as getter
			// // if Z < count      ==> get that element 
			// // else if Z >= count ==> Exception !! ArgumentOutOfRangeException
			// 
			// // arrayList[Z] = 100;                                             // use indexer as setter
			// // if Z < count      ==> set that element to the value given
			// // else if Z >= count ==> Exception !! ArgumentOutOfRangeException , cannot Add with the indexer
			// 
			// 
			// // Problems of Non-Generic Collections : 
			// // arrayList.Add(1);         ==> casting from int[value type] to object[reference type] (Boxing)
			// // arrayList.Add("Shoura");  ==> compiler cannot enforce type safety (ex: function to return the sum of the array list ==> exception !! )
			// 
			// 
			// // To sum up , when to use the arraylist ? when making a heterogeneous array : 
			// // (containing many types , ex : first element string , second element object from Point class , third element int , ...)

			/* End ******************************************************************************************************************/

			#endregion


			#region Generic Collections [Lists --> List]

			/* Start *****************************************************************************************************************/

			// // List is the Generic ArrayList , new version of ArrayList , (there is no ArrayList<> , to use a Generic ArrayList use the List)
			// // List is based on the Array internally (array of T)
			// // List is found in : System.Collections.Generics       --> In Global Usings
			// 
			// // The list is dynamic sized also , works with the same mechanism of the ArrayList (for expanding and shrinking size ), check the last region
			// 
			// 
			// List<int> list = new List<int>();
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 0 , capacity: 0
			// 
			// list.Add(1);
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 1 , capacity: 4
			// 
			// list.AddRange(new int[] { 2, 3, 4 });             // Takes IEnumerable<int> Type
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 4 , capacity: 4
			// 
			// list.Add(5);
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 5 , capacity: 8 (double the last size = 4*2 )
			// 
			// 
			// list.TrimExcess();
			// // trims the list to the actual used size (count) to save the memory and free or release or deallocate unused bytes , same as TrimToSize() 
			// // in ArrayList .. free (12 bytes ==> 4sizeOfInt * 3Unused = 12 bytes)
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 5 , capacity: 5
			// 
			// // List has an indexer:
			// 
			// // Console.WriteLine($"element : {list[Z]}");                          // use indexer as getter
			// // if Z < count ==> get that element
			// // else if Z >= count ==> Exception!! ArgumentOutOfRangeException
			// 
			// // list[Z] = 100;                                                      // use indexer as setter
			// // if Z < count ==> set that element to the value given
			// // else if Z >= count ==> Exception!! ArgumentOutOfRangeException , cannot Add with the indexer
			// 
			// 
			// list = new List<int>(5) { 1,2,3,4,5};
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 5 , capacity: 5
			// 
			// 
			// list.Add(6);
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 6 , capacity: 10 (double the last size = 5*2 )
			// 
			// list = new List<int>() { 1, 2, 3, 4, 5 , 6 , 7 , 8 , 9 , 10 };
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");    // count: 10 , capacity: 16 (4 --> 8 --> 16)
			// 
			// 
			// foreach (int i in list)      // No Unboxing 
			// 	Console.WriteLine(i);
			// 
			// // we used "foreach" because the List class implements the "IList<T>" interface , that implements the "IEnumerable" interface
			// 
			// // Advantages of using generic collections : No boxing and unboxing , and compiler can enforce type safety
			// // ex: list.Add("Shoura"); --> not allowed 

			/* End ******************************************************************************************************************/

			#endregion


			#region List Methods

			/* Start *****************************************************************************************************************/

			// // List - class member methods  : Self Study
			// // List - object member methods : 
			// 
			// // most methods in the array is found in the List ( + more methods ) , bacause List is based internally on an array 
			// // we will discuss the methods (cube in Visual studio) , not the extension methods (cube with a down arrow in Visual studio)
			// 
			// List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
			// 
			// list.Add(11);                               // Adds after the last element in the list (at the back of the list)
			// list.AddRange(new int[] { 0, 9 });          // Takes IEnumerable , and adds it to the back of the list
			// list.Insert(13, 10);                        // Takes a position index to add the item, and the item itself (position must be <= count,exception !) 
			// list.InsertRange(14, new int[] { 57, 3 });  // Takes a position index to add the IEnumerable, and the IEnumerable itself
			// 											   // (position + IEnumerable.count must be <= count , exception !)
			// list.BinarySearch(8);                       // (by default uses CompareTo Function that is in IComparable interface)
			// list.BinarySearch(8 /*,IComparer class */); // takes an object of class that implements the IComparer interface to use it in searching
			// List<Employee> employees = new List<Employee>()
			// {
			// 	new Employee(1,"Mahmoud",3_000),
			// 	new Employee(2,"Shoura",9_000),
			// };
			// int index = employees.BinarySearch(new Employee(1, "Mahmoud", 3_000), new EmployeeComparer());
			// // list.BinarySearch(/* index , count , item , IComparer class */); // search in a specific portion of the list, start index and count from that index 
			// 
			//
			// // (important : list must be sorted with the values we search with) .. returns the index where the item is in , if not found then return the 
			// // bitwise complement (~x) , where x is the index of the larger element. if not found a larger element then bitwise complement of the list.count
			// // works with the binary search technique , so if there are multiple items that are right answers for the search .. then it will return the first
			// // item the algorithm found (may be in the half of the list ... )
			// 
			// list.Clear();    // makes all the elements by the default value , but the capacity is the same 
			// Console.WriteLine($"count : {list.Count} , capacity : {list.Capacity}");
			// 
			// 
			// list.Contains(100);           // returns true if the element is in the list and false otherwise
			// 
			// int[] arr = new int[10];     // size must be greater than or equal to the size (count) of the list , otherwise will throw exception 
			// list.CopyTo(arr);            // Check the other overloads 
			// 
			// list.EnsureCapacity(10);     // ensures that the capacity is greater than or equal to the given number , and if the capacity is less then
			// 							 // double the capacity until it's greater than or equal the given number   
			// 
			// list.Remove(10);             // Removes the first occurence of a specific object from the list
			// list.RemoveAt(1);            // Removes the element at a specific index 
			// 
			// list.Reverse();              // Reverse the list 
			// 
			// list.Sort();                 // sort ascending , the type must have CompareTo (default comparer)
			// list.Sort(/*IComparer*/);    // sort ascending , by the comparer given 
			// 
			// list.ToArray();              // Copies the elements of the list to a new array 
			// 
			// // list. [ Exists , Find , FindAll , RemoveAll , TrueForAll , ...]  takes function as a parameter (delegates) that will be discusses later 

			/* End ******************************************************************************************************************/

			#endregion


			#region Generic Collections - Other Lists [Linked list , Stack , Queue]

			/* Start *****************************************************************************************************************/

			// // 1 - Linked List : 
			// LinkedList<int> linkedList = new LinkedList<int>();
			// linkedList.AddFirst(1);
			// linkedList.AddAfter(linkedList.First, 2);
			// linkedList.AddLast(3);
			// // Check the remaining functions ... 
			// 
			// foreach (int i in linkedList)
			// {
			//     Console.WriteLine(i);
			// }
			// 
			// // List : Internally based on array , so it's a contiguous part of the memory .. getting and setting is done in one step O(1) , but adding and
			// //        deleting may cost alot because of (doubling the size , copying elements , ... [we've discussed that in the previous regions] )
			// // Linked List : NOT A CONTIGUOUS PART OF THE MEMORY , Node that hold the value and pointer (reference) to the next node (As a chain) , getting
			// //               and setting is hard because if we want to get the last element then we must visit the N nodes (N => Size of the list)
			// 
			// // use List if getting and setting is more often that the adding and deleting (dynamic sized & Same type [homogeneous])
			// // use Linked List if adding and deleting is more often that the getting and setting (dynamic sized & Same type [homogeneous])
			// 
			// // The reference of the linked list refers to the first element of the linked list 
			// // The "next" of the last node always refers to NULL 


			// // 2 - Stack : Last In First Out , First In Last Out
			// Stack<int> stack = new Stack<int>();
			// stack.Push(1);
			// stack.Push(2);
			// stack.Push(3);
			// int firstStack = stack.Pop();
			// Console.WriteLine(firstStack);   // 3
			// Console.WriteLine(stack.Count);  // 2 
			// stack.Peek();                    // returns the object at the top without removing it , if no elements ==> Exception
			// stack.TryPeek(out int res);      // returns true if there is elemets and copies it in the out parameter without removing, otherwise returns false
			// stack.Pop();                     // if the stack is empty , then it will Throw Exception 
			// stack.TryPop(out int R);         // return true if pop successfully (output parameter) or false if the stack was empty , without exceptions
			// 
			// Console.WriteLine("Elements : ");
			// foreach (int i in stack)
			// 	Console.WriteLine(i);



			// // 3 - Queue : First In First Out , Last In Last Out
			// Queue<int> queue = new Queue<int>();
			// queue.Enqueue(1);
			// queue.Enqueue(2);
			// queue.Enqueue(3);
			// int firstQueue = queue.Dequeue();
			// Console.WriteLine(firstQueue);   // 1
			// Console.WriteLine(queue.Count);  // 2
			// queue.Peek();                    // returns the object at the top without removing it , if no elements ==> Exception
			// queue.TryPeek(out int Res);      // returns true if there is elemets and copies it in the out parameter without removing, otherwise returns false
			// queue.Dequeue();                 // if the queue is empty , then it will Throw Exception 
			// queue.TryDequeue(out int R);     // return true if dequeue successfully (output parameter) or false if the queue was empty , without exceptions
			// 
			// Console.WriteLine("Elements : ");
			// foreach (int i in queue)
			// 	Console.WriteLine(i);
			// 

			/* End ******************************************************************************************************************/

			#endregion


			#region Revision

			/* Start *****************************************************************************************************************/

			// To sum up : 
			// if we want a collection that holds elements of the same type [homogeneous]  :
			//    - Static size   : Array of the given type 
			//    - Dynamic sized : List / Linked List

			// if we want a collection that holds elements of different types [heterogeneous] :
			//    - Static size   : Array of Objects
			//    - Dynamic sized : ArrayList 


			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
