using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_4.Operators_Overloading
{
	internal class Complex
	{
		public int Real { get; set; }
		public int imaginary { get; set; }


		#region Operator Overloading (Binary , Unary , Relational)

		// ------------------------------------- Binary -----------------------------------------------------

		// Must be NON-Private & Class member function [Static]
		public static Complex operator +(Complex left, Complex right)
		{
			return new Complex()
			{
				Real = (left?.Real ?? 0) + (right?.Real ?? 0),
				imaginary = (left?.imaginary ?? 0) + (right?.imaginary ?? 0)
				// To make protective code .. Note : put brackits because the + has more priority than null coalese operator " ?? " 
			};
		}

		// Subtraction (the same but with " - " sign)
		public static Complex operator -(Complex left, Complex right)
		{
			return new Complex()
			{
				Real = (left?.Real ?? 0) - (right?.Real ?? 0),
				imaginary = (left?.imaginary ?? 0) - (right?.imaginary ?? 0)
			};
		}

		// Can be done with ( * , / ) also 


		// ------------------------------------- Unary ------------------------------------------------------

		public static Complex operator ++(Complex obj)
		{
			return new Complex()
			{
				Real = (obj?.Real ?? 0) + 1,
				imaginary = obj?.imaginary ?? 0
			};
		}

		// -- 
		public static Complex operator --(Complex obj)
		{
			return new Complex()
			{
				Real = (obj?.Real ?? 0) - 1,
				imaginary = obj?.imaginary ?? 0
			};
		}


		// ------------------------------------- Relational -------------------------------------------------

		// They require the matching operator, if implement ">" then we must implement "<" , same (">=" and "<=" ) , ("==" and "!=" )
		public static bool operator >(Complex left, Complex right)
		{
			if (left.Real == right.Real)
				return left.imaginary > right.imaginary;
			return left.Real > right.Real;
		}
		public static bool operator <(Complex left, Complex right)
		{
			if (left?.Real == right?.Real)
				return left?.imaginary < right?.imaginary;
			return left?.Real < right?.Real;
		}

		public static bool operator ==(Complex left, Complex right)
		{
			if (left?.Real == right?.Real)
				return left?.imaginary == right?.imaginary;
			return false;
		}
		public static bool operator !=(Complex left, Complex right)
		{
			if (left?.Real != right?.Real)
				return left?.imaginary != right?.imaginary;
			return false;
		}

		#endregion

		#region Casting Operator Overloading

		// It must be NON-Private Class Member [Static] function

		public static /*int*/ explicit operator int (Complex c)     // Note: explicit     // We don't write the return of the function   
		{
			return c?.Real ?? 0;
		}


		public static implicit operator string(Complex c)          // Note: implicit
		{
			return c?.ToString() ?? string.Empty;
		}






		#endregion

		public override string ToString()
		{
			return $"{Real} + {imaginary}i";
		}
	}
}
