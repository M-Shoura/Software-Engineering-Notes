using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal class Helper02<T> where T : IComparable<T>
	{
		public static int SearchArray(T[] arr, T value)
		{
			if (arr != null)
			{
				for (int i = 0; i < arr.Length; i++)
				{
					// if (arr[i] == value)
					// 	 return i;

					if (arr[i].Equals(value))          // Check the notes in Employee struct and Program class to know why we used "Equals" function
						return i;					   // it's always there .. in value types checks and reference types (we may override it to compare
													   // the values not references)
				}
			}
			return -1;
		}

		public static void BubbleSort(T[] arr)
		{
			if(arr != null)
			{
				for(int i=0; i< arr.Length; i++)
				{
					for(int j = 0; j< arr.Length-i-1; j++)
					{
						//if (arr[j] > arr[j+1])    // Error with ( > ) because we cannot work with type T (not all types has implementation for > operator) 
						
						if (arr[j].CompareTo(arr[j+1]) == 1)          // Where T : IComparable , so it will have CompareTo function 
						{
							Helper.Swap(ref arr[j], ref arr[j + 1]);
						}
					}
				}
			}
		}
	}
}
