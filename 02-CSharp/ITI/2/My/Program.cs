using System.ComponentModel.Design;
using System.IO.Pipelines;

namespace My
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Every thing in .Net is a Datatype

            // Datatypes : 
            // Class 
            // Struct : in c++ , struct was there for backwar compatability , but here in C# is has some uses ! 
            // Enum : Special type of structs , that has a pre-defined values (days of week, monthes of year, ....)
            // delegates : special type of classes 
            // interface : code contract , till now we cannot define attributes inside the interface,.. will be discussed later


            // Each class OR struct here can have 4 things : 
            // 1 - Data (characteristics)
            // 2 - Behaviours (methods)
            // 3 - Properties (attribute and functions)
            // 4 - Event (discussed later , Observer design pattern , subscribe and notify when event occures , ... )


            // CLR : .Net framework , language runtime , runtime environment , after the compiler makes the IL , the CLR carries out the job of 
            //       jitting , authentication , authorization , exception handling , garbage collection , .... 
            // 
            // BCL : libraries that are provided by Microsoft , consists of some dll files that consists of many datatypes (classes , structs,
            //       Enums , Interfaces) 
            // 
            // CTS : Common type system , tells us that every datatype is one of the TWO types : Value Type and Reference Type

            // search : primitive and non-primitive datatypes 

            // Value types : Struct , Enum 
            // Reference types : Class

            // in C++ , the classes where value types , reference types were created when using pointers 

            // Note : in C# , we don't have global variables (but this can be achieved using some work arrounds and some design patterns)

            // int , float , double => all of them compile to BCL structures or classes, as int in C# is a struct called "Int32" that represents
            // the primitive datatype of int in .Net

            // int x;       // C# keyword
            // Int32 y;     // BCL struct (can be written in any managed code here) 

            // int x;       // 4 uninitialized bytes in the stack 
            // Note : the compiler in C# is very strict compaing to c++ compiler , as we cannot use the variable x if not initialized with a value
            //        Now it has garbage but this cannot be shown or seen due to restricting the usage of uninitialized variables

            // int in C# , integer in VB , all of them will be Int32 (System.Int32 , it's a structure) when compilation in the IL


            // Note : with value types , if x=y; then if y changes this will NOT affect x , and also vice versa ! (as they are in stack)

            // Stack VS Heap => Heap can streach in size , while stack is fixed size

            // with Reference types , it's a bit different 

            // object will be in the heap , referenced by variables from the stack 


            // self study : datatypes in C# , which are signed and which are not signed 

            // - structs will be more sutable with numeric datatypes and having small size , classes are better when having different datatypes 
            // - No inheritance between structs , but we can inherit between classes

            // primitive datatypes : All of them are value type , EXCEPT the string , it's a reference type .... but behaving like a value type
            //                       datatype (for ease of use) .. ans strings also are initialized WITHOUT new keyword


            // System.Object : reference class that can be found in the BCL , it's the ROOT , BASE , PARENT datatype for all managed types in
            //                 .NET , this means that all user defined or built-in datatypes , all reference or valuetype datatypes inherit from
            //                 System.Object (directly or indirectly) "in this case only the struct can inherit"
            // 

            // why struct inherits indirectly from System.Object =>
            // for two reasons : 
            // 1 - to make some behaviours supported for ALL datatypes in .NET (some methods , ex: tostring, getType, ... )
            // 2 - writing code without specifying the datatype (datatype can be changed during compile time) , this was not there in the 
            //     first release of .Net , "Generics" where there in 2005 , and before generics we wanted to achieve the same result , this 
            //     can be done through "Object class" , as it's the parent type for all datatypes and can hold anything (it's bad practice)

            // 1 - 
            // System.Object members : 
            //  - public virtual string ToString(){}            // default imp => returns the datatype name , but we must override it to get 
            //                                                     the state representation of an object 
            //                                                     by default => namespace+className
            //  - public virtual bool Equal(Object Right){}     // we will discuss "Identity equality" and "value equality"
            //  - public virtual int GetHashCode(){}            // any object in the managed heap has a unique value (getHashCode doesn't
            //                                                     return the address as the address changes, but returns the object identity
            //                                                     which is a unique identifier given to the object by the CLR .. it's used
            //                                                     in the hashtables or dictionary .. but the most use is for the object identity
            //                                                     as every different object has a different hashCode)
            //  - public Type GetType(){}                       // to know the real datatype of the object, as we may use generalizationn and 
            //                                                     binding as we know when sending an object as a parameter to a function but the
            //                                                     type of it is the base type. (this is the ONLY ONE NOT VIRTUAL so not override)


            // the compiler produces IL and ALSO metadata (data describing another data) , this metadata can be seen using "ILDissassembler" , and 
            // we can see this metadata in the runtime regardless the type of reference that we is pointing to the object ... this meta data is 
            // used in GetType() method 
            // ex: 
            // class Point{ int x, y; }
            // Point P1 ..... ;
            // Object O1 = P1;     // valid 
            // O1.GetType()        // see .name => Point 



            // References :
            // Object O1; 
            // now Zero Bytes have been allocated in the Heap 
            // Only referece is stored in the stack 

            // O1 = new Object();
            // Now we will allocated required number of bytes in the heap (number of bytes = Object Size + overhead variables)
            // ex: point has int x,y; => so the size = 4+4 = 8 bytes , + overhead variables 

            // overhead variables : 
            // - To make the CLR able for managing the lifetime of objects , we add 2 overhead variables (32 bit or 64 bit based on the
            //   architecture of the OS , in our case it's 64 bit => 8 bytes each variable) , first overhead variable holds the object identity
            //   or the unique identifier (the two varaibles are called "type pointer" and "application synchronization block"). These two 
            //   variables are two internal structures the GC adds them on each object to manage the lifetime of them in the heap.

            // - So any class (even if it's size is small) will have overhead variables that may have size larger then the object size ! 

            // so class point  => 4*2 (int x,y sizes) + overhead (2*8) => 8 + 16 = 24 bytes total object size
            // so class Object => 0 + overhead (2*8) => 0 + 16 = 16 bytes total object size


            // so now , what does the keyword "new" do ? 
            // 1 - allocate required number of bytes in the heap 
            // 2 - initialize allocated bytes with default values (cross out) , this is done before using Ctor
            // 3 - call user defined constructor if exists (constructor is called "ctor" in the IL)
            // 4 - Assign reference 

            // when making the reference (ex: Point P1;) it's actually same as pointer in C++ , as it refers to the object that is stored in the
            // heap ... the referece in the stack has a size = 8 bytes and holds the actual place of the object in the heap 

            // Point P1;   // 0 bytes allocated in the heap , 8 bytes allocated in the stack 

            // ObjectName.GetHashCode() => return the unique identifier that is stored in the overhead variables with the object in the heap 

            // Now what happens when we have 2 object and we make p1 = p2; 
            // now p1 is unreachable object in the heap , and p2 now has 2 references in the stack , p1 and p2 , this appears when we 
            // use .GetHashCode with the 2 references , we will see that the two are equal. 
            // Note : the unreachable object which is in the heap will be deleted by the GC (garbage collector) , you don't have to take care
            //        of memory in the heap as we did with C++ 

            // The GC shifts all the living-objects beside each others , this is done after deleting the dead unreachable objects , this may 
            // change the addresses of the as shifting the place will change the memory address of the object , but the .GetHashCode still 
            // returns the first value (so this makes us sure that .GetHashCode doesn't relate to the address of the object in the heap) , and here
            // also when the GC works , the program must stop to make these operations , and one of the most important operations is called 
            // "reference correction" , as the references are changed because the address changes 

            // Note : we must minimize the times the GC runs , becuase it stops the application (for some ms) , but still we must minimise by
            //        taking care of object creation and avoid making many unnesissary objects (ex: using stringBuilder instead of string in
            //        some cases that will be discussed later .. )

            // Note : We can enforce the GC to run , but it's not a good approach , it's better to keep it as it is ! 

            // Note : structs are stored in the stack , so there is no "overhead variables". 


            // -------------------------------

            // part 2 : 

            // when checking "Do not use top-level statements" , now VS will not generate the namespace, class, and things found in the first
            // class that is there by default , but then the compiler will generate them later .. 

            // Now when making the first C# console application , we will have the default program class show (generated by VS), which has 
            // the main function , and it's inside a namespace with the same name of the project ... (we can change all of these things .. )

            // Class view => another view for the classes in the project .. shown from tab "view" => class view 
            // here we can find that class "program" inherits from class object "BY DEFAULT" , as we discussed before

            // Object Browser => for more info about this type or class , use the object browser , shown from tab "view" => object browser
            // here we can see the function signatures and some metadata about the type 

            // Note : to start running the application we have a shortcut => ctrl+F5 => run without debug , F5 => run with debug
            //        when using debugger and any problem or exception happens in the code , the dubugger is attached , but without the
            //        debugger , the exception will be thrown and shown on the console black screen. (excpetions will be handled later .. ) 


            // To make a region and make the code "appears" modular 
            // shortcut => ctrl+k , ctrl+s => region and put the code inside it. 


            // int x;
            // Console.WriteLine(x);    // error , will not compile becuse we use a not assigned variable (uninitialized variable)


            // int x=5;
            // int y = x;
            // x++; 
            // We will notice that after y=x , each of them are different variables , changing in one of them will not affect the other 

            // int is a struct , (BCL => Int32) , it inherits from System.Object but "Indirectly" , value type datatypes (structures and enums)
            // inherit from System.ValueType first , that inherits from System.Object , why this intermidiate System.ValueType ? to change 
            // some behaviours for the structs (different function implementation)


            // reference types : 
            // Note : we have class called "Object" , and other class called "object" , what is the difference ? 
            // Object : BCL Keyword , that is used by the compiler in the IL code 
            // object : C# keyword , it's finally converted to Object in the IL also ! 
            // Note : all C# keywords start with small letter case 

            // object O1;
            // 8 bytes in the stack for the reference 
            // 0 bytes in the heap , not yer allocated ! 
            // Console.WriteLine(O1.GetHashCode());    // compilation Error , use of unassigned local variable 

            // O1 = new object();
            // 1 - allocate required number in the heap (object size + overhead variables)
            // 2 - Initialize allocated object 
            // 3 - call ctor if exists 
            // 4 - Assign reference to the newly created object in the heap 
            // Console.WriteLine(O1.GetHashCode());    // now valid ! 

            // When creating an object we can create it with "syntax sugar" : 
            // 1 - object x = new object();       // default way
            // 2 - object x = new ();             // syntax sugar


            // Syntax sugar => means that if we see the IL code , we will notice that both will have the same IL code , so the compiler 
            //                 makes them the same when compilation .. it's an easier way of writing ! 


            // object O2 = new();

            // O2 = O1;        // reference equality , now O2 is unreachable object in the heap and will be deleted by the GC 
            // Console.WriteLine(O1.GetHashCode());  // same unique identifier 
            // Console.WriteLine(O2.GetHashCode());  // same unique identifier 



            // now to read data from the user : 
            // int x = Console.ReadLine();    // error cannot implicitly convert string to int , as the readline always gets string 
            // self study : Console.Read() and Console.ReadKey()   

            // so we use "Parse" method that is in struct "int" that converts any thing to int value (if possable)
            // int x = int.Parse(Console.ReadLine());
            // but Parse method has a problem that if the user entered a value that cannot converted to an int , we will have an exception 
            // or runtime error (will be solved using TryParse later ... )
            // Note : we also have double.Parse() , char.Parse() , float.Parse() , ... 

            // we will notice that we have a warning in the previous readline method , that's because we could have a null reference exception
            // starting from C# 8 the nullable reference types and non-nullable reference types were introduced ... we can stop this for
            // now till discussing it by => right click on the project => properties => nullable => disable , 
            // OR
            // double click on the project => nullable tag => disable it by writing "disable"


            // what if we want to convert any thing to any thing ? 
            // use convert class that has many functions and many overloads : 
            // int a = Convert.ToInt32(Console.ReadLine());


            // Before C# 6.0 : printing the string : using string.Format()
            // int x = 9, y = 100, z = x + y;
            // string s = string.Format("Equation = {0} + {1} = {2}", x, y, z);   // it's the same as printf and scanf in C
            // Console.WriteLine(s);

            // this can be directly written in the console.writeline and it will be known 
            // Console.WriteLine("Equation = {0} + {1} = {2}", x, y, z);


            // After C# 6.0 : string manipulation operator 
            // string s = $"Equation = {x} + {y} = {z}";
            // Console.WriteLine(s);

            // or directly : 
            // Console.WriteLine($"Equation = {x} + {y} = {z}");

            // we can use string.Format or string manipulation to print with a format , ex: as a currency then add :C , as hedadecima add :X
            // ex: 
            // Console.WriteLine($"Equation = {x:C} + {y:C} = {z:X}");


            // now starting with branching and looping : 


            // Note : bool is used in C# from day zero , so it's not like C++ (non-zero value is fase) , no , bool must be 0 or 1 only
            // int b = 5;
            // if (x) { .. }         // wrong , nothing called if(x)
            // if(1)                 // wrong , not valid 
            // if(b=5)               // wrong , also not valid
            // so we must write a condition or a statement that evaluated to true or false

            // bool flag = true;
            // if(flag) {...)        // valid , because it is evaluated to true or false inside the condition , means if (flag == true) 

            // remember if , else if , else , 
            // with "if conditions" , we don't have differences between C++ and C# , but with "switch cases" we have some differences (later .. )


            // with string we don't use "new" keyword in most cases , because most string constructors takes parameter of char pointer (char *)
            // but there is a constructor that takes a char and count (repeat the char for a known count)
            // string str = new string("Hello");     // same as string s = "Hello";
            // string str1 = new string('a', 10);    // repeats 'a' for 10 times => "aaaaaaaaaa"

            // Console.WriteLine(str + " " + str1);

            // But with other classes we use "new" and specify the ctor we want


            // scopes in C# : 

            // we have a block scope , that can be after a loop or if conditon for example , or can be like this wihtout any statmenet befote it
            // ex: 

            // {
            //     int abc=10;
            //     Console.WriteLine(abc);
            // }    // block scope 

            // for(int i=0; i<1; i++)
            // {
            //     Console.WriteLine(i);
            // }    // block scope 



            // Note : if the scopes are siblings , then we can declare variables with the same name in each of them 
            // {
            //     int abc = 100;
            //     Console.WriteLine(abc);
            // }
            // 
            // {
            //     int abc = 100;
            //     Console.WriteLine(abc);
            // }

            // but if scopes are a parent and child (as we are here in a function and we have a variable called x) , it's not allowed to have a 
            // variable with the same name ! 

            // int testCases = 10;
            // {
            //     // int testCases = 1000;         // Error , because we have a variable with the same name in a larger scope ! 
            // }

            // So we have (from smaller scope to largest) : 
            // Block Scope 
            // Next is the local variable (local variable in a function)
            // Next is the member variable in class or struct (object variable or static variable)


            // the interface can contain only : 
            // - Class 
            // - Enum 
            // - Struct 
            // - interface




            // Arrays : 
            // Array is an object , it's a reference type and allocated in the heap 

            // int[] arr;      // Declare array reference 
            // Zero bytes in the heap , 8 bytes allocated in the stack 

            // arr = new int[5];
            // Here allocate an object in the heap , of size = 5 (4*5 = 20 bytes) + the overhead.
            // initialized with the default values for the int type (0)

            // for(int i=0; i<arr.Length; i++)
            //     Console.WriteLine(arr[i]);

            // to declare and then initialize : 
            // arr = new int[5] { 1, 2, 3, 4, 5 };       // Must give values for the same size of array (ex: 5 initialized elements)


            // syntax sugar : 
            // int[] array = { 1, 2, 3, 4, 5 };         // but in the compiled code (seen by ILSpy) , it's ==> int[] array = new int[5] {1,2,3,4,5};

            // some extension methods (LINQ mehthods , will be discussed later .. )
            // array.Union()
            // array.Select()
            // .....
            // ..... 


            // why these methods are here ? 
            // because in the global usings we use "System.Linq" , and if we want to stop it we can disable implicit usings and then 
            // use only "what we want" , ex: (using System;) and now we will not find linq methods

            // Array properties (properties will be discussed later .. )
            // Length 
            // LongLength     : if the length is more than the int value 
            // Rank           : dimentions of the array (ex: 1 or 2 or ... )
            // ... 


            // Array function : 
            // GetValue(indx)
            // SetValue()     : have some overloads ..
            // .....
            // .....


            // Exceeding the upperbound of the array , WILL NOT BE RECOGNIZED BY THE COMPILER , THROWS RUNTIME ERROR
            // Exception : System.IndexOutOfRangeException


            // int[] Arr1 = { 1, 2, 3, 4, 5 };
            // int[] Arr2 = { 100,200 };
            // Console.WriteLine(Arr1.GetHashCode());    // different hashcodes ... 
            // Console.WriteLine(Arr2.GetHashCode());    // different hashcodes ... 

            // Referencd equality , shallow copy : 
            // Arr1 = Arr2;                   // now they are same object , same identity , same state , one object in the heap has 2 references 

            // Console.WriteLine(Arr1.GetHashCode());    // same hashcodes ... 
            // Console.WriteLine(Arr2.GetHashCode());    // same hashcodes ... 


            // What if i want : Arr1 = Arr2  ==> new object with new identity and same state as Arr2
            // Deep Copy : use .Clone function : 

            // Arr1 = (int[]) Arr2.Clone();    // we MUST EXPLICITLY CAST , as .Clone returns System.Object
            // now the references are different , we created a new array having same state of array2 and array1 references it (the new created array)


            // accessing array elements : 
            // - Zero bazed 

            // int[] ar = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // Console.WriteLine(ar[0]);             // first 
            // Console.WriteLine(ar[ar.Length-1]);   // last
            // Console.WriteLine(ar[ar.Length]);     // Runtime exception , Error
            // NEW !! 
            // Console.WriteLine(ar[^0]);            // same as ar[ar.Length] , Runtime exception , Error
            // Console.WriteLine(ar[^1]);            // ar[ar.Length-1] , last element
            // Console.WriteLine(ar[^ar.Length]);    // ar[0] , first element 

            // int n = 5;
            // Console.WriteLine(ar[^n]);            // can be a variable ! 

            // this is applicable because of the Index class : 

            // Index idx = ^1;
            // Console.WriteLine(ar[idx]);

            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // what about slicing the array ? 
            int[] MyArr = new int[20];
            // Array.Copy(arr, MyArr, 5);     // has many overloads 

            // a better way : 
            
            MyArr = arr[0..3];       // start included (index 0 here included , end is Execluded index 3 here is not included ! )
            MyArr = arr[..5];        // start from index 0 to index 5 
            MyArr = arr[3..];        // start from index 3 to the end (last is included)
            MyArr = arr[..5];        // start from index 0 to index 5 (last is not included)
            MyArr = arr[3..^3];      // start from index 3 to index length-3 (and last is not included also)
            MyArr = arr[^6..^3];        // start from length-6 to index length-3 (and last is not included also)
            // MyArr = arr[^3..^6];        // Error !!!! 

            Console.WriteLine(arr.GetHashCode());      // different hashcodes ... 
            Console.WriteLine(MyArr.GetHashCode());    // different hashcodes ... 


            // this is applicable because of the Range class :
            Range rng = ..3;
            MyArr = arr[rng];        // start from index 0 to index 3


            // What about Two Dim arrays ? 
            // 1 - Normal 2d array : 
            int[,] TwoDimArray = new int[3, 2] { {1,2},{3,4},{5,6} };
            Console.WriteLine(TwoDimArray.Length);       // total length , 3*2 = 6
            Console.WriteLine(TwoDimArray.Rank);         // Here numebr of ranks = 2 (two dim array ) 
            Console.WriteLine(TwoDimArray.GetLength(0)); // length of the first dimention 
            Console.WriteLine(TwoDimArray.GetLength(1)); // length of the second dimention 

            Console.WriteLine("----------------------------------------------------------------");
            for(int i=0; i<TwoDimArray.GetLength(0); i++)
            {
                for(int j=0; j<TwoDimArray.GetLength(1); j++)
                {
                    Console.Write(TwoDimArray[i,j] + " ");
                }
                Console.WriteLine();
            }


            // 2 - Jagged Array : 
            // different number of columns for different rows 

            int[][] JaggedArray = new int[3][];

            // Ex: we have 3 students , each student can enrol different number of courses ! 
            JaggedArray[0] = new int[3];
            JaggedArray[1] = new int[6];
            JaggedArray[2] = new int[5];


        }
    }
}
