using BenchmarkDotNet.Filters;
using System.Xml.Linq;
using System;
using static System.Net.Mime.MediaTypeNames;

namespace Session_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region Notes and self study

            /* Start *****************************************************************************************************************/

            // important article for Switch evolution : https://mihirdave95.medium.com/evaluation-of-switch-in-c-be587f7de47c 
            // important article for loops : https://medium.com/@musheikh47/optimized-looping-in-c-d7a96f74d55a

            // load string in the IL code in C#
            // Span<char> for string optimization!
            // Parallel.ForEach
            // foreach with IAsyncEnumerable<T>

            /* End ******************************************************************************************************************/

            #endregion


            #region Debug Mode VS Release Mode

            /* Start *****************************************************************************************************************/

            // The difference between Debug and Release configurations in C# (and .NET in general) lies in how your application is compiled
            // and optimized during development vs. production.

            // Debug Configuration:
            // - Includes Debugging Symbols
            // - No Compiler Optimizations
            // - Larger Executable Size & Slower Performance (because no optimizations are applied)

            // Release Configuration: 
            // - Compiler Optimizations Enabled
            // - No Debugging Symbols (unless configured)
            // - Faster & Smaller Executables

            // Switching Modes in Visual Studio:
            // - Go to the top toolbar dropdown(near the green Start/ Play button)
            // - Select Debug or Release from the list

            // To sum up : 
            // use Debug Mode when : During development and testing
            // use Release Mode when : Before deployment or performance testing

            /* End ******************************************************************************************************************/

            #endregion


            #region How to test the performance ?

            /* Start *****************************************************************************************************************/

            // We can test the performance using two ways : 

            // 1 - Manual Timing (Basic Way) : Use Stopwatch from System.Diagnostics
            // Ex: 
            //      Stopwatch sw = Stopwatch.StartNew();
            //      TestedMethod();         
            //      sw.Stop();
            //      Console.WriteLine($"Elapsed Time: {sw.ElapsedMilliseconds} ms");
            //
            // 2 - BenchmarkDotNet (Best Practice) : A library to benchmark C# code. It gives precise results (avoids JIT warm-up noise, ...)
            // Ex: 
            //      - First download BenchmarkDotNet package
            //      - Add [Benchmark] attribute above the function that we want to test
            //      - in the main method , add :
            //                                     BenchmarkRunner.Run<TestBenchmark>();
            //                                                 OR
            //                                     var summary = BenchmarkRunner.Run<StringBenchmark>();
            //                                                 OR
            //                                     var summary = BenchmarkRunner.Run(typeof(Program).Assembly);
            //      - Switch to Release mode because Debug mode skips or breaks benchmarks
            //      - Run , Then in the console we will find a table that has the benchmarks


            // Tips : 
            // - Avoid testing on noisy environments(e.g., while other heavy apps are running).
            // - Run benchmarks multiple times to get stable results.
            // - Warm up methods before timing them(JIT optimization).

            /* End ******************************************************************************************************************/

            #endregion


            #region Debugging (Breakpoints and Tracepoints)

            /* Start *****************************************************************************************************************/

            // 1 - Put a break point , any code before the break point will run smothly without debugging 
            //     but after the break point the compiler will run every line and you will have the controllers 
            //     for the debugging process ==> step into , step out , step over , stop debugging , restart , continue

            //     - step into (F11) ==> if we have a function , it will go inside the function to trace its code , it works
            //                           only in case of user defined functions (ex : will not work with WriteLine function).
            //
            //     - step out (Shift + F11) ==>  if i don't want to debug the remaining code in the function and want to return back 
            //                                   to the code where we stepped in , in the function (Exits current method). 
            //
            //     - step over (F10) ==> debug the code line by line without stepping inside any function
            //
            //     - stop debugging (Shift + F5) ==> will stop debugging
            //
            //     - restart (Ctrl + Shift + F5) ==> will restart the debugging from the first break point
            //
            //     - continue (F5) ==> will skip debugging the remaining code unless there is another break point it will
            //                         move to it (Resume execution until next breakpoint)

            // Note : when debugging a function for example (WriteLine) , if we used step over or step into we will have
            //        the same result .. we will not debug the inside code if the function in any case of them .

            // Note : Hover over variables to see their value at runtime.



            // Tracepoints : Special breakpoints that don't stop your program , instead they log a message to the Output window while
            //               continuing execution.

            // How to Set a Tracepoint ?
            // Right click an existing breakpoint (red dot) or create one.
            // Click on "Actions..."
            // Check "Continue execution" (this makes it a Tracepoint)
            // 
            // Write your message, like:
            // i = { i }, result = { result } (use the same syntax as string interpolation ($"..."), so use {variableName} to log values

            // Click Close.
            // 
            // Your output will appear in the Output → Debug window every time that line is hit


            // Note : the Tracepoints must be on the right line , the line that has a variable that it's value is changing ... Ex: 
            // 
            // for (int i = 0; i < 100; i++)
            // {
            //     i++;        // add a Tracepoint here not on another line .. 
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Control Statements

            /* Start *****************************************************************************************************************/

            // Control statements : Determine how the flow of control moves through a program .
            //
            // 1 - Conditional Statements ==> if , switch
            // 2 - Loop Statements        ==> for , while , do while , for each 
            // 3 - Jump Statements        ==> break , continue , return , goto
            // 4 - Exception Statements   ==> try , catch , finally                (discussed NEXT session) 

            /* End ******************************************************************************************************************/

            #endregion


            #region Conditional Statements (if , switch)

            /* Start *****************************************************************************************************************/

            // if : 
            //
            // Console.WriteLine("Enter a month number in the 1st Quarter : ");
            // int monthNum = int.Parse(Console.ReadLine());
            // if(monthNum == 1)
            // {
            //     Console.WriteLine("Jan");
            // }
            // else if(monthNum == 2)
            // {
            //     Console.WriteLine("Feb");
            // }
            // else if (monthNum == 3)
            // {
            // 	   Console.WriteLine("Mar");
            // }
            // else
            // {
            //     Console.WriteLine("Not existed");
            // }


            // switch :
            //
            // Console.WriteLine("Enter a month number in the 1st Quarter : ");
            // int monthNum = int.Parse(Console.ReadLine());
            // switch (monthNum)
            // {
            // 	case 1:
            // 		Console.WriteLine("Jan");
            // 		break;
            // 	case 2:
            // 		Console.WriteLine("Feb");
            // 		break;
            // 	case 3:
            // 		Console.WriteLine("Mar");
            // 		break;
            // 	default:
            // 		Console.WriteLine("Not existed");
            // 		break;
            // }


            // other example on switch :

            // Console.WriteLine("Enter your name : ");
            // string name = Console.ReadLine();
            // 
            // switch (name)
            // {
            //     case "Ahmed":
            //     case "ahmed":                                      // different cases with same body
            //			Console.WriteLine("Hello Ahmed");
            //			break;
            //     case "Aya":
            // 			Console.WriteLine("Hello Aya");
            // 			break;
            //     case "Omar":
            // 			Console.WriteLine("Hello Omar");
            // 			break;
            //     default:
            //			Console.WriteLine("Unknown");
            //			break;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Important Advantage of Switch cases in C#

            /* Start *****************************************************************************************************************/

            // switch case in C# can be used as the next example, not in equality only as most programming languages , but also with
            // relational patterns (> < >= <=) , and Logical patterns (and, or, not)

            // Console.WriteLine("Enter your age : ");
            // int age = int.Parse(Console.ReadLine());
            // 
            // switch (age)
            // {
            //     case > 22:
            //         Console.WriteLine("Age greater than 22");
            //         break;
            //     case < 22 and >0:
            // 		   Console.WriteLine("Age less than 22 and more than 0");
            // 		   break;
            //     default:
            // 		   Console.WriteLine("Age equals 22");
            // 		   break;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Evolution of switch in C# 6.0

            /* Start *****************************************************************************************************************/

            // object input = new object();
            // // input = "Shoura";
            // // input = 15.58903;
            // input = 3;
            // 
            // switch (input)
            // {
            //     case int:
            //         Console.WriteLine($"it's an int ---> {input}");
            //         break;
            //     case double:
            //         Console.WriteLine($"it's a double ---> {input}");
            //         break;
            //     case string:
            //         Console.WriteLine($"it's a string ---> {input}");
            //         break;
            //     default:
            //         Console.WriteLine("None of the above ! ");
            //         break;
            // }

            // Note : We can change the name of the variable , and use it inside the case , Ex:  

            // switch (input)
            // {
            //     case int x:
            //         Console.WriteLine($"it's an int ---> {x}");
            //         break;
            //     case double y:
            //         Console.WriteLine($"it's a double ---> {y}");
            //         break;
            //     case string:
            //         Console.WriteLine($"it's a string ---> {input}");
            //         break;
            //     default:
            //         Console.WriteLine("None of the above ! ");
            //         break;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Evolution of switch in C# 7.0

            /* Start *****************************************************************************************************************/

            // -- When Keyword

            // object input = new object();
            // input = "Shoura";
            // // input = 15.58903;
            // // input = 3;
            // 
            // switch (input)
            // {
            // 	case int changedName when changedName > 10 && changedName < 20:
            // 		Console.WriteLine($"it's an int and greater than 10 and less than 20 ---> {changedName}");
            // 		break;
            // 	case double:
            // 		Console.WriteLine($"it's a double ---> {input}");
            // 		break;
            // 	case string:
            // 		Console.WriteLine($"it's a string ---> {input}");
            // 		break;
            // 	default:
            // 		Console.WriteLine("None of the above !");
            // 		break;
            // }

            // Moreover .. Having more than one condition on the same variable --> 

            // int input = 3;
            // switch (input)
            // {
            // 	case int when input > 10 && input < 20 :
            //         Console.WriteLine($"it's an int greater than 10 and less than 20 ---> {input}");
            // 		   break;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Evolution of switch in C# 8.0 (Switch Expression)

            /* Start *****************************************************************************************************************/

            // string option = "1";
            // string message = "";
            // 
            // // Till C# 7.0
            // switch (option)
            // {
            // 	case "1":
            //      message = "Using option 1";
            // 		break;
            // 	case "2":
            // 		message = "Using option 2";
            // 		break;
            // 	case "3":
            // 		message = "Using option 3";
            // 		break;
            // 	default:
            // 		message = "Unsupported Option";
            // 		break;
            // }

            // New way with C# 8.0   ---> Switch Expression
            // taking the variable (or object from a class) and directly switching on it 

            // message = option switch
            // {
            // 	"1" => "Using Option 1",
            // 	"2" => "Using Option 2",
            // 	"3" => "Using Option 3",
            // 	_ => "Unsupported Option"           // As the default 
            // };

            // Other example with classes (switching on the properties and attributes of the object) : 

            //  class Person
            //  {
            //		public string Name { get; set; }
            //		public int Age { get; set; }
            //  }

            // Person person = new Person();
            // person.Name = "Shoura";
            // person.Age = 22;

            // string message = "";
            // message = person switch 
            // {
            //     { Name : "Ahmed", Age : 22} => "Hello Ahmed 22 years old" ,
            //     { Age : 30 } => "Hello Person with 30 years old",
            //     _ => "Undefined"                                                    // As default
            // };

            /* End ******************************************************************************************************************/

            #endregion


            #region Evolution of switch in C# 9.0

            /* Start *****************************************************************************************************************/

            // The previous example but with one or more logical operators (and , or , not) : 

            //  class Person
            //  {
            //		public string Name { get; set; }
            //		public int Age { get; set; }
            //  }

            // Person person = new Person();
            // person.Name = "Shoura";
            // person.Age = 22;

            // string message = "";
            // message = person switch 
            // {
            //     { Name : "Ahmed", Age : > 22 and < 28 } => "Hello Ahmed between 22 and 28 years old" , // must be "and" not "&&"
            //     { Age : 30 } => "Hello Person with 30 years old",
            //     _ => "Undefined"                                                    // As default
            // };


            // Also .. 


            // message = option switch
            // {
            // 	"1" or "4" => "Using Option 1 or Option 4",       // difference from the previous version that we can use "or" ..
            // 	"2" => "Using Option 2",
            // 	"3" => "Using Option 3",
            // 	_ => "Unsupported Option"           // As the default 
            // };


            // Also .. 


            // double price = 40;
            // string result = price switch
            // {
            //  	< 10 => "low",
            //  	> 100 => "high",
            //  	_ => "medium"
            // };


            /* End ******************************************************************************************************************/

            #endregion


            #region What to use (if or switch) ? And what are Jump Tables

            /* Start *****************************************************************************************************************/

            // When using switch cases , in some cases a jump table is created 
            // The concept of jump table is key to understanding why switch can be more performant than if-else chains in certain scenarios


            // When you write a switch statement on integral types(like int, byte, char, enum, .. ), the compiler may generate a jump table
            // which is essentially a performance optimization. The jump table allows the runtime to jump directly to the matching case using
            // constant-time lookup O(1), rather than doing multiple comparisons (if else chain).

            // When Does the Jump Table Apply?
            // The switch must be over integral types(like int, char, enum , ... ) 
            // All case labels must be known at compile-time
            // The range of case values should be dense(like 1, 2, 3, 4...) (1,10,20 => worng and we won't have a jump table)

            // Note : When you're using pattern matching (like relational patterns <, >, is, etc.) or switch on reference types
            //        (string, objects), the compiler cannot use a jump table — so performance will be more like if-else.


            // To generate a jump table for Strings , the cost is high .. So when the jump table will be generated?
            // if we have more than 5 cases in the switch case , the compiler will generate a jump table .. other than
            // that it will work as an if else chain.


            // Use switch when:
            // - You're comparing a single variable against multiple possible values.
            // - You want cleaner and more expressive syntax with switch expressions.


            // Use if when:
            // - You're testing multiple unrelated conditions.
            // - You're comparing multiple variables together.
            // - The condition doesn't fit well into a pattern.


            // Interview Tip : I prefer switch when working with a single variable and multiple pattern-based outcomes, especially with
            //                 newer C# features like pattern matching and switch expressions. I use if when I need to combine multiple
            //                 variables or conditions that aren't easily expressed as patterns.

            /* End ******************************************************************************************************************/

            #endregion


            #region Loop Statements (1 - for)

            /* Start *****************************************************************************************************************/

            // When it's used ? when having a block of code that i want to repeat by a known number of times or iterating a collection

            // Console.WriteLine("1");
            // Console.WriteLine("2");
            // Console.WriteLine("3");
            // Console.WriteLine("4");
            // Console.WriteLine("5");
            // 
            // Console.WriteLine("****************************");
            // 
            //  (initialization; condition; iteration)
            // // 1 - initialization : initialize the variables , executed once before the loop starts
            // // 2 - condition      : condition that will stop the loop , Checked before every iteration
            // // 3 - iteration      : incrementing/decrementing variables , executed after the loop body, every iteration
            // for (int i = 1; i <= 5; i++)
            // {
            // 		Console.WriteLine(i);
            // }
            // 
            // for(;;)
            // {
            //      // infinite loop 
            // }
            // 
            // Notes : The first way is better in the performance ==> almost done in 5 steps
            //         the second way is more readable and maintainable but almost done in 16 steps because
            //         of the headache of checking the condition and incrementing/decrementing variables

            // Note : The for loop is just syntactic sugar, the compiler transforms the for loop into something similar to a while during
            //        compilation.

            // Note : Use for instead of foreach when working with arrays or lists if performance is critical (especially when avoiding
            //        iterator allocations). 

            /* End ******************************************************************************************************************/

            #endregion


            #region Loop Statements (2 - for each)

            /* Start *****************************************************************************************************************/

            // When it's used ? Iterating a collection (array , list , dictionaries , sets , .. )

            // important note : when using foreach, the collection must be a class that implements IEnumerable or IEnumerable<T> interfaces
            //                  because foreach will call GetEnumerator function (will be discussed later) , so we can make a class that 
            //                  implements IEnumerable interface and implement GetEnumerator , then use this type with a foreach ! 


            // int[] Numbers = { 1, 2, 3, 4, 5 };
            // 
            // foreach (int number in Numbers)
            // {
            // 	Console.WriteLine(number);
            // 	// number += 10;                             // Error , invalid because we take a copy from the collection
            // }


            // we cannot change "number" as we did (number += 10) , because we're iterating over a copy of each element in the collection,
            // not a reference to the actual element.
            //
            // So what about Reference Types ???
            // If you have a collection of reference types, like objects, you can modify their internal state in foreach:
            // class Person { public string Name; }
            // 
            // var people = new List<Person> { new Person { Name = "Mahmoud" }, new Person { Name = "Shoura" } );
            // 
            // foreach (var p in people)
            // {
            //     p.Name += " Updated";            // This is fine !
            // }
            // Because you're modifying the object itself, not the reference.

            // So , If the element is a reference type, you can change its internal state. But if the element is a value type, you’re
            // working with a copy, so changes won’t persist.

            // To sum up : 
            // for each ==> slower in execution , takes a copy then works with it , don't have full control on the collection , easier syntax
            //              great for read-only iteration , No index is available by default but can avoid this problem using LINQ
            //
            // for loop ==> faster in execution , having full control on the collection and the indexes


            // Performance Note :
            // foreach on arrays is almost as fast as for in .NET 6 +.
            // But foreach on other collections (like List<T>) allocates an enumerator (slower).
            // For performance-critical code, for might be better on large collections.

            /* End ******************************************************************************************************************/

            #endregion


            #region Loop Statements (3 - Do While && 4 - While)

            /* Start *****************************************************************************************************************/

            // Do While Loop : 
            // The loop body always executes at least once because the condition is checked after.
            //
            // int number;
            // do
            // {
            //      Console.WriteLine("Enter an Even Number : ");
            // 	    number = int.Parse(Console.ReadLine());
            // } while (number % 2 == 1);


            // While Loop : 
            // Advanced Example on While loops (will be discussed later) --> Ado.net and reading from the database
            // 
            // SQLReader reader = new SQLReader();
            // while(reader.Read())
            // {
            //     // code;
            // }

            // Note : the performance of for and while loop is identical and generates the same IL too , do while loop is faster in
            //        execution than while and for loops (minor difference)

            /* End ******************************************************************************************************************/

            #endregion


            #region Jump Statements and iterator methods

            /* Start *****************************************************************************************************************/

            // Jump Statements : Used to alter the normal flow of execution.

            // break    : Exit the nearest enclosing loop or switch.
            // continue : Skip the current iteration and continue with the next.
            // return   : Exit the method and optionally return a value.
            // throw    : Used to throw an exception and jump to a catch block.
            // goto     : Jump to a labeled statement(generally discouraged "spaghetti code") (discussed next region).
            // yield break / yield return : Used in iterators to control flow in IEnumerable<T>. (discussed next region)

            /* End ******************************************************************************************************************/

            #endregion


            #region Iterator methods (yield return , yield break)

            /* Start *****************************************************************************************************************/

            // iterator method: A special kind of method in C# that returns elements one at a time using the yield return statement
            //                  instead of returning all elements at once. It produces a sequence (usually an IEnumerable or IEnumerator)


            // yield : used to produce elements one at a time from a method without needing to build and return a complete collection.
            // There are two yield statements:
            // - yield return <value> : returns the next element in the sequence.
            // - yield break : ends the iteration early.

            // use yield when : 
            // 1 - Lazy evaluation: Elements are computed on demand, saving memory.
            // 2 - Simplified code: No need to create a custom collection or enumerator manually.
            // 3 - Streaming large data: Ideal for huge datasets (like files, APIs, ... )


            // use yield break when :
            // - exiting the iterator early


            // yield example : 
            // public IEnumerable<int> GetNumbers()
            // {
            //     yield return 1;
            //     yield return 2;
            //     yield return 3;
            // }
            // foreach (int num in GetNumbers())
            // { 
            //     Console.WriteLine(num);                // 1 2 3
            // }


            // yield break example : 
            // IEnumerable<int> FilterPositive(int[] nums)
            // {
            //     foreach (var num in nums)
            //     {
            //         if (num < 0)
            //             yield break;            // Stop yielding if a negative number is found
            // 
            //         yield return num;
            //     }
            // }


            // So what is the difference between return and yield break ? 
            // return: Used in normal methods (non-iterator methods) to exit the method and optionally return a value.
            //         (Execution effect : Method Ends)
            // yield break: Used only in iterator methods (those using yield return) to stop iteration early and exit the method
            //              without returning any more elements. (Execution effect : Iteration ends (like break for loop)

            /* End ******************************************************************************************************************/

            #endregion


            #region goto and goto with switch case

            /* Start *****************************************************************************************************************/

            // goto : A jump statement that transfers control to a labeled statement within the same method, allowing you to skip over
            //        parts of code or jump back. It's generally discouraged in modern programming because it can make code harder to read
            //        and maintain (also known as "spaghetti code").


            // Valid Use Cases for goto: Exiting deeply nested loops


            // goto example : 
            // int number = 0;
            // 
            // start:
            // Console.WriteLine("Enter a number (0 to quit):");
            // number = int.Parse(Console.ReadLine());
            // 
            // if (number != 0)
            // {
            //     Console.WriteLine("You entered: " + number);
            //     goto start;
            // }

            // goto with switch example : 
            // Console.WriteLine("Enter the budget : ");
            // int budget = int.Parse(Console.ReadLine());
            // 
            // switch (budget)
            // {
            //     case 3000:
            //         Console.WriteLine("Option 3");
            // 		   // Console.WriteLine("Option 2");
            // 		   // Console.WriteLine("Option 1");
            // 		   goto case 2000;
            // 		   break;                       // unreachable code
            //     case 2000:
            // 		   Console.WriteLine("Option 2");
            //         // Console.WriteLine("Option 1");
            //         goto case 1000;
            // 		   break;                       // unreachable code
            // 	   case 1000:
            // 		   Console.WriteLine("Option 1");
            // 		   break;
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region TryParse

            /* Start *****************************************************************************************************************/

            // The TryParse method is a safe way to convert strings to numeric (or other) types without throwing exceptions if the
            // conversion fails. Unlike int.Parse() or Convert.ToInt32(), TryParse() doesn’t throw an exception when the conversion fails
            // but instead, it returns false. if input is invalid ==> No exception thrown

            // Almost every primitive type in .NET provides TryParse (int , double , DateTime , bool , Enum (C#7.0), .. )   

            // In the example with ( do while loop ) , it was not a deffensive code .. because we will get an exception when entering
            // for example a string not a number as wanted .. so we must write code that avoids runtime errors
            // and exceptions

            // int number;
            // bool flag;
            // do
            // {
            // 	   Console.WriteLine("Enter an Even Number : ");
            // 	   // number = int.Parse(Console.ReadLine());
            // 	   flag = int.TryParse(Console.ReadLine(), out number);
            // } while (number % 2 == 1 || !flag);                          // Ckech again .... 

            // Note :  if TryParse fails , the output paramater takes the default value for it's type (in our case int ==> 0)

            // Example 2 : starting from C# 7.0, you can declare the variable inside the out directly (ex: out int number) , and the
            //             variable number will exist only inside the if block.
            //
            // string input = "123";
            // if (int.TryParse(input, out int number))
            //     Console.WriteLine($"Parsed number: {number}");
            // else Console.WriteLine("Invalid number.");


            // Discard (_) with TryParse :
            // bool flag = int.TryParse("123", out _);    // you ignore the parsed result , but we want to know the flag result

            /* End ******************************************************************************************************************/

            #endregion


            #region String

            /* Start *****************************************************************************************************************/

            // A String is built in datatype (class , so it's a Reference Type) , internally is an array of characters
            // contained in the "System" namespace
            // internally, a string is an immutable object , you can’t modify it after creation. Every time you change a string, a new
            // object is created in memory. Old strings become garbage (collected later by Garbage Collector). to use a mutable string then
            // use StringBuilder (Next Region)

            // String stored in memory as: The reference (address) is in the stack and the actual characters stored contiguously in the heap.

            // Strings are zero-indexed arrays of characters. Each character = 2 bytes (UTF-16 encoding). String is Enumerable so you can
            // foreach over a string (char by char). It's also Interned which means duplicated literals may point to same memory location.

            // string name;
            //      1 - Declare for a reference of type "string"
            //      2 - This reference "name" is refering to the default value of Reference Types = Null
            //      3 - CLR will allocate 4 bytes at the STACK for the reference "name"
            //      4 - CLR will allocate 0 bytes at the HEAP
            // 
            // name = new string("Ali");   
            //      1 - CLR will allocate 6 Bytes at the heap (3 characters * 2 bytes for each = 6)
            //      2 - then initialize the allocated bytes with the default value for each char
            //      3 - Call the user defined constructor 
            //      4 - return the location at the heap that will be refernced by the reference "name"
            // 
            // name = "Ali";               // syntax sugar for name=new string("Ali");
            // 
            // Console.WriteLine(name);
            // Console.WriteLine(name.GetHashCode());         
            // Note : GetHashCode method will be discussed later in OOP ! generates an int that represents the object location in the memory


            // Common String methods:
            // - str.Length                                => get number of characters (property not a function so we don't need ())
            // - Substring(), Contains(), IndexOf()        => Extension methods (called with an object not the class name .. )
            // - ToUpper(), ToLower()                      => Extension methods (called with an object not the class name .. )
            // - Trim(), Split(), Replace()                => Extension methods (called with an object not the class name .. )
            // - StartsWith(), EndsWith()                  => Extension methods (called with an object not the class name .. )
            //
            // - Format()                                  => Class member method  (called by the class name)
            // - IsNullOrEmpty() , IsNullOrWhiteSpace()    => Class member methods (called by the class name) return true or false 
            // - ................


            // Note : String Interpolation vs String Concatenation:
            //        String interpolation is usually more efficient than concatenation. This is because the compiler can optimize
            //        interpolated strings and often uses a StringBuilder behind the scenes, especially in loops.
            //  string concatination : "Hi " + NameVariable + ". How are you ?"  
            //  string interpolation : $"Hi {NameVariable}. How are you ?"  


            // Important note with strings in C# :
            // When initializing two string variables with the same values .. they will reference the only one place at the heap (Interning)

            // Interning : .NET CLR optimizes memory by storing only one copy of each unique string literal. If two string literals have the
            //             same value, they share the same address in memory!

            // Ex:
            // string name1 = "Mahmoud";
            // string name2 = "Mahmoud";
            // 
            // Console.WriteLine($"name1 = {name1} , HashCode = {name1.GetHashCode()}");   // Same hashcode 
            // Console.WriteLine($"name2 = {name2} , HashCode = {name2.GetHashCode()}");   // Same hashcode 


            // More over :
            // 
            // string name1 = "Mahmoud";
            // string name2 = "Shoura";
            // 
            // Console.WriteLine($"name1 = {name1} , HashCode = {name1.GetHashCode()}");        // Mahmoud + Having different hashcode
            // Console.WriteLine($"name2 = {name2} , HashCode = {name2.GetHashCode()}");        // Shoura  + Having different hashcode
            // 
            // name2 = name1; // Then name1 value in the heap will have 2 references and name2 value in heap will be an unreachable object ..	
            // Console.WriteLine("********** After Modification ***********");
            // 
            // Console.WriteLine($"name1 = {name1} , HashCode = {name1.GetHashCode()}");        // Mahmoud + Having same hashcode
            // Console.WriteLine($"name2 = {name2} , HashCode = {name2.GetHashCode()}");        // Mahmoud + Having same hashcode
            // 
            // name1 = "Yassmin";
            // Console.WriteLine("********** After Modification Second time ***********");
            // 
            // Console.WriteLine($"name1 = {name1} , HashCode = {name1.GetHashCode()}");        // Yassmin + Having different hashcode
            // Console.WriteLine($"name2 = {name2} , HashCode = {name2.GetHashCode()}");        // Mahmoud + Having different hashcode
            // 
            // for any other reference type, we will find that "name1" and "name2" reference the same place at the Heap => "Yassmin"
            // but because the string is an Immutable type that is internally built on an Array that is fixed lengh .. then name1
            // will be changed to a new place at the heap with new hashcode .. but name2 will stay reference the first string "Mahmoud"


            // Another example : 
            // 
            // string message = "Hello";
            // Console.WriteLine($"message = {message} , hashcode = {message.GetHashCode()}");
            // 
            // message += " Mahmoud";
            // Console.WriteLine("******* After Changing ******* ");
            // 
            // Console.WriteLine($"message = {message} , hashcode = {message.GetHashCode()}");
            // 
            // Here we will notice that the hashcodes are different because after modification we had a new place at the heap with
            // a different hashcode .. and "Hello" is now an unreachable object in the heap waiting for the garbage collector to delete it


            // Comparing Strings :             
            // 1 - ==  : For strings, it checks the **values**, not the references. This behavior is because the `==` operator is
            //           (overloaded) in the String class to compare the values char-by-char. String interning helps sometimes in reference
            //           equality, but `==` always compares values for strings. For other reference types == checks for reference equality 

            // 2 - Equals()  : Also compares values. Can be made case-sensitive or case-insensitive depending on the overload you use.
            //                 Works similarly to == for strings, but gives you more control (example: StringComparison.OrdinalIgnoreCase)

            // 3 - Compare() : Used often for sorting or ordering strings. Compares the values of two strings and returns :
            //                     - 0  if they are equal,
            //                     - <0 if the first string comes before the second,
            //                     - >0 if the first string comes after the second.

            /* End ******************************************************************************************************************/

            #endregion


            #region String Builder

            /* Start *****************************************************************************************************************/

            // The String Builder is also a string but internally it's a linked list (linked list of buffers (chunks), not a
            // character-by-character linked list..). String Builder is a mutable string (Unlike regular string objects) allows modification
            // without creating new object each time. This is good for performance and prevents creating many objects that will be deleted
            // later by the grabage collector
            // 
            // StringBuilder message ;
            //      1 - declare for reference of type "StringBuilder"
            //      2 - now "message" is refering to the default value of the reference type = NULL
            //      3 - CLR will allocate 4 bytes for this reference "message" at the STACK
            //      4 - CLR will allocate 0 bytes for this reference "message" at the HEAP
            // 
            // message = new StringBuilder("Hello");
            // Console.WriteLine($"name1 = {message} , HashCode = {message.GetHashCode()}");
            // 
            // message.Append(" Mahmoud");
            // Console.WriteLine("********* After modification ***********");
            // 
            // Console.WriteLine($"name1 = {message} , HashCode = {message.GetHashCode()}");
            //
            // Here we will notice that the hashcodes are the same .. not same as the string (no new object is created and allocated in
            // the heap)


            // To convert a StringBuilder to a String => string result = strBuilder.ToString();
            // To convert a string to a StringBuilder => StringBuilder strBuilder = new StringBuilder(myString);

            // string builder methods : (take care of the function overloads)
            // StringBuilder message = new StringBuilder("Hello");
            // 
            // message.Length;                                  // Gets or sets the length of the current string (property not a function !!)
            // message.Capacity;                                // Gets or sets the maximum number of characters the StringBuilder can hold
            //                                                  // before it needs to allocate more memory. Sets the initial capacity if known
            // message.Append(" Mahmoud");                      // Appends it to the end of the current StringBuilder. 
            // message.AppendLine("Age : 22");                  // Appends it to the end of the current StringBuilder followed by a newline.
            // message.AppendJoin(';', "Mahmoud", "Shoura");    // Appends items with seperating it with a separator (can take an array)
            // message.AppendFormat("{0} : {1}", true , 'A');   // Appends a format string. 
            // message.Insert(index, "Random");                 // inserts in a specific index.
            // message.Remove(startIndex, length);              // to remove a portion or substring.
            // message.Replace(oldValue, newValue)              // Replaces all occurrences of the old string with the new string.
            // message.Clear();                                 // Clears the StringBuilder and removes all characters.
            // message.ToString();                              // Converts the StringBuilder content to a string

            /* End ******************************************************************************************************************/

            #endregion


            #region String VS String Builder

            /* Start *****************************************************************************************************************/

            // Performance Considerations
            // String Interpolation vs String Concatenation: String interpolation is usually more efficient than concatenation.This is because
            // the compiler can optimize interpolated strings and often uses a StringBuilder behind the scenes, especially in loops.
            //
            // Example of inefficient concatenation in a loop:
            // string result = "";
            // for (int i = 0; i < 1000; i++)
            // {
            //     result += $"Iteration {i} ";
            // }
            //
            // Better approach using StringBuilder:
            // 
            // var sb = new StringBuilder();
            // for (int i = 0; i < 1000; i++)
            // {
            //     sb.AppendLine($"Iteration {i}");
            // }
            // string result = sb.ToString();


            // The string is an immutable type that cannot change in it's value .. because the string is an array of characters
            // with fixed size .. so if we want to change the string we must change the place in the memory and have a place with the new size 
            // producing many unreachable objects in the heap 


            // The String Builder is also a string but internally it's a linked list (linked list of buffers (chunks), not a
            // character-by-character linked list..). String Builder is a mutable string (Unlike regular string objects) allows modification
            // without creating new object each time. This is good for performance and prevents creating many objects that will be deleted
            // later by the grabage collector


            // To sum up : if we have a string that we modify it (appending , removing , ... ) more that reading it (ex: in a loop), then
            // it's better to use the string builder .. but if we read the string more than modifying it , then the string will be better
            // then string builder . why ? disscussed in arrays in the next region.

            // Feature                 string          StringBuilder:
            // Mutable ?            No (Immutable)      Yes (Mutable)
            // Memory Efficient?    No (in loops)           Yes
            // Namespace              System            System.Text

            /* End ******************************************************************************************************************/

            #endregion


            #region One Dim. Array

            /* Start *****************************************************************************************************************/

            // Array is a class (reference type) , in C# arrays are Zero-indexed
            // 
            // int[] arr;
            //      - declare for reference of type "Array of Integer"
            //      - This reference "arr" is refering to the default value of reference types = NULL
            //      - This Reference can refer to an object of type "Array of integer"
            //      - CLR will allocate 4 bytes at STACK for the reference (uninitialized)
            //      - CLR will allocate 0 bytes at HEAP
            // 
            // arr = new int[2];                                  // Note : must define the size of elements in array .. (compile-time error)
            //      - CLR will allocate 8 bytes at the heap
            // 		- will be initialized with the default value for int = 0 
            // 
            // arr[0] = 10;                   // Set the value
            // 
            // Console.WriteLine(arr[0]);
            // Console.WriteLine(arr[1]);
            // Console.WriteLine(arr[2]);     // not a compilation error but a runtime error	(IndexOutOfRangeException)
            // 
            // for (int i = 0; i < arr.Length; i++)
            // {
            //  	Console.WriteLine(arr[i]);
            // }
            // 
            // OR 
            //
            // foreach (int n in arr)
            // {
            //     Console.WriteLine(n);
            // }


            // another ways to initialize the array : 

            // int[] arr2 = new int[3] {1,2,3};
            // int[] arr3 = new int[] {1,2,3};               // Auto known size
            // int[] arr4 = { 1, 2, 3 };                     // Auto known size


            // arr2 = { 10,20,30};          // Wrong when modifying an existing array
            // arr2 = new[] { 10,20, 30};   // right when modifying an existing array


            // Console.WriteLine(arr.Length);      // number of items in it (the size)
            // Console.WriteLine(arr.Rank);        // number of dimentions


            // Advantages of Arrays    ==> O(1) to access any item of the array 
            // Disadvantages of Arrays ==> Fixed length

            // Array ==> contigious part of the memory 
            // Linked List ==> different parts of the memory
            // list ==> dynamic size as the linked list and access the element in O(1) as the array (discussed in Collections, advanced C#)


            // How the array is stored in the memory ? 
            // The reference is in the stack , references the object in the heap .. the object that is in the heap is stored in 
            // contigious part of the memory that means if the first element of the array address is 0X000 (in hexadecimal) then
            // the second element address in the array will be in 0X004 , and the third element address will be in 0X008 and
            // so on (this example if the array is int) .. the reference in the stack references the first byte of the first element
            // of the array 


            // Important Function : Array.ConvertAll(arr, lambda_expression) discussed in Advanced C# also
            // Type Casting in Arrays : In the case of arrays, if you try to cast an array from one type to another (such as casting an
            //                          int[] to a double[]), C# will throw an InvalidCastException unless the array elements are compatible.
            // Ex:
            // int[] intArray = { 1, 2, 3 };
            // double[] doubleArray = (double[]) intArray;  // Throws InvalidCastException
            //
            // To solve this problem , use Array.ConvertAll()
            // int[] intArray = { 1, 2, 3 };
            // double[] doubleArray = Array.ConvertAll(intArray, x => (double)x);
            //
            // Ex2 :
            // int[] numbers = { 1, 2, 3, 4 };
            // string[] stringNumbers = Array.ConvertAll(numbers, n => n.ToString());
            // foreach (var s in stringNumbers)
            //     Console.WriteLine(s);           // prints: "1" "2" "3" "4"    (As strings)

            /* End ******************************************************************************************************************/

            #endregion


            #region Two Dim. Array (Rectangular)

            /* Start *****************************************************************************************************************/

            // Two Dim. Arrays ==>
            // 1 - Rectangular array (ex: int[,]) (as a table in SQL => having a fixed size of columns in each rows)
            // 2 - Jagged Array (ex: int[][]) (as a table in NoSQL (documnet/collection) => number of columns in rows are different)
            // 
            // 
            // Rectangular array (ex: int[,]) : ex => university students that enroll the same number of courses during the year 
            // 
            // int[,] Marks = new int[2, 4];  // [numOfRows , numOfColumns]
            // 								  // CLR will allocate 32 bytes at HEAP and initialize them with the default values of int = 0  
            // 
            // Accessing Elements : arr[1,1];
            //
            // can also be initialized as : 
            // Marks = new int[2, 4] { { 1, 2, 3, 4}, { 1, 2, 3, 4} };
            // 
            // Marks[0, 0] = 1;
            // Marks[0, 1] = 2;
            // Marks[0, 2] = 3;
            // Marks[0, 3] = 4;
            // 
            // Marks[1, 0] = 1;
            // Marks[1, 1] = 2;
            // Marks[1, 2] = 3;
            // Marks[1, 3] = 4;
            // 
            // Console.WriteLine($"The length of the array (3*5) = {Marks.Length}");    // 8 
            // Console.WriteLine($"The number of dim of the array = {Marks.Rank}");     // 2
            // Console.WriteLine($"The length of first dim = {Marks.GetLength(0)}");    // 2 
            // Console.WriteLine($"The length of second dim = {Marks.GetLength(1)}");   // 4 

            // Note : GetLengh is ONE Based , but takes parameter Zero based

            // To read the input from the user we can use nested loops : 
            // bool flag;
            // for (int i = 0; i < Marks.GetLength(0); i++)
            // {
            // 	Console.WriteLine($"Student Number {i + 1} (rows)");
            // 	for (int j = 0; j < Marks.GetLength(1); )
            // 	{
            // 		flag = false;
            // 		Console.WriteLine($"Enter the grade of subject no. {j + 1} (columns)");
            // 		flag = int.TryParse(Console.ReadLine(), out Marks[i, j]);
            // 		j += (flag ? 1 : 0);
            // 	}
            // }


            // To Show the values in the array with nested loops : 
            // for (int i = 0; i < Marks.GetLength(0); i++)
            // {
            // 	    Console.WriteLine($"Student Number {i + 1} (rows)");
            // 	    for (int j = 0; j < Marks.GetLength(1); j++)
            // 	    {
            // 	    	Console.WriteLine($"The grade of subject no. {j + 1} (columns) = {Marks[i,j]}");  
            //      }
            // }


            // To Show the values in the array with only one loop :
            // int last = -1;
            // for (int i = 0; i < Marks.Length; i++)
            // {
            // 	    if(last != (i / Marks.GetLength(1)))
            // 	    {
            // 	    	last = (i / Marks.GetLength(1));
            //          Console.WriteLine();
            //      }
            // 	    Console.Write($"{Marks[i / Marks.GetLength(1) , i % Marks.GetLength(0)]} ");
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region Two Dim. Array (Jagged)

            /* Start *****************************************************************************************************************/

            // Jagged Array (ex: int[][]) : (as a table in NoSQL (documnet/collection) => number of columns in rows are different)
            // ex => university students that enroll (different) number of courses during the year 
            // It's a ONE Dim. array of arrays , each index in the array contains reference to another array

            // int[][] marks = new int[3][];                  // array of size 3 , each index references another array
            // marks[0] = new int[5] {1,2,3,4,5};
            // marks[1] = new int[2] {6,7};
            // marks[2] = new int[3] {8,9,10};
            // 
            // Console.WriteLine(marks.Length);
            // Console.WriteLine(marks[0].Length);

            // Accessing Elements : marks[1][1];

            // for (int i = 0; i < marks.Length; i++)
            // {
            //     for (int j = 0; j < marks[i].Length; j++)
            //     {
            //         Console.Write(marks[i][j] + " ");
            //     }
            //     Console.WriteLine();
            // }

            /* End ******************************************************************************************************************/

            #endregion


            #region (Rectangular) VS (Jagged) Two Dim Arrays

            /* Start *****************************************************************************************************************/

            // Feature	          Jagged Array (int[][])	               Rectangular Array (int[,])
            // Structure             Array of arrays                           Single 2D block
            // Row size              Can be different                          Must be the same
            // Memory                 More flexible                          Allocated as a block
            // Access notation          arr[i][j]                                 arr[i, j]

            /* End ******************************************************************************************************************/

            #endregion


            #region Array Methods (class member methods ==> static methods) 

            /* Start *****************************************************************************************************************/

            // Note : don't forget to take a look at the function overloads
            // Note : Here are some examples , you must try to search and use the other functions not mentioned here
            // Note : Take care about the Capital Letters of function names !
            //
            // class member methods : called by the class it self
            // 
            // 
            // int[] numbers = { 5, 3, 2, 1, 4 };
            // Array.Sort(numbers);                         // Sort the Array in ascending order
            // 
            // Array.Reverse(numbers);                      // Reverse the Array
            // 
            // note : if we want to sort the array in descending order , then sort the array then reverse it ! OR use LINQ (discussed later)
            // 
            // int[] arr1 = { 1, 2, 3, 4 };
            // int[] arr2 = new int[5];
            // Array.Copy(source, destination, lenghToBeCopiedFromSourceStartingFromBegin);
            // Array.Copy(arr1, arr2, 3);   // now arr2 = {1,2,3,0,0}, lengh must be less or equal to the size of the destination array
            // 
            // 
            // 
            // Array.Clear(arr2);            // makes each element in the array with the default value , the array will still has
            // 							     // the same size but eleemnts with default value
            // 
            // Array.Clear(array, index, length)	    // Clears the elements by setting them to default
            // 
            // Array.ConstrainedCopy(source, sourceIndex, destination, destinationIndex, length);
            // Array.ConstrainedCopy(arr1, 2, arr2, 1, 1); // now arr2 = {0,3,0,0,0}
            // 
            // 
            // int[] newArr1D = (int[]) Array.CreateInstance(typeof(int), 2);          // same as new int[2]
            // int[,] newArr2D = (int[,]) Array.CreateInstance(typeof(int), 2 , 4);    // same as new int[2,4]
            // 
            // 
            // Array.IndexOf(arr1, 5);        // returns the first index where the number occured
            // Array.LastIndexOf(arr1, 5);    // returns the last index where the number occured
            // 
            // Array.Resize(ref array, newSize);	         // Changes the size of the array


            // Note : before discussing some array functions , we must first know delegates ! some functions will be discussed in
            //        Advanced C# delegate session (Find , FindAll , Exists)

            /* End ******************************************************************************************************************/

            #endregion


            #region Array Methods (object member methods ==> non-static methods) 

            /* Start *****************************************************************************************************************/

            // Note : don't forget to take a look at the function overloads
            // Note : Here are some examples , you must try to search and use the other functions not mentioned here
            //
            // object member methods : called by an object from class , not the class itself
            // 
            // int[] arr1 = { 1, 2, 3};
            // int[] arr2 = new int[5];
            // 
            // arr1.CopyTo(arr2, 2);    // copies all the calling array (arr1) to the other array starting from a specific index 
            // 						    // Take care about the sizes to avoid exceptions ! now arr2 = {0,0,1,2,3}
            // 
            // 
            // arr1.GetLength(0);       // returns the lengh of the "first" Dim. 
            // arr1.GetLength(1);       // returns the lengh of the "first" Dim. if  exists , if not it will throw exception !
            // 
            // 
            // 
            // arr1.GetValue(0);        // same as arr1[0] , returns the value in this specific index 
            // arr1.SetValue(100,0);    // same as arr1[0] = 100 , sets the value to the specific index 


            // Some functions are LINQ extension methods (discussed later also .. ) : 
            // Note : Take care of the return of each extension method .. 
            // - arr.Min()      	      Returns the minimum value
            // - arr.Max()                Returns the maximum value
            // - arr.Sum()                Returns the sum of all elements
            // - arr.Average()            Returns the average of all elements
            // - arr.Contains(value)      Checks if the value exists
            // - arr.Where(predicate)     Filters based on condition
            // - arr.ToList()             Converts to a List

            /* End ******************************************************************************************************************/

            #endregion
        }
    }
}