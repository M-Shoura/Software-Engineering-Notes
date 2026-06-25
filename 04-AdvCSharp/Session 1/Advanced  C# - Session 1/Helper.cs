using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced__C____Session_1
{
	internal static class Helper /*<T>*/    // specify the type here if we want to use the T inside the class , ex: property --> T Salary; 
	{
		#region SWAP , Non - Generic , Bad Overloading 

		// // An overload for swapping two integers
		// public static void Swap(ref int x, ref int y)
		// {
		// 	int Temp = x;
		// 	x = y;
		// 	y = Temp;
		// }
		// 
		// // An overload for swapping two doubles
		// public static void Swap(ref double x, ref double y)
		// {
		// 	double Temp = x;
		// 	x = y;
		// 	y = Temp;
		// }
		// 
		// // An overload for swapping two Points
		// public static void Swap(ref Point x, ref Point y)         // must be passing by ref , to change the objects that they refer in the heap 
		// {                                                         // not changing the objects internally (use passing by value in this case)
		// 	Point Temp = x;
		// 	x = y;
		// 	y = Temp;
		// }

		#endregion

		#region SWAP , Non - Generic , Using Objects
		// public static void Swap(ref object x, ref object y)
		// {
		// 	object Temp = x;
		// 	x = y;
		// 	y = Temp;
		// }

		#endregion

		#region SWAP , Generic
		public static void Swap<T> (ref T x, ref T y)
		{
			T Temp = x;
			x = y;
			y = Temp;
		}

		#endregion

	}
}
