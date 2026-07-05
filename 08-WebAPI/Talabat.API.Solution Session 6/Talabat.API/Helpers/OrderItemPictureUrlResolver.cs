using AutoMapper;
using Talabat.API.DTOs;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;

namespace Talabat.API.Helpers
{
    public class OrderItemPictureUrlResolver : IValueResolver<OrderItem, OrderItemDTO, string>
    {
        private readonly IConfiguration _configuration;

        public OrderItemPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(OrderItem source, OrderItemDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.Product.PictureURL))
            {
                string baseURL = _configuration["ApiBaseURL"];
                return $"{baseURL}/{source.Product.PictureURL}";
            }
            return string.Empty;
        }
    }
}
