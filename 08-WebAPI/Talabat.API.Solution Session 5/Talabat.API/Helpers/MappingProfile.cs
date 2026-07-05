using AutoMapper;
using Talabat.API.DTOs;
using Talabat.Core.Entities.Basket;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Entities.Products;
using static System.Net.WebRequestMethods;

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


            CreateMap<Address, AddressDTO>().ReverseMap();

        }
    }
}
