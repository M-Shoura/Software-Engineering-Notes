using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities.Order_Aggregate;

namespace Talabat.Core.Services.Contract
{
    public interface IOrderService
    {
        // 1 - Create Order
        Task<Order?> CreateOrderAsync(string buyerEmail, string basketId, int deliveryMethodId, Address shippingAddress);


        // 2 - All Orders for specific User
        Task<IReadOnlyList<Order>> GetOrdersForUserAsync(string buyerEmail);


        // 3 - Specific Order for a specific User
        Task<Order?> GetOrderByIdForUserAsync(int orderId, string buyerEmail);


        // 4 - Get All Delivery Methods
        Task<IReadOnlyList<DeliveryMethod>> GetDeliveryMethodsAsync();
    }
}
