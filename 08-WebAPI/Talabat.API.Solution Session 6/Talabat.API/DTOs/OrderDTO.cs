using System.ComponentModel.DataAnnotations;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.API.DTOs
{
    public class OrderDTO
    {
        // [Required]
        // public string BuyerEmail { get; set; }            // We will get the email from the Token .. 
        
        [Required]
        public string BasketId { get; set; }
        
        [Required]
        public int DeliveryMethodId { get; set; }
        
        public AddressDTO ShippingAddress { get; set; }
    }
}
