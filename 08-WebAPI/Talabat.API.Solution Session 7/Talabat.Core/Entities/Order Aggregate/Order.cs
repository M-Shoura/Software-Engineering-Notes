using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Talabat.Core.Entities.Order_Aggregate
{
    public class Order : BaseEntity
    {
        // The EFCore (When making migration) wants a accessable empty parameterless constructor for classes that will be mapped to table 
        // or classes used inside classed mapped to tables so we will make empty constructors for all the classes we've made in order module
        // These Ctors can be private also , to have only by the efcore when generating tables and forcing users to use the other ctors
        public Order()
        {

        }

        public Order(string buyerEmail, Address shippingAddress, DeliveryMethod deliveryMethod, ICollection<OrderItem> items, decimal subTotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DeliveryMethod = deliveryMethod;
            Items = items;
            SubTotal = subTotal;
        }

        // Why we have BuyerEmail here instead of BuyerId ? (Email contained in the Token)
        // security issue , to prevent a user to see orders of another user if he got his id , instead we can verify that the email that 
        // came from the Token = BuyerEmail of the order .. so no user can see orders of another user unless he logged in with his account.
        // So if the BuyerId is contained in the Token then The two properties are the same and prevent any security issue
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTime.UtcNow;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;

        
        public Address ShippingAddress { get; set; }
        // Note : Address is not a navigational property , will be mapped in the database in one table (1-1 total participation from 2 sides)

        
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal SubTotal { get; set; }

        // public int DeliveryMethodId { get; set; }              // Foreign Key
        // We can comment it and Get it from the database + EFCore tracks it .. and it will be known automatically without the Foreign Key
       
        public DeliveryMethod DeliveryMethod { get; set; }        // navigational property one 


        // public decimal Total { get; set; }
        // "Total" is a derived attribute , can be implemented by two ways : 
        // 1 - Readonly property (only get) + [NotMapped] data annotation
        //     Ex: 
        // 
        //     [NotMapped]
        //     public decimal Total { get { return SubTotal + DeliveryMethod.Cost; } }
        //        or (new syntax)
        //     [NotMapped]
        //     public decimal Total => SubTotal + DeliveryMethod.Cost;
        //
        // 2 - getter method (start with "Get" , to be automatically mapped later when using order DTO GetTotal mapped to Total in DTO)
        //     Note : Function must be called "GetX" , and property in DTO must be called "X"
        //     This is a derived attribute 
        //     Ex:
        //
        //     public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;


        public decimal GetTotal() => SubTotal + DeliveryMethod.Cost;


        // Will be used next session with Payment Module , written here to avoid making a new migration .. 
        // initialized with empty string because it's required (not nullable) , and we will not use it this sessions at all   
        public string PaymentIntentId { get; set; } = "";      

    }
}
