using AutoMapper;
using Talabat.API.DTOs;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Entities.Order_Aggregate;
using Talabat.Core.Entities.Products;


namespace Talabat.API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product,ProductToReturnDTO>()
                .ForMember(dest => dest.BrandName , o => o.MapFrom(src => src.Brand.Name))
                .ForMember(dest => dest.CategoryName , o => o.MapFrom(src=>src.Category.Name))
                .ForMember(dest => dest.PictureUrl, o => o.MapFrom<ProductPictureUrlResolver>());


            CreateMap<CustomerBasketDTO, CustomerBasket>();
            CreateMap<BasketItemDTO, BasketItem>();

            CreateMap<Core.Entities.Order_Aggregate.Address, AddressDTO>().ReverseMap();


            CreateMap<Order, OrderToReturnDTO>()
                .ForMember(dest => dest.DeliveryMethod, opt => opt.MapFrom(src => src.DeliveryMethod.ShortName))
                .ForMember(dest => dest.DeliveryMethodCost, opt => opt.MapFrom(src => src.DeliveryMethod.Cost));

            CreateMap<OrderItem, OrderItemDTO>()
                .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.Product.ProductId))
                .ForMember(dest => dest.ProductName, opt => opt.MapFrom(src => src.Product.ProductName))
                .ForMember(dest => dest.PictureURL, opt => opt.MapFrom(src => src.Product.PictureURL))
                .ForMember(dest=>dest.PictureURL, opt => opt.MapFrom<OrderItemPictureUrlResolver>());
        }
    }
}
