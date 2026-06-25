namespace OOP___Session_2
{
	internal class Car
	{
        #region Constructors

        public Car()
        {
        	  
        }

        // If you define a constructor , compiler will no longer generate empty parameterless constructor
        public Car(int _id , string _model , double _speed)
        {
            id = _id ;
			name = _model ;
			speed = _speed ;
            Console.WriteLine("Ctor 1");
        }

		public Car(int _id, string _model) : this (_id , _model , 180)
		{
			// id = _id;                      // Constructor chaining 
			// model = _model;                // Constructor chaining
			// speed = 180;                   // Constructor chaining
			Console.WriteLine("Ctor 2");
		}

		public Car(int _id) : this(_id , "Kia 2024")
		{
			// id = _id;                     // Constructor chaining
			// model = "Kia 2024";			 // Constructor chaining
			speed = 160;
			Console.WriteLine("Ctor 3");
		}

        #endregion

        #region Properties

        // in our case it's better to be automatic properties ... , but they are now full properties : 
        private int id;
        public int Id
		{
			get { return id; }
			set { id = value; }
		}
        private string? name;
		public string? Name
		{
			get { return name; }
			set { name = value; }
		}
        private double speed;
		public double Speed
		{
			get { return speed; }
			set { speed = value; }
		}

		#endregion

		#region Methods

		public override string ToString()
		{
			return $"Id: {id} \nModel:{name} \nSpeed: {speed}";
		}

		#endregion
	}
}
