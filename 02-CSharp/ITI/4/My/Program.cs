using System.Diagnostics;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;

namespace My
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // stack trace and stack frame for each function and function scope
            // why we can have two variables with the same name but in diff functions ? => diff stack frames in the stack

            // self study : is there any differences between stack frame for a static function or non-static func ? 

            // stack frame : the handling way of the memory is same as the stack datastructure
            //               so the top frame in the stack is the function that we are executing now 

            // the size of the stack is 1 MB , take care of the stack overflow exception (when recursive call without base condition)

            // any local variable has it's size in the stack frame when declaration of the stack frame in the stack memory , but we cannot 
            // deal with this space until declaration and initialization of the local variable.

            // we can see a variable that is in another stack frame , but when we have a reference to it ! 

            // stack is automatically managed by the CLR , so when reaching the end of the function (last curly brace) then the function is deleted 
            // from the stack ! 

            // self study : hot reload in debugging (feature that exists only with VS)
            //              also we can right click and "Add watch" , that we can watch variables there and can change their values on the run ! 
            //              there is a window called "Locals" shows local variables , and "Autos" shows some local variables (+-2 up and down) , 
            //              and "Immediate Window" for writing code that will be executed one time only , and "Call Stack" window that shows the call
            //              stack or the stack trace of functions (shown when debugging)


            // To write code that access the stack trace : 
            // use the "StackTrace" class that is the namespace "System.Diagnostics"
            // Note : Even if we didn't use this namespace , we could find the class "StackTrace" , that's because if we see the dropdown
            //        list when writing the class name we find that "first button from left" is enabled , which says "add items from
            //        unimported namespaces"

            // StackTrace stackTrace = new StackTrace();
            // var sframes = stackTrace.GetFrames();
            // for (int i = 0; i < sframes.Length; i++)
            //     Console.WriteLine(sframes[i].GetMethod().Name);


            // input parameters :
            // the input parameter has the same scope of the local variable , but it takes it's initial value from the caller , not 
            // garbage or by the function it self ! 


            // named input parameter : used to change the order of the sending of parameter
            // func(param1Name: "str", param2Name: 3) // different ordering with providing the name only
            // it's a syntax sugar , if we see the ILSpy we will find them ordered by the compiler in the C# code

            // default value for parameters : must be the last parameters from the right , as C++ 



            // passing by value for value types , passing by reference for value types

            // for passing by referece for any datatype (value type or reference type) : 
            // - Add "ref" keyword only before the parameter in the function call and in the parameter list in the function
            // in main : 
            // Swap(ref a , ref b);
            // 
            // function itself : 
            // public static void Swap(ref int a , ref int b){ ... }


            // sending by reference can be used to return more than one return from the function , change in the sent parameters directly


            // so to summerize : sending value types by value => Read only 
            //                   sending value types by reference => Read and write

            // Note : we cannot send by reference without initializing , so we must initialze the variable first before sending by ref .. 
            //        that's because it's read and write ! 


            // passing by out : it's the same as passing by reference , but without initialization !
            // add an "out" keyword in the function call and the function parameter list 

            // Func(out a , out b);
            // 
            // function itself : 
            // public static void Func(out int a , out int b){ ... }

            // Note : inside the function the out parameters cannot be used before initializing them 

            // some syntax sugar with passing by out : 
            //   Func(out int x , out int y);           // declared in the same scope
            // is the same as these two steps : 
            //   int x, int y; 
            //   Func(out x, out y); 


            // what if we have 2 output parameters and we don't want to get the second one , so we can put the discard "_" , and in the IL
            // it will be a variable that is never used ! it's a syntax sugar also 

            // SumMul(x, y, out int sum , out int mul);   // in the IL they are the same
            // SumMul(x, y, out int sum , out _);         // in the IL they are the same



            // passing by value for reference types , passing by reference for reference types


            // passing by value for reference types : the object in the heap now has 2 references
            // passing by reference for reference types : 


            // params : for variable length input parameters
            // in the function itself : 
            // public static int SumArray(params int[] arr){ ... }
            // in the main : 
            //   SumArray(1,2,3,4,5,6);
            //   SumArray(1);
            //   SumArray(new int[] {1,2,3});
            // Note : params must be the last in the parameter list , and any thing can be before it ! string , int , ... 


            // foreach : 
            // foreach(var x in arr) { // deal with x directly } 
            // Note : foreach is less flexible than for , and also it's slower ! it's easy in writing only , it's better only when having
            //        a collection without an iterator , so we can use the foreach with it




            // --------------------------------------------------------------------------------------------------------------------------
            // --------------------------------------------------------------------------------------------------------------------------


            // Part 2 : 

            // getters and setters , property 
            // making the attribute public makes us cannot put any validations on the input data
            // use getters and setters to complete separation between the data and it's use 

            // the getter and setter each of them can have a different access level (internal and public)

            // setters and getters disadvantages : they are called as "Functions" !! 

            // we can use "getters" and "setters" with one statemenet , and also used as an attribute , not a function .. 
            // this is done using the properties 


            // how to write the property : 
            // public decimal Salary;                    // attribute
            // public decimal Salary(){ };               // function
            // public decimal Salary{ get{}  set{} };    // property

            // inside the set , we have a "value" , that has the value from setting the attribute

            // we can have set only , get only , set and get , ... each of them can have a different access level ... 
            // public decimal Salary{ public get{} internal set{ value > 5000 ? value : 5000;} }; 

            // in the IL Code, we see functions called "get_Salary" and "set_Salary" , and these function are used when trying to 
            // read or write this variable or field

            // public decimal taxes {get {return 0.15*Salary;} }
            // this property doesn't have a set , so we cannot set value to it

            // proeprty is the same as function , we have static property , virtual property , abstract property ,
            // overloading (in special type of properties only => Indexer) , as the default property cannot have different shapes
            // to be overloaded


            // note : inside the class , ex: in the ctor , is it better to use the property or the attribute directly ? 
            //        it's better to use the attribute directly if we don't have validations/filtration in the getter/setter so this 
            //        will avoid making a stack frame for the getter/setter as they are functions also ! but if we have validation 
            //        or filtration we can copy it into the ctor or use the property directly.

            // note : we could have a stackOverFlow Exception , incase we return the property in it's "get" ! 
            // public decimal Salary { get { return Salary;} }    // wrong , we must return another variable to avoid exception 

            // read only property : self study
            // 

            // indexer in C# : it's the same as operator overloading in C++ ( in C# no operator overloading for the [] but we have the
            //                 indexer)

            // so the [] is used for only the indexer, it's the property that can take more then input parameter and can be overloaded ! 
            // indexer must have minimum 1 input parameter

            // indexer examples : 
            // phoneBook p = new phoneBook() {NumArray , NamesArr};
            //   p[3, "Mahmoud"] = 1234;
            //   p["Mahmoud"] = 1234;
            //   p[3] = 1234;
            //   Console.WriteLine(p[3]);
            //   Console.WriteLine(p["Mahmoud"]);

            // datatype of the indexer : long (long is the datatype taken from the set and returned from the get)

            // defining an indexer : 
            // public long this[string name]        // this is the overload that takes a string and returns long , ex: p["mahmoud"] = 123
            // {                                    //                                                             ex: cw(p["mahmoud"]);
            //      //   p["Mahmoud"] = 1234;
            //      //   Console.WriteLine(p["Mahmoud"]);
            //
            //      get
            //      {
            //         for(;i<names.length;) if(names[i] == name) return number[i]; return -1 (if not found);
            //      }
            //      set
            //      {
            //         for(;i<names.length;) if(names[i] == name) number[i] = value;
            //      }
            // }

            // another overload that takes idx and return the number and the name : 
            // public string this[int idx]         //   Console.WriteLine(p[3]);
            // {
            //     get
            //     {
            //          if(idx>0 && idx<size) return $"name and number"; return string.Empty; 
            //     }
            // }

            // another overload that is a setter only , and takes the idx and name and number , sets the name and idx
            // public long this[int idx, string name]    //  p[3, "Mahmoud"] = 1234;
            // {
            //     set
            //     {
            //          if(idx>0 && idx<size)
            //              names[idx] = name ;
            //              number[idx] = value ;
            //     }
            // }
        }
    }
}
