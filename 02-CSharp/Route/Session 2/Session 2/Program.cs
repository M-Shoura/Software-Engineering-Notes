namespace Session_2
{
    internal struct Program
    {
        static void Main(string[] args)
        {
            #region Revision

            /* Start *****************************************************************************************************************/

            // Dot Net is a big platform for software technologies 
            // Cloud ==> Azure 
            // Web ==> Asp.Net , Blazor
            // Desktop ==> .Net MAUI , WPF , Winforms
            // Mobile ==> .Net MAUI , Xamarin
            // Gaming ==> Unity
            // IOT ==> ARM32 , ARM64
            // AI ==> MLNET , .Net for Apache Spark

            // The .NET SDK includes:
            // - Base Class Libraries (FCL , that contains BCL) 
            // - Infrastructure such as:
            //     - Languages: C#, F#, VB.NET
            //     - Compilers: Roslyn (C# & VB), F# compiler
            //     - Runtime components: Common Language Runtime (CLR), Garbage Collector, JIT Compiler

            // VB doesn't support asp.net core application , but C# and F# does support 

            /* End ******************************************************************************************************************/

            #endregion


            #region Compiler and Interpreter

            /* Start *****************************************************************************************************************/

            // Compiled Languages ==> The compiler takes all the code, compiles it to the native code (all the code at one time)
            //                        so there must not be any syntax errors in the code (Translates whole program at once, Gives
            //                        compile-time errors)

            // Interpreted Languages ==> The interpreter takes the code line by line , translates and executes each line and if this line
            //                           has a syntax error then the previous code is executed but the program stops here at the line that
            //                           has an error

            // Compiled Languages ==> C , C++ , C# , Java , Rust
            // Interpreted Languages ==> Python , Javascript , PHP

            // .NET is Hybrid :
            // C# code is compiled into IL (Intermediate Language) using the Roslyn compiler.
            // At runtime, the IL is interpreted or JIT-compiled into native machine code by the CLR (Common Language Runtime).

            /* End ******************************************************************************************************************/

            #endregion


            #region Error Types

            /* Start *****************************************************************************************************************/

            // We have four types of errors : 
            // 1 - Syntax Error ==> occures at compilation time, error in the syntax, ex : (semicolon) , (write console not Console)
            // 2 - Runtime Error (Exception) ==> occures during program execution or runtime (when jitting) , ex : divide by zero 
            // 3 - Logical Error ==> Code runs without crashing, but produces incorrect output (unexpected output because of wrong logic)
            // 4 - Warning ==> not an error, just a compiler notification, ex: Declaring a variable but never using it

            // Notes : 
            // - Warnings do not stop compilation, but they’re good to fix.
            // - Runtime errors are caught using try-catch blocks in C#.
            // - Logical errors are the hardest to catch because compilers and runtimes won’t complain.

            /* End ******************************************************************************************************************/

            #endregion


            #region First C# Program

            /* Start *****************************************************************************************************************/

            // namespace Session_2                       // The root namespace name is as the project name by default
            // {										    
            // 	 internal struct Program                  // It can be a class or struct
            // 	 {									    
            // 	 	static void Main(string[] args)      // Entry Point (Starting Point) is the Main Function
            // 	 	{								    
            //   
            // 	 	}
            //   }
            // }

            // What is string[] args ? 
            // This is the parameter of the Main method , it represents command-line arguments passed to your application when it starts
            // Array of strings , et’s say you run your app from the command line like this => 
            //
            //     dotnet run hello world
            //  Then 
            //     args[0] == "hello"
            //     args[1] == "world"
            //
            // These input can be used for : 
            // - Passing input files
            // - Dynamic values at runtime

            // In newer versions of C#, you can also write the main method without command-line arguments (static void Main() { .. })

            /* End ******************************************************************************************************************/

            #endregion


            #region Comments

            /* Start *****************************************************************************************************************/

            // Single Line Comment

            /*
                 Multi
                 Line
                 Comment
             */

            // Keyboard shortcut : 
            // comment   ==> ctrl+k ctrl+c  
            // uncomment ==> ctrl+k ctrl+u

            /* End ******************************************************************************************************************/

            #endregion


            #region Identifing the variables (Declaration & Initialization)

            /* Start *****************************************************************************************************************/

            // Declaration: 
            // int x;

            // Initialization: 
            // x = 100;

            // Declaration + Initialization:
            // int x = 100;

            // Note: Behind the scenes, the variable also has a memory address — this is where it's stored in the memory

            // C# is a managed code so you don't need to allocate variables in the memory manually. The CLR handles memory allocation
            // and garbage collection.

            // In C# we have pointers like C++ but it's (unsafe code) and must be inside "unsafe" code blocks because the memory can be
            // wrong accessed and managed in a wrong way.
            // Ex: 
            //
            // unsafe
            // {
            //     int x = 10;
            //     int* p = &x;
            //     Console.WriteLine((int)p);      // Prints memory address of x
            //     Console.WriteLine(*p);          // Prints 10
            // }
            // Notes:
            //       - You need to enable unsafe code in the project settings to run this.
            //       - Not available in safe environments like Blazor, MAUI, or ASP.NET Core.
            //       - Usually used in performance - critical or interop scenarios, like talking to native C/C++ libraries.
            //       - unsafe means you bypass the CLR's memory safety checks, so use with caution!

            /* End ******************************************************************************************************************/

            #endregion


            #region Naming Convention

            /* Start *****************************************************************************************************************/

            // First of all , IT'S NOT A MUST !!

            // 1 - PascalCase ==> (FirstName, MyApplication, .. ), used with Class names, method names, property names, namespaces, Enum names 
            // 2 - camelCase  ==> (firstName, myApplication), used with Local variables, method parameters, private fields
            // 3 - Kabab-Case ==> (First-Name, first-name), NOT used in C# , but used in URLs, Angular file names, or JavaScript file names)
            // 4 - Snake_Case ==> (First_Name , first_name), NOT commonly used in C# , but seen in Python or some database column names
            // 5 - SCREAMING_CAPS ==> (FIRST_NAME), NOT universal in C# , but can be used with Constants

            // General C# Convention Summary:
            // PascalCase     : Classes, methods/functions , properties, namespaces, enums, interface
            // camelCase      : Local variables, parameters, private fields
            // SCREAMING_CAPS : Constants

            // General Notes : 
            // Use meaningful names => Avoid x, y, data1 unless it's for short scopes.
            // Use nouns for classes and verbs for methods.

            /* End ******************************************************************************************************************/

            #endregion


            #region CTS and CLS

            /* Start *****************************************************************************************************************/

            // CTS ==> Common Type System 
            // CLS ==> Common Language Specifications

            // Common Type System(CTS) : The Common Type System (CTS) is part of the .NET framework and defines how types are declared,
            //                           managed, and used in all .NET languages. It ensures that types are consistent and can interact
            //                           across languages like C#, VB.NET, and F#.CTS allows objects from one language to be used in another
            //                           language, ensuring type safety and smooth interaction across the platform.
            //
            //            Types in CTS : Value Types , Reference Types , built-in or custom
            //            Type Safety  : CTS ensures type safety, meaning that operations on a variable are done in a way that is compatible
            //                           with the data type. It prevents type mismatch errors like trying to store a string in an int variable
            // 
            // Benifits of CTS :
            //   1 - Interoperability: It allows code written in different.NET languages to communicate and interact with each other.
            //   2 - Consistency: Provides a consistent set of types across languages, reducing confusion and preventing errors.
            //   3 - Type Safety: Ensures that the types used in different languages are safe and compatible, maintaining data integrity.


            // Common Language Specification (CLS) : It's a subset of CTS, defines a set of rules that ensure languages can work together
            //                                       and be compatible in the .NET environment. While CTS defines all types and how they
            //                                       interact, CLS limits the types and features to those that can be used across all
            //                                       languages in the .NET ecosystem. Essentially, it’s a way to ensure that cross-language
            //                                       interoperability is possible by setting clear boundaries on language features.
            //
            //                                       Ex: The CLS restricts the use of certain types to ensure compatibility across languages.
            //                                           For example, some languages like C# support unsigned types (ex: uint), but CLS does
            //                                           not support them because other languages (VB.NET) do not have an equivalent type.
            //                                           Same thing if a method in C# has parameters that are not CLS-compliant (like
            //                                           unsigned int), it cannot be accessed from another language like VB.NET.
            //
            //                                       Ex: with properties and parameters, The CLS defines rules around what can be used for
            //                                           properties and parameters. For example, a language like C# may support ref or out
            //                                           parameters, but other languages may not support them. The CLS limits this to ensure
            //                                           consistency.

            /* End ******************************************************************************************************************/

            #endregion


            #region Datatypes and Default values

            /* Start *****************************************************************************************************************/

            // Datatypes are catigorized into 2 categories : 
            // 1 - Value Types (Primitive)        ===> stored in the stack
            // 2 - Reference Types (NonPrimitive) ===> the reference (address) is stored in the stack but the actual data is in the heap 
            //     ex : string name = "Mahmoud";  what is stored in the heap => Mahmoud , what is stored in the stack => 101101
            //     101101 ==> address that the variable is stored in the heap. Here the reference is (4 bytes on a 32-bit system
            //     OR 8 bytes on a 64-bit system) in the stack and holds the address of the data in the heap (7*2= 14 byte)
            //
            // Important Note : Nullable types and Pointer types are not separate categories of data types in C#. Instead,
            //                  they are modifications or features applied to existing data types. (discussed later)

            // Value types VS Reference Types : 
            // The difference between them is how are the variables stored in the memory (RAM) in the stack & heap
            // Value types : hold their data directly in memory(in the stack).When you assign a value type to another variable, the data
            //               itself is copied.
            // Reference types : hold a reference(pointer) to the actual data stored in the heap. When you assign a reference type to another
            //                   variable, only the reference is copied, not the actual data.


            // ValueType (Primitive) : struct , enum
            // Reference Types (NonPrimitive) : class , interface

            // struct , enum , class , interface can be built-in or user-defined 

            // built-in structs (some of them) :
            // - byte  /  sbyte        1 byte (8 bits)
            // - short /  ushort       2 bytes
            // - int   /  uint         4 bytes
            // - long  /  ulong        8 bytes
            // 
            // - float                 4 bytes
            // - double                8 bytes	
            // - decimal               16 bytes
            //  
            // - bool                  1 byte
            // - char                  2 bytes
            // - DateTime              8 bytes
            // 
            // - starting from C# 10 (Dot Net 6)
            // - DateOnly              8 bytes    
            // - TimeOnly              8 bytes
            //

            // Note : DateTime stores the number of ticks (100-nanosecond intervals) since 12:00 AM, January 1, 0001 
            // Moreover : how to use DateOnly and TimeOnly : 
            //     DateTime dt = DateTime.Now;  
            //     DateOnly dateOnly = DateOnly.FromDateTime(DateTime.Now); 
            //     TimeOnly timeOnly = TimeOnly.FromDateTime(DateTime.Now);

            // notes: byte ==> only positive numbers
            //        sbyte ==> (signed byte) positive/negative real numbers
            //        short,int,long ==> positive/negative real numbers
            //        ushort,uint,ulong ==> (u for unsigned) only positive real numbers
            //
            //        float , double , decimal ==> floating point numbers


            // built-in classes (some of them) :
            // - Object ==> Parent datatype for all datatypes (except void), ValueType (Primitive) or Reference Types (NonPrimitive) , 
            //              built-in or user-defined, all of them inherite from Object class. So object Can hold and store any data type.
            // - String 
            // - Array
            // - Delegate



            // Default values for datatypes : 
            //
            // Value Types: 
            //
            //   int -> 0
            //   long -> 0L
            //   short -> 0
            //   byte -> 0
            //   decimal -> 0.0M
            //   float -> 0.0f
            //   double -> 0.0
            //   bool -> false
            //   char -> '\0'(null character)
            //   DateTime->DateTime.MinValue(January 1, 0001 at 00:00:00.000)
            //
            // Reference Types : 
            //
            //   Object -> Null
            //   Class object -> Null
            //   string -> Null
            //   Array  -> Null
            //   Note : if array not initialized then = Null , and if initialized then each element in the array will have it's default value

            /* End ******************************************************************************************************************/

            #endregion


            #region Value Types

            /* Start *****************************************************************************************************************/

            // The Base Class Library (BCL) : A set of fundamental libraries in the .NET Framework that provide functionality to C# and
            //                                other .NET languages. The BCL includes many of the common types that represent basic data types.
            //
            // The C# keywords              : A part of the C# language syntax.

            // - The BCL types are the types defined in the.NET Framework and represent the actual types (ex: System.Byte, System.Int32, ..)
            // - The C# keywords are the built-in type aliases that C# uses for the BCL types, they internally map to their corresponding BCL
            //   types, (ex: byte, int, bool, .. ) 

            // mapping of BCL types to C# keywords:
            // BCL         C# Keyword
            // -------------------
            // Byte    ==>  byte
            // Int16   ==>  short
            // Int32   ==>  int
            // Int64   ==>  long
            // Single  ==>  float
            // Double  ==>  double
            // Decimal ==>  decimal
            // Char    ==>  char
            // String  ==>  string
            // Boolean ==>  bool
            // Object  ==>  object
            //
            // We can write both BCL and C# Keyword but writing C# keywords is better because they are easier to read.

            // ex: int
            // it's a struct value type , stored in the stack

            // important
            // int x;      ==> CLR will allocate 4 uninitialized bytes at the Stack for variable x (if tried to access now => compile error)
            // x = 5;      ==> Now x is initialized and has a value, not garbage
            // int y = 10; 
            // y=x;        ==> Now y has the same value of x (5)
            // x++;        ==> Now x has a new value (6)
            // cw(y);      ==> y still has the old value of x before (++)

            // So the value types don't share the same place at the memory, when you assign a value type to another variable, the
            // actual value is copied.

            /* End ******************************************************************************************************************/

            #endregion


            #region Reference Types

            /* Start *****************************************************************************************************************/

            // First we will make Point class to test the example
            // class Point
            // {
            //     int x;   // 4 bytes
            //     int y;	// 4 bytes
            // }  

            // Point P1;        ==> declare for reference variable of type Point initialized to NULL
            //                  ==> reference P1 can refer to object of type "Point" OR "type inhert from Point class" (due to polymorphism)
            //                  ==> This reference is stored on the Stack, it takes 4 bytes on a 32-bit system or 8 bytes on a 64-bit system
            //                  ==> CLR will allocate 0 bytes at the Heap


            // P1 = new Point();
            // after new keyword :
            // 1 - Allocate for required number of bytes for the object at the heap (in our case 8 bytes + CLR Overhead variables)
            // 2 - initialize the allocated bytes at the heap with the default values of it's datatype
            // 3 - calling the user defined constructor (if exists) , and if doesn't exist then call the default parameterless constructor
            // 4 - Assign the address of the newly created object in the heap to the reference (P1) in the stack

            // Point P2 = new Point();
            // P2 = P1;

            // now the first object has 2 references , P1 or P2 .. they share the same object at the heap 
            // and the second object (the newly created) is now "unreachable object"

            // P2.X = 5;
            // cw(P2.x)   ==> 5 
            // cw(P1.x)   ==> 5 also

            // why ? because they reference the same place at the memory and any change in one of them will affect the other one

            // Note : Reference types store a reference(address) to the actual data stored in the heap, which means that when you assign a 
            //        reference type to another variable, you're actually copying the reference (memory address), not the actual data.

            // Notes :
            // 1 - The default values for reference type variable (class , string , object , .. ) ==> NULL
            // 2 - don't allocate many objects at the heap that will be unreachable objects, because the garbage collector pauses the
            //     application temporarily when needed (called a GC pause or stop-the-world event) to clean unreachable objects in the heap.

            /* End ******************************************************************************************************************/

            #endregion


            #region Code Snippets

            /* Start *****************************************************************************************************************/

            // Code Snippets : Shortcuts in Visual Studio that help you write common code patterns faster and more accurately.

            // cw+tab ===> Console.WriteLine();
            // if+tab ===> if condition
            // switch+tab ===> switch case 
            // for+tab ===> for loop
            // ctor ===> constructor of a class (discussed in OOP)
            // prop ===> property (discussed in OOP)


            // Custom Snippets: Create them using Visual Studio -> Tools -> Code Snippets Manager

            /* End ******************************************************************************************************************/

            #endregion


            #region Object Class

            /* Start *****************************************************************************************************************/

            // Object : A class (Reference Type) : The parent datatype to all the datatypes in Dot Net value types or reference types,
            //                                     built-in or user defined .. all of them

            // Why we need a class that all datatypes inhert from ? 
            // 1 - To enable boxing/unboxing and polymorphism, but boxing and unboxing had some problems , so later "Generics" solved these
            //     problems in C# 2.0 .. (generics was not there in C# 1.0)
            // 2 - 4 functions/behaviours that should exist in every datatype (3 can be overriden and 1 cannot)
            //   1 - ToString(); ==> by default gets the string representation of the object (default: namespace+type) (can override)
            //   2 - GetHashCode() ==> generates and returns a unique integer hash code (used in hashing algorithms/collections) (can override)
            //   3 - Equals(object); ==> by default checks if equal (the references not the object state (data of the object)) (can override)
            //   4 - GetType(); ==> Returns the Type object representing the runtime type of the instance (CANNOT BE OVERRIDEN) , this type 
            //                      object that is returned has "Name" , "FullName" , "namespace" , BaseType , ...

            // Note : GetType().name; ===> returns name of the class / struct
            //		  ex: int x = 10;
            //	      Console.WriteLine(x.GetType().name); ==> Int32

            // GetType()  VS   ToString()
            // GetType  : returns a Type object that has "Name" , "FullName" , "namespace" , BaseType ,..  default returns Namespace.TypeName
            // ToString : returns a string
            //            if the class doesn't override the function inherited from object class , then it will return : Namespace.TypeName
            //            if the class override the function inherited from object class , then each type will return a string , types that 
            //            override the ToString() : 
            //                  - Value Types: byte, sbyte, short, ushort, int, uint, long, ulong, float, double, decimal => return value
            //                                 bool           ==>   "True" or "False"
            //                                 char           ==>   the character itself
            //                                 DateTime       ==>   date in full format
            //                                 TimeSpan       ==>   duration like "01:00:00"
            //                                 DateOnly       ==>   (since .NET 6)
            //                                 TimeOnly       ==>   (since .NET 6)
            //                                 Guid           ==>   formatted GUID string
            //                                 Enum           ==>   name of the enum member
            //                  - Reference Types: 
            //                                 string         ==>   returns itself
            //                                 StringBuilder  ==>   returns the built string content
            //                                 Uri            ==>   returns the full URI string
            //                                 Version        ==>   ex: "1.0.0.0"
            //                                 IPAddress      ==>   ex: "192.168.1.1"


            // object O1;
            // - declare for a reference of type "Object" that refer to NULL
            // - this reference "O1" can refer to an instance(object) of type "Object" or any other type that inherts class "Object"
            //   (meaning All value types or reference types , built-in or user defined)
            // - 4 or 8 bytes (depending on the system) have been allocated for the reference in the Stack 
            // - 0 bytes have been allocated in the Heap

            // O1 = new object();
            // O1 = new string("Shoura");     or    O1 = "Shoura";
            // O1 = 3;
            // O1 = 12.55;
            // O1 = new DateTime();

            // Note : Previous 3 exmples with value types .. here they are stored in the heap although they are value types
            //        Boxing and Unboxing (will be discussed later)

            /* End ******************************************************************************************************************/

            #endregion


            #region Fractions (default double) and Digit Separator (_)

            /* Start *****************************************************************************************************************/

            // The default datatype for fractions is "double" , so if we write 3.14, it’s automatically treated as a double by default, and 
            // to change this behaviour , we must specify the type using "m" and "f" characters
            // double b = 5.3;       
            // float a = 5.3f;       or       a = 5.3F
            // decimal c = 5.3m      or       c = 5.3M

            // ( _ ) : called a digit separator feature introduced in C# 7.0. You can place underscores inside numeric literals to make
            //         large numbers easier to read, ex: long num = 100_000_000;   cw(num); ==> will be printed without the underscores

            /* End ******************************************************************************************************************/

            #endregion


            #region String Interpolation and Other Approaches

            /* Start *****************************************************************************************************************/

            // String Interpolation : A feature in C# introduced in C# 6 that allows you to embed expressions inside string , making it
            //                        more readable and maintains performance over string concatenation (using StringBuilder in some cases)

            // Ex1 :
            //   string s = "mahmoud";
            //   Console.WriteLine($"hi my name is {s}");

            // Advanced : 

            // Ex2 : 
            //   int a = 5, b = 10;
            //   string result = $"Sum of {a} and {b} is {a + b}";

            // Ex3 : 
            //   double price = 25.512345;
            //   string message = $"The price is {Math.Round(price, 2)}.";   // The price is 25.51.

            // Ex4 : 
            //   int age = 18;
            //   string status = $"You are {(age >= 18 ? "an adult" : "a minor")}.";



            // String Interpolation and Formatting :
            // You can use format specifiers to control how values are represented and format them :
            // { value: C} — Currency format
            // { value: D} — Decimal format
            // { value: F} — Fixed - point format
            // { value: F2} — Fixed - point format, two decimal places.
            // { value: X} — Hexadecimal format
            // { value: N} — Number with group separators that uses commas as thousands separators.
            // { value: P} — Percentage format.
            // { date: yyyy - MM - dd} — Formats a DateTime to a specific date format.
            // { date: hh: mm: ss} — Formats the time.
            //
            // Examples : 
            // 
            // int number = 255;
            // Console.WriteLine($"Hex: {number:X}"); // Output: Hex: FF
            //
            // double price = 1234.5678;
            // string formattedPrice = $"The price is {price:C2}";    // Currency with two decimal places
            // Console.WriteLine(formattedPrice);                     // Output: The price is $1,234.57
            // 
            // double interestRate = 0.05;
            // string interestRateFormatted = $"Interest rate: {interestRate:P2}";    // Percentage with two decimal places
            // Console.WriteLine(interestRateFormatted);                              // Output: Interest rate: 5.00%
            //
            // decimal price = 99.99M;
            // string formattedPrice = $"Price: {price:C2}";          // $99.99 (Currency format with 2 decimal places)
            // Console.WriteLine(formattedPrice);                     // Output: Price: $99.99
            //
            // double value = 123.45678;
            // string formatted = $"Value: {value:F2}";               // Two decimal places
            // Console.WriteLine(formatted);                          // Output: Value: 123.46
            //
            // int number = 1000000;
            // string formattedNumber = $"Number: {number:N2}";       // No decimals
            // Console.WriteLine(formattedNumber);                    // Output: Number: 1,000,000.00
            //
            // DateTime now = DateTime.Now;
            // string formattedDate = $"Today's date is {now:yyyy-MM-dd} and time is {now:HH:mm:ss}";
            // Console.WriteLine(formattedDate);                      // Output: Today's date is 2025-04-11 and time is 14:35:47
            //
            // string message = $"This is a curly brace: {{ Curly }}";     // Escaping Curly Braces by doubling them
            // Console.WriteLine(message);                                 // Output: This is a curly brace: { Curly }



            // String Interpolation vs. Other Approaches:
            // While string interpolation is great, there are other ways to format strings in C#:
            // 
            // 1 - String.Format(): This is the traditional way of formatting strings.
            // string result = string.Format("Hello, my name is {0} and I am {1} years old.", name, age);
            //
            // 2 - String.Concat(): This method concatenates multiple strings together, but doesn't allow formatting.
            // 
            // 3 - StringBuilder (discussed later) : For complex string concatenation operations or inside loops, StringBuilder can be more
            //                                       efficient thanstring interpolation.

            /* End ******************************************************************************************************************/

            #endregion


            #region Value Type Casting

            /* Start *****************************************************************************************************************/

            // From one value type to other value type ...
            // 1 - Implicit Casting (Widening)
            // 2 - Explicit Casting (Narrowing)
            // 3 - Parse
            // 4 - Convert

            // 1 - Implicit Casting (Widening) : This happens automatically, when there is no risk of data loss (ex: int to long)
            //       
            // int x = 10;
            // long y = x ; ==> implicit casting [Safe Casting]


            // 2 - Explicit Casting (Narrowing) : This requires manually casting the value, as there may be a loss of data or precision
            //
            // long a = 10;
            // int b = (int)a ; ==> explicit casting [Unsafe Casting], if variable a had a big value that int cannot store, then variable b
            //                                                         will contain garbage value (overflow) WITHOUT EXCEPTIONS but bad value
            //
            // to solve getting garbage value, use the checked block and unchecked block (used for overflow checking only) , if there is a
            // overflow then there is an exception thrown (enforce overflow checking) => Arithmetic operation resulted in an overflow
            // checked
            // {
            //    long a = 1_000_000_000_000;
            //    int b = (int) a; 
            // 	  unchecked
            // 	  {
            // 	     Console.WriteLine(b);   // we put it here because it's not nessisary to check on this statement 
            // 	  }
            // }
            // 
            // string num = "5";
            // int number = (int) num;           // wrong ! we can modify this casting operator (discussed later), but now it's not valid 



            // 3 - Parsing : Used to cast a string representation of a value into its corresponding data type (from string to the caller
            //               datatype), but if the string is not in the correct format, it will throw a FormatException.
            //
            // cw("Enter the name : ")
            // string name = Console.ReadLine();    ==> will get a warning because Console.ReadLine() can return null ..
            //                                          so to avoid the warning here use nullable string (discussed later)
            //
            // cw("Enter the age : ")
            // int age = int.Parse(Console.ReadLine());



            // 4 - Convert : a class contianing a set of methods used for castring from a datatype to another
            //
            // cw("Enter the name : ")
            // string name = Console.ReadLine();     
            //
            // cw("Enter the age : ")
            // int age = Convert.ToInt32(Console.ReadLine());
            // 
            // double salary = 3.75;
            // int salaryIntNumber = Convert.ToInt32(salary);  // Rounds the double to the nearest integer , will become 4 in our case
            //
            // string a = "true";
            // bool b = Convert.ToBoolean(a);    // No Problem 
            //
            // string a = "Shoura";
            // bool b = Convert.ToBoolean(a);    // Runtime error or Exception !


            // Important Note : we don't use convert or parse in the real world .. because they don't handle excpetions
            //                  ex : int age = Convert.ToInt32(Console.ReadLine());  and we entered "Shoura" .. then 
            //                  we will get an excpetion. Instead we use "TryParse" (will be discussed later)

            /* End ******************************************************************************************************************/

            #endregion


            #region Operators

            /* Start *****************************************************************************************************************/

            // 1 - Unary 
            //     [ ++ ] , [ -- ] ==> (both can be prefix or postfix)
            // 2 - Binary
            //     [ + ] , [ - ] , [ * ] , [ / ] , [ % ] 
            // 3 - Assignment
            //     [ = ] , [ += ] , [ -= ] , [ *= ] , [ /= ] , [ %= ] , [&= |= ^= <<= >>=] , (the only one which works from right to left)
            // 4 - Relational (Comparison)
            //     [ == ] , [ != ] , [ >= ] , [ <= ] , [ > ] , [ < ] 
            // 5 - Logical 
            //     [ ! ] , [ && ] , [ || ]  , (short circuit , if the first doesn't match the condition it will not continue)
            // 6 - Bitwise 
            //     [ ^ ] , [ & ] , [ | ] , [ ~ ] , [ >> ] , [ << ] , (long circuit)
            // 7 - Ternary / Conditional
            //     [ = ? : ] 

            // other types of operators discussed later : 
            // - Null-Coalescing Operator
            // - Is Operator
            // - As Operator
            // - Lambda Operator (Expression)
            // - Type Checking Operators


            // Note : If you are not familier with them .. YOU SHOULD SEARCH !	


            // Operators priority/precedence and Asscoitivity
            // 1 - Parentheses ()
            // 2 - Unary operators (++, --)
            // 3 - Multiplication, Division, and Modulus *  /  %
            // 4 - Addition and Subtraction +  -
            // 5 - Assignment operators =  +=  -=  
            // 
            // Associativity:
            // - Left to right : for operators like  *  /  +   -   =
            // - Right to left : for assignment operators and prefix unary operators.

            /* End ******************************************************************************************************************/

            #endregion


            #region String escape sequences (\n , \t , ....)

            /* Start *****************************************************************************************************************/

            //  \'   --> single quote 
            //  \"   --> double quote
            //  \\   --> Backslash
            //  \t   --> Tab (space)
            //  \n   --> New line
            //  \0   --> Null Character
            // 
            // if we want to escape ALL the meaning of the '\'  (any of the last mentioned) in the string , then wtire @ as below:
            // string FolderPath = @"C:\Users\lenovo\Desktop\New folder (2)\C#\Session 4";
            // or write it without @ but with double backstash ===> 
            // string FilePath = "C:\\Users\\lenovo\\Desktop\\New folder (2)\\C#\\Session 4";

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}