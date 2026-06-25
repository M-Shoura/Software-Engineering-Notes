using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_1
{
	// Delegates : 
	public delegate bool ConditionDelegate(int a);                 // Replaced by built-in delegate [predicate] (discussed next regions (built-in delegates))

	// Generic One :
	public delegate bool ConditionDelegateGeneric<T>(T a);         // Replaced by built-in delegate [predicate] (discussed next regions (built-in delegates))

	internal static class Finding
	{
		#region Bad Way !!! 

		public static List<int> FindOddNumbers(List<int> numbers)
		{
			List<int> result = new List<int>();
			if (numbers is not null)
			{

				for (int i = 0; i < numbers.Count; i++)
				{
					if (numbers[i] % 2 == 1)
						result.Add(numbers[i]);
				}
			}
			return result;
		}

		public static List<int> FindEvenNumbers(List<int> numbers)
		{
			List<int> result = new List<int>();
			if (numbers is not null)
			{

				for (int i = 0; i < numbers.Count; i++)
				{
					if (numbers[i] % 2 == 0)
						result.Add(numbers[i]);
				}
			}
			return result;
		}
		public static List<int> FindNumbersDivisibleBySeven(List<int> numbers)
		{
			List<int> result = new List<int>();
			if (numbers is not null)
			{

				for (int i = 0; i < numbers.Count; i++)
				{
					if (numbers[i] % 7 == 0)
						result.Add(numbers[i]);
				}
			}
			return result;
		}


		#endregion

		#region Non-Generic

		public static List<int> FindNumbers(List<int> numbers, ConditionDelegate dlg)
		{
			List<int> result = new List<int>();
			if (numbers is not null && dlg is not null)
			{

				for (int i = 0; i < numbers.Count; i++)
				{
					if (dlg(numbers[i]))
						result.Add(numbers[i]);
				}
			}
			return result;
		}

		#endregion

		public static List<T> Find<T>(List<T> Elements, /*ConditionDelegateGeneric<T> dlg*/  Predicate<T> dlg)
		{
			List<T> result = new List<T>();
			if (Elements is not null && dlg is not null)
			{

				for (int i = 0; i < Elements.Count; i++)
				{
					if (dlg(Elements[i]))
						result.Add(Elements[i]);
				}
			}
			return result;
		}
		public static bool CheckOdd(int a) { return a % 2 == 1; }
		public static bool CheckEven(int a) { return a % 2 == 0; }
		public static bool CheckDevisibleBySeven(int a) { return a % 7 == 0; }
		public static bool CheckLengthMoreThanFive(string a) { return a?.Length > 5; }
	}
}
