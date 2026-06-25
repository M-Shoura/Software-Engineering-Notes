using System;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP___Session_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Notes and self study (OLD)

            /* Start *****************************************************************************************************************/

            // Copied and pasted below : 
            // https://medium.com/@CodeWithHonor/c-stack-vs-heap-memory-f8a737af9919






            // structs are not like classes (no virtual table or runtime type info for derived types)
            // User-defined Conversion Operators

            // More about Metadata Attributes and how to define a custom attributes
            // Deconstruct() (for value unpacking) , Destructor ~ClassName() (for cleanup)
            // how is and as behave with user-defined classes ? (oop session 2 or 3)


            // reference between classes 

            // You can make a class public static (e.g., utility classes), but not just static alone at the top level.


            // next session : 

            // Operator Overloading
            // Used to redefine operators like +, ==, etc., for user-defined types.
            // 
            // 
            // public class Point
            // {
            //     public int X, Y;
            // 
            //     public static Point operator +(Point a, Point b)
            //     {
            //         return new Point { X = a.X + b.X, Y = a.Y + b.Y };
            //     }
            // }

            #region OOP 4 sealing

            // 🔒 Sealing an Override
            // You can prevent further overriding using the sealed keyword.
            // 
            // 
            // public class Parent
            // {
            //     public virtual void Work() => Console.WriteLine("Parent");
            // }
            // 
            // public class Child : Parent
            // {
            //     public sealed override void Work() => Console.WriteLine("Child");
            // }
            // 
            // public class GrandChild : Child
            // {
            //     // ❌ Error: Cannot override sealed method
            //     // public override void Work() { }
            // }




            #endregion


            /*


                Classes and Objects

                Constructors (default, parameterized, static) (done for structs)



                Overriding methods with virtual, override, and new

                Access to protected members



                Polymorphism

                Compile-time (method overloading)

                Run-time (method overriding and interfaces)

                Abstract classes vs Interfaces




                Abstraction

                Abstract classes and abstract methods

                Interfaces and implementation



                🧠 Advanced OOP Topics

                Static Classes and Members

                Static fields, methods, constructors

                Utility/helper classes




                Object Lifecycle & Garbage Collection

                IDisposable and using statement

                Finalizers (~ClassName())



                Expression-bodied members (done for functions in properties in session 1 oop)





                Partial Classes

                Splitting class definition across files




                Nested Classes




                🔁 OOP Techniques & Practices


                Composition vs Inheritance




                🧪 Testing & Debugging OOP Code
                Unit Testing OOP Components

                Mocking interfaces/classes

                Using tools like xUnit/NUnit
             */

            /* End ******************************************************************************************************************/

            #endregion


            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // How to override properties and what else can be overriden inside the class ?

            // Links: https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/access-modifiers




            // C# tuples

            /* End ******************************************************************************************************************/

            #endregion


            #region Class Library

            /* Start *****************************************************************************************************************/

            // Class Library : A reusable common collection of classes, interfaces, methods, and other types that are compiled into a DLL
            //                 (Dynamic Link Library) file. These libraries can be referenced and used in other C# projects such as console
            //                 apps, web apps, or other libraries—without rewriting the code.
            // 
            // What Is It Used For?
            // - Code reuse: Share common functionality across multiple applications.
            // - Separation of concerns: Keep business logic, data access, or utilities in separate components.
            // - Modular design: Break large systems into maintainable parts.
            // 
            // You can put inside it: Classes, Interfaces, Enums, Structs, Delegates, Utility methods, Extension methods


            // Console Application : Executable code , when building .. we have the .dll file (containing the IL) , and the .exe file
            // (containing the native code)
            // Class Library : NOT an executable code (doesn't have the main function [entry point]) , when building .. we have the .dll file
            // (containing the IL) ONLY


            // To Create a Class Library in Visual Studio : File => New => Project => Choose Class Library
            // Then write your code (e.g., utility methods or business logic)
            // Then build the project => It generates a .dll file

            // Ex : 
            // Class Library Code (inside MyLibrary.dll):
            // namespace MyLibrary
            // {
            //     public class MathHelper
            //     {
            //         public static int Add(int a, int b) => a + b;
            //     }
            // }
            //
            // - Console App That Uses the Library :
            //
            // using MyLibrary;
            // class Program
            // {
            //     static void Main()
            //     {
            //         int result = MathHelper.Add(5, 3);
            //         Console.WriteLine(result);            // Outputs 8
            //     }
            // }


            // In our solution now I will add a new proect which is a class library to have the common classes , .. that we want. Then 
            // there is an important step here .. we can build the code of the library then we will notice that the .dll file is created
            // inside the class library folder, we can copy this file and paste it inside our project -> bin , but this is not an efficient
            // way because with any change to the library code we must build then take the file and paste it inside the bin of our project.

            // There is an easy way : right click on the dependencies of our project -> add project reference -> mark on the class library 

            // After that , right click on the solution -> build the solution  
            // we now will notice a new file (common.dll) inside the bin folder of our projects , and any change in the code of the library
            // then building it will automatically change (not nessesary to make the previous steps of copying and pasting manually) 
            // means that if we changed the code in the library and build it .. the .dll file in the bin folder in the projects who reference
            // will be deleted and the new one will replace it automatically.

            /* End ******************************************************************************************************************/

            #endregion


            #region Class

            /* Start *****************************************************************************************************************/

            // Class : A fundamental building block of object-oriented programming (OOP). It is a blueprint or templete for creating objects, 
            //         providing definitions for fields (data) and methods (behavior).
            // Note  : The class is a Reference Type datatype , means that the pointers (references) to the object (not the object itself) are
            //         stored in the stack , but the instances are stored in the heap.
            //
            //        - Memory (Ram) ==> Stack + Heap 
            //        - Stack ==> 1 Mb with 32 bit os   ,   4 Mb with 64 bit os 
            //        - Heap  ==> Shrink and grows up 


            // What can be written inside the class ? 
            //
            // Member Type                           | Notes                                                                        
            // --------------------------------------|------------------------------------------------------------------------------
            // Fields (Attributes)                   | Variables to hold data (class member[static] OR object member[non-static] )  
            // Properties                            | Encapsulated fields with get/set (New way of Incapsulation)                  
            // Methods                               | Functions (getter & setter [old way of incapsulation])                       
            // Events                                | For event-driven programming (Discussed later in Advanced C# )               
            // Constructors                          | Special function because same name of class or struct + no return            
            // Static Constructors                   | One allowed per type                                                         
            // Delegates                             | Define method signatures                                                     
            // Indexers                              | Allows indexing like arrays (special type of properties)                     
            // Nested Types                          | Classes, structs, enums, interfaces, delegates                               
            // Operators (Overloads)                 | Must be `public static`                                                      
            // Finalizers (destructors) (~ClassName) | Cleanup before garbage collection


            // Basic Syntax:
            //
            // public class Person
            // {
            //     // Field
            //     private string name;
            // 
            //     // Property
            //     public string Name
            //     {
            //         get => name;
            //         set => name = value;
            //     }
            // 
            //     // Constructor
            //     public Person(string name)
            //     {
            //         this.name = name;
            //     }
            // 
            //     // Method
            //     public void SayHello()
            //     {
            //         Console.WriteLine($"Hello, my name is {name}");
            //     }
            // }



            // Key Concepts About Classes

            // 1 - Supports Inheritance
            // Classes can inherit from other classes:
            // 
            // class Student : Person
            // {
            //     public int Grade { get; set; }
            // }

            // 2 - Can Implement Interfaces
            // public class Car : IVehicle
            // {
            //     public void Drive() { ... }
            // }

            // 3 - Supports All Access Modifiers (discussed in "Access Modifiers - Continued" region below)
            //      - private (default), private protected, protected, internal, protected internal, public



            // Ex : Car Class 
            // 
            // Car C1;
            // - Declaring for a reference of type "Car" , Refering to Null (default value)
            // - CLR will allocate 4 bytes at the STACK for this reference "C1"
            // - CLR will allocate 0 bytes at the HEAP 
            // 
            // C1 = new Car();
            // - Allocate required number of bytes for the allocated object at the heap ( 4+4+8 = 16 ) bytes
            // - Initialize the allocated bytes for each and every attribute with the default value of attribute datatype 
            // - Call the user defined constructor (if exists)
            // - Assign the address of the allocated object at the HEAP to the Refernce in the stack "C1"


            // The constructor in struct/class is a special method :
            //  - named always with the same name of the struct/class 
            //  - has no return 
            //
            // The constructor is automatically called when an object is created. It is used to initialize object state (set initial
            // values for fields or properties).


            // Constructors in Classes (differes from struct constructor) : 
            //
            // 1 - If no constructor is defined , compiler will generate default empty parameterless constructor that Do Nothing which
            //     is done for consistency (to make the creating of the object easier if you want to initialize the attributes later)
            //
            // 2 - If you define a constructor , compiler will no longer generate empty parameterless constructor , if we want the 
            //     empty parameterless constructor then we must write it explicitly.
            //
            // 3 - We can have more than one constructor each with different signature (types of parameeters , number of parameters ,
            //     order of parameters) ==> (constructor overloading)
            //
            // 4 - When we notice that constructors have common behaviour with the same code and logic ==> ( Constructor Chaining )
            //     Constructor Chaining : execute code inside the first constructor then execute constructor which started chaining.
            //     - Constructor Chaining between Constructors in the same class                  :this(...) 
            //     - Constructor Chaining between Constructors in the class and it's parent class :base(...) 
            //     ex : in Car class constructors :
            //          C1 = new Car(10);
            //          Console.WriteLine(C1);
            //          // output : Ctor 1 \n Ctor 2 \n Ctor 3
            //
            // 5 - You cannot inherit constructors, but you can call base class constructors using : base(...)
            //  
            // Note : 
            //   - We can have a Static constructor.    (Discussed later ... )
            //   - We can have a Copy Constructor.      (Discussed later ... )
            //   - We can have a Private Constructor (used in Singleton Design Pattern).


            // Object Initializer : readable way to create and initialize an object without explicitly calling a constructor or manually
            //                      assigning values for every property.
            // Note : Only public settable properties or fields can be initialized this way ....
            //
            // Ex: 
            // Car Test = new Car
            // {
            // 	    Id = 1,
            // 	    Name = "Kia",
            // 	    Speed = 200
            // };
            // 
            // Note : If the class has a parameterized constructor, you can still use object initializers after calling it:
            // Car Test = new Car("Kia")
            // {
            // 	    Id = 1,
            // 	    Speed = 200
            // };


            // 🧩 Class types (Will be discussed later) : 
            // Feature	              Description
            // Abstract Classes       Cannot be instantiated, used for base behavior
            // Sealed Classes	      Cannot be inherited
            // Static Classes	      Cannot be instantiated, all members must be static
            // Partial Classes	      Split across multiple files
            // Nested Classes	      Classes defined within another class
            // Generic Classes	      Work with any data type (ex: List<T>)

            /* End ******************************************************************************************************************/

            #endregion


            #region Heap VS Stack

            /* Start *****************************************************************************************************************/

            // In C#, memory is divided into two regions: the Stack and the Heap.
            // We must understanding the differences between them for writing efficient and correct C# code.


            // Stack Memory : The stack is a region of memory that is used to store local variables and function call information. It is
            //                called a “stack” because it behaves like a stack of items, with the most recently added item being the first 
            //                one to be removed (last in, first out).
            // 
            // Stack is fast to allocate and deallocate memory from it because the stack has a fixed size and the memory is allocated and
            // deallocated in a last-in, first-out manner.
            // 
            // However, the stack has a limited size and can only store a finite amount of data. If the stack grows too large, it can cause
            // a stack overflow, which can lead to a crash or other unpredictable behavior.


            // Heap Memory : The heap is a region of memory that is used to store objects. It is called a “heap” because it is not organized
            //               in a particular order and can be accessed randomly.
            // 
            // In C#, objects are dynamically allocated on the heap using the new keyword. When an object is no longer needed, it is the
            // responsibility of the garbage collector to deallocate the memory and reclaim it for future use.
            // 
            // Heap is a more flexible region of memory than the stack, but it is also slower to allocate and deallocate memory from. This
            // is because the heap has no fixed size and the garbage collector must constantly monitor and manage the memory being used.

            // Datatypes :
            // Value type datatypes : Stored in the Stack directly.
            // Reference type datatypes : The reference is stored in the Stack , but the actual object is stored in the heap.


            // To Sum Up : 
            // 1 - Allocation and deallocation:
            //   - Memory on the stack is allocated and deallocated very quickly, because the stack has a fixed
            //     size and the memory is allocated and deallocated in a last-in, first-out manner.
            //   - Memory on the heap is allocated and deallocated more slowly, because the heap has no fixed size
            //     and the garbage collector must constantly monitor and manage the memory being used.
            //
            // 2 - Size:
            //   - The stack has a fixed size and can only store a finite amount of data. If the stack grows too large, it can cause a
            //     stack overflow, which can lead to a crash or other unpredictable behavior.
            //   - The heap has no fixed size and can store an unlimited amount of data as long as there is enough physical memory available
            //
            // 3 - Accessibility:
            //   - Memory on the stack only accessed by the function that created it and any functions called by that function
            //   - Memory on the heap, on the other hand, can be accessed by any part of the program.
            //
            // 4 - Lifetime:
            //   - The lifetime of a variable on the stack is limited to the function in which it was created. Once the function
            //     returns, the memory for that variable is deallocated and the stack pointer moves back to the previous function’s block
            //   - The lifetime of an object on the heap is not tied to any particular function and can outlive the function in which
            //     it was created. The garbage collector is responsible for deallocating objects on the heap when they are not needed
            //             
            // 5 - Usage:
            //   - The stack is generally used for storing small, short-lived variables such as local variables and function parameters,
            //   - The heap is generally used for storing larger, longer-lived objects.

            /* End ******************************************************************************************************************/

            #endregion


            #region Struct vs Class + What is Object Slicing ?

            /* Start *****************************************************************************************************************/

            // Classes and Structs are used to make real business objects , so we are always compare them with each other to use the 
            // better one IN OUR CASE ... 


            // Memory Allocation Differences :
            //
            // Struct ==> A value type, struct objects are totally stored in the Stack. 
            // Class  ==> A reference type, class objects are stored in the Heap with a reference in the Stack.


            // Constructors Difference : 
            //
            // Struct ==> will generate the parameterless constructor (Always) that initializes all the attributes with the default value.
            //            The constructor is the only one responsible for initializing the attributes in the struct.
            //            The "new" keyword is only used for choosing the constructor that we will use.
            //            C# ≤ 10 (up to .NET 6) it was NOT ALLOWED to create a User-defined default ctor , starting from C# 11 it's allowed.
            //            C# ≤ 10 (up to .NET 6) it was a MUST to initialize all the fields , starting from C# 11 .NET 7 (defaults applied)
            //
            // Class  ==> If no user defined constructor exists , compiler will generate empty parameterless constructor that Do Nothing
            //            If you define a constructor , compiler will no longer generate empty parameterless constructor

            // Other Differences : 

            // 1 - Assignment Behavior : 
            // Class => references the same object
            // Struct => creates a copy
            // 
            // Ex: Class  
            // MyClass c1 = new MyClass { X = 5 };
            // MyClass c2 = c1;
            // c2.X = 10;               // changes c1.X too , because c1 and c2 references the same object in the heap
            // 
            // Ex: Struct
            // MyStruct s1 = new MyStruct { X = 5 };
            // MyStruct s2 = s1;
            // s2.X = 10;               // s1.X remains 5 — copy

            // 2 - Nullability
            // class object can be null
            // struct object cannot be null (unless it's a Nullable<T>)
            // 
            // MyClass c = null;     // allowed
            // MyStruct s = null;    // compile-time error
            // 
            // int? x = null;        // Nullable struct        

            // 3 - inheritance :
            //      - Structs can't inherit other structs or classes (except `System.ValueType`)
            //      - Classes can inherit other classes 

            // 4 - Finalizers (destructors) (`~ClassName`) : used to perform cleanup operations before an object is reclaimed by the garbage
            //                                               collector (GC) (You cannot predict when it will run by the GC).
            //      - Structs do not support destructors
            //      - Classes support them

            // 5 - Abstract and Virtual members (discussed later) : 
            //      - Structs cannot be abstract and cannot contain virtual members 
            //      - Classes can be Abstract and can contain virtual members 

            // 6 - using "new" keyword when Instantiation: 
            //      - Struct : it's optional to use , BUT ALL fields must be assigned manually before use. Trying to access any field before
            //                 fully assigning all fields results in a compile-time error.
            //      - Class : It's a must to use "new" keyword , because they involve a reference on the heap.

            // 7 - Overloading and Overriding (Discussed later) : 
            //      - Struct : Supports Overloading Only
            //      - Class : Supports Both Overloading and Overriding


            // Notes : Class and Struct are the same in =>  
            // Both of them can implement interfaces
            // Both of them can contain static constructors


            // When to Use What?
            // Use CLASS When                             Use STRUCT When
            // You need polymorphism, inheritance	      You want lightweight objects
            // Large/complex data	                      Small data structures (like a Point)
            // You need null support	                  You want to avoid heap allocations



            // Why struct doesn't supports inheritance ? 
            // Object Slicing : A concept from C++, but it helps explain why structs in C# don't support inheritance. Object slicing happens
            //                  when a derived child type (which has extra data) is assigned to a base type parent variable, and the extra data
            //                  is lost in the process, “sliced off”, leaving only the base portion. This happens because the base object
            //                  doesn't know about the additional members in the derived object.


            // Structs (have that problem) : 

            // In C#, structs are value types, and they don’t support inheritance (except from System.ValueType) — partly to prevent
            // object slicing.
            // 
            // ---- Imagine (NOT ALLOWED):
            // 
            // struct A
            // {
            //     public int X;
            // }
            // 
            // struct B : A        // ❌ Not allowed
            // {
            //     public int Y;
            // }
            // If B were assignable to an A (and slicing happened), then assigning B to A would cause Y to be lost — a serious bug for value
            // types, which are copied by value. To avoid such bugs, C# completely disallows inheritance for structs.


            // Classes (doesn't have that problem) : 

            // Ex1: Classes doesn't have this problem (object slicing) :
            //
            // class A
            // {
            //     public int X;
            // }
            // 
            // class B : A
            // {
            //     public int Y;
            // }
            // 
            // A a = new B { X = 10, Y = 20 };
            // 
            // // Console.WriteLine(a.Y);        // ❌ We can't do this , Compile-time error
            // 
            // 
            // Console.WriteLine(((B)a).Y);      // After Castinggggg      // Outputs: 20
            // // Now, 'a' is of type A, but it refers to a B object.
            //
            // if we tried to make this with structs we cannot do it because of object slicing in structs


            // Ex2: Classes doesn't have this problem (object slicing) :
            // 
            // class A
            // {
            //     public void fun1() { Console.WriteLine("Function 1"); }
            // }
            // 
            // class B : A
            // {
            //     public void fun2() { Console.WriteLine("Function 2"); }
            // }
            // 
            // public static void test(A notSlicedObject)
            // {
            //     notSlicedObject.fun1();
            // }
            // 
            //
            // In the main function : 
            //     B fullObject = new B();
            //     test(fullObject);
            //
            // - Output : Function 1
            // 
            // - We will notice that we can't use notSlicedObject.fun2(), Why ? Because notSlicedObject is a reference to an object of type A,
            //   so it can only use methods or attributes bounded to that object type. But we can cast the type of the reference to make it
            //   reference an object of type B instead of type A and that way we can access attributes and methods bound to type B.
            //
            //
            // - BUT if the function was implemented as : 
            //
            // public static void test(A notSlicedObject)
            // {
            //     ((B)notSlicedObject).fun2();
            // }
            //
            // 
            // Output : Function 2
            //
            // Note: Casting the reference type didn't change the type of the object itself, instead the only change that happened is to the
            // reference to that object. The object itself didn't have to be sliced off because it never changed. We only change the type
            // of the reference that is referencing that object, so that when we say the reference is referencing a type A object then the
            // reference has only access to attributes and methods that an object of type A would have, and when we say the reference is
            // referencing a type B object then the reference has only access to attributes and methods that an object of type B would have.
            // Note that we can only do this type of conversion or casting only to classes that have an inheritance relationship between
            // them like the example above, otherwise you have to explicitly define that conversion. 

            /* End ******************************************************************************************************************/

            #endregion


            #region Inheritance - Second OOP Pillar

            /* Start *****************************************************************************************************************/

            // Inheritance : One of the core principles of OOP (second OOP pillar) , Allows you to define a new class (child/derived) that 
            //               inherits members (fields, properties, methods, ...) from an existing class (parent/base). This avoids Code
            //               duplication. (Is-a relationship)


            // Notes :
            // - Inheritance is supported with classes only (not allowed in Structs (except System.ValueType) , see last region..)
            // - Inheritance is not allowed with sealed Classes (discussed later ..)
            // - Inheritance is allowed only from one parent (multiple class inheritance IS NOT ALLOWED).


            // Basic Syntax : internal class Child : Parent     ==> " Child : Parent " , means class Child inherits from class Parent.

            // Ex:
            //
            // class Animal
            // {
            //     public void Eat() => Console.WriteLine("Eating...");
            // }
            // 
            // class Dog : Animal
            // {
            //     public void Bark() => Console.WriteLine("Barking...");
            // }
            // 
            // Dog d = new Dog();
            // d.Eat();                    // inherited from Animal
            // d.Bark();                   // defined in Dog


            // Note : inheritance ==> "is a" relationship
            // ex : Kia "is a" Car          // class Kia inherits from class Car
            //      Dog "is a" Animal       // class Dog inherits from class Animal


            // Types of Inheritance in C#
            //
            // - Single	              One child inherits from one parent
            // - Multilevel	          Child inherits from a parent who inherits from another parent
            // - Hierarchical	      Multiple children inherit from one parent
            //
            // Note : Multiple inheritance is NOT ALLOWED in C# (having more than one parent )


            // Accessibility consistency between base and derived classes : 
            //
            // public class   : internal class ==> Error ! inconsistent accessibility (when a public class try to inherit from an internal class)
            //                                     Note : A derived class CANNOT BE more accessible than its base class.
            // internal class : public class   ==> No problem (Restricting visibility is OK)
            // public class   : public class   ==> No problem (Access level matches) 
            // internal class : internal class ==> No problem (Access level matches)


            // Constructor Chaining in Inheritance : By default, if a derived class constructor doesn't explicitly call a base constructor,
            //                                       the parameterless constructor of the base class is automatically invoked. to call a 
            //                                       specific base constructor, use    : base(...)

            // Ex: 
            //
            // class Base
            // {
            //     public Base()
            //     {
            //         Console.WriteLine("Base constructor");
            //     }
            // }
            // 
            // class Derived : Base
            // {
            //     public Derived()
            //     {
            //         Console.WriteLine("Derived constructor");
            //     }
            // }
            // Output:
            // Base constructor  
            // Derived constructor


            // Note : if we don't have a parameterless constructor then we MUST call a specific constructor (in the next case , the
            //        parameterless constructor is not auto generated because we wrote another constructor that is not parameterless)
            //
            // Ex2:
            // 
            // class Base
            // {
            //     public Base(string x)
            //     {
            //         Console.WriteLine("Hi from A" + x);
            //     }
            // }
            // class Derived : Base
            // {
            //     public Derived() : base("test x")
            //     {
            //         Console.WriteLine("Hi from B");
            //     }
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Access Modifiers - Continued

            /* Start *****************************************************************************************************************/

            // Last session we discussed ONLY THREE access modifiers ==> private , internal , public
            // Now we will discuss ==> private protected (or protected private) , protected , internal protected (or protected internal)
            // They are related to inheritance ...


            // 1 - private protected (C# 7.2) : 
            // - Accessible only within =>
            //     1 - the containing class
            //     2 - in derived classes (inheriting class) that are in the same assembly only (same project) 
            // - Not accessible in derived classes outside the project (derived class must be in the same assembly).
            // - Inside the class: works like private.
            // - Inherited as private protected ( second generation child classes can inherit private protected from first generation childs ..)
            // - Use case: Tighter control than protected internal. You want it to be inherited but not accessible by unrelated classes in the
            //             same assembly.
            //
            // Ex: 
            // 
            // class Base
            // {
            //     private protected int Data = 42;
            // }
            // 
            // class Derived : Base
            // {
            //     void Test()
            //     {
            //         Console.WriteLine(Data);            // ✅ Only if in the same assembly , inherited as Private Protected also .. 
            //     }
            // }
            // class Derived2 : Derived
            // {
            //     void Test2()
            //     {
            //         Console.WriteLine(Data);            // ✅ Only if in the same assembly , inherited as Private Protected also .. 
            //     }
            // }



            // 2 - protected : 
            // - Accessible in =>
            //    1 - same class
            //    2 - derived classes, even if the derived class is in a different project/assembly (regardless of assembly).
            // - Inside the class: works like private.
            // - Inherited as protected.
            // - Use case: When you want to allow child classes to access a member, but keep it hidden from external access.
            //
            // Ex: 
            // 
            // class Base
            // {
            //     protected int Value = 100;
            // }
            // 
            // class Derived : Base
            // {
            //     void Access()
            //     {
            //         Console.WriteLine(Value);        // ✅ Allowed in any derived class (regardless of assembly)
            //     }
            // }



            // 3 - protected internal : 
            // - Accessible in =>
            //     1 - any class in same assembly (like internal)
            //     2 - in derived classes in same assembly or other assemblies (like protected)
            // - This is a union of protected and internal.
            // - Inherited as protected internal
            // - Use case: For members you want to share across the assembly and also make available to subclasses in other projects.
            // - In same project (assembly): acts like internal (fully accessible).
            // - In another project in the same solution: acts like protected (accessible only if inherited).
            //
            // Context	                               Accessible?
            // Same assembly, not derived	           ✅ Yes
            // Derived class in same assembly	       ✅ Yes
            // Derived class in another assembly	   ✅ Yes
            // Not derived and in another assembly	   ❌ No


            // Notes :
            // See "Common" class library
            // - if we inherite from a class then the private attributes are not inherited in the new class , if we want the attribute to
            //   be inherited , then make it private protected, to achieve encapsulation and also be able to be inherited
            // - To enusre that the encapsulation is achieved , attributes must be private , private protected or protected


            // To Sum Up : 
            //
            // Notes : 
            // - private                 Only within the defining class
            // - private protected	     Only derived and same-assembly
            // - protected	             Only derived types (anywhere)
            // - internal	             Only within the same assembly
            // - protected internal	     Either derived or same-assembly
            // - public                  Everywhere


            //   | Modifier             | Same Class  |    Derived Class    |    Other Class      |    Derived Class   |   Other Class     |
            //   |                      |             |   (Same Assembly)   |  (Same Assembly)    |   (Other Assembly) | (Other Assembly)  |
            //   | -------------------- | ------------| --------------------|---------------------|--------------------|-------------------|
            //   | `private`            |     ✅      |      ❌            |       ❌            | ❌                 |    ❌             | 
            //   | `private protected`  |     ✅      |      ✅            |       ❌            | ❌                 |    ❌             | 
            //   | `protected`          |     ✅      |      ✅            |       ❌            | ✅                 |    ❌             | 
            //   | `internal`           |     ✅      |      ✅            |       ✅            | ❌                 |    ❌             | 
            //   | `protected internal` |     ✅      |      ✅            |       ✅            | ✅                 |    ❌             | 
            //   | `public`             |     ✅      |      ✅            |       ✅            | ✅                 |    ✅             | 

            /* End ******************************************************************************************************************/

            #endregion


            #region Association (Composotion & Aggregation)

            /* Start *****************************************************************************************************************/

            // Association : Relationship between classes that was there before the inheritance, association can be further categorized into: 
            // 1 - Aggregation ("has-a" relationship with shared ownership)
            // 2 - Composition ("has-a" relationship with strong ownership)

            // Important Note : Association (Composition & Aggregation) ==> "has a" relationship
            // ex : Order "has a" Order Items
            //      Rooms "has a" chair

            // Why assocoation is not a pillar for OOP ? 
            // Because it was there before the OOP , ex: struct department has an array of type struct Employee.


            // 1 - Aggregation (Weak Association / Shared Ownership / Optional) : Aggregation represents a "whole-part" relationship, but the 
            //                                                                    part CAN EXIST independently of the whole.
            // Note : Check "Association Aggragation" folder in this project. 
            //
            // Example: Department can contain Professors or not , if no Professors then there is still a department and Professors can exist
            //          independently.
            // 
            // public class Professor
            // {
            //     public string Name { get; set; }
            // }
            // public class Department
            // {
            //     public string Name { get; set; }
            //     
            //     // Aggregation: Department has Professors, but Professors can exist independently
            //     public List<Professor> Professors { get; set; } = new List<Professor>();
            // }
            //
            // Notes : 
            // - If the Department is deleted, Professor objects still exist.
            // - Lifetimes are not tightly bound.


            // 2 - Composition (Strong Association / Ownership / mandatory) : Composition is a stronger form of aggregation, where the part
            //                                                                CANNOT EXIST without the whole.
            // Note : Check "Association Composition" folder in this project.
            // 
            // Example: House must contain Room , of no Room then there will not be House.
            // 
            // public class Room
            // {
            //     public string Color { get; set; }
            // }
            // public class House
            // {
            //     public Room Room { get; set; }
            // 
            //     public House()
            //     {
            //         // Composition: Room is created and owned by House
            //         Room = new Room();
            //     }
            // }
            //
            // Notes : 
            // - If the House is destroyed, the Room should be too.
            // - Lifetimes are tightly bound.


            // Important note : Composition relationship is much better , efficient and flexible than Inheritance relationship 

            /* End ******************************************************************************************************************/

            #endregion


            #region Polymorphism - Third OOP Pillar

            /* Start *****************************************************************************************************************/

            // Polymorphism => means "Many Forms" ... Consists of (Overloading & Overriding)
            //              (Overloading supported with Class & Struct , Overriding supported with Class only )
            //              * Overloading : DONE IN COMPILE TIME. Method/Operator/... with the same name in the same class or struct, each 
            //                              with different behaviour , they must have different signature.
            //                              Notes :
            //                                      1 - Different Signature : different ( number / type / ordering ) of the parameters.
            //                                      2 - RETURN TYPES and PARAMETER NAMES is NOT enough to distinguish overloads.
            //
            //              * Overriding  : DONE IN RUNTIME. overriding the functions , properties , .. inherited from the parent and changing 
            //                               the behaviour of it. Not supported with structs because there is no inheritance (prerequisite).
            //                               Done using inheritance , virtual, override, new(for hiding, not true overriding), and base keywords

            /* End ******************************************************************************************************************/

            #endregion


            #region Polymorphism => 1. Overloading 

            /* Start *****************************************************************************************************************/

            // Overloading : DONE IN COMPILE TIME. also called "Compile-time Polymorphism" and "Static Binding" and "Early Binding".
            // Requires : Different Signatures => ( number / type / ordering ) of the parameters + Also in the same Scope (usually class/struct)
            //
            // First of All => Overloading is supported in Class and Struct. 
            //
            // Overloading : can be one of the next FIVE ==> 
            //               1 - Indexer Overloading              ==> Discussed Before 
            //               2 - Constructor Overloading          ==> Discussed Before  
            //               3 - Method Overloading			      ==> NOW
            //               4 - Operator Overloading             ==> Next Session
            //               5 - Casting Operator Overloading     ==> Next Session
            //
            // Method Overloading : Multiple methods with the same name but different signatures. Methods must be in the same scope (usually the
            //                      same class or struct) Used to make same method name to perform different tasks based on the parameters passed.
            // Ex: using Helper class in this solution =>
            // Helper.sum();       // We will notice that we have 5 Overloads
            // 
            // Note : compiler determines which method to call based on the arguments passed to the method.
            //
            // Having more than one function with the SAME NAME but DIFFERENT BEHAVIOUR , each with different signature.
            // Notes :
            //   1 - Different Signature : different ( number / type / ordering ) of the parameters.
            //   2 - RETURN TYPES and PARAMETER NAMES is NOT enough to distinguish overloads.
            //
            // No additional advantages in performance or memory .. It's better in Readability Only.
            // 
            // Console.WriteLine();     // Has 18 different overloads , check them by ( Ctrl + Shift + Space )


            // Overloading with params : 
            // 
            // public void Display(string message) { }
            // public void Display(params string[] messages) { } 
            // 
            // Display("Hello");          // Calls the first
            // Display("A", "B", "C");    // Calls the second
            // Note : Be careful, params can cause ambiguity when used alongside other overloads.


            // Compiler Resolution : The C# compiler selects the best match at compile time based on =>
            // - Number of arguments 
            // - Type match (exact match > implicit conversion > params)
            // - Accessibility and ambiguity
            // 
            // - Example:
            // 
            // void Process(double x) { }
            // void Process(int x) { }
            // Process(5);   // Calls Process(int x) => exact match preferred
            //
            // void Process(double x) { }
            // void Process(long x) { }
            // Process(5);   // Calls Process(long x) => compiler has conversion preference rules , int → long is preferred over int → double
            //
            // - Ambiguous Call Example : 
            // 
            // public void DoSomething(float x) { }
            // public void DoSomething(double x) { }
            // 
            // DoSomething(5.0);            // Calls DoSomething(double x) => defualt is double
            // DoSomething(5.0f);           // Calls DoSomething(float x) 
            // DoSomething(5);              // Error: ambiguous between float and double
            //                              // To fix: explicitly cast the argument or remove ambiguity.

            // Practical Use Cases :
            // - Provide default behavior and customized behavior.
            // - Increase code readability, usability and code clarity.

            /* End ******************************************************************************************************************/

            #endregion


            #region Polymorphism => 2. Overriding

            /* Start *****************************************************************************************************************/

            // Method Overriding : Overriding is a key part of runtime polymorphism. It allows a derived class to provide a specific
            //                     implementation of a method that is already defined in its base class.
            // 
            // Overriding ensures that the correct method is called based on the actual object type, not the reference type, resolved at runtime







            // Required Keywords :
            //
            // virtual : Declares a method in the base class that can be overridden
            // override: Provides a new implementation in the derived class


            // Prerequisite => Inheritance .... that's why it's not supported in structs , only supported in classes 
            // 
            // How to override ?
            // Two ways :
            //
            // 1 - Keyword "override": The parent must allow this by making the function NonPrivate & virtual
            //                         (ex: TestVirtual in Parent and child)
            //
            // 2 - Keyword "new"     : Implement a new function in the child class with the same name of the function in the parent
            //                         class , containing the logic wanted for the child class .. not nessisary to have the same
            //                         return type or access modifier , only the name ... and to avoid the warning only write "new" 
            //                         before the return type and after the access modifier (ex: TestNew function in Parent and child)
            // 
            // Note : Overriding using "new" keyword is not a right overriding, the difference between Keyword "override" and Keyword "new"
            //        will be noticed when discussing "Binding" at next regions
            // 
            // Example: 
            // Child child = new Child(1, 2, 3);
            // child.TestVirtual();
            // child.TestNew();
            // 
            // 
            // Note : we can use "base" keyword inside the child class to refer to things inside the parent class (ex:TestNew in child)
            // 
            // base inside the child refers to the parent class
            // base inside the parent refers to object class
            // 
            // Console.WriteLine(child.ToString());       // ToString is inherited from Parent class , that inherites it from Object class
            //                                            // We can change the behaviour of the function as shown in child class


            // important : we can also override Properties by the two ways defined "new" and "override" .. check the classes





            // 2 - Run-time Polymorphism (Method Overriding) : Occurs when a base class reference points to a derived class object and calls
            //                                                 an overridden method.
            // 
            // Requires:
            // - Inheritance
            // - virtual method in base class
            // - override in derived class
            // 
            // Example:
            // 
            // public class Animal
            // {
            //     public virtual void Speak()
            //     {
            //         Console.WriteLine("The animal makes a sound.");
            //     }
            // }
            // 
            // public class Dog : Animal
            // {
            //     public override void Speak()
            //     {
            //         Console.WriteLine("The dog barks.");
            //     }
            // }
            // 
            // public class Cat : Animal
            // {
            //     public override void Speak()
            //     {
            //         Console.WriteLine("The cat meows.");
            //     }
            // }
            // Usage:
            // 
            // Animal myAnimal = new Dog();  // Base class reference
            // myAnimal.Speak();             // Output: The dog barks.
            // 
            // myAnimal = new Cat();
            // myAnimal.Speak();             // Output: The cat meows.
            // Note : This is late binding (decision made at runtime).





            // 🔷 2. Run-Time Polymorphism (Dynamic Binding)
            // Occurs when you use inheritance + virtual/override, and decisions are made at runtime.
            // 
            // ✅ Virtual and Override
            // 
            // public class Animal
            // {
            //     public virtual void Speak()
            //     {
            //         Console.WriteLine("Animal speaks");
            //     }
            // }
            // 
            // public class Dog : Animal
            // {
            //     public override void Speak()
            //     {
            //         Console.WriteLine("Dog barks");
            //     }
            // }
            // Usage:
            // 
            // 
            // Animal a = new Dog();
            // a.Speak(); // Output: Dog barks (runtime decision)


            // ✅ Method Overriding → Run-Time Polymorphism
            // The method to be called is determined at runtime, based on the actual object type, not the reference type.
            // 
            // Requires virtual in the base class and override in the derived class.
            // 
            // Also called dynamic binding or late binding.
            // 
            // Example:
            // 
            // public class Animal
            // {
            //     public virtual void Speak() => Console.WriteLine("Animal speaks");
            // }
            // 
            // public class Dog : Animal
            // {
            //     public override void Speak() => Console.WriteLine("Dog barks");
            // }
            // 
            // Animal a = new Dog();
            // a.Speak(); // Output: Dog barks → Decided at runtime
            // 🟢 Here, even though the reference is Animal, the actual object is Dog, so the overridden method is invoked at runtime.
            // 
            // Overriding	Runtime	Dynamic binding / Late binding









            // Inheritance and Method Behavior
            // 1 - Method Overriding (Runtime Polymorphism)
            // Use virtual and override:
            // 
            // class Animal
            // {
            //     public virtual void Speak() => Console.WriteLine("Animal speaks");
            // }
            // 
            // class Cat : Animal
            // {
            //     public override void Speak() => Console.WriteLine("Cat meows");
            // }
            // 2. Method Hiding (Not recommended usually)
            // Use new keyword:
            // 
            // class Animal
            // {
            //     public void Speak() => Console.WriteLine("Animal speaks");
            // }
            // 
            // class Dog : Animal
            // {
            //     public new void Speak() => Console.WriteLine("Dog barks");
            // }
            // This hides the base method instead of overriding it.
            // 
            // Example with Base and Derived Constructors
            // 
            // class Person
            // {
            //     public string Name;
            // 
            //     public Person(string name)
            //     {
            //         Name = name;
            //     }
            // }
            // 
            // class Student : Person
            // {
            //     public int Grade;
            // 
            //     public Student(string name, int grade) : base(name)
            //     {
            //         Grade = grade;
            //     }
            // }









            // base	   : Optionally calls the base class's version of the method
            // new     : Hides a method without overriding (not true overriding – see below)
            // 
            // Rules of Overriding
            // - The base method must be marked with virtual, abstract, or override.
            // - The derived method must use the override keyword.
            // - The method signature must be identical (name, return type, parameter types).
            // - Only class members can be overridden — not static, private, or constructors.
            // - Structs can't override because they don't support inheritance (only interfaces).
            // 
            // Advanced Example with base
            // 
            // public class Logger
            // {
            //     public virtual void Log(string message)
            //     {
            //         Console.WriteLine($"Base log: {message}");
            //     }
            // }
            // 
            // public class FileLogger : Logger
            // {
            //     public override void Log(string message)
            //     {
            //         base.Log(message);      // Call base class method
            //         Console.WriteLine($"File log: {message}");
            //     }
            // }
            // 
            // Logger logger = new FileLogger();
            // logger.Log("Saving file");
            // // Output:
            // // Base log: Saving file
            // // File log: Saving file


            // Method Hiding (new keyword) (not ...)
            // 
            // public class A
            // {
            //     public void Show() => Console.WriteLine("A");
            // }
            // 
            // public class B : A
            // {
            //     public new void Show() => Console.WriteLine("B");    // hides, not overrides
            // }
            // 
            // A obj = new B();
            // obj.Show();            // Output: A (method hiding, not polymorphic)


            // ✅ Use override to get polymorphism; use new only when you intentionally want to hide the base method.






            // 🆚 Comparison: Overriding vs Overloading vs Hiding
            // Feature	          Overriding	                     Overloading	      Hiding (new)
            // Purpose	          Replace inherited behavior	Add multiple variants	Replace visibility
            // Requires virtual?	      Yes	                          No	               No
            // Resolved at	             Runtime	                 Compile time	       Compile time
            // Same signature?	      ✅ Required	                 ❌ Must differ	      ✅ Usually same
            // Uses override?	          ✅	                          ❌	            ❌ Uses new
            // 


            // Common Mistakes : 
            // - Forgetting virtual in base class	
            // - Using override without virtual	
            // - Trying to override private/static methods, Only instance, accessible methods can be overridden
            // - Using new unintentionally, Use override for polymorphic behavior


            // Summary : 
            // Overriding = Runtime polymorphism.
            // Requires virtual in base and override in derived.
            // Structs and static methods do not support overriding.
            // Enables clean extensibility and flexibility in object-oriented design.


            // 
            // ✅ Basic Syntax
            // 
            // public class Animal
            // {
            //     public virtual void Speak()
            //     {
            //         Console.WriteLine("Animal speaks");
            //     }
            // }
            // 
            // public class Dog : Animal
            // {
            //     public override void Speak()
            //     {
            //         Console.WriteLine("Dog barks");
            //     }
            // }
            // 
            // Animal a = new Dog();
            // a.Speak();              // Output: Dog barks

            /* End ******************************************************************************************************************/

            #endregion


            #region Abstract Class and Interface for Polymorphism

            /* Start *****************************************************************************************************************/

            // Bonus: abstract and interface for Polymorphism
            // Abstract Class:
            // 
            // public abstract class Shape
            // {
            //     public abstract void Draw();
            // }
            // 
            // public class Circle : Shape
            // {
            //     public override void Draw()
            //     {
            //         Console.WriteLine("Drawing a circle");
            //     }
            // }
            //
            // Interface:
            // 
            // public interface IShape
            // {
            //     void Draw();
            // }
            // 
            // public class Square : IShape
            // {
            //     public void Draw()
            //     {
            //         Console.WriteLine("Drawing a square");
            //     }
            // }
            // Both abstract classes and interfaces are commonly used to achieve run-time polymorphism (Overriding).



            // 🔶 Abstract Classes vs Interfaces
            // ✅ Abstract Class
            // Can have method implementations.
            // 
            // Can define constructors.
            // 
            // Supports fields and access modifiers.
            // 
            // csharp
            // Copy
            // Edit
            // public abstract class Shape
            // {
            //     public abstract void Draw();
            //     public void Describe() => Console.WriteLine("Shape class");
            // }
            // ✅ Interface
            // Pure contract: methods only (default interface methods were added in C# 8+).
            // 
            // No fields.
            // 
            // Supports multiple inheritance.
            // 
            // csharp
            // Copy
            // Edit
            // public interface IDrawable
            // {
            //     void Draw();
            // }
            // Use abstract classes when:
            // 
            // You want base functionality or state.
            // Use interfaces when:
            // 
            // You want to define behavior contracts (especially multiple ones).



            /* End ******************************************************************************************************************/

            #endregion


            #region Covariance and Contravariance (Advanced)

            /* Start *****************************************************************************************************************/

            // ⚙ Covariance and Contravariance (Advanced)
            // Used with generics, delegates, and interfaces.
            // 
            // Covariance (out)
            // Allows a method to return a more derived type than specified.
            // 
            // 
            // IEnumerable<object> objList = new List<string>(); // OK due to covariance
            // Contravariance (in)
            // Allows a method to accept less derived parameter types.
            // 
            // 
            // Action<object> action = (s) => Console.WriteLine(s);
            // Action<string> stringAction = action; // Not allowed
            // But:
            // 
            // 
            // Action<string> actStr = s => Console.WriteLine(s);
            // Action<object> actObj = actStr; // Error
            // Use in and out keywords in generic interfaces to enable this.
            // 
            // 🚀 When to Use Polymorphism
            // Building extensible systems (plugins, modules, strategy patterns).
            // 
            // Creating generic processing pipelines (e.g., list of base-class references to various subclasses).
            // 
            // Reducing code duplication and switch-case branching.
            // 
            // 🧠 Real-world Analogy
            // Imagine an IPaymentProcessor interface with different implementations:
            // 
            // 
            // public interface IPaymentProcessor
            // {
            //     void ProcessPayment(decimal amount);
            // }
            // 
            // public class PayPalProcessor : IPaymentProcessor
            // {
            //     public void ProcessPayment(decimal amount) => Console.WriteLine("Paid with PayPal");
            // }
            // 
            // public class StripeProcessor : IPaymentProcessor
            // {
            //     public void ProcessPayment(decimal amount) => Console.WriteLine("Paid with Stripe");
            // }
            // Now you can write code like:
            // 
            // 
            // IPaymentProcessor processor = new StripeProcessor();
            // processor.ProcessPayment(500); // Runtime polymorphism
            // ✅ Summary
            // Feature	Compile-Time (Overloading)	Run-Time (Overriding)
            // Resolution	At compile time	At runtime
            // Inheritance required	❌	✅
            // Method signature	Different	Same
            // Keywords	None	virtual / override / abstract
            // Flexibility	Low	High
            // 


            /* End ******************************************************************************************************************/

            #endregion


            #region Binding

            /* Start *****************************************************************************************************************/

            // // Now we will notice the difference between overriding using "new" or "virtual override" 
            // // Binding : Reference from Parent --> Object from Child
            // 
            // // The reference of the parent , can reference an object of the same type OR any object that inherits from it directly
            // // or indirectly
            // 
            // // A reference from the Parent --> an object from the child 
            // // then 
            // // we will have only the attributes , functions , properties (Which are in the Parent only) .. Only them are accessable
            // 
            // // what about the methods that are overriden by "new" or "virtual override" ? 
            // // 1 - methods overriden by "new" : it's a [Static Binded Method]. The implementation of the "Parent" Class is executed 
            // // 2 - methods overriden by "virtual override" : it's [Dynamic Binded Method]. The LAST OVERRIDE is executed 
            // 
            // // 1 - Static Binding [Early binding => at Compilation time] : Compiler will bind function call based on the reference
            // //                                                             not the Object .. it's known in the IL because it's done
            // //                                                             in the compilation time
            // // 2 - Dynamic Binding [Late binding => at Run time] : CLR will bind function call based on the Object not the reference
            // //                                                     it's done in the runtime , searching where is the last override 
            // //                                                     and executing it .. (ex: TypeC inherits from TypeB & TypeB inherits
            // //                                                     from TypeA .. At the main => TypeA test = new TypeC();   the last
            // //                                                     override of the function was in TypeB , So it will be executed)
            // 
            // Parent Ref = new Child(1, 2, 3);
            // Ref.X = 1;
            // Ref.Y = 2;
            // // Ref.Z = 3;                 // Error ! not accessable because it's a property in the child
            //    
            // Ref.TestVirtual();            // execute the code in the Child , overriden by "override" keyword
            // Ref.TestNew();                // execute the code in the Parent , overriden by "new" keyword
            // Ref.TestInheritance();        // No problem , it's in the parent 
            // 							  // Ref.OnlyInChild();         // Error ! not accessable because it's a method in the child
            // 
            // // Note : if the function is "virtual" in the parent .. it can be overriden by the two ways no problem
            // //        but if it's not "virtual" in the parent .. then it only can be overriden by the "new" keyword
            // //        ex : Test1 & Test2 & Test3 methods in Parent and Child classes
            // 
            // Ref.Test1();
            // Ref.Test2();
            // Ref.Test3();

            // // Important : 
            //
            // // Binding : Reference from Parent --> Object from Child
            // // Not Binding : Reference from Child --> Object from Parent
            // 
            // Parent p = new Parent(1, 2);             // Can reference a parent object
            // p = new Child(1, 2, 3);                  // Can reference a child object
            // 
            // Child ch = (Child)p;                     // This is not binding , this is explicit casting
            // 
            // // if the casting is accepted and "p" was actually referencing a child object , then there is no problem 
            // // but it "p" was referencing a paraent object then at the runtime we will have "InvalidCastException"
            // 
            // // Next sessions we will discuss the "Casting Operator Overloading" to skip this problem 




















            // ⚠️ Method Hiding (new Keyword)
            // If you define a method with the same name in a derived class without overriding, you're hiding the base method, not overriding it.
            // 
            // 
            // public class Base
            // {
            //     public void Show() => Console.WriteLine("Base Show");
            // }
            // 
            // public class Derived : Base
            // {
            //     public new void Show() => Console.WriteLine("Derived Show");
            // }
            // 
            //
            // Base obj = new Derived();
            // obj.Show(); // Output: Base Show (because it's hidden, not overridden)
            // To override, use virtual and override.

            /* End ******************************************************************************************************************/

            #endregion


            #region Binding Example 1 - Employees

            /* Start *****************************************************************************************************************/

            // // Binding is a behaviour 
            // 
            // // Example 1 --> Employee , Full time Employee , Part time Employee
            // 
            // // using Object initializer:
            // FullTimeEmployee fullTimeEmployee = new FullTimeEmployee()
            // {
            // 	Id = 1,
            // 	Name = "Mahmoud",
            // 	Age = 22,
            // 	Salary = 5_000
            // };    
            // EmployeeHelper.ProcessEmployee(fullTimeEmployee);
            // // I am Basic Employee																  
            // // Employee: Id = 1, Name = Mahmoud, Age = 22, Salary = 5000 
            // 
            // 
            // PartTimeEmployee partTimeEmployee = new PartTimeEmployee()
            // {
            // 	Id = 2,
            // 	Name = "Shoura",
            // 	Age = 22,
            // 	HourRate = 120
            // };  
            // EmployeeHelper.ProcessEmployee(partTimeEmployee);
            // // I am Basic Employee
            // // Employee: Id = 2, Name = Shoura, Age = 22, HourRate = 120

            /* End ******************************************************************************************************************/

            #endregion


            #region Binding Example 2 - Classes (A, B, C, D, E)

            /* Start *****************************************************************************************************************/

            // ClassA typeA = new ClassC(1, 2, 3);
            // typeA.A = 11;
            // // typeA.B = 22;   // Error 
            // // typeA.C = 33;   // Error
            // 
            // typeA.MyFun01();   // static binded method , compiler will call the function in the reference "ClassA"
            // 				      // output ==> I am Base , [Parent]
            // 					  
            // typeA.MyFun02();   // dynamin binded method , CLR will bind the function call to the last override for "MyFun02"
            // 				      // [ For class ClassC ==> The last override is in ClassC itself ] .. 
            //                    // output ==> ClassC, A = 11, B = 2, C = 3
            // 
            // 
            // 
            // ClassB typeB = new ClassC(1, 2, 3);
            // typeB.A = 11;
            // typeB.B = 22;     
            // // typeB.C = 33;     // Error
            //
            //
            // typeB.MyFun01();    // output ==> I am derived [Child]       "will execute the function of the reference"
            // typeB.MyFun02();    // output ==> ClassC, A = 11, B = 22, C = 3



            // ClassA typeA = new ClassE(1,2,3,4,5);
            // ClassB typeB = new ClassE(1,2,3,4,5);
            // ClassC typeC = new ClassE(1,2,3,4,5);
            // 
            // typeA.MyFun02();       // Last override for ClassA ==> was in ClassC ==> output : ClassC, A = 1, B = 2, C = 3
            // typeB.MyFun02();       // Last override for ClassB ==> was in ClassC ==> output : ClassC, A = 1, B = 2, C = 3
            // typeC.MyFun02();       // Last override for ClassC ==> was in ClassC ==> output : ClassC, A = 1, B = 2, C = 3
            // 
            // // After Breaking the Chain by "new virtual" and starting a new chain ==>
            // Console.WriteLine("After : ------------------------------------- ");
            // 
            // ClassD typeD = new ClassE(1,2,3,4,5);
            // ClassE typeE = new ClassE(1,2,3,4,5);
            // 
            // typeD.MyFun02();      // Last override for ClassD ==> was in ClassE ==> output : ClassE, A = 1, B = 2, C = 3, D = 4, E = 5
            // typeE.MyFun02();      // Last override for ClassE ==> was in ClassE ==> output : ClassE, A = 1, B = 2, C = 3, D = 4, E = 5
            // 
            // Console.WriteLine();
            // 
            // typeA.MyFun01();      // each reference will execute the function in it , I am Base , [Parent]
            // typeB.MyFun01();	     // each reference will execute the function in it , I am derived [Child]
            // typeC.MyFun01();	     // each reference will execute the function in it , I am derived [Grand Child]
            // typeD.MyFun01();	     // each reference will execute the function in it , Grand Grand Child
            // typeE.MyFun01();      // each reference will execute the function in it , Grand Grand Grand Child

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}