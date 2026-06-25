namespace OOP___Session_4.Abstraction
{
	internal abstract class Shape
	{
		public decimal Dim01 { get; set; }  /* = default */       // done by new keyword
		public decimal Dim02 { get; set; }  /* = default */		  // done by new keyword

        // Abstract Property
        public abstract	 decimal Perimeter { get; }        // same to the automatic property but with abstract keyword !


        protected Shape(decimal _Dim01, decimal _Dim02)
        {
			Dim01 = _Dim01; 
			Dim02 = _Dim02;
        }


        // Abstract Method
        public abstract decimal CalcArea();
		// because i don't know how to implement this function , because it depends on the shape it self and there
		// is no standard form for calculating the area .. It is Abstract Method
		// Note : Abstract methods Must be in Abstract Classes ONLY

		public void TestReference()
		{
			Console.WriteLine("HI TEST");
		}
	}
}
