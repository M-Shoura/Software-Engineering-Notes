using OOP___Session_3.BuiltIn_interfaces.Icomparer;
using OOP___Session_3.BuiltIn_interfaces;
using System.Text;

namespace OOP___Session_3
{
	internal class Program
	{
		static void Main(string[] args)
		{
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // More about Explicit Interface Implementation

            /* End ******************************************************************************************************************/

            #endregion


            #region Interface 

            /* Start *****************************************************************************************************************/

            // Interface : A code contract between the developer that will write the interface and the developer that will implement it
            //             in class or struct, all classes or structs that implement this interface have common standards between them    

            // What is the difference between inheritance and implementation?
            // inheritance => inherite the basic things, ex: Person has name and age , eating and walking functionality , then Doctor
            // inherite them , Teacher inherite them ... but when making an interface then it will contain the functionality of Working 
            // as a Doctor or the functionality of working as a Teacher ... every type that will implement the interface must have the 
            // functionalities inside it                               

            // usually the name starts with I .. Ex : IMyType 


            // What can be written inside the interface ?
            // 1 - Signature for property
            // 2 - Signature for the method 
            // 3 - Default implemented method & Default implemented property [C# 8.0 .net core 3.1 (2019)]

            // Every signature must be implemented in the classes and structs that implement the interface (without changing signature)

            // Allowed Access Modifiers inside a interface 
            // 1 - Private Protected   (or Protected Private)
            // 2 - Protected 
            // 3 - Internal 
            // 4 - Internal Protected  (or Protected Internal)
            // 5 - Public

            // The default access modifier inside the interface --> Public
            // [For Signatures] Not allowed access modifier inside the interface --> Private , because this behaviour will be implemented 
            //                                                                       in types that will implement the interface , so why ??

            // private is allowed only in one case -> Default Implemented Method , ex : function swap that is a default implemented method
            // inside the interface .. that is used inside default implemented sorting method in the interface .. the user wants only sorting
            // function not the swap function , so make it private in this case (helper method inside the interface)

            // interface01 : interface02  ==> Inheritance    "between class and class or interface and interface"
            // Class01 : Class02          ==> Inheritance    "between class and class or interface and interface"
            // Class01 : interface01      ==> Implementation "between class and interface"

            // Ex on inheritance between interfaces : 
            // IBird  { eat , drink }
            // IFlyable : IBird  { fly }

            // The penguin will implement ==> IBird      "Can eat and drink only"
            // The Eagle will implement ==> IFlyable     "Can eat , drink , fly"



            // // We can make a variable (reference) of type interface but we cannot make an object of interface because inside the
            // // interface we have signatures , so why ??
            // 
            // IMyType myTypeInterface;
            // // declare of reference of type "IMyType" refering to null 
            // // CLR will allocate 4 bytes at the stack for the reference 
            // // This reference "myType" can refer to an object of class or struct that implement the interface
            // 
            // // myType = new IMyType();             // Invalid
            // myTypeInterface = new MyType();        // Valid
            // myTypeInterface.Salary = 1;
            // myTypeInterface.MyFun();
            // myTypeInterface.Print();               // Accessable because the reference is from type interface "IMyType"
            // 
            // MyType myTypeClass = new MyType();
            // myTypeClass.Salary = 2;
            // myTypeClass.MyFun();
            // // myTypeClass.Print();                // NOT Accessable because the reference is from type class "MyType"
            //                                        // and "Print" is a [Default implemented method] that is not implemented in the
            // 									      // class it self , so to use it the reference must be from the interface


            // Having the interface solved 2 problems : 
            // 1 - We don't have multiple inheritance from multiple classes , but we can implement multiple interfaces 
            // 2 - Struct doesn't support inheritance but can implement multiple interfaces


            // Maybe the class has some behaviours that are not interconnected to each other , so put some interconnected behaviours
            // in one place "interface" and implement the wanted interface only (best fit my functions and behaviours)

            /* End ******************************************************************************************************************/

            #endregion


            #region Allowed Access Modifiers inside a interface

            /* Start *****************************************************************************************************************/

            // ASK GPT AGAIN
            /*
                         * Access Modifiers for Interfaces (in C#)
            🔹 At the Interface Level (Declaration)
            When declaring an interface inside a namespace, the following access modifiers are allowed:
            
            Modifier	Allowed?	Meaning
            public	✅	Accessible anywhere
            internal	✅	Accessible within the same assembly
            (no modifier)	✅	Defaults to internal
            private, protected, protected internal, private protected	❌	Not allowed at top level
            
            Example:
            csharp
            Copy
            Edit
            public interface IPublicInterface { }
            
            internal interface IInternalInterface { }
            
            interface IDefaultInterface { } // Same as internal
            🔹 Inside an Interface (Members)
            All members in an interface are implicitly public and abstract — you do not write any access modifier.
            
            Member Type	Allowed?	Access Modifier
            Method	✅	Always public (cannot specify)
            Property	✅	Always public
            Indexer	✅	Always public
            Event	✅	Always public
            Fields	❌	Not allowed
            Constructors	❌	Not allowed
            Access Modifiers	❌	Not allowed for members
            
            ❌ Invalid:
            csharp
            Copy
            Edit
            public interface IExample
            {
                private void DoSomething(); // ❌ Not allowed
            }           
            ✅ Valid:
            csharp
            Copy
            Edit
            public interface IExample
            {
                void DoSomething(); // ✅ Implicitly public
                int MyProperty { get; set; }
                event EventHandler OnCompleted;
            }
            🔸 C# 8.0 and Later: Default Interface Methods
            Starting from C# 8, interfaces can contain:
            
            default implementations for methods
            
            static methods
            
            private methods (for internal logic)
            
            But all other members are still public
            
            ✅ Example (C# 8+):
            csharp
            Copy
            Edit
            public interface IExample
            {
                void DoSomething(); // Public
            
                private void HelperMethod() { } // ✅ Allowed in C# 8+ for internal logic
            
                public static void StaticUtility() { } // ✅ C# 8+
            
                public void DefaultMethod() // ✅ Allowed in C# 8+
                {
                    Console.WriteLine("Default implementation");
                }
            }           
            ✅ Summary: Access Modifiers in Interfaces
            Context	Allowed Modifiers
            Interface declaration	public, internal, (default = internal)
            Interface members (classic)	None (always public by default)
            C# 8+ interface members	private, public, static (only in limited cases)
                         
             */

            // Allowed Access Modifiers inside a interface :
            // 1 - Private Protected   (or Protected Private)
            // 2 - Protected 
            // 3 - Internal 
            // 4 - Internal Protected  (or Protected Internal)
            // 5 - Public

            // Private can be used inside the interface in only one case => Default Implemented Method

            // Default access modifier inside the interface : Public 

            // To use a default implemeneted method from an interface , the reference must be of type interface.

            /* End ******************************************************************************************************************/

            #endregion


            #region Interface Example 2

            /* Start *****************************************************************************************************************/

            // // Interface Example 02 : 
            // 
            // SeriesByTwo seriesByTwo = new SeriesByTwo();
            // Helper.Print10NumbersFromSeries(seriesByTwo);
            // // Print10NumbersFromSeries can take any type (class or struct) that implements that interface , because the arguments
            // // in this function is a reference from the interface "ISeries" and can refer any type that implement it 
            // 
            // SeriesByThree seriesByThree = new SeriesByThree();
            // Helper.Print10NumbersFromSeries(seriesByThree);
            // 
            // SeriesByFour seriesByFour = new SeriesByFour();
            // Helper.Print10NumbersFromSeries(seriesByFour);

            /* End ******************************************************************************************************************/

            #endregion


            #region Interface Example 3

            /* Start *****************************************************************************************************************/

            // Airplane airplane = new Airplane();
            // airplane.Left();
            // airplane.Right();
            // // airplane.Forward();     // Error , because it's private in the class and cannot be changed
            // // To use this function the reference must be of type that interface , that is explicitly
            // // implemented the function inside the class "Airplane"
            // 
            // Console.WriteLine("flyable : ");
            // IFlyable flyable = new Airplane();
            // flyable.Left();
            // flyable.Right();
            // flyable.Backward();
            // flyable.Forward();
            // 
            // Console.WriteLine("movable : ");
            // IMovable movable = new Airplane();
            // movable.Left();
            // movable.Right();
            // movable.Backward();
            // movable.Forward();

            /* End ******************************************************************************************************************/

            #endregion


            #region Shallow Copy and Deep Copy

            /* Start *****************************************************************************************************************/

            // We will discuss the Shallow Copy , Deep Copy with reference types , in value types there is only one type of copying

            // Shallow Copy : when taking a shallow copy of an obejct (reference type) , changing in the copy also changes in the
            //                original object , and changing in the original also changes in the copy.
            //                 
            // Deep Copy : when taking a deep copy of an obejct (reference type) , then changing in the copy doesn't change in the
            //             original object, and changing in the original doesn't change in the copy 

            /* End ******************************************************************************************************************/

            #endregion


            #region Shallow Copy

            /* Start *****************************************************************************************************************/

            // // Shallow Copy ==> 
            // 
            // int[] Arr01 = { 1, 2, 3 };
            // int[] Arr02 = { 4, 5, 6 };
            // 
            // Console.WriteLine($"HashCode for Arr01 = {Arr01.GetHashCode()}");       // Different address
            // Console.WriteLine($"HashCode for Arr02 = {Arr02.GetHashCode()}");       // Different address
            // 
            // Arr02 = Arr01;
            // Console.WriteLine("After Shallow Copying *********************** ");
            // 
            // Console.WriteLine($"HashCode for Arr01 = {Arr01.GetHashCode()}");
            // Console.WriteLine($"HashCode for Arr02 = {Arr02.GetHashCode()}");
            // 
            // // We will notice that after the shallow copying they have the same address in the memory, means that the object { 1, 2, 3 }
            // // now has TWO references , (Arr01 & Arr02) , and any change in any of the two references will affect the other one . and 
            // // the object { 4, 5, 6 } is now unreachable object
            // 
            // Arr01[0] = 100;
            // Console.WriteLine("After Changing Arr01[0] *********************** ");
            // 
            // Console.WriteLine($"Arr01[0] : {Arr01[0]}");   // 100
            // Console.WriteLine($"Arr02[0] : {Arr02[0]}");	  // 100

            /* End ******************************************************************************************************************/

            #endregion


            #region Deep Copy

            /* Start *****************************************************************************************************************/

            // // Deep Copy ==> Clone Method OR Copy Constructor
            // 
            // int[] Arr01 = { 1, 2, 3 };
            // int[] Arr02 = { 4, 5, 6 };
            // 
            // Console.WriteLine($"HashCode for Arr01 = {Arr01.GetHashCode()}");       // Different address
            // Console.WriteLine($"HashCode for Arr02 = {Arr02.GetHashCode()}");       // Different address
            // 
            // Arr02 = (int[])Arr01.Clone();
            // // Why we need explicit casting ? because "Clone" method returns a type "Object" 
            // Console.WriteLine("After Deep Copying *********************** ");
            // 
            // Console.WriteLine($"HashCode for Arr01 = {Arr01.GetHashCode()}");       // Different address
            // Console.WriteLine($"HashCode for Arr02 = {Arr02.GetHashCode()}");	   // Different address
            // 
            // // We will notice that after the deep copying they still don't have the same address in the memory, means that "Clone" 
            // // method will generate a new object in the heap with new and different identity (hash code and place at the memory) .. and 
            // // this object will have the same object state (Data) of Caller object "Arr01" .. and the object { 4, 5, 6 } is now
            // // unreachable object in the heap
            // 
            // Arr01[0] = 100;
            // Console.WriteLine("After Changing Arr01[0] *********************** ");
            // 
            // Console.WriteLine($"Arr01[0] : {Arr01[0]}");      // 100 
            // Console.WriteLine($"Arr02[0] : {Arr02[0]}");      // 1 

            /* End ******************************************************************************************************************/

            #endregion


            #region Clone Method and Why it says that it makes a Shallow Copy ??? 

            /* Start *****************************************************************************************************************/

            // Until now , "Clone" method performs a deep copy , but in the documentation (Source Code) of the method we can find that :
            // Clone method : Make a new array which is a shallow copy of the original array.

            // 1 -  if the array was of a value type datatype (structs : int , float , double , ... ) then no problem with shallow copying
            // 2 - if the array was of a reference type datatype (class) , there is two difference scenarios :


            // // 2.1 -  if the type is string (immutable) :
            // 
            // string[] ArrString01 = { "Mahmoud", "Ahmed" };
            // string[] ArrString02 = { "Shoura" };
            // 
            // Console.WriteLine($"HashCode for ArrString01 = {ArrString01.GetHashCode()}");
            // Console.WriteLine($"HashCode for ArrString02 = {ArrString02.GetHashCode()}");
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrString01 = {ArrString01[0]}");
            // Console.WriteLine($"HashCode for ArrString01[0] = {ArrString01[0].GetHashCode()}");
            // Console.WriteLine($"The first element in ArrString02 = {ArrString02[0]}");
            // Console.WriteLine($"HashCode for ArrString02[0] = {ArrString02[0].GetHashCode()}");
            // Console.WriteLine();
            // 
            // 
            // ArrString02 = (string[])ArrString01.Clone();
            // Console.WriteLine("After Deep Copy : ************************************** ");
            // Console.WriteLine();
            // 
            // // we will notice that they still don't have the same address , but ...
            // Console.WriteLine($"HashCode for ArrString01 = {ArrString01.GetHashCode()}");
            // Console.WriteLine($"HashCode for ArrString02 = {ArrString02.GetHashCode()}");
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrString01 = {ArrString01[0]}");
            // Console.WriteLine($"HashCode for ArrString01[0] = {ArrString01[0].GetHashCode()}");
            // Console.WriteLine($"The first element in ArrString02 = {ArrString02[0]}");
            // Console.WriteLine($"HashCode for ArrString02[0] = {ArrString02[0].GetHashCode()}");
            // Console.WriteLine();

            // // We will notice that they don't have the same address in the memory , means that Clone method have generated a new array of
            // // type string in the heap , which internally hold the reference of "Mahmoud" and "Ahmed" in the heap (because they are
            // // strings reference types and they are stored in the heap) .. 
            // 
            // ArrString01[0] = "TEST";
            // Console.WriteLine("After changing ArrString01[0] : ******************************");
            // Console.WriteLine();
            // 
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrString01 = {ArrString01[0]}");
            // Console.WriteLine($"HashCode for ArrString01[0] = {ArrString01[0].GetHashCode()}");
            // Console.WriteLine($"The first element in ArrString02 = {ArrString02[0]}");
            // Console.WriteLine($"HashCode for ArrString02[0] = {ArrString02[0].GetHashCode()}");
            // Console.WriteLine();
            // // We will notice that they have a different address and they are different , because the string is immutable



            // // 2.2 -  if the type was not string (not immutable) : 
            // 
            // StringBuilder[] ArrStringBuilder01 = new StringBuilder[2] ;
            // ArrStringBuilder01[0] = new StringBuilder("Mahmoud");
            // ArrStringBuilder01[1] = new StringBuilder("Ahmed");
            // 
            // StringBuilder[] ArrStringBuilder02 = new StringBuilder[1];
            // ArrStringBuilder02[0] = new StringBuilder("Shoura");
            // 
            // Console.WriteLine($"HashCode for ArrStringBuilder01 = {ArrStringBuilder01.GetHashCode()}");       
            // Console.WriteLine($"HashCode for ArrStringBuilder02 = {ArrStringBuilder02.GetHashCode()}");       
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrStringBuilder01 = {ArrStringBuilder01[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder01[0] = {ArrStringBuilder01[0].GetHashCode()}");     
            // Console.WriteLine($"The first element in ArrStringBuilder02 = {ArrStringBuilder02[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder02[0] = {ArrStringBuilder02[0].GetHashCode()}");     
            // Console.WriteLine();
            // 
            // ArrStringBuilder02 = (StringBuilder[])ArrStringBuilder01.Clone();
            // Console.WriteLine("After Deep Copy : ************************************** ");
            // Console.WriteLine();
            // 
            // Console.WriteLine($"HashCode for ArrStringBuilder01 = {ArrStringBuilder01.GetHashCode()}");      
            // Console.WriteLine($"HashCode for ArrStringBuilder02 = {ArrStringBuilder02.GetHashCode()}");      
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrStringBuilder01 = {ArrStringBuilder01[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder01[0] = {ArrStringBuilder01[0].GetHashCode()}");      
            // Console.WriteLine($"The first element in ArrStringBuilder02 = {ArrStringBuilder02[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder02[0] = {ArrStringBuilder02[0].GetHashCode()}");      
            // Console.WriteLine();
            // 
            // 
            // ArrStringBuilder01[0].Append("TEST");
            // Console.WriteLine("After changing ArrStringBuilder01[0] : ******************************");
            // Console.WriteLine();
            // 
            // Console.WriteLine("Check address of the first elements : ");
            // Console.WriteLine($"The first element in ArrStringBuilder01 = {ArrStringBuilder01[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder01[0] = {ArrStringBuilder01[0].GetHashCode()}");    
            // Console.WriteLine($"The first element in ArrStringBuilder02 = {ArrStringBuilder02[0]}");
            // Console.WriteLine($"HashCode for ArrStringBuilder02[0] = {ArrStringBuilder02[0].GetHashCode()}");
            // 
            // // Here we notice that after changing the "ArrStringBuilder01[0]" by appending a string to it , it's still in the same palce
            // // in the memory (unlike string) .. so any reference to that place at the memory will now have a different value , and 
            // // actually the "ArrStringBuilder02[0]" has the same address to that place in the memory (that's because of the shallow copy) 

            /* End ******************************************************************************************************************/

            #endregion


            #region Built-in interfaces 1 - IClonable

            /* Start *****************************************************************************************************************/

            // // Why the array has Clone() method ??
            // // because it implements the IClonable interface that contains only Clone() method
            // 
            // // Ex: Employee Class in IClonable Interface Folder
            // 
            // Employee employee01 = new Employee()
            // {
            // 	Id = 10,
            // 	Name = "Mahmoud",
            // 	Salary = 5_000,
            // 	Department = new Department() { Id = 101 , Name = "Sales"}
            // 	
            // };
            // Employee employee02 = new Employee()
            // {
            // 	Id = 20,
            // 	Name = "Shoura",
            // 	Salary = 10_000,
            // 	Department = new Department() { Id = 102, Name = "HR" }
            // };
            // 
            // Console.WriteLine($"Hashcode of Employee01 : {employee01.GetHashCode()}");
            // Console.WriteLine($"Hashcode of Employee02 : {employee02.GetHashCode()}");
            // Console.WriteLine();
            // 
            // // 1 - Shallow Copy :
            // Employee employee03 = employee01;
            // 
            // // 2 - Deep Copy : 
            // // using "Clone()" method , which is not implemented in the class 
            // // Note : it's not a must to implement interface "ICloneable" to use clone method , but it's better incase we have a function
            // //        that takes any object that implements the "ICloneable" interface with Clone method ..
            // 
            // employee02 = (Employee)employee01.Clone();
            // // Clone Method : Will Generate NEW object with new Different identity (hash code and address at the memory)
            // //                This object will have the same data of the Caller Object "employee01" 
            // 
            // Console.WriteLine("After Deep Copying *********************** ");
            // Console.WriteLine();
            // Console.WriteLine($"Hashcode of Employee01 : {employee01.GetHashCode()}");
            // Console.WriteLine($"Hashcode of Employee02 : {employee02.GetHashCode()}");
            // Console.WriteLine();
            // Console.WriteLine(employee01);
            // Console.WriteLine(employee02);
            // 
            // 
            // employee01.Department.Name = "Test";
            // Console.WriteLine("After changing the Department name of employee01 : ");
            // 
            // Console.WriteLine(employee01);
            // Console.WriteLine(employee02);
            // // Notice that if we used [ Department = this.Department ] inside the Clone method , any change to the department in 
            // // "employee01" or "employee02" will affect the other because they reference the same place at the heap 
            // 
            // // To sum up , incase of the attribute is a "Value Type" or a "string" then use the "=" assignment operator , else use the 
            // // Clone method
            // 
            // // Copy Constructor , how to perform deep copy using it ?    ==> Special constructor (takes one parameter of the same type)
            // Employee employee04 = new Employee(employee01);              // given the object in the parameters of the ctor

            /* End ******************************************************************************************************************/

            #endregion


            #region Built-in interfaces 2 - ICompareable

            /* Start *****************************************************************************************************************/

            // // Sorting the array:
            // int[] arr = { 5, 3, 6, 1, 2, 7, 4, };
            // Array.Sort(arr);
            // 
            // // So how to sort an array of Employees?
            // // By implementing the "ICompareable" interface and having "CompareTo" function
            // 
            // Employee[]  employees =
            // {
            // 	new Employee(){Id = 10 , Name = "Mahmoud", Salary = 5_000},
            // 	new Employee(){Id = 20 , Name = "Ahmed", Salary = 15_000},
            // 	new Employee(){Id = 30 , Name = "Sayed", Salary = 10_000},
            // 	new Employee(){Id = 40 , Name = "Shoura", Salary = 100_000}
            // };
            // 
            // Array.Sort(employees);        // Error if not implementing the "ICompareable" interface => "InvalidOperationException"
            // 
            // // Sort method takes a "Object" parameter , this type MUST implement "ICompareable" interface , means that it we have the 
            // // function with the same implementation but NOT IMPLEMENTING "ICompareable" interface then it Will Not Work 
            // // int , float , decimal , string , ... implement "ICompareable" interface
            // 
            // // CompareTo Function : 
            // // Returns +VE value if the caller is Greater that the object sent
            // // Returns -VE value if the caller is Smaller that the object sent
            // // Returns Zero value if the caller Equals the object sent
            // 
            // foreach (Employee emp in employees)
            // {
            //     Console.WriteLine(emp);
            // }
            // 
            // // There is now a small problem :
            // int result = employees[0].CompareTo(employees[1]);      // No problem
            // result = employees[0].CompareTo("TEST");                // throws exception ! the funtion parameter can take any "object"
            // // To solve this problem , we will use Generics ... (Next sessions .. )
            // // we will implement the IComparable<Employee> (the generic one that takes employee object only)

            /* End ******************************************************************************************************************/

            #endregion


            #region Built-in interfaces 3 - IComparer

            /* Start *****************************************************************************************************************/

            // // what if we want to compare by a different way that the "CompareTo" function ?
            // // Use the IComparer interface and implement it in a NEW CLASS , that implements the "Compare" function as wanted
            // // Note : IComparer interface is found in "System.Collections"
            // 
            // Employee[] employees =
            // {
            // 	new Employee(){Id = 30 , Name = "Sayed", Salary = 10_000},
            // 	new Employee(){Id = 20 , Name = "Ahmed", Salary = 15_000},
            // 	new Employee(){Id = 10 , Name = "Mahmoud", Salary = 5_000},
            // 	new Employee(){Id = 40 , Name = "Shoura", Salary = 100_000}
            // };
            // 
            // Array.Sort(employees, new EmployeeComparerID());        // Error if not implementing the "IComparer" interface 
            // 
            // foreach (Employee emp in employees)
            // {
            // 	Console.WriteLine(emp);
            // }
            // 
            // // To sum up , implement the most common used way for comparing in the "CompareTo" function of the 
            // // ICompareable interface , and if you want more ways for comparing then use the "IComparer" interface 

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}