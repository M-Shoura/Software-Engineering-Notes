namespace Session_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Programming Paradigms

            /* Start *****************************************************************************************************************/

            // Programming Paradigms : 
            // 1 - Imperative  => Focuses on describing HOW a program operates step by step. Uses sequences of statements, loops, and
            //                    conditions. Easy to understand for simple tasks and closely resembles machine instructions. But Can 
            //                    become complex and hard to maintain for large applications. (Ex: C, python when using procedural style)

            // 2 - Declarative => Focuses on describing WHAT should be done rather than how. Avoids explicit control flow, often uses
            //                    constraints and rules. Leads to clear and maintainable code. But Can be less flexible for complex tasks.
            //                    (Ex: SQL, HTML, CSS, Prolog)



            // 1 - Imperative : 
            //   1.1 - Procedural      => A structured form of imperative programming where tasks are divided into procedures (functions). 
            //                            Uses functions, local/ global variables, and structured flow control. Improves code reuse and 
            //                            modularity.But Still prone to complexity in large projects. (Ex: C, Pascal)
            //
            //   1.2 - Object-Oriented => Organizes code around objects, which are instances of classes. It extends imperative programming by
            //                            introducing objects and classes. Has 4 Pillars: Encapsulation, inheritance, polymorphism, and
            //                            abstraction. Enhances reusability, scalability, and maintainability. But Can be complex and
            //                            introduce performance overhead. (Ex: Java, C++ , SmallTalk (First language))



            // 2 - Declarative : 
            //   2.1 - Functional => A type of declarative programming where functions are treated as first-class citizens, and
            //                       immutability is emphasized. Focuses on pure functions and avoids changing states or mutable data.
            //                       Uses immutability, recursion, higher-order functions. Encourages concise, bug-free code and makes
            //                       debugging easier. But Can be difficult to learn and optimize for performance. (Ex: Haskell, Lisp, Scala)
            //                       - How to know that this language can be used with functional paradigm ?
            //                           - store a function in a variable
            //                           - A function that returns a function
            //                           - A function that takes other function as a parameter
            //                       

            // First Class Functions : Functions are treated like values: passed as arguments , returned from other functions , stored in variables
            // Pure Functions : A function is pure if Same input => Same output , ex: int Add(int a, int b) => a + b; NOT int counter = 0; int Increment() => ++counter;
            // Immutability : Data cannot be changed after creation , if we want to change it then instead, new data is created
            // Higher-Order Functions: Functions that take functions as input or return functions

            //
            //   2.2 - Logic      => Declares facts and rules that the system uses to infer conclusions. Computation is expressed through
            //                       logical rules and inference rather than step-by-step instructions.Uses logic inference, pattern
            //                       matching, and backtracking. Suitable for AI and expert systems. But Not ideal for general - purpose
            //                       applications. (Ex: Prolog, Datalog)


            // Other Programming Paradigms : 
            // Event-Driven Programming => Executes code in response to events (Ex: user actions, messages). Uses event handlers, listeners,
            //                             and callbacks. Well-suited for user interfaces and asynchronous applications. But Can lead to
            //                             callback hell and difficult debugging. (Ex: JavaScript (for web dev), GUI frameworks)
            // 
            // Concurrent & Parallel Programming => Focuses on executing multiple tasks simultaneously. Threads, processes, synchronization
            //                                      mechanisms. Improves performance on multi-core systems. But Requires careful handling of
            //                                      race conditions and synchronization. (Ex: Java(with threads), Go(goroutines))


            // C# is a multi-paradigm programming language, meaning it supports multiple programming paradigms.
            // 1 - Object-Oriented Programming (OOP) [Primary Paradigm]
            // 2 - Procedural Programming : where code is structured into functions and executes step by step.
            // 3 - Functional Programming (Since C# 3.0) : 
            //                  - Lambda expressions (=>)
            //                  - Higher order functions (functions as arguments OR return a function) (delegates Func<>, and Action<>)
            //                  - LINQ (Language Integrated Query)
            //                  - Immutability with readonly and record types(C# 9)
            //                  - BUT WE CANNOT have all the features of functional programming like standalone function or global variable
            // 4 - Declarative Programming : with LINQ & Metadata Attributes , Metadata Attributes => [Obsolete] that is used to mark a
            //                               method, class, property, or field as deprecated, meaning it should no longer be used because
            //                               a better alternative exists , if used the compiler shows a warning (or an error if specified)
            //                               [Obsolete("MSG")] => Warning    ,    [Obsolete("MSG" , true)] => Error
            // 5 - Event-Driven Programming : via Delegates & Events.
            // 6 - Concurrent & Parallel Programming : supports multithreading and asynchronous programming. (Async / Await)


            // Notes : 
            // In java , use "Observer design pattern" to use the Event driven programming paradigm 
            // In java , use "Stratigy design pattern" to use the Functional programming paradigm 

            /* End ******************************************************************************************************************/

            #endregion    


            #region Before 2002 and before Dot Net

            /* Start *****************************************************************************************************************/

            // For Low-Level Development (System Programming & Performance-Critical Apps) : 
            // 1 - Win32 API : Used C and C++ to directly call Windows system functions . Can direct access to hardware and memory
            // 2 - Visual C++  

            // For GUI Application Development (Rapid Windows App Development) : 
            // 1 - Visual Basic 6 : For creating Windows applications with drag-and-drop UI design.
            // 2 - Delphi : Similar to VB6, but more powerful and faster.

            // For Web Development (Early Web Technologies) : 
            // 1 - Classic ASP (Active Server Pages) : Before ASP.NET, web development on Windows was mainly done using Classic ASP , 
            //                                         Microsoft's first server-side scripting language for dynamic web pages.
            //                                         Used VBScript or JScript(Microsoft’s version of JavaScript).


            // Problems before .net framework 2002 : 
            // 1 - Most Windows applications were NOT cross platform (apps didn't work on macOS & Linux).
            // 2 - Different programming languages had separate runtimes, making cross-language difficult (write Delphi in Visual Basic file)


            // Example on C++ , C++ Compilation Process: 
            // cpp file (helloworld.cpp) ==> compile (Compiler: GCC, Clang , ..) ==> native machine code (helloworld.exe or helloworld.out)


            // Before.NET Framework(2002), Windows development was fragmented and had many issues, such as:
            // - Platform Dependency – Windows apps couldn’t run on other OS unless we compile the code again for that platform.
            // - Language Interoperability Issues – C++, VB6, and Delphi couldn’t easily work together.
            // - Manual Memory Management – Developers had to manually allocate and free memory (does not have built-in garbage collection)
            // - DLL Hell – Different versions of DLLs caused compatibility issues.
            // - Limited Security & Web Capabilities – Classic ASP had vulnerabilities.

            /* End ******************************************************************************************************************/

            #endregion


            #region With Dot Net framework 2002

            /* Start *****************************************************************************************************************/

            // The Birth of.NET Framework(2002)

            // 1 - Common Language Runtime(CLR) runtime environment
            // It allowed multiple languages(C#, VB.NET, F#) to run on the same platform. Cross-Language Interoperability – C# and VB.NET
            // could use the same compiled libraries. C# and VB.NET can share the same compiled DLL because of CLR.


            // 2 - Intermediate Language(IL) & Just-In-Time(JIT) Compilation
            // Instead of compiling to machine code, .NET languages compiled to an intermediate language(IL).
            // At runtime, the JIT compiler converted IL into machine code for the target OS.
            // This solved platform dependency to some extent, but .NET was still Windows-only in 2002


            // 3 - Managed Code & Automatic Memory Management
            // Memory allocation was handled by the Garbage Collector (GC) and No more memory leaks or using pointers like in C++



            // 4 - Unified Framework Libraries (FCL – Framework Class Library)
            // A standardized library for all applications, called the Framework Class Library(FCL).
            // Developers no longer needed third - party libraries for basic operations.
            // Contains the entire collection of .NET libraries, including BCL, Windows Forms, ASP.NET, ADO.NET, WPF, etc.
            // The same APIs could be used across desktop, web, and enterprise applications.
            // Example (Using .NET FCL for File Handling) (File.WriteAllText())
            // Note : BCL (Base Class Library)	A core subset of FCL that provides fundamental functionalities like Collections, File I/O,
            //        Threads, and Data Types. ex: System namespace , collections classes 
            // BCL is always included in every .NET application, but FCL depends on what type of app you’re building.
            //
            // Summary:
            // FCL (Framework Class Library) = Full .NET Library(Includes UI, Web, Database, and BCL).
            // BCL (Base Class Library) = The Core of .NET(Provides fundamental types, collections, and I/O).
            // So, BCL is a part of FCL, but FCL is much bigger! 


            // 5 - ASP.NET – The Future of Web Development , faster, more secure, and scalable.
            // Classic ASP (before.NET) was mixing HTML with server - side code which was hard to maintain
            // ASP.NET(2002) introduced:
            // - Code-behind model–Separated logic from UI (better maintainability).
            // - Compiled execution – ASP.NET pages were compiled, making them faster than Classic ASP.
            // - Improved security – Features like authentication and authorization were built-in.


            // 6 - ADO.NET – Database Connectivity Made Easier
            // Before.NET: Developers used ADO (ActiveX Data Objects), which was slow and hard to maintain.
            // With.NET(ADO.NET):
            // - Improved performance and scalability.
            // - Support for disconnected databases (DataSets).
            // - Easy integration with SQL Server, Oracle, and more.



            // In conclusion : 
            //       Problem Before .NET                            Solution in .NET
            // Platform - dependent native code              Intermediate Language(IL) + JIT Compilation
            // Manual memory management                      Garbage Collector(GC)
            // DLL Hell	                                     .NET Assemblies + GAC(Global Assembly Cache)
            // Hard cross-language integration               Common Language Runtime(CLR)
            // Messy, slow web development                   ASP.NET – Faster, scalable web apps
            // Poor database handling                        ADO.NET – Optimized database access


            // But .NET 2002 Had Some Limitations
            // 1️ - Still Windows-Only – .NET 1.0 was not cross-platform (Mono project existed but wasn’t official).
            // 2️ - No Open Source – .NET Framework was proprietary, limiting community contributions.


            // Why Was .NET 2002 Still Windows-Only ?
            // When Microsoft launched .NET Framework 1.0 in 2002, it was designed only for Windows. Here’s why:
            // 
            // 1️ - Microsoft’s Business Strategy (Windows - Centric Focus)
            //     Microsoft wanted to strengthen Windows dominance. At the time, Windows was the most widely used OS for businesses.
            //     Microsoft made money from Windows licenses, so they focused.NET on keeping developers locked into Windows.
            //     There was no business incentive to support Linux / macOS.
            // 
            // Example: Java vs.NET Business Strategy
            // Java (by Sun Microsystems): "Write Once, Run Anywhere" (Cross - platform via JVM).
            // ASP.NET Framework: "Write for Windows, Run Best on Windows".
            // Microsoft positioned .NET as the best way to build Windows applications (Windows Forms, ASP.NET, and ADO.NET were Windows-only).
            // 
            // 2️ - .NET Framework Was Built on Windows Technologies
            // .NET Framework relied heavily on Windows-specific components like:
            //   - Win32 API – Core Windows functions.
            //   - COM (Component Object Model) – Used for interoperability.
            //   - Registry & Windows Security Features – Deeply integrated into the Windows OS.
            //   - IIS (Internet Information Services) – Required for ASP.NET web applications.
            // 
            // This deep Windows integration made .NET fast and efficient on Windows but completely tied it to Windows.
            // 
            // 3️ - No Open Source – No Community Porting Efforts
            //   - .NET Framework was closed-source in 2002, meaning only Microsoft controlled it. This meant the open - source community
            //      couldn’t modify or port it to Linux / macOS.
            // 
            // 4️ - Windows - Only GUI Frameworks (WinForms & WPF)
            //   -  Windows Forms (WinForms) and Windows Presentation Foundation (WPF) were designed only for Windows. They used
            //      GDI +, DirectX, and Windows - native controls, making them impossible to run on Linux / macOS.
            


            // In 2004 , the Mono Project Tried to Make.NET Cross-Platform (unofficial and incomplete)
            // Mono (an open - source project) reverse-engineered .NET to run on Linux/macOS.
            // Mono’s limitations in early years:
            // - Couldn’t fully implement WinForms(since it depended on Windows APIs).
            // - ASP.NET apps worked, but only with limited features.
            // - Performance was slower than Microsoft’s .NET.


            // Note : in the folder , the IL_Spy is provided to see the IL or intermidiate code

            /* End ******************************************************************************************************************/

            #endregion


            #region Base Class Library (BCL)

            /* Start *****************************************************************************************************************/

            // The Base Class Library(BCL) is the core of.NET and provides the fundamental functionality needed for any .NET application.
            // It includes essential classes for data types, collections, file handling, networking, and threading.
            // 
            //  1.System Core (Fundamental Types & Operations)
            //     - Namespace: System
            //     - Purpose: Provides basic types, mathematical operations, exceptions, and object handling.
            //     - Common Classes:
            //         Object                           The base class of all types in .NET
            //         String                           Represents immutable text
            //         Int32, Double, Boolean           Numeric and logical data types
            //         Math                             Provides mathematical functions like Math.Sqrt(), Math.Pow().
            //         Exception                        Base class for errors and exceptions.
            //
            //
            // 2. Collections (Data Structures)
            //     - Namespace: System.Collections, System.Collections.Generic
            //     - Purpose: Provides data structures like lists, dictionaries, queues, and stacks.
            //     - Common Classes:
            //          List / List<T>                             A resizable list (like an array but dynamic).
            //          Dictionary / Dictionary<TKey, TValue>      A key-value store for fast lookups.
            //          Queue / Queue<T>                           A FIFO (First-In-First-Out) data structure.
            //          Stack / Stack<T>                           A LIFO (Last-In-First-Out) data structure.
            //
            //
            // 3. File & IO Operations
            //     - Namespace: System.IO
            //     - Purpose: Handles file and stream operations (reading/writing files, working with directories).
            //     - Common Classes:
            //          File                            Static helper class for file operations(File.ReadAllText()).
            //          StreamReader, StreamWriter      Read/write files as text.
            //          Directory                       Create, delete, and move directories.
            //          Path                            Helps manipulate file paths.
            //
            //
            // 4. Networking & Web Requests
            //     - Namespace: System.Net
            //     - Purpose: Enables communication with web servers and networking.
            //     - Common Classes:
            //          HttpClient                      Sends HTTP requests and receives responses.
            //          WebRequest                      Makes web requests(deprecated in .NET 6+).
            //          WebClient                       A simple way to download/upload files over HTTP.
            //
            //
            // 5. Multithreading & Parallel Programming
            //     - Namespace: System.Threading, System.Threading.Tasks
            //     - Purpose: Provides support for parallelism, async programming, and multithreading.
            //     - Common Classes:
            //          Thread                          Represents an OS-level thread.
            //          Task                            Represents an asynchronous operation.
            //          Parallel                        Provides parallel execution methods.
            // 
            //
            // 6. Reflection (Runtime Type Information)
            //     - Namespace: System.Reflection
            //     - Purpose: Allows examination of assemblies, types, and methods at runtime.
            //     - Common Classes:
            //           Type                           Represents type metadata.
            //           Assembly                       Represents a .NET assembly.
            //           MethodInfo                     Provides details about a method in a class.
            //

            /* End ******************************************************************************************************************/

            #endregion


            #region Common Language Runtime (CLR)

            /* Start *****************************************************************************************************************/

            // CLR stands for Common Language Runtime, and it's a core component of the .NET framework.
            // it's important because : 
            // 1 - Language Interoperability : CLR allows you to write code in multiple .NET languages (like C#, VB.NET, F#) and run it all
            //                                 together in the same application. ex: you could write a math library in VB.NET and use it in
            //                                 a C# web application that's because all .NET languages compile to the same Intermediate
            //                                 Language (IL), which the CLR understands.
            // 
            // 2 - Memory Management & Garbage Collection : CLR automatically handles memory: when objects are created, and when they are
            //                                              no longer used, it removes them from memory. This is done by the Garbage Collector
            //                                              that runs in the background. This prevents memory leaks and makes development
            //                                              easier because we don’t have to manually allocate/deallocate memory like in C++.
            // 
            // 3 -  Code Execution & JIT Compilation : Our code is first compiled into Intermediate Language (IL) (like a middle-ground
            //                                         between human code and machine code). Then at runtime, CLR uses a Just-In-Time (JIT)
            //                                         compiler to convert IL into machine code specific to your system. This makes the
            //                                         performance optimized for your specific hardware and we also can run the application
            //                                         on different systems.
            //                                         Note : When we double click on a .exe of a C# project, the IL is loaded , then the CLR
            //                                                and JIT Compiler converts it to the machine code , then the system execute it.
            //
            // 4 - Exception Handling : CLR provides a unified way to catch and handle errors (ex: file not found, divide by zero, .. ) using
            //                          System.Exception class, exception types, Stack traces, Inner exceptions, rethrow exceptions (throw).
            //                          The CLR monitoring Code execution , and if there is any problem happened then it stops the current
            //                          flow and creates an object representing the error , and then goes back to the call stack looking for
            //                          the catch block that can handle the exception. Ex: if we tried to access a wrong index of an array
            //                          then the CLR will => Notice the out-of-range error - Generate an IndexOutOfRangeException - jump to
            //                          the matching catch block - Run the finally block no matter what.
            //
            // 5 - Security : CLR includes a security model that : 
            //                 - Verifies that code is safe to execute (type-safe)
            //                 - Prevents code from accessing memory it shouldn’t.
            //
            // 6 - Assemblies and Metadata : All .NET code is packaged into assemblies (.DLLs or .EXEs), which contain :
            //                               IL Code , Metadata (info about types, methods, ..) and Resources (images, strings, .. )


            // Note : in the folder , the IL_Spy is provided to see the IL or intermidiate code

            /* End ******************************************************************************************************************/

            #endregion


            #region Dynamic Link Library (DLL)

            /* Start *****************************************************************************************************************/

            // DLL stands for Dynamic Link Library, It's a file that contains code, data, and resources that can be used (or "linked")
            // by other programs — without needing to rewrite or duplicate that code, file extension is (.dll)

            // Ex: 
            // Suppose you create a library (class) in C# called HelperMathFunctions containing Square function, then you compile it into a
            // DLL: HelperMathFunctions.dll, then in another project, you reference it like this :
            // int result = HelperMathFunctions.Square(5);          // 25

            /* End ******************************************************************************************************************/

            #endregion


            #region Compilation Steps

            /* Start *****************************************************************************************************************/

            // Compilation Steps in C#
            // When you compile and run a C# program, it goes through these 4 main steps:
            // 
            // 1 - Source Code (.cs) => C# Compiler (Rosyln) (csc.exe)
            // The (.cs) files (C# source code) are compiled by the C# compiler and provides a (.exe) file , this is the IL code , also called 
            // Microsoft IL (MSIL) or Common IL (CIL). So the output of this stage is an assembly file (like .exe or .dll)
            // 
            // 
            // 2 - Metadata Generation : The compiler generates metadata that describes:
            //                                  - Types (classes, structs)
            //                                  - Members (methods, properties)
            //                                  - References to other assemblies
            //     
            //     This helps tools like Visual Studio offer IntelliSense and also helps the CLR understand your code structure.
            //     Metadata is stored with the IL in the same file.
            // 
            //
            // 3 - IL + Metadata => CLR Execution (JIT Compilation) : When you run the application, the Common Language Runtime (CLR) takes
            //                                                        over. It uses the Just-In-Time (JIT) compiler to convert IL into native
            //                                                        machine code. Native code is optimized for performance for current OS
            //                                                        and hardware.
            // 
            // 4 - Execution of Native Code : After JIT compilation, the CPU executes the native code.
            //      The CLR manages:
            //          - Memory (with garbage collection)
            //          - Security
            //          - Threading
            //          - Exception handling
            // 
            //      Then Your app is now live and running!

            // to decrease the overhead of the JIT (just in time) Compiler :
            //               1 - 64 bit so it's very fast
            //               2 - Jitting happen per function call (only called function will be jitted)
            //               3 - Jitting for first call only as long as the program is not terminated
            // Important notes : 
            //  - Compilation time ==> C# code to IL
            //  - Runtime ==> IL to native code



            // The problem with .net framework that was not cross-platform : we cannot convert from IL code to a mac/linux code
            // (machine code for other platforms) , we could do this only with Windows OS. That's because we had only the Windows SDK 
            // which means Software Development Kit , contains : .NET CLI (Command Line Interface) for creating, building, and running
            // applications ,  The C# compiler (csc) to compile C# code into assemblies or executables , and Core libraries and frameworks,
            // such as ASP.NET, Entity Framework, and others, to build web, desktop, or mobile applications. So : 
            // If use windows , the IL will be converted to native code of windows by JIT Compiler at the runtime 
            // If we use macos or linux , we don't have a JIT compiler that converts the IL to Linux or macos native code

            // Also another problem with Dot Net framework, we must deploy the application on a server that works with windows, which is
            // expensive in comparison with linux servers

            // Note : in the folder , the IL_Spy is provided to see the IL or intermidiate code

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Dot Net Core 

            /* Start *****************************************************************************************************************/

            // How Did .NET Become Cross-Platform ?
            // 2014                Microsoft publicly announced its commitment to open-source .NET and to make .NET Core cross-platform
            // 2016               .NET Core 1.0 officiall release , supported Linux/macOS also.
            // 2020               .NET 5 unified .NET Core and.NET Framework into one platform.

            // So in 2016 the first version of the Dot Net Core was introduced to solve the problem of cross platform applications
            // (dot net core 1.0)

            // Benefits : 
            // 1 - Cross Platform  : now we have the sdk of linux and macos
            // 2 - Open Source     : Now we can see any code we want !
            //	                     Note : To browse the source code ==> source.dot.net ==> search with the full path 
            // 3 - Component Based : Download only the components you want , from Nuget.org package manager 

            /* End ******************************************************************************************************************/

            #endregion


            #region C# & .Net framework & .Net Core Versions 

            /* Start *****************************************************************************************************************/

            // Dot Net Framework Versions : 
            //          - .net framework 1.0      2002   C# 1.0
            //          .
            //          . 
            //          .
            //          - .net framework 4.8      2019   C# 7.3

            // Dot Net Core Versions : 
            //          - .net core 1.0        2016   C# 6.0
            //          .
            //          .
            //          - .net core 3.0        2019   C# 8.0        same year and C# version
            //          - .net core 3.1        2019   C# 8.0        same year and C# version
            //          - .net 5.0             2020   C# 9.0        (next release of dot net core)
            //          - .net 6.0             2021   C# 10.0
            //          - .net 7.0             2022   C# 11.0
            //          - .net 8.0             2023   C# 12.0
            //          - .net 9.0             2024   C# 13.0


            // difference between Dot Net versions : New technology is introduced / optimizing the architecture .
            // difference between C# versions: ex => in C# 9.0 we had only datetime datatype, but in C# 10.0 Date & Time datatypes were there
            //                                 ex => syntax sugar (easier syntax) in C# 9.0 , with top level statements  

            // Any ODD version of Dot Net ==> STS Standard term support (18 months or 1.5 years)
            // Any EVEN version of Dot Net ==> LTS Long term support (36 months or 3 years) 

            /* End ******************************************************************************************************************/

            #endregion


            #region Project & Solution

            /* Start *****************************************************************************************************************/

            // We will work with console project in the first parts of the course until reaching MVC part then we will work with web project
            // Solution can have many projects, a project must be contained in a solution
            // Ex : IKIA solution has 3 projects ==> 
            //                   1 - Desktop Project
            //                   2 - Web Project
            //                   3 - Class Library (Has the common classes between the projects)

            // Important Note : We can run a concole application , but we cannot run a Class library (discussed later)

            /* End ******************************************************************************************************************/

            #endregion


            #region NameSpaces

            /* Start *****************************************************************************************************************/

            // Namespace : Logical container [can contain only (class , struct , interface , enum , other namespaces)], namespaces can be 
            // Physical or Vitrual. Any project has a namespace, here the namespace is the project name and it's called the Root namespace 
            // or Entry namespace. using namespaces help us to know if the (class , struct , interface , enum , other namespaces) is
            // contained in the project or no , directly in the root namespace or in a sub namespace that is contained in a root namespace.
            // Also helps us when having multiple (classes , structs , interfaces , enums) with the same name , each one can be contained
            // in a different namespace
            // Note : A namespace can contain only : Class , Struct , Interface , Enum , Other namespaces
            //
            // Summary : 
            // - avoid naming conflicts
            // - Organizing Code in logically
            // - Code Readability


            // Note : A namespace is declared using the namespace keyword, followed by the namespace name (cannot contain spaces , but _ )
            // Note : namespace is optional, but used for organizing code and avoiding name collisions.

            // To use a class or member of a namespace, you can either :  
            // 1 - Use the fully qualified name (including the namespace) => var myObject = new MyNamespace.MyClass();
            // 2 - Use the using directive to import the namespace into your code so you can use the classes without the fully qualified name
            //        using MyNamespace;
            //        var myObject = new MyClass();


            // Ex : Physical Namespace ==> a physical path in the system 
            // if the project name is system then the namespace is system, if it contains a folder called web, that contains a folder called
            // forms, that contains a class named button ... Now the namespace is ==> system.web.forms.button 


            // Ex : Virtual Namespace ==> There is no actual path like this
            // namespace System.Web.Forms
            // {
            //     class Button {}
            // }
            // Note: can be used as ==> using WebButton = System.Web.Forms.Button , then use  "WebButton" directly as it's the alias name

            /* End ******************************************************************************************************************/

            #endregion


            #region Starting with Visual Studio

            /* Start *****************************************************************************************************************/

            // Visual Studio Installer is used to manage the versions of Visual studio and the workloads (technologies) and components
            // installed on it. The project contains the Dependencies and classes, Dependencies contain references to external libraries
            // and frameworks that help with compiling and running the project.

            // Note : in Dot Net framework Dependencies where called "References"

            /* End ******************************************************************************************************************/

            #endregion


            #region First Class

            /* Start *****************************************************************************************************************/

            // The Entry point of the program is the Main function 

            // namespace Project_Name 
            // {
            // 	  class Program
            // 	  {
            // 	  	 static void Main()
            // 	  	 {
            // 	  	 	Console.WriteLine("Hello");
            // 	  	 	Console.ReadLine();
            // 	  	 }
            // 	  	 
            // 	  	 void test()
            // 	  	 {
            // 	  	 
            // 	  	 }
            // 	  }
            // }
            // 

            // Note : we have global usings , introduced with dot Net 6.0 and C# 10 to simplify code by reducing the need to include
            // common using directives in each file. You can define global usings in a separate file(like GlobalUsings.cs) or in the
            // project file(.csproj). these includes are automatically included across all files in the project. This can significantly
            // reduce redundancy, especially for commonly used namespaces.

            /* End ******************************************************************************************************************/

            #endregion


            #region Some Visual Studio Shortcuts

            /* Start *****************************************************************************************************************/

            // ctrl+k ctrl+s     ==> make region , class , ....
            // ctrl+k ctrl+d     ==> clean the code

            // comment   ==> ctrl+k ctrl+c  
            // uncomment ==> ctrl+k ctrl+u

            // ctrl+space ==> drop down menu .

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}