namespace Advanced_C____Session_3_Part_1
{
	// Step 0 : Define the Delegate :
	public delegate int StringFuncDelgate(string s);
	// functions that can be used with this delegate :  (returns int , and have only one parameter which is a string)

	static class StringFunctions
	{
		// The routine of OOP !
		// It could be more easier when sending it as an anoymous function [will be discussed]
		public static int GetCountOfUpperCase(string? str)
		{
			Console.WriteLine("Upper Case");
			int count = 0;
			if (str != null)
			{
				for (int i = 0; i < str.Length; i++)
					if (char.IsUpper(str[i]))
						count++;
			}
			return count;
		}
		public static int GetCountOfLowerCase(string? str)
		{
			Console.WriteLine("Lower Case");
			int count = 0;
			if (str != null)
			{
				for (int i = 0; i < str.Length; i++)
					if (char.IsLower(str[i]))
						count++;
			}
			return count;
		}
	}
	static class SomeFunctions
	{
		public static bool Test(int num) { return num > 0; }
		public static string Cast(int num) { return num.ToString(); }
		public static void Print() { Console.WriteLine("Hello World!"); }
		public static void PrintName(string name) { Console.WriteLine($"Hello {name}"); }
	}
	internal class Program
	{
		static void Main(string[] args)
		{
            #region Self Study and Notes

            /* Start *****************************************************************************************************************/

            // Try to understand (example on delegates) : 
            //     Func<int, int, Func<int, int>> GetOperation(string op)
            //     {
            //         if (op == "add")
            //              return (a) => (b) => a + b;
            //         return (a) => (b) => a * b;
            //     }
            //     
            //     var addFunction = GetOperation("add");
            //     Console.WriteLine(addFunction(5)(10)); // Output: 15


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


            // C# session 3 arrays : 

            // Note : before discussing some array functions , we must first know delegates ! some functions will be discussed in
            //        Advanced C# delegate session (Find , FindAll , Exists)

            /* End ******************************************************************************************************************/

            #endregion


            #region What is a Delegate ? & Example 01

            /* Start *****************************************************************************************************************/

            // // Delegate is a C# Language Feature , means to delegate a behaviour to someone other to perform it rather than you 
            // // first introduced in C# 2.0 , and in C# 3.0 they introduced the built-in delegates (Predicate , Func , Action)
            // // Has 2 usages : 
            // // 1 - Functional Programming Paradigm (cannot implement all the features of functional programming)
            // // 2 - Event-Driven Programming Paradigm
            // 
            // // In Java , if we want to have features of Functional Programming Paradigm , we must impelement the Stratigy Design Pattern [discussed later] 
            // // In Java , if we want to have features of Event-Driven Programming Paradigm , we must impelement the Observer Design Pattern [discussed later] 
            // 
            // // Functional Programming Paradigm :
            // // 1 - Reference to a Function in a Variable (Pointer to Function)
            // // 2 - Function Return another Function
            // // 3 - Function as a Parameter of another Function
            // 
            // // can we refer to the function by an int variable ?
            // // int x = StringFunctions.GetCountOfUpperCase;               
            // // Error , int cannot refer to a function .. so we must make a delegate datatype
            // 
            // // The delgate , After compilation ==> Class , so we can write the delegate in a namespace with internal or default access modifiers
            // // This class contains a constructor , many functions , and some operator overloading
            // // - Making a new Delegate (Class) , The reference from this delegate can refer to a function or more than one function [Pointer to Function]
            // // - These functions may be class member function [static] or object member functions [non static] 
            // // - These functions must have the same signature of the delegate, (return type , number of parameters and their types) regardless the function
            // //   access modifier , function name and parameter naming  
            // 
            // 
            // // Step 1 - Declare a reference from the delegate :
            // StringFuncDelgate reference;
            // 
            // // Step 2 - Initialize the delegate reference [Pointer to Function] :
            // reference = new StringFuncDelgate(/*method*/ StringFunctions.GetCountOfUpperCase);
            // reference = StringFunctions.GetCountOfUpperCase;               // Syntax Sugar
            // reference += StringFunctions.GetCountOfLowerCase;              // using += (overloaded operator) to reference more than one function
            // reference -= StringFunctions.GetCountOfUpperCase;              // using -= (overloaded operator) to de-reference a function referenced before
            // // (+= and -= are not commonly used here , but used in the event-driven programming , used to subscribe to an event or unsubscribe)
            // 
            // 
            // // // same as 
            // // string name = new string("Shoura");
            // // string name02 = "Shoura";               // Syntax Sugar
            // 
            // 
            // // Step 3 : Use the Delegates :
            // int result = reference.Invoke("MahmOUd");
            // // result = reference("MahmOUd");          // Syntax Sugar   
            // 
            // Console.WriteLine($"Result : {result}");     // 4 , holds the last return of last function

            /* End ******************************************************************************************************************/

            #endregion


            #region Example 02

            /* Start *****************************************************************************************************************/

            // // we will mainly discuss passing a function as a parameter for another function
            // // to use the function as a parameter , we must use delegate with the same signature of the sent function 
            // 
            // // Ex: Sorting Algorithms class 
            // 
            // int[] arr = { 4, 5, 1, 7, 2, 9, 10, 3, 6 };
            // SortingAlgorithms<int>.BubbleSort(arr, SortingTypes.SortDesc<int>);      // sending this function will sort Descending
            // foreach (int i in arr)
            // 	Console.Write($"{i}  ");
            // Console.WriteLine();
            // 
            // SortingDlg<int, int, bool> dlg = default;  // default is null (because it's converted to a class in the IL after compilation) (must be handelled in the method)
            // dlg = SortingTypes.SortAsc<int>;
            // 
            // // discussed next regions (built-in delegates) :
            // Func<int, int, bool> dlgNew = SortingTypes.SortAsc<int>;
            // 
            // SortingAlgorithms<int>.BubbleSort(arr, /*dlg*/ dlgNew);              // sending this function will sort Ascending
            // foreach (int i in arr)
            // 	Console.Write($"{i}  ");
            // Console.WriteLine("\n");
            // 
            // 
            // // Other Example : 
            // string[] names = { "Ali", "Mahmoud", "Mo", "Ahmed", "Shoura" };      // we want to sort the names by their length
            // 
            // Func<string, string, bool> dlgString = SortingTypes.SortDesc;        // discussed next regions (built-in delegates)
            // SortingAlgorithms<string>.BubbleSort(names, dlgString);
            // foreach (string name in names)
            // 	Console.WriteLine(name);
            // 
            // Console.WriteLine();
            // 
            // SortingAlgorithms<string>.BubbleSort(names, SortingTypes.SortAsc<string>);
            // foreach (string name in names)
            // 	Console.WriteLine(name);

            /* End ******************************************************************************************************************/

            #endregion


            #region Example 03

            /* Start *****************************************************************************************************************/

            // // Ex: Finding.cs
            // 
            // List<int> numbers = Enumerable.Range(0,100).ToList();   // 0..99        // Enumerable.Range() will be discussed later 
            // 
            // // First we want to make a function that takes a list and then returns a list that contains only the Odd numbers 
            // List<int> Odds = Finding.FindOddNumbers(numbers);
            // 
            // // Second we want to make a function that takes a list and then returns a list that contains only the Even numbers 
            // List<int> Evens = Finding.FindEvenNumbers(numbers);
            // 
            // // Third we want to make a function that takes a list and then returns a list that contains only numbers divisible by 7 
            // List<int> DivBySeven = Finding.FindNumbersDivisibleBySeven(numbers);
            // 
            // 
            // // We will notice that the functions are almost the same but with a minor changing in the condition , so how to use delegates ?
            // ConditionDelegate dlg = Finding.CheckEven;
            // Evens = Finding.FindNumbers(numbers, dlg);
            // dlg = Finding.CheckOdd;
            // Odds  = Finding.FindNumbers(numbers, dlg);
            // 
            // 
            // 
            // // What about making the method Generic , to find elements with specific criteria in the list of any type
            // // With strings : 
            // List<string> names = new List<string>() { "Mahmoud","Ahmed","Shoura","Ali","MO"};
            // 
            // /*ConditionDelegateGeneric<string>*/ Predicate<string> deleg = Finding.CheckLengthMoreThanFive;   // updating to a built-in function
            // List<string> result = Finding.Find(names, deleg);
            // 
            // // With int : 
            // /*ConditionDelegateGeneric<int>*/ Predicate<int> dlgInt = Finding.CheckEven;                      // updating to a built-in function
            // Evens = Finding.Find(numbers, dlgInt);

            /* End ******************************************************************************************************************/

            #endregion


            #region Built-in Delegates (Predicate , Func , Action)

            /* Start *****************************************************************************************************************/

            // These 3 built-in delegates were introduced in C# 3.0

            // 1 - Predicate : it can reference a [function returns bool and takes One parameter of any type]
            //                 no overloads , only one
            //                 ex: check Example 03
            //
            // 2 - Func      : it can reference a [function MUST returns Any Type and takes Zero upto 16 parameter of any type]
            //                 ex: check Example 02
            //                 17 overload (Delegate Overloading)
            //                 0 parameters + 1 return
            //                 1 parameters + 1 return
            //                 2 parameters + 1 return
            //                            .
            //                            .
            //                 16 parameters + 1 return
            //
            // 3 - Action    : We have generic and non-generic versions :
            //                 1 - non-generic version : can reference a function that Don't take parameters and returns void (No Return)
            //                 2 - generic version     : can reference a [function that takes One upto 16 parameter of any type and returns void (No Return)]
            //                 16 overload (Delegate Overloading) + 1 non-generic that takes 0 parameters and returns void (no return)
            //                 1 parameters + 0 return
            //                 2 parameters + 0 return
            //                            .
            //                            .
            //                 16 parameters + 0 return

            // // 1 - Predicate
            // Predicate<int> predicate = SomeFunctions.Test;          // Returns bool
            // predicate.Invoke(100);                                
            // // or
            // predicate(100);                                         // Syntax sugar
            // 
            // 
            // 
            // // 2 - Func
            // Func<int , string> func = SomeFunctions.Cast;           // Returns string
            // func.Invoke(100);
            // // or
            // func(100);                                              // Syntax sugar
            // 
            // 
            // 
            // // 3 - Action
            // Action action = SomeFunctions.Print;                    // Non-generic version , doesn't take any parameters + returns void
            // action.Invoke();
            // // or
            // action();                                               // Syntax sugar
            // 
            // Action<string> actionGeneric = SomeFunctions.PrintName;     // Generic version , take one parameter + returns void
            // actionGeneric.Invoke("Shoura");
            // // or
            // actionGeneric("Shoura");                                // Syntax sugar
            // 
            // 
            // // We may make a user defined delegate but in one case , if the function takes more that 16 parameters :)

            /* End ******************************************************************************************************************/

            #endregion


            #region Anonymous Method and Lambda Expression

            /* Start *****************************************************************************************************************/

            // // What if we wanted to make a function that will be used only one time ?
            // // we must follow the routine of OOP when making the function , by making a class or struct to hold that function , access modifier 
            // // for the class and the function , static or non-static , return type , naming , .... and so on [Stand-alone function]
            // 
            // // when Anonymous Method was introduced in C# 2.0 , and when Lambda Expression was introduced in C# 3.0 the previous problem was solved
            // 
            // // Anonymous Methods : C# 2.0 Feature
            // 
            // // 1 - Predicate
            // Predicate<int> predicate = /*public static bool Test*/ delegate (int num) { return num > 0; };
            // predicate.Invoke(100);
            // 
            // 
            // // 2 - Func
            // Func<int, string> func = /*public static string Cast*/ delegate (int num) { return num.ToString(); };
            // func.Invoke(100);
            // 
            // 
            // // 3 - Action
            // Action action = /*public static void Print*/ delegate () { Console.WriteLine("Hello World!"); };
            // action.Invoke();
            // 
            // Action<string> actionGeneric = /*public static void PrintName*/ delegate (string name) { Console.WriteLine($"Hello {name}"); };
            // actionGeneric.Invoke("Shoura");
            // 
            // 
            // 
            // // Lambda Expression : C# 3.0 Feature
            // // =>  ... Called as "Fat Arrow" and Read as "Goes To"
            // 
            // // 1 - Predicate
            // Predicate<int> Predicate = (int num) =>  num > 0;
            // // or 
            // Predicate = num =>  num > 0;         // One Parameter "without brackets" , and also without the type of the parameter "known from the delegate"
            // Predicate.Invoke(100);
            // 
            // 
            // // 2 - Func
            // Func<int, string> Func = num => num.ToString();
            // Func.Invoke(100);
            // 
            // 
            // // 3 - Action
            // Action Action = () => Console.WriteLine("Hello World!");
            // Action.Invoke();
            // 
            // Action<string> ActionGeneric =  name => Console.WriteLine($"Hello {name}"); 
            // ActionGeneric.Invoke("Shoura");

            /* End ******************************************************************************************************************/

            #endregion


            #region List Methods that take Function as a parameter

            /* Start *****************************************************************************************************************/

            // List<int> numbers = new List<int>() { 1,2,3,4,5,6,7,8,9,10};
            // List<int> OddNumbers;
            // OddNumbers = Finding.Find<int>(numbers, Finding.CheckOdd);
            // // or using the anonymous method and not following the OOP routine 
            // OddNumbers = Finding.Find<int>(numbers, delegate (int a) { return a % 2 == 1; } );
            // // or using Lambda Expression
            // OddNumbers = Finding.Find<int>(numbers, a => a % 2 == 1 );
            // 
            // // in list methods we have:
            // // "FindAll" returns a list containing the items match the criteria 
            // OddNumbers = numbers.FindAll(n => n % 2 == 1);
            // 
            // // "Find" and "FindLast" returns the first element that matches the condition
            // numbers.Find(n => n % 2 == 1);             // 1  ... The first occurence
            // numbers.FindLast(n => n % 2 == 1);         // 9  ... The last occurence
            // 
            // // "Exist" returns true if one or more than one element matches the condition , "some in JavaScript"  
            // numbers.Exists(n => n >= 10);              // true
            // 
            // // "TrueForAll" returns true if All the elements match the condition , otherwise false "every in JavaScript"
            // numbers.TrueForAll(n => n % 2 == 1);       // false
            // 
            // // "RemoveAll" returns the number of elements removed from the list , and the list now don't contain any element that follows the condition
            // numbers.RemoveAll(n => n < 0);
            // 
            // // "ForEach" returns nothing (Action)
            // numbers.ForEach(n => n += 10);
            // // or if multiple lines
            // numbers.ForEach(n =>
            // {
            // 	n *= 10;
            // });

            /* End ******************************************************************************************************************/

            #endregion


            #region Function Returns a Function

            /* Start *****************************************************************************************************************/

            // // This is common in the BCL classes implemented in the .net core
            // 
            // Action x = DelegateDoAction();
            // x();
            // // or 
            // x.Invoke();
            // // or 
            // DelegateDoAction()();

            /* End ******************************************************************************************************************/

            #endregion
        }

        public static Action DelegateDoAction()
		{
			return delegate () { Console.WriteLine("Hello World"); };
			// or
			return () => Console.WriteLine("Hello World");
		}
	}
}
