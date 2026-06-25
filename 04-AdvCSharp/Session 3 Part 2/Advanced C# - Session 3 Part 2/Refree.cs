using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_2
{
	// subscriber
	internal class Refree
	{
		public Refree(string? name)
		{
			Name = name;
		}

		public string? Name { get; set; }

		public override string ToString() => $"Refree: {Name}";

		public void Look(object? sender, LocationEventArgs eventArgs)
		{
			Ball? ball = sender as Ball;
			Console.WriteLine($"{this} : Refree is looking at the ball >>> {eventArgs.NewLocation} , Fired by: {ball?.Id} ");
		}
	}
}
