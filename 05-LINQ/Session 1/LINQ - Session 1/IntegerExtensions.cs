using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ___Session_1
{
	internal static class IntegerExtensions /* <T> */     // Cannot be generic class
 	{
		public static int Reverse(this int number)            // this ==> means Extension method
		{
			int ans = 0;
			while (number != 0)
			{
				ans = ans *10 + number % 10;
				number /= 10;
			}
			return ans;
		}
	}
}
