using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace OOP___Session_2.Association_composition
{
	internal class Order
	{
		// Association Composition Relationship ( Has a )
		// Order has a OrderItems

		public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public decimal SubTotal { get; set; }
        public OrderItem[] Items { get; set; }
        public decimal ShippingPrice { get; set; }


		// To make an object of type Order , you must send an object of OrderItem class in the ONLY ONE constructor here ..
		// So it's a must to make an Order object to make a OrderItem object (has a relationship) (Mandatory ==> Composition)

		public Order(string buyerEmail , OrderItem[] items)
        {
            BuyerEmail = buyerEmail;
            Items = items;   
        }
    }
}
