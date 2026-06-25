using OOP___Session_4.Abstraction;
using OOP___Session_4.Casting_Operators_Overloading;
using OOP___Session_4.Operators_Overloading;
using OOP___Session_4.Partial;
using OOP___Session_4.Static_and_Constants;

namespace OOP___Session_4
{
	internal class Program
	{
		static void Main(string[] args)
		{
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // Difference between abstraction and encapsulation
            // Difference between readonly and static attribute 
            // Self study : the partial method (video : Part 12 last 4 min.)

            /* End ******************************************************************************************************************/

            #endregion


            #region Overloading - Continued

            /* Start *****************************************************************************************************************/

            // Last sessions we've discussed the :
            // 1 - Indexer Overloading
            // 2 - Constructor Overloading
            // 3 - Methods Overloading

            // This session we will discuss the remaining two types :
            // 4 - Operators Overloading
            // 5 - Casting Operators Overloading

            /* End ******************************************************************************************************************/

            #endregion


            #region Operators Overloading - Binary Operators

            /* Start *****************************************************************************************************************/

            // // How can we have the summation of 2 Employees ?
            // // we must overload the "+" operator inside the Employee class
            // 
            // // Ex: Complex Class inside the "Operators overloading" folder
            // Complex C1 = new Complex() { Real = 2 , imaginary = 4};
            // Complex C2 = new Complex() { Real = 3 , imaginary = 5};
            // 
            // Complex C3 = C1 + C2;         // First we must overload the "+" inside the class 
            // 
            // // Note : this overload must be NON-Private & Class member function [Static]
            // 
            // Console.WriteLine(C3);
            // 
            // // Note : C4 += C1;
            // //        C4 =  C1 + C2 + C3 ;
            // // No problem with all of them , they work with the overload we've implemented  

            /* End ******************************************************************************************************************/

            #endregion


            #region Operators Overloading - Unary Operators

            /* Start *****************************************************************************************************************/

            // // Ex : " ++ " , postfix or prefix they are the same 
            // // Ex: Complex Class inside the "Operators overloading" folder
            // 
            // Complex C1 = new Complex() { Real = 5 , imaginary = 10 };
            // 
            // Console.WriteLine($"C1 ==> {C1} , Hashcode = {C1.GetHashCode()}");        
            // C1++;
            // Console.WriteLine("After ++ ");
            // Console.WriteLine($"C1 ==> {C1} , Hashcode = {C1.GetHashCode()}");          // New Place , different hashcode
            // 
            // Complex C2 = ++C1;
            // 
            // Console.WriteLine("After Complex C2 = ++C1; ");
            // Console.WriteLine($"C1 ==> {C1} , Hashcode = {C1.GetHashCode()}");         // Same Place at the memory      
            // Console.WriteLine($"C2 ==> {C2} , Hashcode = {C2.GetHashCode()}");         // has 2 references , C1 & C2

            /* End ******************************************************************************************************************/

            #endregion


            #region Operators Overloading - Comparison / Relational Operators

            /* Start *****************************************************************************************************************/

            // // Ex : " > , < , >= , <= , == , != " , postfix or prefix they are the same 
            // // Ex: Complex Class inside the "Operators overloading" folder
            // 
            // Complex C1 = new Complex() { Real = 1 , imaginary = 2};
            // Complex C2 = new Complex() { Real = 1 , imaginary = 2};
            // 
            // if (C1 > C2)
            // 	Console.WriteLine("C1 is greater than C2");
            // else if (C1 < C2)
            // 	Console.WriteLine("C2 is greater than C1");
            // else
            // 	Console.WriteLine("C1 and C2 are Equal in values");
            // 
            // 
            // if (C1 == C2) Console.WriteLine("YES");     
            // else Console.WriteLine("NO"); 
            // 
            // // The default implementation of == checks if they reference the same object at the memory and has the same Hash Code
            // // or not , can be changed by Operators Overloading 

            /* End ******************************************************************************************************************/

            #endregion


            #region Casting Operators Overloading

            /* Start *****************************************************************************************************************/

            // object O1 = 3;          // Boxing
            // int X = (int) O1;       // must be explicit casting
            // 
            // // So how to cast an object from "Complex" class to an int ?
            // // We must overload the casting operator , check "Complex" class ...
            // // It must be NON-Private Class Member [Static] function
            // 
            // Complex C1 = new Complex() { Real = 5 , imaginary = 7};
            // 
            // int num = (int) C1;                                       // Explicit casting [recommended]
            // Console.WriteLine($"Num = {num}");
            // 
            // string complex =/*(string)*/ C1;                                      // Implicit casting 
            // Console.WriteLine($"String Complex = {complex}");
            // 
            // // No difference between the implicit and the explicit but the explicit is recommended (because it's more readable)

            /* End ******************************************************************************************************************/

            #endregion


            #region Casting Operators Overloading - Business need and more advanced example

            /* Start *****************************************************************************************************************/

            // // Ex : Class "User" and Class "UserViewModel" in Casting Operators Overloading Folder
            // 
            // // Model : A class that represents a table existed in the Database 
            // //         ex : database table "user" , inside the application class "user" , each column in the table has a property in 
            // //              the application in the class
            // // ViewModel : A class that represents the Data that will be rendered in the view (HTML)
            // 
            // // suppose we retrieved a user from the database and we want to show it in the view (HTML) , then we must cast the "User" to "UserViewModel" 
            // 
            // User user = new User() 
            // { 
            // 	Id = 1 , 
            // 	FullName = "Mahmoud Shoura" , 
            // 	Email = "mahmoud@gmail.com" , 
            // 	Password = "123ABC" , 
            // 	SecurityStmp = Guid.NewGuid() 
            // };
            // 
            // UserViewModel userViewModel = (UserViewModel)user;
            // // Note : we can overload this casting operator inside "User" class or "UserViewModel" class
            // //        we write it inside the view model because the model must only contain properties inside the table in the database without behaviours
            // 
            // Console.WriteLine($"Fname : {userViewModel.FName} , LName : {userViewModel.LName} , email : {userViewModel.Email} , Password : {userViewModel.Password}");

            // // important question , why we are telling that this is overloading ?
            // // because there is a hidden implementation that we cannot se , that appears when :
            // object obj = new UserViewModel();
            // UserViewModel model = (UserViewModel)obj;         
            // // We didn't implement this but it's there .. so we are overloading it to be able to cast from other types 

            // // Casting Operators Overloading which we've done here was for "Manual Mapping" , and this is not frequently used (in small cases only) 
            // // in MVC we will use a package called "AutoMapper" that will do this mapping automatically , and by providing some configurations if necessary

            /* End ******************************************************************************************************************/

            #endregion


            #region Abstraction - Fourth OOP Pillar

            /* Start *****************************************************************************************************************/

            // // Abstract class , Abstract property , Abstract method
            //
            // // What is abstraction ?
            // // There are TWO opinions : 
            // // 1 - A definition that holds the same meaning of encapsulation (hide the not important things for users in the class , private & properties)
            // // 2 - It's a pillar of OOP , Abstract class , abstract method , abstract property 
            // 
            // 
            // // Abstract class : A Partial implementation to other classes 
            // //                  Cannot be instatiated (cannot create objects / instances) because it's not fully implemented 
            // //                  The class that can include abstract members (properties / methods)
            // //                  Inside the Abstract class , we can write fully implemented code or abstract code 
            // 
            // 
            // // Note :
            // // concrete_Class : concrete_Class      ==> inherit
            // // interface : interface                ==> inherit
            // // abstract_Class : abstract_Class      ==> inherit
            // // concrete_Class : interface           ==> Implement
            // // concrete_Class : abstract_Class      ==> inherit AND IMPLEMENT
            // 
            // Rect rectangle = new Rect() { Dim01 = 10 , Dim02 = 20};
            // decimal rectArea = rectangle.CalcArea();
            // decimal rectPeri = rectangle.Perimeter;
            // Console.WriteLine($"Rect Area : {rectArea}");
            // Console.WriteLine($"Rect Peri : {rectPeri}");
            // 
            // 
            // Circle circle = new Circle(10);
            // decimal circleArea = circle.CalcArea();
            // decimal circlePeri = circle.Perimeter;
            // Console.WriteLine($"Circle Area : {circleArea}");
            // Console.WriteLine($"Circle Peri : {circlePeri}");
            // 
            // // Abstract Method ==> is in Abstract class
            // // Signatue of Method ==> is in Interface
            // 
            // // How to implement the abstract methods or abstract properties ?
            // // by the same way of overriding the virtual properties or virtual methods , with keyword "override"
            // 
            // // What can we write inside the abstract class ? (four things of the class + 2 abstract )
            // // 1 - attribute  
            // // 2 - Property   
            // // 3 - method 	  
            // // 4 - Events 	  
            // // 5 - Abstract property        // new 
            // // 6 - Abstract method 		   // new 

            // // important : 
            // // We can make a constructor in an abstract class , it's used for initializing the attributes + for constructor chaining .. 
            // // ofcourse it's not used for making objects (because we cannot create objects from the abstract class) but we can make a reference
            // // that can refer to an object of a concrete class that inherit and implement this abstract class (reference)
            // 
            // Shape shape = new Square(5);
            // shape.TestReference();
            // 
            // Square square = new Square(5);
            // square.TestReference();
            // 
            // // in interface to use the default implemented method in the interface the reference must be from the interface , but here in the
            // // abstract class we can use the fully implemented method in the abstract class from it's reference or reference from the concrete class













            // 4 - Abstraction   ==> (supported with Class and Struct)
            //       - Focusing on what an object does, not how it does it.
            //       - Hide complexity
            //       - Provide simple and clear interfaces
            //       - Often implemented using abstract classes or interfaces


            // Abstract Classes and Inheritance
            // You can create abstract base classes that force derived classes to implement certain methods:
            //
            // abstract class Shape
            // {
            //     public abstract double GetArea();
            // }
            // 
            // class Circle : Shape
            // {
            //     public double Radius;
            //     public override double GetArea() => Math.PI * Radius * Radius;
            // }


            /* End ******************************************************************************************************************/

            #endregion


            #region Interfaces VS Abstract Class

            /* Start *****************************************************************************************************************/

            // So what is the difference between the interface and the abstract class ?
            // Class or an abstract class hold the base things to form the (is a relationship) but interfaces are used to implement and
            // insure that this type has a behaviour or functionality.

            // Abstract class : A Partial implementation to other classes that will implement the remaining abstracts by their way in the future
            // Interface : Code Contract , if you implemented the interface then you must have the behaviours of this interface and can implement them

            /* End ******************************************************************************************************************/

            #endregion


            #region Static Keyword 1 - Static Class

            /* Start *****************************************************************************************************************/

            // Static Class : A Container for class members ( Static members [Properties , Attributes , Constructor , Methods] and Constants )
            // We cannot make objects from a static class (because it contains only static members or constants) NOT OBJECT MEMBERS
            // Don't mix between the static class and the abstract class as we cannot make objects from them 
            // Cannot inherit from it 


            // Note : Also Non-Static Class can have these : Static Attributes , Static Constructor , Static Methods
            // Static built-in Classes : Math , Console , Convert 

            /* End ******************************************************************************************************************/

            #endregion


            #region Static Keyword 2 - Static Constructor

            /* Start *****************************************************************************************************************/

            // Object Member Constructor (default one used many times before) :
            // We can have more than one object member constructor , it's not the right place for initializing the static attributes (because i will
            // not make an object)

            // Static Constructor (special constructor ==> (Don't have an access modifier + Don't take a Parameter )) :
            // - Maximum only one Static Constructor per class 
            // - Will be executed by CLR just only ONE TIME PER CLASS LIFFETIME before any use of the class , uses of the class ==>
            //       1 - Call Static Method
            //       2 - Call Static Property 
            //       3 - Create object from this class 
            //       4 - create object from another class inheriting from this class
            //           (if the class was non-static because static classes cannot be inherited , here we are talking about the constructor itself)


            // We write inside the Static constructor the code that we want to be executed ONLY ONE TIME

            /* End ******************************************************************************************************************/

            #endregion


            #region Static Keyword 3 - Static Property and Attribute + Constants

            /* Start *****************************************************************************************************************/

            // Static property and static attribute : 

            // The value of the property doesn't change by changing the object state , and we may use it without making an object from the class 
            // Important : The static property (Class member property) MUST interact (Get & Set) with one of the Two :
            //                1 - Static Attribute (Class member attribute)
            //                2 - Constants

            // What initializes the static attribute ? NOT NEW KEYWORD
            // Why not new keyword ? because this is a static attribute and don't depend on making an object from the class (can be used without an object)
            // Compiler will Initialize the Static attribute with the default value of attribute datatype 
            // Also can be initialized in the static constructor


            // Constant : if the class is static then we can use the constant without an object but if the class is non-static then we must make an object 
            //            to use the constant variable through , and it cannot be static in the case of non-static class
            // With constants : The value must be given with the declaration and cannot be changed later
            //                  Const variable cannot have set method in the property (cannot be changed)
            
            /* End ******************************************************************************************************************/

            #endregion


            #region Static Keyword 4 - Static Methods

            /* Start *****************************************************************************************************************/

            // Static Method :

            // it's better to be an class member function [Static] .. it's not important to make an object from it to use the helper function "CmToInch"
            // because the returned value (result of calling the method) doesn't change by changing the object state , doesn't depend on the object
            // state (Attributes and properties) 

            /* End ******************************************************************************************************************/

            #endregion


            #region Sealed Keyword (Class , Method , Property)

            /* Start *****************************************************************************************************************/

            // Sealed Class : No one can inherit from this class , it's sealed .. used to force the developer to not inherit this class 
            // Note : this class can inherit from other classes , but other classes cannot inherit from it 


            // Sealed Method : A Method that cannot be overriden in the child classes that inherit from the Parent class (containing the sealed method)
            // the sealed method can be overriden by the keyword "new" , but with the keyword "override" it cannot be overriden 
            // Note : Don't forget the difference between the "new" and "override" keyword when binding 

            // revision on the difference between sealed override method and "new" method and it's impact on the child class ==> part 11 (A.Nasr)  


            // Sealed Property : A property that cannot be overriden and changing it's implementation (same as sealed method)

            /* End ******************************************************************************************************************/

            #endregion


            #region Partial Keyword (Class , struct , interface , Method "Self Study")

            /* Start *****************************************************************************************************************/

            // // Partial class ==> Class that is written in one or more than one file 
            // // When do we need partial ?
            // // 1 - when more than one developer are working on the same class
            // // 2 - when using the ORM such as EF core (and working with "Database first" approach)
            // //     Ex : database first means that we design the database then the EF Core will generate the classes , we may have added some 
            // //          more functions in the classes generated by EF Core .. so if we've changed the database and the EF core re-generated the
            // //          classes for us .. we've lost the added functions that we added before , so we add our functions in a partial class to be saved 
            // //          and away from the continious changing of the other class (because of changing database)
            // 
            // 
            // TestPartial testPartial = new TestPartial()
            // {
            // 	Id = 1,                                   // from the First file
            // 	Name  = "Mahmoud Shoura",				  // from the First file
            // 	Age = 22,								  // from the First file
            // 	Salary = 100_000_000                      // from the Second file
            // };
            // 
            // // The compiler interacts with the two files as one file and one class
            // 
            // // In Struct and Interface It's the same as here in the Classes 

            /* End ******************************************************************************************************************/

            #endregion


            #region Summary - Class Types

            /* Start *****************************************************************************************************************/

            // 1 - Concrete Class ==> solid class , fully implemented class that we can make objects from and can be inherited 
            // 2 - Abstract Class ==> Partial Implementation for classes that will provide the full implementetion for the abstracts in the future 
            //                        Cannot make objects from because it's not fully implemented 
            // 3 - Static Class   ==> contains static members and constants only (helpers), used without making objects from (also cannot make objects from)
            // 4 - Sealed Class   ==> Cannot inherit from it , stop the chain of inheriting in this class 
            // 5 - Partial Class  ==> Class that is written in one or more files

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}