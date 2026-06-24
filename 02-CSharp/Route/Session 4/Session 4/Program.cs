namespace Session_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Self study and Notes

            /* Start *****************************************************************************************************************/

            // Span<T> and stackalloc 

            // important links : https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-reference-types
            //                   https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/builtin-types/nullable-value-types

            /* End ******************************************************************************************************************/

            #endregion


            #region Boxing and UnBoxing

            /* Start *****************************************************************************************************************/

            // Now we will talk about another type of casting : Boxing and Unboxing
            // Boxing (Safe Casting) : Casting from datatype [ValueType ==> stored in stack] to datatype [ReferenceType ==> stored in heap] 
            // Unboxing (UnSafe Casting) : Casting from datatype [ReferenceType ==> stored in heap] to datatype [ValueType ==> stored in stack]
            //                             The reverse of boxing, it is the process of extracting the value type from the object reference type

            // Why does this happen ? 
            // Because value types (stored in stack) must be wrapped in a heap-allocated object when treated like reference types

            // EX:
            // object Obj;
            // - Declare of reference of type "object" , Refering to NULL
            // - This reference "Obj" can refer to an instance from type "Object" or any other datatype (parent for all datatypes)
            //
            // int x = 5;
            // Obj = x;
            // - CLR Allocates memory in the heap
            // - CLR Copies the value of x to that heap object
            // - CLR Store the reference of the object created in the heap to Obj 
            //
            // Obj = new string("Shoura");  // NO boxing Done .. object and string are already reference types
            // Obj = 'A';     // (Boxing , Implicit and safe casting), from char[ValueType] to object[ReferenceType]
            // Obj = true;    // (Boxing , Implicit and safe casting), from bool[ValueType] to object[ReferenceType]
            // Obj = 3;       // (Boxing , Implicit and safe casting), from int [ValueType] to object[ReferenceType]


            // Ex:
            // int x = 5;
            // object O1 = x;
            // - Casting from int [ValueType] to object [ReferenceType] Done Implicitly ===> Boxing
            // - C# is a pure OOP Language so we can only inherite from one parent (in C++ we have multi-inheritance [more than one parent])
            // - That's why Boxing is safe Casting


            // Ex:
            // object O2 = 10;
            // int y = (int) O2;
            // - Casting from object [ReferenceType] to int [ValueType] Done Explicitly ===> UnBoxing (Unsafe and may cause Exceptions)
            // - if "O2" contain value that cannot be converted to (int and only int) then we will have "InvalidCastException" , it's a
            //   Runtime error NOT A compilation error (No problem with compiler).
            // - to avoid exceptions we can use "is" and "as" operators (still perform boxing and unboxing, discussed later)


            // Ex:
            // Example of Invalid Unboxing Example:
            // object obj = 10;
            // double d = (double)obj;           // ❌ Runtime InvalidCastException


            // To sum up : We must avoid Boxing and UnBoxing because they introduce overhead
            //             - Heap allocation on boxing.
            //             - Type checking and casting on unboxing.
            //             When studying Advanced C# (Generics Topic) we will use it instead of Boxing and UnBoxing.
            //             Span<T> can also help in avoiding Boxing and Unboxing .. (Self-Study)

            /* End ******************************************************************************************************************/

            #endregion


            #region "is" and "as" casting

            /* Start *****************************************************************************************************************/

            // 1 - is Keyword : used for type checking or pattern matching. Checks if an object is of a certain type , Returns a
            //                  boolean(true or false). Safe — doesn't throw exceptions.
            // 
            // Ex:
            // if (obj is string)
            // {
            //     Console.WriteLine("obj is a string");
            // }
            //
            // C# 7.0+: Pattern Matching
            // if (obj is string s)
            // {
            //     Console.WriteLine($"It's a string with value: {s}");
            // }


            // 2 - as Keyword : Use "as" when you want to try casting without risking exceptions (Safe Casting). cast an object to a
            //                  specific reference type (or nullable) , Returns null if the cast fails , Works only with reference types or
            //                  nullable types.
            // 
            // Ex:
            // object obj = "hello";
            // string s = obj as string;
            // if (s != null)
            // {
            //     Console.WriteLine("Successfully cast using 'as'");
            // }

            // So to avoid Invalid Cast Exceptions , use "as" : 
            //
            // string s = (string)obj;        // Bad: may throw InvalidCastException
            //       
            // string s = obj as string;      // Better: safe way
            // if (s != null)
            // {
            //     .....
            // }


            // Comparison Between is and as
            // Feature             is                 as
            // Purpose          Type checking    Safe casting
            // Return Type      bool             Casted object or null
            // Throws error?	No               No
            // Works with       All types        Reference & nullable types only
            // Pattern Match    Yes(C# 7+)	     No

            /* End ******************************************************************************************************************/

            #endregion


            #region Pattern Matching

            /* Start *****************************************************************************************************************/

            // Pattern Matching : A feature that was introduced in C# 7.0  lets you test and extract information from values in a readable 
            //                    and type-safe way. It combines conditional logic with type checks, value checks, and structure
            //                    decomposition — all done within an expression or statement.

            // Common Pattern Matching Forms:

            // 1 - Type Pattern (is keyword)
            // Ex: 
            // object obj = "Hello";
            // if (obj is string s)
            // {
            //     Console.WriteLine(s.ToUpper());      // safe, no casting needed
            // }
            // Here checks the type and assigns the casted value to s

            // 2 - Constant Pattern
            // Ex:
            // int x = 10;
            // if (x is 10)
            // {
            //     Console.WriteLine("x is 10");
            // }
            // Here checks if the value matches a constant

            // 3.Relational Pattern(C# 9+)
            // Ex:
            // int age = 25;
            // if (age is > 18 and < 30)
            // {
            //     Console.WriteLine("Young adult");
            // }
            // Here checks ranges using comparison operators

            // 4 - Logical Patterns (and, or, not)
            // Ex:
            // if (age is < 18 or > 60)
            // {
            //     Console.WriteLine("Not a working age");
            // }
            // Here combines multiple patterns logically

            // 5 - Switch Expressions with Patterns (C# 8+)
            // Ex:
            // string result = age switch
            // {
            //     < 18 => "Minor",
            //     >= 18 and < 60 => "Adult",
            //     _ => "Senior"
            // };
            // Here it's a cleaner, expression-based replacement for switch-case default case (and without breaks !)

            // 6 - Property Pattern (C# 8+) (properties are discussed later in OOP)
            // Ex: 
            // Person p = new Person { Name = "Ali", Age = 22 };
            // if (p is { Age: > 18 })
            // {
            //     Console.WriteLine("Adult");
            // }
            // Here matches on object properties


            // Benefits of Pattern Matching : 
            // - Avoids manual is checks and casting
            // - Improves readability
            // - Makes switch and if more expressive

            /* End ******************************************************************************************************************/

            #endregion


            #region Nullable datatypes .. 1 - Value Types [C# 2.0]

            /* Start *****************************************************************************************************************/

            // It was introduced at C# 2.0 
            // Nullable Datatypes Value Types : allows assigning a Null to a variable of type Value Types 
            // By default , Null is valid value for Reference type datatypes, but not a valid value for Value type datatypes (structs & enum)
            //
            // valid use case : When retrieving data from the database and for example the age is nullable column .. then we must get the
            //                  age value in a nullable value type datatype.
            //                  

            // Nullable value types datatypes : (ex => int)    : Allows int values + null 
            //                                  (ex => double) : Allows double values + null 
            //                                      ......


            // declare a nullable value type variable : 
            // 1 - Nullable<int> Age;
            // OR
            // 2 - int? Age;          // Syntax sugar
            //
            // Age = 10;
            // Age = null;       // No Problem !


            // in the nullable datatype , we have 2 important properties (properties for Nullable<T>):
            //      .HasValue : checks if the current nullable object has a valid value for it's underlying type (int,float, .. )
            //      .Value : gets the current nullable object value 
            // Note : Always check .HasValue before accessing .Value to avoid runtime exceptions!


            // Ex:
            // int x = 10;              // Can hold int values only
            // int? y = x;              // implicit casting , safe casting , can hold int values + null

            // Ex:
            // int? a = 10;
            // int? b = null;
            // int c = (int)a;         // Must be explicit casting , unsafe casting , in our case no problems
            // int d = (int)b;         // Must be explicit casting , unsafe casting , in our InvalidCastingException in Runtime !


            // so how can we solve the previous problem ?
            // --> writing protective code (deffensive code) to survive against any senario .. 
            // We have 4 ways and the last is the most important way and the most common used : 


            // 1 : _______________________________________
            // if (a != null)
            // 	    b = (int)a;
            // else
            // 	    b = 0;
            // 
            // 2 : _______________________________________
            // if (a.HasValue)
            //  	b = a.Value;
            // else
            //  	b = 0;
            // 
            // 3 : _______________________________________
            // b = a.HasValue ? a.Value : 0;
            // 
            // 4 : _______________________________________
            // Null Coalescing Operator (most common used , works with nullable Value types and reference types also)
            // b = a ?? 0;        // syntax sugat for the last way --> b = a.HasValue ? a.Value : 0;


            // Nullable with == and != (can be compared directly)
            // int? x = 5;
            // int? y = null;
            // 
            // bool result = x == y;               // result = false


            // Nullable in Method Return:
            // Useful when you want to return “no result (Null)” from a method.
            // Ex:
            // int? FindUserAge(string name)
            // {
            //     if (name == "John")
            //          return 30;
            //     return null;
            // }


            // Casting between Nullable types : 
            // 1 - Nullable to Non-Nullable
            // int? a = 5;
            // int b = (int)a;                      // Works fine

            // If "a" is null, this will throw "InvalidOperationException":
            // int? a = null;
            // int b = (int)a;                      // ❌ Exception

            // Safer with .GetValueOrDefault() or null-coalescing operator:
            // int b = a.GetValueOrDefault();       // returns 0 if null
            // int c = a ?? 0;                      // use default -1 if null


            // 2 - Casting Between Nullable Types (Implicit & Explicit Conversions)
            //
            // int? a = 5;
            // double? b = a;                      // implicit: int → double
            // - If a is null, then b will be null after the cast , no exception.
            // 
            // double? a = 5.5;
            // int? b = (int?)a;                  // explicit: double → int
            // - If "a" has value that cannot fit in "int" datatype , then we will not have any exceptions , but garbage value inside "b"
            // 
            // 
            // 
            // 3 - Using as with Nullable Types : as only works with reference types or nullable value types.
            // object o = 5;
            // int? val = o as int? ;             // Works
            // 
            // - But this won’t work with non-nullable:
            // int val = o as int;                // ❌ Compilation error
            // 
            // 
            // 
            // 4 - Using is with Nullable Types
            // int? x = 10;
            // if (x is int value)
            // {
            //     Console.WriteLine($"x is {value}");
            // }
            // 
            // 
            // 5 - Nullable with Convert Class (Convert methods return default values when null is passed)
            // int? a = null;
            // double b = Convert.ToDouble(a);        // returns 0.0 (default value)



            // Summary Table :
            // -------------------------------------------------------------------------
            // From         To                          Behavior
            // int?         int                  Requires explicit cast, throws if null
            // int          int?                 Implicit
            // int?         double?              Implicit
            // double?      int?                 Requires explicit cast 
            // int?         object               Boxing
            // object       int?                 Unboxing, use as or cast

            /* End ******************************************************************************************************************/

            #endregion


            #region Nullable datatypes .. 2 - Reference Types [C# 8.0]

            /* Start *****************************************************************************************************************/

            // - Nullable reference types were introduced in C# 8.0 to help developers minimize NullReferenceException.
            // - Null is the default value for variables of type reference datatypes (class , interface) so .. why there is nullable reference
            //   type datatypes ?
            // - Unlike nullable value types (like int?), nullable reference types are not a new type (A variable of type T and a variable of
            //   type T? are represented by the same .NET type), they are only a compiler inhancment, how ?
            // - If we are working in the best way then it's NOT important to check the nullability before using for string, but it's important
            // - for string? (nullable string or any nullable reference type datatype)


            // string message = "Hi";
            // message = null;                        // It's right but we have a warning .. "possible null value for a non-nullable type" 
            // string? message2 = null;               // But here there is no warnings .. it's a nullable string
            // Console.WriteLine(message2.Length);    // Compiler warning , message2 may be null, we may have an exception 


            // - Null-forgiving operator ! 
            //
            // Example 1 : 
            // string? name = "Shoura";
            // Console.WriteLine(name!.Length);          // we say to the compiler : neglect the warning 
            //
            // Example 2 : 
            // string notNullable = "Hi";
            // string nullable = null;
            // notNullable = nullable!;       // here we can use the null-forgiveness ( ! ) to avoid the warning ... 


            // Enabling Nullable Reference Types
            // 1 - You enable this feature in your .csproj file:  <Nullable>enable</Nullable>
            // 2 - at the top of a file: #nullable enable


            // Note : WE CANNOT USE PROPERTIES .HasValue and .Value WITH NULLABLE REFERENCE TYPES , ONLY NULLABLE VALUE TYPE !

            // Ex:
            // class employee
            // {
            //      public string FName { get; set; }
            //      public string? LName { get; set; }
            // 	 
            //      - we have a warning in "FName" , Why ? because it's not a nullable string 
            //      - so when did this variable hold null ? 
            //      - if we didn't provide a constructor for our class then the compiler generates an empty constructor 
            //      - this empty constructor does nothing but only Initializes fields to their default values string => NULL;
            // 	    - But if we wrote the constructor as the next line , we will notice that the warning is now with the constructor not "FName"
            //
            //      public employee()
            //      {
            //          
            //      }
            // 	 
            // 	    - so to solve this problem we have two ways : 
            // 	    - 1 - inside the constructor write ==> Fname = "";        // initialize it with a value that is not null ;
            // 	    - 2 - initialize the property itselt ==> public string FName { get; set; } = "";
            //                                               Note : by default it's ==> public string FName { get; set; } = null;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Null Propagation Operator

            /* Start *****************************************************************************************************************/

            // The null propagation operator (?.) in C# is used to safely access members and dereferencing and propagation through the object
            // (properties, methods, or indexers) that might be null, without throwing a "NullReferenceException"
            // Note : This is done only with Reference Types (nullable or not) .. 
            // Ex: string?.Length is a syntax sugar for ===>   string != null ? string.Length : null 


            // Ex:
            // object?.Member
            // If object is null, the entire expression returns null instead of throwing an exception.


            // Ex:
            // Person person = null;
            // - Instead of: person.Name.Length     // (which would throw an exception)
            // int? length = person?.Name?.Length;  // Returns null safely


            // Ex:
            // double x = default;          // default = 0 for all numeric datatypes
            // int[] arr = default;         // default = null .. here we have a warning because it's an array not a nullable array
            // int[]? arr2 = default;       // default = null .. here we don't have a warning because it's a nullable array
            // 
            // for (int i = 0; i < arr.Length /* propagation and deReferencing */ ; i++)
            // 	    Console.WriteLine(arr[i]);
            // 
            // - the last loop will cause a (null reference exception) because the array now still references null !
            // - so how we can solve this problem ==> 2 ways :
            // 
            // 1 - more one condition in the loop
            // for (int i = 0; (arr != null) && (i < arr.Length); i++)
            // 	    Console.WriteLine(arr[i]);
            // 
            // 2 - using the Null Propagation Operator
            // for (int i = 0; i < arr?.Length /* propagation and deReferencing */ ; i++)
            // 	    Console.WriteLine(arr[i]);
            // 
            // - using the previous 2 ways is not the best practice in that case (many checks if it references null or not in the loop)
            // - the best practice will be simple if condition to check if it's null or not before the loop :
            // 
            // if (arr != null)
            // 	  for (int i = 0; i < arr.Length; i++)
            // 	    	Console.WriteLine(arr[i]);
            // 	  
            // - it's used as the best practice when having one check on the object as the next example : 
            // int len = arr.Length;                // unsafe code , may throw exception (null reference exception)
            // int? len = arr?.Length;              // must be a nullable int because arr?.Length may return null or the length
            // int length = arr?.Length ?? 0;       // the best way 


            // Ex: classes will be discussed next session
            //
            // class Employee
            // {
            //     public int Id { get; set; }
            //     public string? Name { get; set; }
            //     public Department Department { get; set; }
            // }
            //
            // class Department
            // {
            //     public int Code { get; set; }
            //     public string? Title { get; set; }
            // }
            //
            // Employee employee = new Employee();     // {Id = 0 , Name = null , Department = null}
            // employee.Department = new Department(); // {Code = 0 , Title = null} 
            //
            // if(employee != null)                                                         // Check employee is not null
            // {
            // 	  if(employee.Department != null)                                           // Check department is not null
            // 	  {
            //         Console.WriteLine(employee.Departmet.Title ?? "Not Available");      // Check title is not null
            //    }
            // }
            //
            // or (produce the same result) : 
            //
            // Console.WriteLine(employee?.Department?.Title ?? "Not Available");


            // Don't mix between Null-coalescing operator (??) and Null Propagation Operator (?.)
            // string name = person?.Name ?? "Unknown";
            // - means if person = null then name = "Unknown" without throwing Exception, if person is not null then name = person.name;

            // Note : incase of working with value types , we must use a nullable value type if we will use the Null Propagation Operator
            //        only without the Null-coalescing operator .. 
            // Ex: 
            // int length = arr?.Length;       // Compilation Error , if arr is null then we cannot initialize a non-nullable int with NULL 
            // int? length = arr?.Length;      // this is right , using a nullable int 

            // Why use Null Propagation Operator ?
            // 1 - Prevents NullReferenceException
            // 2 - Useful in complex object graphs (obj?.Child?.GrandChild)
            // 3 - Result is null if any part before the access is null

            /* End ******************************************************************************************************************/

            #endregion


            #region Functions (User Defined)

            /* Start *****************************************************************************************************************/

            // Function : A block of reusable code that performs a specific task.

            // - Main function is the entry point of the program. 
            // - Functions achieve : maintainability and usability of the code.
            // - Function must solve ONE and only ONE problem (single responsibility)

            // in SQL , the function MUST return .. but here in C# functions can return or not, functions that doesn't return (void functions)

            // Define a function : 
            //
            // [access_modifier(optional)] [return_type] [method_name] ([parameter_list])
            // {
            //     // method body
            // }

            // Access Modifier: controls visibility.
            // Return Type: Specifies the type of value the method returns (void if nothing).
            // Method Name
            // Parameters: Input values passed to the method.
            // Body: Contains the logic.


            // Function declaration (Prototype) : Access Modifier(Optional) + Return type + Name + Parameters
            // Function Signature (used by the compiler to identify overloads) : Method name + Parameter types and number and order
            // overloading is discussed later , but we cannot overload a method by just changing its access modifier.
            // Ex: two functions having the same signature but different access modifiers.
            // public int Add(int x, int y ) { }         // wrong overloading
            // private int Add(int x, int y) { }         // wrong overloading


            // Note : Function Signature doesn't include Return type / Access modifier / Parameter Names / static, async, or other modifiers


            // Note : if we didn't write Access Modifiers in the function declaration, it will take a default value where the function is written
            //        Class     => Private
            //        Interface => Public


            // Function == Method 
            // A function can be a class member or object member :
            // - Class member  ==> called through the class name and must be static function 
            // - Object member ==> called through an object from the class and it's NOT a static function
            //
            // Note : if we are in a function and wanting to call another STATIC function IN THE SAME CLASS then we can call it 
            //        without the class name. Ex : if we have a function here in this class "Program" called "DoSomething" , then 
            //        to call it ==> [ DoSomething(); ] ... also no problem to call it by the class name [ Program.DoSomething(); ]
            //        But if the function was in another class then must be called ==> [ AnotherClass.DoSomething(); ]


            // - When calling the function : Name (Arguments)


            // - Usually we write function name in PascalCase 

            // - We can also write functions as : Expression - bodied Methods, Short - hand for simple methods :
            // Ex: 
            // int Square (int x) => x * x;


            // - Local Functions(C# 7.0+): You can declare a function inside another method
            // Ex:
            // void Outer()
            // {
            //     int Inner(int x) => x * x;
            //     Console.WriteLine(Inner(4));
            // }


            // - Extension Methods, Add methods to existing types (discussed again later) :
            // Ex:
            // public static class MyExtensions
            // {
            //     public static int WordCount(this string str)            // using "this" keyword
            //     {
            //         return str.Split().Length;
            //     }
            // }
            //
            // Used like:
            //
            // string text = "Hello World";
            // int count = text.WordCount();


            // EX:
            //
            // public class Hamada
            // {
            // 	 public static void PrintShapes(int Count = 5 , string Pattern = "$$$")      // Optional Parameters
            // 	 {
            // 		for (int i = 1; i <= Count; i++)
            // 		{
            // 			Console.WriteLine(Pattern);
            // 		}
            // 	 }
            // }

            // Hamada.PrintShapes(10 , "%_%");                      // Passing the parameters by the same order
            // Hamada.PrintShapes(Pattern:"%_%" , Count:10);        // Passing the parameters by Names (can change the order) "Named Parameters"
            // Hamada.PrintShapes(10);                              // Taking the "Pattern" as the default value provided up
            // Hamada.PrintShapes(Pattern:"________");              // Taking the "Count" as the default value provided up
            // Hamada.PrintShapes();                                // No Parameters , taking the default values provided up

            // Note : parameters that has a default value must be the last parameters in the parameter list ==> 
            // Ex : public static void PrintShapes(int Count = 5 , string Pattern = "$$$" , int x )      // WRONG !!
            // Ex : public static void PrintShapes(int x , int Count = 5 , string Pattern = "$$$" )      // Right

            /* End ******************************************************************************************************************/

            #endregion


            #region Passing Value Type Parameters  

            /* Start *****************************************************************************************************************/

            // First of all we must know that every function called in our program has a stack frame in the STACK , the stack frame
            // contains the parameters of the function and the local variables defined in the function .. because the Main function
            // is the entry point of the program .. it's the first stack frame in the Stack . After finishing executing the 
            // function , it's stackframe is deleted from the Stack.


            // Ex 1 : Passing By Value
            //
            // static void SWAP(int x , int y)
            // {
            // 	    int temp = x;
            // 	    x = y;
            // 	    y = temp;
            // }
            //
            // - In Main Function : 
            //
            // int a = 5;
            // int b = 7;
            // Console.WriteLine($"A = {a}");    // 5
            // Console.WriteLine($"B = {b}");    // 7
            // 
            // Console.WriteLine("After ----------------- ");
            // 
            // SWAP(a, b);                      // Passing by value
            // Console.WriteLine($"A = {a}");   // 5
            // Console.WriteLine($"B = {b}");   // 7
            // 
            // We will notice that nothing happened ! This is called Passing By Value :
            // when sending the parameters by the way mentioned above, we actually send a COPY of the variables not the variables
            // itself .. in the stack frame of the function SWAP the two variables are swapped but after finishing executing the 
            // function the stackframe is deleted from the stack .. so we now will work with the values that are in the stackframe
            // of the main function (which are the values without the swapping) 


            // Ex 2 : Passing By Reference (adding "ref" in function parameters and arguments when calling the function)
            //
            // Note: You must initialize the variable before passing it using ref.
            // 
            // static void SWAP( ref int x, ref int y )
            // {
            // 	    int temp = x;
            // 	    x = y;
            // 	    y = temp;
            // }
            //           
            // - In Main Function : 
            //
            // int a = 5;
            // int b = 7;
            // Console.WriteLine($"A = {a}");    // 5
            // Console.WriteLine($"B = {b}");    // 7
            // 
            // Console.WriteLine("After ----------------- ");
            // 
            // SWAP(ref a, ref b);              // Passing by Reference
            // Console.WriteLine($"A = {a}");   // 7
            // Console.WriteLine($"B = {b}");   // 5
            // 
            // We will notice that the variables are swapped successfully !
            // This is called Passing By Reference :
            // when sending the parameters by the way mentioned above , we actually send the variables itself , so any change in them
            // will affect the real variables in the stack frame of the main function 

            /* End ******************************************************************************************************************/

            #endregion


            #region Passing Reference Type Parameters 

            /* Start *****************************************************************************************************************/

            // First of all we must know that every function called in our program has a stack frame in the STACK , the stack frame
            // contains the parameters of the function and the local variables defined in the function .. because the Main function
            // is the entry point of the program .. it's the first stack frame in the Stack . After finishing executing the 
            // function , it's stackframe is deleted from the Stack.


            // Key Concept: Reference Types Are Passed by Value — But the Value Is a Reference
            // When you pass a reference type (like a class object, array, string, etc.) to a method:
            // - You're passing the reference (pointer) to the object, by value.
            // - That means the method receives a copy of the reference (not a copy of the object).
            // - Both the caller and the method point to the same object in memory.


            // Ex 1 : Passing By Value and trying to modify the Object's Content (Works!)
            // 
            // static int SumArray(int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	arr[0] = 100;
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            //
            // - In Main Function : 
            //
            // int[] numbers = { 1, 2, 3 };
            // SumArray(numbers);                   // 105        ==> Passing by Value
            // Console.WriteLine(numbers[0]);       // 100
            // 
            // 
            // We will notice that the array has changed .. that's because when sending a reference type variable (by value) as a  
            // parameter for the function , we send the address of the object in the heap .. so the parameter defined in the stack 
            // frame of the new function references the same object in the Heap (means that the object in the heap now has 
            // two references and any of them can change in the object)   



            // Ex 2 : Passing By Reference (adding "ref" in function parameters and arguments when calling the function) and trying to
            //        modify the Object's Content (Works!)
            // 
            // static int SumArray(ref int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	arr[0] = 100;
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            //
            // - In Main Function : 
            //
            // int[] numbers = { 1, 2, 3 };
            // SumArray(ref numbers);                 // 105        ==> Passing by Reference
            // Console.WriteLine(numbers[0]);         // 100
            // 
            // Again we will notice that the array has changed .. that's because when sending a reference type variable (by reference)
            // as a parameter for the function , we send the address of the reference in the stack , in our example we send the 
            // address of "numbers" which is in the stack now .. that references the object in the heap and can be changed also 



            // Ex 3 : Passing By Value and trying to Reassign the Reference (Does not affect caller !)
            //
            // static int SumArray(int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	arr = new int[] { 4, 5, 6 };
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            //
            // - In Main Function : 
            //
            // int[] numbers = { 1, 2, 3 };
            // SumArray(numbers);                  // 15        ==> Passing by Value
            // Console.WriteLine(numbers[0]);      // 1

            // By passing the parameters by value in the last example and trying to reference a new object , in the function 
            // now we are working with a new array which is referenced .. the reference in the stack frame of the function now 
            // references a new object in the heap and doesn't reference the "numbers" object which was sent as a parameter by value
            // so any change will not affect the first array which is now referenced only be "numbers" in the main , and the array object
            // that is in the main function will not reference a new object 


            // Ex 4 : Passing By Reference (adding "ref" in function parameters and arguments when calling the function) and trying to
            //        Reassign the Reference (Works!)
            //
            // static int SumArray(ref int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	arr = new int[] { 4, 5, 6 };
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            //
            // - In Main Function : 
            //
            // int[] numbers = { 1, 2, 3 };
            // SumArray(ref numbers);                 // 15        ==> Passing by Reference
            // Console.WriteLine(numbers[0]);         // 4

            // By passing the parameters by reference in the last example and trying to reference a new object , in the function 
            // now we are working with the original reference in the main function which reference the array in the heap .. so any change 
            // will affect the reference in the heap , in our case the array object {1,2,3} now is unreachable and also the original 
            // reference "numbers" also reference the new array object in the heap {4,5,6} 


            // To sum up .. The difference between sending the reference type parameters by value or reference type parameters by reference
            // appears clearly when changing the reference itself , not changing the object internally . So use "ref" only if you must change
            // the caller's reference.

            // Important note : Strings are reference types but immutable, so assigning or modifying a string works more like a value type.

            /* End ******************************************************************************************************************/

            #endregion


            #region Passing By Out + ("out" VS "ref")

            /* Start *****************************************************************************************************************/

            // static int SumMul(int x, int y)
            // {
            // 	    int sum = x + y;
            // 	    int mul = x * y;
            //      
            // 	    return sum;           
            // 	    // return mul;      // here we cannot return more than one int .. 
            // }

            // To solve this problem we can : 
            // 1 - return an array of size = 2       ==> return new int[] {sum,mul};
            // 2 - return an object from a user defined class containing two properties sum & mul 
            // 3 - use output parameters 
            // 4 - passing parameters by reference 

            // we will skip the first two ways , 

            // 3 - using output parameters :
            // static void SumMul(int x, int y, out int sum, out int mul)
            // {
            // 	    sum = x + y;
            // 	    mul = x * y;
            // }
            // int x = 10 , y = 5 , ResultSum , ResultMul ;      
            // SumMul(x , y , out ResultSum , out ResultMul );   // also can be ==> SumMul(x , y , out int ResultSum , out int ResultMul);

            // - Notice that it's not important to initialize the two output variables .. 
            // - Notice that it's a MUST assign values to the output parameters in the function before exiting.

            // Note : if you don't want to get any results from the function but you want to use the function itself and the logic inside it
            // then change the output parameters and use "discard _"
            // Discard : 
            // - means : You must receive a value (due to syntax or semantics), But you don't care about using it.
            // - used before in TryParse out parameter , Switch Expressions , here in out function parameter , ... 
            // Ex : SumMul(x , y , out _ , out _ );


            // 4 - passing parameters by ref : 
            // static void SumMul(int x, int y, ref int sum, ref int mul)
            // {
            // 	    sum = x + y;
            // 	    mul = x * y;
            // }
            // int x = 10, y = 5, ResultSum=0, ResultMul=0;
            // SumMul(x , y , ref ResultSum , ref ResultMul );

            // - Notice that it's a MUST to initialize the two variables sent by reference.
            // - Notice that it's not important to give values to the ref parameters in the function.

            /* End ******************************************************************************************************************/

            #endregion


            #region Passing By in 

            /* Start *****************************************************************************************************************/

            // Passing Read-Only (in keyword) : Introduced in C# 7.2 — passes the variable by reference, but read-only.
            // Usage : Passing large structs (value types) without copying (avoid performance cost of copying), while ensuring immutability.

            // Ex:
            // void Show(in int x)
            // {
            //     Console.WriteLine(x);
            //     // x++;                 // ❌ Not allowed — x is read-only
            // }
            // 
            // int a = 5;
            // Show(in a);

            /* End ******************************************************************************************************************/

            #endregion


            #region Params 

            /* Start *****************************************************************************************************************/

            // Basic code we know from before sessions :
            // static int SumArray(int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            // int[] numbers = { 1, 2, 3, 4, 5, 6, 7 };
            // int Total = SumArray(numbers);
            // Console.WriteLine(Total);

            // What if I want to send the elements of the array directly to the function ?? ==> using params keyword
            // The params keyword : allows a method parameter to accept a variable number of arguments. It must be the last parameter in
            //                      the method signature, and it must be a single-dimensional array.


            // static int SumArray(params int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            // int Total = SumArray(1, 2, 3, 4, 5, 6, 7);
            // 
            // OR 
            // 
            // int[] arr = { 10, 20, 30 };
            // SumArray(arr);


            // Important notes : 
            // 1 - The function can have ONLY ONE params parameter (Maximum 1)
            // 2 - The type of the parameter MUST be single-dimensional array 
            // 3 - This parameter must be the last in the parameter list
            //     (parameters without default value THEN parameters with default value THEN params parameter)
            // 4 - Avoid it for performance, since it allocates an array behind the scenes , also it reduces clarity in some cases.


            // Ex : 
            // static int SumArray(int a , int b = 5 , params int[] arr)
            // {
            // 	    int sum = 0;
            // 	    if (arr != null)
            // 	    {
            // 	    	for (int i = 0; i < arr.Length; i++)
            // 	    		sum += arr[i];
            // 	    }
            // 	    return sum;
            // }
            // int Total = SumArray(1, 2, 3, 4, 5, 6, 7);  // Total = 25 because => 1 goes to "a" .. 2 goes to "b" , others to params "arr" 

            // Remember :
            // Console.WriteLine("{0} + {1} = {2} ... done by {3}",10,20,30,"Mahmoud" /* actually they're params of object */ );

            /* End ******************************************************************************************************************/

            #endregion


            #region Exception Handling (try catch finally)

            /* Start *****************************************************************************************************************/

            // Before using Try Catch we must write protective code, Try Catch Finally is useful with unexpected exceptions allowing you to
            // recover or log errors instead of crashing the program... we must use ways we've studied before such as :
            // - Null Propagation Operator (?.) , TryParse Method , Null-Coalescing Operator (??) ... 


            // In TRY block , we write the code that MAY through excpetion .. and if the code throws exception , we are going to catch
            // the exception in the CATCH block without having a runtime error and stop program execution .. we can specify the type of
            // exception thrown and catched be the catch block or make it general and catch the GENERAL "Excpetion" class that all exceptions
            // inherit from it .. the FINALLY block (it's optional) is executed if we have an exception or not , it will be executed at all 
            // times and it's used to release or free or close the unmanaged resources (ex: close the database connection (discussed later ..))
            // 
            // Exceptions : 
            // 1 - System Excpetions : Problems with the code 
            // // // 1.1 - Format Exception
            // // // 1.2 - Index Out Of Range Exception
            // // // 1.3 - Null Reference Exception
            // // // 1.4 - Invalid Operation Exception
            // // // 1.5 - Arethmetic Exception
            // // // // // // 1.5.1 - Divide By Zero Exception
            // // // // // // 1.5.2 - Overflow Exception
            // 2 - Application Exception : Problems with the server or database or ....


            // Exception Class Properties : 
            // 1 - Message => Error message
            // 2 - StackTrace => Call stack info
            // 3 - InnerException => If exception wraps another
            // 4 - Source => Application or object that caused it

            // Note : We can throw an exception manually by (  throw new Exception("Something went wrong") );


            // It can be : try catch , try finally , try catch finally , try catch catch ... finally 

            // try
            // {
            // 	    int[] arr = new int[] {1,2,3};
            // 	    int x = int.Parse(Console.ReadLine());
            // 	    int y = int.Parse(Console.ReadLine());
            //      
            // 	    int z = x / y;
            //      
            // 	    arr[100] = 10000;
            // }
            // catch(FormatException e)
            // {
            //      Console.WriteLine(e.Message);
            // }
            // catch(DivideByZeroException e)
            // {
            // 	    Console.WriteLine(e.Message);
            // }
            // catch(IndexOutOfRangeException e)
            // {
            //      Console.WriteLine(e.Message);
            // }
            // catch(Exception e)
            // {
            // 	    Console.WriteLine(e.Message);
            // }
            // finally
            // {
            //      Console.WriteLine("Finally Done !");
            // }

            // Note : we can have ONLY ONE catch block which catches the "Exception" class object "Parent class for all of them" , but we 
            //        can have many catch blocks each having an Exception type ...

            // Some Protective code : 
            // try
            // {
            // 	    int x, y, z;
            // 	    do
            // 	    {
            // 	    	Console.WriteLine("Enter x : ");
            // 	    } while (!int.TryParse(Console.ReadLine(), out x));
            // 
            // 	    do
            // 	    {
            // 	    	Console.WriteLine("Enter y : ");
            // 	    } while (!int.TryParse(Console.ReadLine(), out y) || y==0);
            // 
            // 	    z = x / y;
            // 
            // 	    int[] arr = new int[] { 1, 2, 3 };
            // 
            // 	    if (arr?.Length > 100)
            // 	    {
            // 	    	arr[100] = 10000;
            // 	    }
            // }
            // catch (Exception e)
            // {
            // 	    Console.WriteLine(e.Message);
            // }
            // finally
            // {
            // 	    Console.WriteLine("Finally Done !");
            // }

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}