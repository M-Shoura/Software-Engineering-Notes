using System.Linq;
using System.Text.Json.Serialization;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.API.DTOs
{
    public class OrderToReturnDTO
    {
        public int Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }

        [JsonIgnore]
        public Address ShippingAddress { get; set; }
        // Note : Use [JsonIgnore] Json Ignore data annotation to stop the error of Swagger , above the navigational properties 
        //        or objects from classes inside a class (didn't know how to solve this problem , use this data annotation and it will
        //        also not be ignored in the Json !!! )



        // Changed to String , instead of OrderStatus .. to get it from the database as string as we want
        // (notice : the configuration written before + using [EnumMember()] in the Enum)
        public string Status { get; set; }                     
        

        public string DeliveryMethod { get; set; }              // must write configuration to be mapped from the DeliveryMethod nav property
        public decimal DeliveryMethodCost { get; set; }         // must write configuration to be mapped from the DeliveryMethod nav property


        public ICollection<OrderItemDTO> Items { get; set; } = new HashSet<OrderItemDTO>(); // Using a DTO here ... Flatten ProductItemOrdered
        public decimal SubTotal { get; set; }
        
        
        public decimal Total {  get; set; }
        // without writing any configuration , this property will take it's value from the derived attribute as a getter method (GetTotal)

        public string PaymentIntentId { get; set; } = "";
    }
}
