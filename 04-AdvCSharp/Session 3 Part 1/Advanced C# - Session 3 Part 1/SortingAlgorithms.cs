using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_1
{
	public delegate TResult SortingDlg<in T1, in T2, out TResult>(T1 x, T2 y);    // Replaced by built-in delegate [Func] (next regions(built-in delegates))
	// using in and out here is to make sure that in types must be only for the parameters and out type must be only for the Return type
	// if violating the previous line , Error ... But without them no problem

	internal class SortingAlgorithms<T>
	{
		#region Two functions with the same logic but one line different !!
		// public static void BubbleSortAsc(int[] arr)
		// {
		// 	if (arr is not null)
		// 	{
		// 		Console.WriteLine("Sorting Ascending");
		// 		for (int i = 0; i < arr.Length; i++)
		// 		{
		// 			for (int j = 0; j < arr.Length - i - 1; j++)
		// 			{
		// 				if (arr[j] > arr[j + 1])
		// 					SWAP(ref arr[j], ref arr[j + 1]);
		// 			}
		// 		}
		// 	}
		// }
		// 
		// public static void BubbleSortDesc(int[] arr)
		// {
		// 	if (arr is not null)
		// 	{
		// 		Console.WriteLine("Sorting Descending");
		// 		for (int i = 0; i < arr.Length; i++)
		// 		{
		// 			for (int j = 0; j < arr.Length - i - 1; j++)
		// 			{
		// 				if (arr[j] < arr[j + 1])
		// 					SWAP(ref arr[j], ref arr[j + 1]);
		// 			}
		// 		}
		// 	}
		// }

		#endregion


		// the user who will use the function will send the sorting way he wants (delegate sorting type to the user)
		public static void BubbleSort(T[] arr, /*SortingDlg*/ Func<T, T, bool> dlg)
		{
			if (arr is not null && dlg is not null)
			{
				for (int i = 0; i < arr.Length; i++)
				{
					for (int j = 0; j < arr.Length - i - 1; j++)
					{
						// if (arr[j] > arr[j + 1])
						// if (dlg?.Invoke(arr[j] , arr[j+1]) == true)      // check only one time in the first if condition

						if (dlg.Invoke(arr[j], arr[j + 1]))
							SWAP(ref arr[j], ref arr[j + 1]);
					}
				}
			}
		}
		private static void SWAP(ref T a, ref T b)
		{
			T Temp = a;
			a = b;
			b = Temp;
		}
	}
	class SortingTypes
	{
		// sort based on the value if numbers , and lexicographically sorting with strings (any character A before any character B Regardless the lengh)
		public static bool SortAsc<T>(T x, T y) where T : IComparable
		{
			return x.CompareTo(y) == 1;
			// return x > y;
		}
		public static bool SortDesc<T>(T x, T y) where T : IComparable
		{
			return x.CompareTo(y) == -1;
			// return x < y;
		}


		// another overloads to sort based on the lengh of string (Not generic)
		public static bool SortAsc(string a, string b)
		{
			return a?.Length > b?.Length;
		}
		public static bool SortDesc(string a, string b)
		{
			return a?.Length < b?.Length;
		}
	}
}
