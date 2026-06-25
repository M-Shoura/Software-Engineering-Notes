using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_3.Interface_Example_02
{
	class Helper
	{
		// // This is not overloading !!! the function implementation is the same 
		// public static void Print10NumbersFromSeries(SeriesByTwo series)
		// {
		// 	if(series != null)
		// 	{
		// 		for(int i=0; i<10; i++)
		// 		{
		//             Console.WriteLine(series.Current);
		// 			series.GetNext();
		//         }
		// 		series.Reset();
		// 	}
		// 	return;
		// }
		// public static void Print10NumbersFromSeries(SeriesByThree series)
		// {
		// 	if (series != null)
		// 	{
		// 		for (int i = 0; i < 10; i++)
		// 		{
		// 			Console.WriteLine(series.Current);
		// 			series.GetNext();
		// 		}
		// 		series.Reset();
		// 	}
		// 	return;
		// }

		public static void Print10NumbersFromSeries(ISeries series)
		{
			if (series != null)
			{
				for (int i = 0; i < 10; i++)
				{
					Console.Write($"{series.Current}\t");
					series.GetNext();
				}
				series.Reset();
                Console.WriteLine();
            }
		}
	}
}
