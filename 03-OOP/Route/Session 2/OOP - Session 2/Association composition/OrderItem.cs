namespace OOP___Session_2.Association_composition
{
	internal class OrderItem
	{
		// Association Composition Relationship ( Has a )
		// OrderItem has an Item

		public int Id { get; set; }
		public Product Product { get; set; }             // if it's nullable Product then it may be an aggregation relationship
		                                                 // not a must ofcourse but check the constructor .. 
		public decimal Price { get; set; }               // Price of the product (if maybe there is a sale or buy 5 get 10% discount ..)
														 // Can equal the price of the product , no problem 
		public int Quantity { get; set; }


		// To make an object of type OrderItem , you must send an object of Product class in the ONLY ONE constructor here ..
		// So it's a must to make an OrderItem object to make a Product object (has a relationship) (Mandatory ==> Composition)

		public OrderItem(Product product)
		{
			Product = product;
		}
	}
}
