using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advanced_C____Session_3_Part_2
{

	class LocationEventArgs : EventArgs
	{
        public Location NewLocation { get; set; }		
    }

    // Publisher
	internal class Ball
	{
        public int Id { get; set; }

		public Ball(int id)
		{
			Id = id;
		}


		// public /* event */ Action<Location>? LocationChanged;
		// we can delete the keyword "event" and every thing will work properly BUT There are 2 small problems:
		// 1 - "LocationChanged" now is named in Visual Studio as a field (not a major problem)
		// 2 - if accidently writing this in the main : 

		// ball.LocationChanged += P1Team1.Run;
		// ball.LocationChanged += P2Team1.Run;
		// ball.LocationChanged += P1Team2.Run;
		// ball.LocationChanged += P2Team2.Run;

		// ball.LocationChanged = refree.Look;             // = only not += or -=

		// Then we will only subscribe to the last one , with = only and we will delete the old ones from the invocation list
		// but when using the keyword "event" we will be restricted to use only += or -= (subscribe or unsunscribe) and this is better .. 

		// Moreover , Action & Predicate & Func are not used here with Events .. The recomendation is to use a special delegate "EventHandler" ,
		// which has a non-generic version and a generic one ... Every class subscribes must follow the signature of this delegate "EventHandler"
		// it is : public delegate void EventHandler(object? sender, EventArgs e);   "Non-generic version"
		// means : returns void and takes two arguments , first is the "sender" which notifies (usefull when we have many sernders for notifications
		// and we want to know who notified me ) ... and the second is "EventArgs" object , an object of EventArgs class (it's an empty class) or 
		// any type that inherits from it , it's usefull when we want to send anything with the event (ex: new location in our example)

		public event EventHandler<LocationEventArgs> LocationChanged;

		private Location location;
		public Location Location
        {
            get => location; 
            set 
            { 
                if(!location.Equals(value))
                {
                    location = value;

                    // Fire Event
                    // Notify Subscribers
                    // LocationChanged?.Invoke(location);

					// In the recomendation in Dot Net .. we don't invoke the event directly as the previous line , we make a
					// new protected virtual method to invoke the event there
					// Why ? Because if there is a class that inherits from the "Ball" class , and wants to invoke the event 
					//       protected makes it possible to invoke the event in the child
					//       virtual allows overriding the method in the child 

					On_LocationChanged(location);
                }
            }
        } 

		protected virtual void On_LocationChanged(Location location)
		{
			LocationChanged?.Invoke(this , new LocationEventArgs() { NewLocation = location});
		}

	}
}
