namespace My
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // OS + Hardware => Platform 
            // The platform can understant Native Code , Instruction Sets , Machine Language

            // same machine code cannot be executed on different platforms, so C++ code was platform dependent (not cross platform) , 
            // coupled with the platform that i compiled the code on it

            // with C++ , code => compiler (gcc.exe) => Native code 
            // Note : the gcc compiler was cross platform compiler , this mean that we can find a gcc compiler for each OS

            // developers wanted : 
            // 1 - Cross language (ex: creating class with language X , and use this class in language Y) 
            // 2 - Cross platform (ex: compile one time , run everywhere)


            // with C# 2002 : 
            // using compiler CSC.exe , we will produce "Assembly File" , not related to assembly language (.exe or .DLL) , but it means that
            // we can assemble more than one C# file or VB .net file in a single output file , and this file is NOT written in native code, but 
            // it's written in a new language called "IL => Intermidiate language" , or "CIL => Common Intermidiate language" , or 
            // "MSIL => Microsoft Intermidiate language" , or "Managed Code" , we can see this language using ILSpy program.

            // But now we must convert the IL to Native Code , how this can be done ? 
            // using the CLR which is a ting OS over the OS

            // CLR => Common Language Runtime , that runs the Managed Code , AND WE MUST HAVE THE CLR ON ANY OS TO CONVERT IL=>NATIVE CODE

            // The CLR has garbage collector and other components , and has the JIT Compiler. 

            // JIT Compiler : Just In Time Compiler , runtime compiler that works in the runtime , converts IL to machine code (done in RAM) ,
            //                the .exe is in Hard Disk.

            // So now we can take the IL or DLL and use it in another OS (While having a JIT compiler for that OS)

            // 2002 : 
            // .Net Framework 1.0 
            // - C# 
            // - VB.Net 
            // C# and VB.Net have different syntax , but features in C# can be found in VB.NET , and it's a PURE OOP Language

            // F# is a functional programming language 
            // C# is a pure OOP languare , but has many functional programming aspects


            // after having the IL as an intermidiate step , now we can write C# class and use it inside a VB.Net program ! 


            // .Net Framework has : 
            //   1 - CLR
            //   2 - BCL (Base Class Library) / FCL (Framework Class Library) : some Dlls that come with the .NET framework, that has datatypes
            //                                                                  to make anything ! 

            // Next Part
            // --------------------------------------------------------------------------------------------------------------------------------

            // Part 2 : 

            // what is the problem of the two phase compilation ? Taking more time ! 


            // How to make this problem less effective? 
            // - Jitting per function call , first jitting main function , .... 
            // - native code will be cached as long as the program is running 

            // caching native code is effective in web applications that are hosted on a server working 24/7 , but has minimal effect in desktop and
            // mobile applications , because cache is deleted every shut down.

            // that's why it's important to execute each function before any presentation for the project, as this makes the code faster due to 
            // the jitting that happened 

            // what other problems were introduced with the two phase compilation ? 
            // as we can see the IL code using ILSpy , we can reverse engineer the code and get the source code of the application !! and this 
            // is a very bad problem not only for the business but olso in security wise , as anyone can see the code and know how to hack it 

            // the problem of having the DLL and getting from it the scource code is shown in mobile applications and Desktop application , 
            // because the user will have the DLL file , but in web applications the DLL is on the server , and the attacker must be from the 
            // people having access to the server 

            // so to solve the previous problem , we can use "obfuscators" to make the IL that is not understandable, ex: changing variable names , 
            // also clear all comments , some tools make function with the maximum code lines (700 line for a function in C#) , and this function
            // is useless , but we put it to make it a difficult task on the person wanting to know the actual C# code 

            // how to see the IL code ?
            // 1 - IIS Assembler : comes with .Net , we can use it to view the IL code
            // 2 - .Net Reflector: given IL see C# (or VB.net) , then now it's the ILSpy (open source, it's for C# only) 


            // was the .net framework realy cross platform ? NO 
            // That's because we couldn't didn't have the .net framework for linux (it's the most used OS for web servers) , but for macOS
            // it was supported.

            // Mono framework , it's an open source that supports windows, macos , linux

            // problems for Mono framework : 
            // - must see the updater version of .Net framework first then apply these updates to Mono framework
            // - it's an open source and community support , so if we have a problem it's not supported as working with actual .Net Framework


            // now microsoft's most important service is Cloud , not OS, Office, XBox as before ... so they must be able to act with different OS
            // expecially linux.

            // with .Net Core : 
            // 1 - Cross platform : microsoft make .net framework for each OS (linux, macOS, windows)
            // 2 - Open-source
            // 3 - Component Based : for each project , install the pachages you want


            // when there was .net framework new versions and .net core new versions , there was a ".net standard" (self study)
            // 
            // the next version that will continue : .Net 5.0 


            // Now , Mono framework is Xamarin (making native apps for mobile phones using C#) => it's now .Net MAUI

            // The heirarichy when making a .NET application : 
            // 1 - Solution : contain one or more Projects , each project has it's assembly file (dll for class library project , exe for WPF , ... ) 
            // 2 - Project : contain one or more files and classes. 


            // Important Note : if we want to build apps to be directly native code : 
            // 1 - Visual C++ .net => it's the only compiler that produces Native code , not IL as other .net languages (it's special
            //                        and can be used to make applications that are not managed and runs directly into the machine) , it's also NOT 
            //                        CROSS PLATFORM.
            //
            // 2 - .Net Native => build for .Net native 

            // BCL => Big library of datatypes ,
            // Datatypes in .Net is one of the next 4 types (Class, Struct, Enum, Interface)

            // namespaces : logical grouping for the for datatypes , so we can have two buttons with the same name but different namespaces 
            //              namespace is also found in the "Fully Qualified name"
            //              we can see namespaces as folders and files inside it (logical grouping , NOT physically on the Hard Disk)
            //              ex: fully qualified name =>   System.Web.Forms.Button  , namespace => System.Web.Forms    , Class name =>  Button
            //              By default the namespace has the same name of the project

            // Old classes made in .Net Framework has Root namespace => System
            // New classes made in .Net core has Root namespace => Microsoft


            // .sln file : opens all the projects in VS , was (.sln) , now it's (.slnx) in VS 2026


            // The main function is the startup point in our program 
            // main function : static void Main () { ... }   
            // Note : M is capital for Main function 
            //        Also it's a static function , so we shouldn't make an object from the class having main function first , because if we 
            //        created an object from the class containing main function then the ctor of class will be the entry point !! 


            // To build the solution : 
            // - crtl + shift + b
            // OR
            // - right click on the project => Build

            // important : shortcut for Console.WriteLine(); is cw + tab (for writing on the screen)

            // fully qualified name : System.Console.WriteLine();
            // we can write Console.WriteLine(); but with "using System;" (also it can be in the global usings .. )  


            // global usings : 
            // We have global usings , so that we wrote using system in the first lines of the file 
            // to enable and disable global usings : 
            // right click on the project => properties (here we can change many project settings) => global usings (disable implicit global usings)

        }
    }
}
