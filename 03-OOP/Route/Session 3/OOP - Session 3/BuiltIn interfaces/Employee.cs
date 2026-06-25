namespace OOP___Session_3.BuiltIn_interfaces
{
	internal class Employee : ICloneable , IComparable
	{
		public int Id { get; set; }
		public string? Name { get; set; }
		public decimal Salary { get; set; }
        public Department? Department { get; set; }

        public Employee()
        {
            
        }
		// Special constructor , takes one parameter of the same type and is used to make Deep Copy	
		public Employee(Employee emp)
        {
            this.Id = emp.Id;
			this.Name = emp.Name;
			this.Salary = emp.Salary;
			this.Department = (Department?)emp?.Department?.Clone();
        }
        public object Clone()
		{
			// this ==> The calling object that will be copied 
			return new Employee()
			{
				Id = this.Id,
				Name = this.Name,
				Salary = this.Salary,
				// Department = this.Department         // This is wrong , because it's a reference type that is immutable , check the  
				//									    // region "Clone Method and Why it says that it makes a Shallow Copy ???"
				Department = (Department?) this?.Department?.Clone()
			};
			/// OR	
			return new Employee(this);                  // use the copy constructor here  
		}

		public override string ToString()
		{
			return $"Id: {Id}, Name: {Name}, Salary:{Salary} , {Department?.ToString()??""}";
		}

		// Choose what you is the sorting based on ? ==> ex: salary  
		// +VE value if this.Salary > obj.Value
		// -VE value if this.Salary < obj.Value
		// Zero if this.Salary == obj.Value
		public int CompareTo(object? obj)
		{
			Employee? emp = (Employee?)obj;       // UnSafe , we will know the safe way in the first session in Advanced C# (Generics)

			// if(emp == null)         // Not important , handeled by the next if , salary>null ==> always true 
			// 	   return 1 ;
			
			if (this.Salary > emp.Salary)
				return 1;
			else if(this.Salary < emp.Salary)
				return -1;
			return 0;


			/// OR
			// Better
			return this.Salary.CompareTo(emp.Salary);        // Here we used the "ComapreTo" function of the Decimal that is implemented
			return - this.Salary.CompareTo(emp.Salary);      // For sorting Descending
		}

		// // Sort Descending by two ways ===>
		// 
		// public int CompareTo(object? obj)
		// {
		// 	Employee? emp = (Employee?)obj;
		// 
		// 	if (this.Salary < emp.Salary)            // or return -1  
		// 		return 1;
		// 	else if (this.Salary > emp.Salary)       // or return 1
		// 		return -1;
		// 	return 0;
		// }
	}
}
