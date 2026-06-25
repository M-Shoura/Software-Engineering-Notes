namespace OOP___Session_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Important note : now we started OOP and you must view all the files in the solution, maybe there is another class in the 
            //                  solution that is important .. not only this class as last sessions 

            #region How can we change the Targeted framework ?

            /* Start *****************************************************************************************************************/

            // How to change the Targeted framework in Visual Studio project ?
            // right click on the project , then properties , in General --> Target Framework , choose the version you want 
            //
            // Note : if there is a reference with another project in this project .. then the 2 projects must be with the same 
            //        major version (.net 7 and .net 8) .. no problem if there is a difference in minor versions (.net 7.1 and .net 7.2)
            // 
            // Note : don't miss updating all the installed packages in your project , can be done through the "NuGet manager" or by double
            //        clicking on the project and changing the versions manually.

            /* End ******************************************************************************************************************/

            #endregion


            #region Access Modifiers

            /* Start *****************************************************************************************************************/

            // Access Modifiers : A set of C# Keywords that control the visibility and accessibility scope of classes, methods, properties,
            // fields, and other members of a program. They are essential for implementing encapsulation.

            // We have 6 Access Modifiers , (from the smallest scope to the biggest scope) :
            // 1 - Private 
            // 2 - Private Protected   (or Protected Private)
            // 3 - Protected 
            // 4 - Internal 
            // 5 - Internal Protected  (or Protected Internal)
            // 6 - Public

            // In this session we will discuss only three , any "Protected Access Modifiers" will be discussed later because it's related to
            // the inheritance 

            // 1. private
            // Scope: Accessible only within the containing class or struct.
            // Use case: Hide implementation details that should not be accessed directly from outside the class.

            // 2. internal
            // Scope: Accessible only within the same assembly (project/compiled DLL or EXE).
            // Use case: Useful for hiding implementation details within a project.

            // 3. public
            // Scope: Accessible from anywhere (same class, other classes, other assemblies).
            // Use case: Used when you want your members or class to be globally accessible.


            // Examples with classes:
            // 
            // internal : Using this class (making an object or using a static function in it) must be inside this project ONLY.
            //            Can be accessed inside the project but outside in other projects it will not be accessable.
            //            Error will be : inaccessible due to its protection level. 
            //
            // public   : Using this class can be inside or outside it's project (in the same solution). In case of outside the project,
            //            the new project must have a reference to the project where the class is in (references are discussed later)

            // Examples with members inside a class (attributes or properties or methods or events) : 
            //
            // private  : This member is accessable inside it's class ONLY. 
            // internal : This member is accessible inside it's class and also inside any class that is in the SAME project, not
            //            accessable in other projects.
            // public   : This member is accessable inside it's class and also inside any class that is in the same project and
            //            also inside any class that is in other project in solution. 

            /* End ******************************************************************************************************************/

            #endregion


            #region What can be written inside a namespace

            /* Start *****************************************************************************************************************/

            // We can write inside the namespace : 
            // 1 - Struct    ==> Value Type 
            // 2 - Enum      ==> Value Type
            // 3 - Class     ==> Reference Type
            // 4 - Interface ==> Reference Type
            // 5 - Delegates     (Discussed in Advanced C#)
            //
            // Note : we can write another Namespace inside the current namespace (Nested Namespace)

            // Allowed Access Modifiers inside the namespace : 
            // 1 - internal (default if not specified)
            // 2 - public

            // Note : We cannot make the class private ! because inside the namespace we can only use internal and public 

            /* End ******************************************************************************************************************/

            #endregion


            #region	what can be written inside the class or struct ? 

            /* Start *****************************************************************************************************************/

            // What can be written inside the class or struct ? 
            //
            // Member Type                 | Notes                                                                        
            // ----------------------------|------------------------------------------------------------------------------
            // Fields (Attributes)         | Variables to hold data (class member[static] OR object member[non-static] )  
            // Properties                  | Encapsulated fields with get/set (New way of Incapsulation)                  
            // Methods                     | Functions (getter & setter [old way of incapsulation])                       
            // Events                      | For event-driven programming (Discussed later in Advanced C# )               
            // Constructors                | Special function because same name of class or struct + no return            
            // Static Constructors         | One allowed per type                                                         
            // Delegates                   | Define method signatures                                                     
            // Indexers                    | Allows indexing like arrays (special type of properties)                     
            // Nested Types                | Classes, structs, enums, interfaces, delegates                               
            // Operators (Overloads)       | Must be `public static`                                                      

            // Class VS Struct : 
            // inheritance : Classes only; structs can't inherit other structs or classes (except `System.ValueType`)
            // Finalizers (destructors) (`~ClassName`) : Structs do not support destructors , Only classes support them
            // Structs cannot be abstract and cannot contain virtual members
            //
            // Note : the tasks of the constructor in the structs differs from the tasks of the constructor in the class

            /* End ******************************************************************************************************************/

            #endregion


            #region Allowed Access Modifiers inside a class

            /* Start *****************************************************************************************************************/

            // Allowed Access Modifiers inside a class :
            // 1 - Private  (Default access modifier inside the class or struct)
            // 2 - Private Protected   (or Protected Private)
            // 3 - Protected 
            // 4 - Internal 
            // 5 - Internal Protected  (or Protected Internal)
            // 6 - Public

            // Note : In nested Classes, if you define a class inside another class, you can use ALL access modifiers in the outer class or 
            //        the inner class.

            /* End ******************************************************************************************************************/

            #endregion


            #region Enum

            /* Start *****************************************************************************************************************/

            // Enum : A value type datatype that allows you to define a set of named constants that doesn't change over time (gender , week
            //       days , ..). It’s used to represent a fixed set of related values in a type-safe way.
            // we don't use access modifiers inside the Enum.


            // Basic Syntax :
            //
            // enum DayOfWeek
            // {
            //     Sunday,
            //     Monday,
            //     Tuesday,
            //     Wednesday,
            //     Thursday,
            //     Friday,
            //     Saturday
            // }
            // Each name in the enum represents a constant integer value. By default, the first name is 0, the next is 1, and so on.
            // 
            // DayOfWeek today = DayOfWeek.Monday;
            // int num = (int)today;                 // num = 1


            // Note : you can assign custom values:
            // enum Status
            // {
            //     None = 0,
            //     InProgress = 3,
            //     Completed = 5,
            //     Cancelled = 10
            // }


            // enum Grade   
            // {
            //     // Labels : 
            //     A = 1, 
            //     B /*= 2*/,     // by default the numbering will be continued
            //     C,             // by default the numbering will be continued
            //     D,             // by default the numbering will be continued
            //     E,             // by default the numbering will be continued
            //     F              // by default the numbering will be continued
            // }


            // Backing Type of Enums : By default, enums use int as the underlying type, but you can change it to any integral type for example
            //                         (byte, sbyte, short, ushort, int, uint, long, ulong) Note : we CANNOT USE (FLOAT,DOUBLE,CHAR,STRING,..),
            //                         WE CAN USE ONLY INTERGRAL TYPES. The size of the Enum variable in stack = the size of it's type


            // enum Permissions : byte
            // {
            //     Read = 1,
            //     Write = 2,
            //     Execute = 4
            // }


            // enum Gender : byte  /* byte = [0,255] */
            // {
            //     // Labels : 
            //     Male = 1,            // More than one label with the same value
            //     M = 1,               // More than one label with the same value
            //     Female = 2,
            //     F = 2,
            //     // xyz = 256         // Not allowed ! cannot be converted to a byte , it fits in "int" or larger
            // }


            // Flags Enum (Bitwise Enums) : Use the [Flags] attribute to define bitwise combinable enums
            // 
            // [Flags]
            // enum FileAccess
            // {
            //     None = 0,
            //     Read = 1,      // 0001
            //     Write = 2,     // 0010
            //     Execute = 4    // 0100
            // }
            // 
            // Combine values:
            //
            // FileAccess access = FileAccess.Read | FileAccess.Write;              // 0001 | 0010 = 0011
            //
            // Then check if a flag is set :
            // bool canWrite = (access & FileAccess.Write) == FileAccess.Write ;


            // Enum Operations : 
            // - Get the name from a value
            //   Enum.GetName(typeof(DayOfWeek), 1);       // "Monday"
            //
            // - Get all values
            //   DayOfWeek[] days = (DayOfWeek[]) Enum.GetValues(typeof(DayOfWeek));
            //
            // - Check if value is defined
            //   Enum.IsDefined(typeof(Status), 5);       // true


            // Grade MyGrade = Grade.A;
            // if(MyGrade == Grade.A)
            //      Console.WriteLine(":)");
            // else
            //      Console.WriteLine(":(");


            // MyGrade = (Grade) 4;          // D
            // MyGrade = (Grade) 100;        // 100


            // How to convert the string to an enum label ?
            // Gender MyGender = (Gender)"Male";              // Not Allowed XXXX
            // use Enum.Parse or Enum.TryParse (TryParse has 2 versions and it's better to use the generic one)
            // 
            // Gender x = (Gender)Enum.Parse(typeof(Gender), "Male");         // it's better to use TryParse to avoid the exceptions of
            // 													              // Parse method if it failed to convert
            // 
            // Enum.TryParse(typeof(Gender), "TEST", false , out object? o);  // false ==> ignore case (Case sensitivity)
            // 																  // here we've done "Boxing" , exactly as : object? o = Gender.Male 
            // 																  // this is not the best way
            // 																  // if casting failed , o = null (default value for objects) 
            // 																  
            // Enum.TryParse/*<Gender>*/("Male", false,out Gender g);         // the generic version of TryParse
            // 																  // if the casting failed , g = 0; (default value of enum = 0)
            // 
            // Discuss the previous problem: if the casting failed then g = 0; because it's the default value in this case, the parsing failed
            // but maybe we have a label that has value = 0 in our enum ??? this will not be a correct parsing , so to avoid this problem
            // manually start numbering the labels by making the first label with value !=0 and the next label will have the last value+1 


            // Advanced Example : 
            //
            // enum OrderStatus
            // {
            //     Pending,
            //     Confirmed,
            //     Shipped,
            //     Delivered,
            //     Cancelled
            // }
            // 
            // public void UpdateOrderStatus(OrderStatus status)
            // {
            //     if (status == OrderStatus.Shipped)
            //     {
            //         Console.WriteLine("The order is on its way!");
            //     }
            // }
            //
            // - Enum with Extension Methods (Extension Methods will be discussed later, called through an object) : 
            // public static class OrderStatusExtensions
            // {
            //     public static bool IsFinal(this OrderStatus status)
            //     {
            //         return status == OrderStatus.Delivered || status == OrderStatus.Cancelled;
            //     }
            // }
            // Usage:
            // if (orderStatus.IsFinal()) { ... }


            // Why Use Enums ?
            // Type safety : Only valid values allowed
            // Readability : Names instead of magic numbers
            // Grouping constants : Logical grouping of related values

            // Note : No methods or behaviors can be defined inside enums (but you can use extension methods).

            /* End ******************************************************************************************************************/

            #endregion


            #region Struct

            /* Start *****************************************************************************************************************/

            // Struct : A value type datatype that is used to create small, lightweight objects. It's similar to a class but has different
            //          memory behavior and restrictions.

            // To make a new datatype , what to choose struct or class ?
            // it's based on what you want and the mechanism that it will work with the memory 


            // To make a struct , right click on the project then add a new class , after generating the template change the "class" to 
            // "struct" because we don't have a direct template for the struct 
            //
            // Example :
            //
            // public struct Point
            // {
            //     public int X;
            //     public int Y;
            // 
            //     public Point(int x, int y)
            //     {
            //         X = x;
            //         Y = y;
            //     }
            // 
            //     public void Print()
            //     {
            //          Console.WriteLine($"({X}, {Y})");
            //     }
            // }

            // Allowed Access Modifiers inside a struct :
            // 1 - Private (Default access modifier inside the class or struct)
            // 2 - Internal 
            // 3 - Public

            // Important Note : ANY Access modifier with "Protected" keyword is not allowed in the struct, why ?
            // Because "Protected" is related to the inheritance which is not supported in the struct (cannot be derived from or extended)


            // Note : the life time of the object of a struct is linked with the stack frame of the function in the stack , once the 
            // stack frame is deleted then the object is deleted too ... but with classes the life time is longer , the thing that we 
            // will use while implementing dependancy injection (will be discussed later .. )


            // Struct Constructor : 
            //
            // The constructor in struct/class is a special method :
            //  - named always with the same name of the struct/class 
            //  - has no return 
            //
            // The constructor is automatically called when an object is created 
            //
            // We can have more than one constructor each with different signature(types of parameeters, number of parameters, order of 
            // parameters) ==> (constructor overloading)
            //
            // In struct/class , the access modifier of the constructor is always "public" but in only one case it's private when implementing
            // "singleton design pattern"
            //
            // Structs can be instantiated without using a constructor (i.e., new is optional).
            //
            // You cannot define a parameterless constructor before C# 10.
            //
            // You MUST initialize all fields in a custom constructor (before .Net 7), after that (.Net 7+) fields are initialized with default
            //
            // Structs always have an implicit parameterless constructor that sets all fields to their default values.


            // Job for the constructor in the Struct differes from the job of the constructor in the Class
            //
            // Job of constructor in Struct : 
            // - The only one responsible for initialization of the attributes of that object from the struct
            // 
            // Point P1;
            // - Here P1 is an object , not a reference (Point is a struct [value type] not a class or interface [reference types])
            // - here we --> declare an object of type "Point" 
            // - CLR will allocate 8 (4+4) bytes in the STACK [uninitialized bytes] 
            // 
            // P1 = new Point();
            // - The job of new keyword is different between Struct and Class
            // - in struct "new" keyword is just for choosing the constructor that will initialize the attributes  


            // public struct Point {
            //     public int X;
            //     public int Y;
            // 
            //     // Parameterized constructor
            //     public Point(int x, int y) {
            //         X = x;         // ✅ You must initialize all fields
            //         Y = y;
            //     }
            // }


            // - Using Struct Without Constructor
            // Point p;           // No "new" used
            // p.X = 5;
            // p.Y = 10;          // Must manually assign all fields before use
            //
            // - Using Struct With Constructor 
            // Point p = new Point(5, 10);                // Uses custom constructor


            // Copy Behavior (Value Type) :
            // Structs are copied by value:
            //
            // Point p1 = new Point(1, 2);
            // Point p2 = p1;
            // 
            // p2.X = 5;
            // Console.WriteLine(p1.X);       // Still 1, not affected


            // 🆕 C# 10+ Enhancements to Structs
            // 1 - Can define parameterless constructors
            // 2 - Can define field initializers
            // 
            // public struct Person
            // {
            //     public string Name { get; set; } = "Unknown";     // ✅ C# 10+
            //     public Person() {} // ✅ C# 10+
            // }


            // - we have 4 functions that are in any datatype (value type or reference type) (built in or user defined) :
            //    1 - ToString()
            //    2 - GetHashCode()
            //    3 - Equals()
            //    4 - GetType()
            // 
            // In value types (structs and enums) they inherited these functions from a class called "ValueType" , that inherited these 
            // functions from a class called "object". 
            // 
            // In reference types they inherit the functions directly from object class directly.
            // 
            // 
            // Note : it's not allowed to make structs and enums (value types) to inherit .. inheritance here is allowed only in the 
            //        framework done by the developers of .net 
            // 
            // 
            // ToString() ==> returns Namespace.Datatype (default behaviour) , so what about changing this behaviour ??
            // Ans: Overriding ToString Function (See the Point struct file and notice the override function)
            // 
            // Notes
            // 1 - int x = 10 ; cw(x.ToString()) ==> doesn't print the namespace.Datatype , but prints 10 .. means that int overrides
            //                                       the function by default ..
            // 2 - cw(P1.ToString()) == cw(P1);  ==> WriteLine invokes the ToString function directly
            // 
            // Note : Not all functions inherited from the parents can be overriden (EX : GetType()) .. Will be discussed later 


            // Notes : 
            // 1 - Structs Cannot inherit from another struct or class
            // 2 - Structs can implement interfaces
            // 3 - Structs cannot have destructors (Finalizers)
            // 4 - Structs cannot be abstract and cannot contain virtual members
            // 5 - Struct by default is not null , unless using Nullable<T> or structName? (ex: Point? p1 = new Point();)


            // Structs Can Contain : 
            // - Member Type	
            // - Fields	
            // - Properties	
            // - Methods	
            // - Static Constructors
            // - Constructors (Parameterized only C# < 10 , C# >= 10 allow parameterless)
            // - Events	
            // - Indexers	
            // - Operators(Overloads)	
            // - Static members	
            // - Nested types	
            // - Delegates


            // To sum up , use struct when :
            // You don't need inheritance.
            // The object is small and immutable.
            // You care about performance.
            // You want value semantics (copy by value, not by reference).

            /* End ******************************************************************************************************************/

            #endregion


            #region What is Object-Oriented Programming (OOP) ?

            /* Start *****************************************************************************************************************/

            // in the first session of C# we've discussed the different paradigms of programming (make a revision on session 1 .. ) 

            // Object-Oriented Programming (OOP) : A programming paradigm based on the concept of "objects", which are instances of classes.
            //                                     Each object can store data (fields/properties) and perform actions (methods).

            // OOP Consists of 4 pillars : 
            // 1 - Encapsulation ==> (supported with Class and Struct)
            //       - Hiding internal details and showing only what’s necessary
            //       - Keep data (fields/attributes) private
            //       - show actions (methods or properties) to the outside world , to use the private data or fields.
            //       - Prevent external code from corrupting the internal state
            //         
            // 2 - Inheritance   ==> (supported with Class only)
            //       - One class can inherit behavior and data from another
            //       - Avoid code duplication
            //       - Supports "is-a" relationships
            //
            // 3 - Polymorphism  ==> means Many Forms ... Consists of (Overloading & Overriding)
            //       - (Overloading supported with Class & Struct , Overriding supported with Class only [Related to inheritance] )
            //       - Overloading : functions with the same name in the same class or struct , each with different 
            //                       behavior , they must have different (number or type or ordering) of the parameters 
            //       - Overriding  : overriding the functions , properties , .. inherited from the parent and changing the 
            //                       behavior of it not supported with structs because there is no inheritance (prerequisite)
            // 4 - Abstraction   ==> (supported with Class and Struct)
            //       - Focusing on what an object does, not how it does it.
            //       - Hide complexity
            //       - Provide simple and clear interfaces
            //       - Often implemented using abstract classes or interfaces


            // Goal of OOP : 
            // 1 - Mirrors real-world entities
            // 2 - Encourages code reuse, modularity, and maintenance


            // Term	Meaning recap : 
            // Class	        Blueprint/template for objects
            // Object	        Instance of a class
            // Encapsulation	Hiding internal details
            // Inheritance      Reusing functionality via parent-child classes
            // Polymorphism     One interface, multiple behaviors
            // Abstraction      Simplifying complex systems

            /* End ******************************************************************************************************************/

            #endregion


            #region Encapsulation - First OOP Pillar 

            /* Start *****************************************************************************************************************/

            // Encapsulation : One of the four core pillars of Object-Oriented Programming (OOP). It refers to the merging of data and
            //                 behavior (fields and methods) into a single unit (can be used with class or struct), while restricting direct 
            //                 access to some of the object's components to protect its internal state.

            // Encapsulation = Data hiding(private fields) + Controlled access(public properties or methods)


            // - We will use "Employee" struct as the example :
            // Employee employee = new Employee(1 ,"Shoura" , 22 , 1_000_000);
            // employee.Id = 5;                    // set id directly through the attribute  
            // Console.WriteLine(employee.Id);     // get id directly through the attribute  
            // 
            // - direct interaction with the attributes produce 3 major problems : 
            //    1 - If we change the name of the attribute inside the class or struct then it must be changed at any place it's used in 
            //        (in the file of the class or struct and also in any other file or project !!) 
            //    2 - We cannot control the data and make data validation before assigning the values to data fields
            //    3 - Attribute cannot be "Read only", this is not allowed until now 
            // 
            // Encapsulation solved these three problems : 
            //
            // In C#, encapsulation is implemented using:
            // - Access modifiers (private, public, protected, ... )
            // - Properties with get and set accessors OR getter setter methods (old way)


            // Example 1: Basic Encapsulation Using Private Fields and Public Methods (old way of getters and setters) :
            // public class BankAccount
            // {
            //     private decimal balance;            // Private field (hidden from outside)
            // 
            //     public void Deposit(decimal amount)
            //     {
            //         if (amount > 0)
            //             balance += amount;
            //     }
            // 
            //     public decimal GetBalance()
            //     {
            //         return balance;
            //     }
            // }
            //
            // Usage:
            //
            // var account = new BankAccount();
            // account.Deposit(1000);
            // // Console.WriteLine(account.balance);    // ❌ Not allowed (private)
            // Console.WriteLine(account.GetBalance());  // ✅ Controlled access

            // Example 2: Using Properties (Preferred in Modern C#)
            // public class Person
            // {
            //     private string name;
            // 
            //     public string Name
            //     {
            //         get => name;                  // Read access
            //         set => name = value.Trim();   // Write access can be with logic
            //     }
            // }
            //
            // Usage:
            //
            // var person = new Person();
            // person.Name = "  Shoura  ";
            // Console.WriteLine(person.Name);       // Output: "Shoura" (without spaces)

            // Example 3: Encapsulation with private set (Read-only outside)
            // public class User
            // {
            //     public string Username { get; private set; }
            // 
            //     public User(string username)
            //     {
            //         Username = username;
            //     }
            // }
            //
            // Usage:
            //
            // var user = new User("Admin");
            // Console.WriteLine(user.Username);    // ✅ Read allowed
            // // user.Username = "Hacker";         // ❌ Compile-time error


            // Key Benefits of Encapsulation
            // - Cleaner API : Only expose what is needed and necessary
            // - Security    : Prevents unwanted changes from external code
            // - Validation  : Add logic inside set or methods to validate data
            // - Flexibility : Internal implementation can change without affecting users

            /* End ******************************************************************************************************************/

            #endregion


            #region Properties 

            /* Start *****************************************************************************************************************/

            // Properties : A powerful OOP feature that provide controlled access to class or struct fields. They act as smart wrappers
            //              around fields/attributes, enabling encapsulation and optional logic during getting or setting values.


            // Purpose of Properties :
            // - Hide internal implementation (encapsulation).
            // - Add validation, logging, or events on access/modification.
            // - Replace public fields with a safe interface. 


            // Types of Properties : (Full Property , Automatic Property , Indexer)

            // 1. Full Property (Manual Property) : This is the classic style where you define a private field, and expose it via a get/set
            //                                      accessor. This allows you to include custom logic such as validation, logging, ...  
            // code snippet ==> propfull  (use Tab & Shift Tab to Navigate between the attribute type and name)
            //
            // Use When:
            // - You need custom logic during get or set.
            // - You want to control how values are stored or retrieved.
            //
            // Ex:
            // Writing the private attribute then writing the property below
            // Note : We used to wite the attribute with small first letter and the property with capital first letter
            //
            // private int age;
            // public int Age
            // {
            //     get { return age; }
            //     set
            //     {
            //         if (value >= 0)
            //             age = value;
            //     }
            // }


            // 2. Automatic Property : Introduced in C# 3.0 — this lets the compiler automatically generate the private backing field hidden in
            //                         the background [IL], saving you from writing it manually.
            // code snippet ==> prop (+ Tab)
            //
            // Use When:
            // - you don't need custom logic.
            // - you want clean, concise code for simple get/set access.
            // - You can give it a default value
            //
            // Ex:
            // don't write the private attribute but write the property directly as : 
            // public string Name { get; set; }
            // public int Score { get; set; } = 10;             // can have a default value


            // 3. Indexer Property : Indexers allow a class or struct to be indexed like an array or list using [], but under the hood it's
            //                       just a property with an index.
            // 
            // Note : Indexer Propert will be discussed next region .. 


            // Note : All types of properties can have "get" and "set" , OR "get" only (Good for constants or IDs) , OR "set" only
            //        The property that has "get" only is called a "Derived Attribute" in the database ...


            // Body of "get" and "set" can be written using lambda expression : 
            //
            // Expression-Bodied Property
            // Shorthand for properties with one-line logic.
            // instead of writing :
            //
            // public string FullName
            // {
            //     get { return FirstName + " " + LastName; }
            // }
            //
            // Write :
            // 
            // public string FullName => FirstName + " " + LastName;
            //
            // Or with get/set:
            // 
            // public int Square
            // {
            //     get => value * value;
            //     set => value = value;
            // }


            // Another type : 
            //
            // Init-Only Property (C# 9+) : Can be set only during object initialization, not modified later (Immutable after construction).
            // 
            // public string Username { get; init; }
            // 
            // var user = new User { Username = "admin" };  // ✅
            // user.Username = "newadmin";                  // ❌ Error


            // What to use , a full property or automatic property ?
            // Type           	Backing Field	      Custom Logic	    Use Case
            // Full Property	Manually defined	  Yes    	        Validation, logging  with a specific format, control
            // Auto Property	Compiler-generated	  No	            Simple get/set, clean code


            // Note : 
            // 1 - inside the struct or the class , it's better to use the attribute itself .. don't use the property because it uses
            //     the attribute inside it .. so why ?! , better to use the attribute directly.
            // 
            // 2 - inside the struct or the class , if we want to use the attributes , we can use the keyword "this" , ex: "this.salary"

            /* End ******************************************************************************************************************/

            #endregion


            #region Indexer (Special Property)

            /* Start *****************************************************************************************************************/

            // 3. Indexer : (Special Property) Indexers allow a class or struct to be indexed like an array using [], but under the hood it's 
            //              just a property with an index. Used when we want objects to behave like collections.

            // Indexer is a special property because it's named always with the keyword "this" , and takes parameters. Also we can have more
            // then one indexer property (indexer overloading)

            // The "get" of the indexer property usually have the same code that you can put inside a Getter method , also the "set" of the
            // indexer property usually have the same code that you can put inside a Setter method.

            // string Name = "Shoura";
            // Console.WriteLine(Name[0]);
            // - interacting with the string object (which is a class) as an array, how ??
            //   - To interact with the object of the class or struct as an array, the class must have a special property called "Indexer"
            //     Note : The class or struct must be internally an array 

            // Ex1 : 
            // public class MyNewCollection
            // {
            //     private string[] data = new string[10];
            // 
            //     public string this[int index]
            //     {
            //         get { return data[index]; }
            //         set { data[index] = value; }
            //     }
            // }
            //
            // - Usage:
            // MyNewCollection mc = new MyNewCollection();
            // mc[0] = "Hello";
            // Console.WriteLine(mc[0]);  // Output: Hello


            // Ex2 : PhoneBook struct, check the internal implementation ...
            // 
            // PhoneBook Note = new PhoneBook(3);
            // Note.AddPerson(0, "Mahmoud", 123);
            // Note.AddPerson(1, "Ahmed"  , 456);
            // Note.AddPerson(2, "Shoura" , 789);
            // 
            // Note.SetNumber("Shoura", 999);                       // Set using setter Method (old way)
            // Console.WriteLine(Note.GetNumber("Shoura"));         // Get using getter Method (old way)	
            // 
            // - So how to use the indexer ??
            // 
            // Note["Shoura"] = 999;                                // Set using Indexer
            // Console.WriteLine(Note["Shoura"]);                   // Get using Indexer	
            // 
            //
            // string name = "Shoura";
            // Console.WriteLine(name[0]);
            // name[0] = "X";              // invalid  
            // that's because in the string implementation (source.dot.net , System.String) there is no setter , the indexer is a getter only 
            // 
            // 
            // for(int i=0; i<Note.Size; i++)
            // {
            // 	    Console.WriteLine(Note[i]);
            // }
            // 
            // - Can we use foreach ?
            //   invalid .. because to use foreach because the type must have a GetEnumerator function by implementing IEnumerable
            //   interface (will be discussed later . )

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}