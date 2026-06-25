namespace OOP___Session_4.Abstraction
{
	internal class Circle : Shape
	{
		public Circle(decimal radius) : base(radius , radius)
		{
			// Dim01 = Dim02 = radius;
		}
		public override decimal Perimeter
		{
			get { return 2 * 3.14m * Dim01; }
		}

		public override decimal CalcArea()
		{
			return 3.14m * Dim01 * Dim01;
		}
	}
}
