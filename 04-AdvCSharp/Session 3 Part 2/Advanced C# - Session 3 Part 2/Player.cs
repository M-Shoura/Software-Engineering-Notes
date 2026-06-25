using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_2
{
	// subscriber
	internal class Player
	{
		public Player(string? name, string? team)
		{
			Name = name;
			Team = team;
		}

		public string? Name { get; set; }
        public string? Team { get; set; }

		public override string ToString() => $"Name: {Name} , Team: {Team}";

		public void Run(object? sender , LocationEventArgs eventArgs)
		{
			Ball? ball = sender as Ball;
            Console.WriteLine($"{this} : Player is running towards the ball >>> {eventArgs.NewLocation} , Fired by: {ball?.Id}");
        }
	}
}
