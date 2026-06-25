using System.Threading.Channels;

namespace OOP___Session_4.Static_and_Constants
{
	// this class is a helper class containing helper properties and helper methods , not a must to make objects from it 
	internal static class Utility
	{

		// Static constructor
		static Utility()
		{
			// Code that will be executed only one time per class lifetime
			// ex : initialize the static attributes
			pi = 3.14;
		}


		// Static Property and Attribute
		private readonly static double pi; /* = default; */ // by the compiler in the IL code

		public static double PI
		{
			get { return pi; }
			// set { pi = value; }          // because it's readonly attribute (cannot have set) but can change the value at the constructor it self
		}

		
		// Constant 
		private const int constVariable = 1_000_000;        // the value must be provided here in declaration and cannot be changed after 

		public static int ConstVariable
		{
			get { return constVariable; }
			// set { constVariable = value; }               // Const variable cannot have set method in the property (cannot be changed)
		}



        // Static Methods 
        public static double CmToInch(double cm)
		{
			return cm * 2.54;
		}

		public static double CalcCircleArea(double Radius)
		{
			return PI * Radius * Radius;
		}
	}
}
