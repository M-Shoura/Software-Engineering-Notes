namespace Advanced_C____Session_3_Part_2
{
	internal class Program
	{
		static void Main(string[] args)
		{
			#region Self Study and Notes

			/* Start *****************************************************************************************************************/



			/* End ******************************************************************************************************************/

			#endregion

			#region What is Event-Driven Programming ?

			/* Start *****************************************************************************************************************/

			// Event - Driven Programming Paradigm : When the "Event" fires from the "Publisher" , We "Notify" all the "Subscribers"
			// Remeber : we can write in the class : 1 - , 2 - , 3 - , 4 - Events

			// Ex : A football game , containing Ball , Players , Refree
			//      - the players subscribe to the ball location , if the location changed then they are notified
			//      - the refree also subscribe to the ball location , if the location changed then they are notified

			// Usually the Event is "Public" inside the class , it's a delegate that can reference many functions (+= is used here)

			// Note : Methods that we subscribe with can be object member methods , class member methods , anonymous methods , static or non-static , ...

			///////////////////////////////// We invoke the functions that the event reference them (invokation list : list ocntainig methods that will fire if the subscribers are notified)

			Ball ball = new Ball(101100);
			Player P1Team1 = new Player("Ronaldo", "R.Madrid");
			Player P2Team1 = new Player("Abo-Treka", "R.Madrid");

			Player P1Team2 = new Player("Messi", "Barca");
			Player P2Team2 = new Player("Haland", "Barca");

			Refree refree = new Refree("Gresha");


			// Till now there is no subscribers !
			Console.WriteLine(ball.Location);


			// Subscription [Registration]
			ball.LocationChanged += P1Team1.Run;
			ball.LocationChanged += P2Team1.Run;
			ball.LocationChanged += P1Team2.Run;
			ball.LocationChanged += P2Team2.Run;
			ball.LocationChanged += refree.Look;


			ball.Location = new Location(10, 10, 10);

			Console.WriteLine();
			Console.WriteLine($"{P1Team1} ( P1Team1 ) is fired ! and not interested in the ball location any more");
			Console.WriteLine();

			// Unsubscribe :
			ball.LocationChanged -= P1Team1.Run;


			ball.Location = new Location(20, 20, 20);

			Console.WriteLine();

			// new ball created to use the function of the "sender" and see if there is multiple senders
			Ball ball2 = new Ball(202222);
			ball2.LocationChanged += P1Team1.Run;

			ball2.Location = new Location(100, 100, 100);


			/* End ******************************************************************************************************************/

			#endregion
		}
	}
}
