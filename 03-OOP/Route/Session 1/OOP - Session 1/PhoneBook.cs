namespace OOP___Session_1
{
    internal struct PhoneBook
	{
		#region Attributes

		// All of them are private (default access modifier inside a class or struct)
		string[] names;
		long[] numbers;

		#endregion

		#region Constructors

		// The default constructor which is hidden : 
		// public PhoneBook()
		// {
		//     names = null;           // it's an array , default value = null;
		// 	   numbers = null;         // it's an array , default value = null;
		// 	   size = 0;
		// }

		public PhoneBook(int _size)
		{
			size = _size;
			names = new string[size];
			numbers = new long[size];
		}

		#endregion

		#region Properties

		// in this case it's better to be an automatic property : public int Size { get; }
		int size;
		public int Size
		{
			get { return size; }            // Read-Only property 
        }

		#endregion

		#region Methods (old way before indexers)

		public void AddPerson(int Position, string Name, long Number)
		{
			if (numbers is not null && names is not null)
			{
				if (Position < size)                                      // if(Position >= 0) , but it's an unsigned int  
				{
					names[Position] = Name;
					numbers[Position] = Number;
				}
			}
		}

		// Getter
		public long GetNumber(string Name)
		{
			if (names is not null && numbers is not null)
			{
				for (int i = 0; i < size; i++)
				{
					if (names[i] == Name)
						return numbers[i];
				}
			}
			return -1;
		}

		// Setter
		public void SetNumber(string Name, long Number)
		{
			if (names is not null && numbers is not null)
			{
				for (int i = 0; i < size; i++)
				{
					if (names[i] == Name)
					{
						numbers[i] = Number;
						return;
					}
				}
			}
		}

		#endregion

		#region Indexer (Special Property)

		public long this[string Name]
		{
			get 
			{          // same implementation for "GetNumber" method above ..
				if (names is not null && numbers is not null)
				{
					for (int i = 0; i < size; i++)
					{
						if (names[i] == Name)
							return numbers[i];
					}
				}
				return -1;
			}
			set
            {          // same implementation for "SetNumber" method above ..
                if (names is not null && numbers is not null)
				{
					for (int i = 0; i < size; i++)
					{
						if (names[i] == Name)
						{
							numbers[i] = value;
							return;
						}
					}
				}
			}
		}

		// indexer overloading(having more than one indexer)
		public string this[int index]
		{
			get
			{
				return $"Index: {index} , Name: {names[index]} , Number: {numbers[index]}";
			}
		}

		#endregion
	}
}
