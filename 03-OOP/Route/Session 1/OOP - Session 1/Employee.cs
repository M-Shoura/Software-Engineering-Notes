namespace OOP___Session_1
{
	internal struct Employee
	{
		// Attributes 
		public int Id;
		private string Name;

		public Employee(int _id, string _name, int age , decimal _salary)
		{
			Id = _id;
			Name = _name;
			Salary = _salary;
			Age = age; 
		}

		public Employee(string _name , int _age)
		{
			Name = _name;
			Age =_age;
		}

		#region Encapsulation : using Getter and Setter

		/* Start *****************************************************************************************************************/

		// Apply encapsulation : using getter and setter (old way)
		// Note : It's not a must to use both , we can have getter only without setter or vice versa	
		// Getter :
		public string GetName()
		{
			return Name;
		}

		// Setter : 
		public void SetName(string _name)
		{
			// we can have any logic here and data validation !
			Name = _name?.Length > 5 ? _name.Substring(0, 5) : _name ?? "";
		}

		/* End ******************************************************************************************************************/

		#endregion


		#region Encapsulation : using Property (Full Property & Automatic Property)

		/* Start *****************************************************************************************************************/

		// Apply encapsulation : using Property [Recommended : Easy use like working with the attributes itself]
		
		// 1 - full properties
		private decimal salary;
		public decimal Salary
		{
			get { return salary; }
			set { salary = value > 1_000 ? 1_000 : value; }                          // some logic here 

		}
		
		private decimal deduction;
		public decimal Deduction    // Read only property (without set)
		{
			get { return Salary * 0.1m > 1_000 ? 1_000 : Salary * 0.1m; }
		}


        // 2 - Automatic property                                              
        // private int age;                       // because it's an automatic property a hidden Backing field is generate 
        public int Age { get; set; }

        /* End ******************************************************************************************************************/

        #endregion


        public override string ToString()
		{
			return $"Id : {Id} \nName : {Name} \nAge : {Age} \nSalary : {salary} \nDeduction : {deduction}";
            // inside the struct or the class use the attribute directly ... not the property
        }
    }
}
