namespace Advanced__C____Session_1
{
	internal class Point : IComparable<Point>
	{
		public int X { get; set; }
		public int Y { get; set; }

		public Point(int _X, int _Y)
		{
			X = _X;
			Y = _Y;
		}
		public override string ToString()
		{
			return $"X = {X} , Y = {Y}";
		}

		public int CompareTo(Point? p)
		{
			// it's not important to cast here , we used the generic IComparable interface
			if (p == null)
				return 1;

			if (this.X == p.X)
				return this.Y.CompareTo(p.Y);
			return this.X.CompareTo(p.X);
		}
	}
}
