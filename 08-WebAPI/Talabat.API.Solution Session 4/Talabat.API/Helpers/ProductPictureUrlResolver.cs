using AutoMapper;
using Talabat.API.DTOs;
using Talabat.Core.Entities.Products;

namespace Talabat.API.Helpers
{
    public class ProductPictureUrlResolver : IValueResolver<Product, ProductToReturnDTO, string>
    {
        private readonly IConfiguration _configuration;

        public ProductPictureUrlResolver(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string Resolve(Product source, ProductToReturnDTO destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.PictureUrl))
            {
                string baseURL = _configuration["ApiBaseURL"];
                return $"{baseURL}/{source.PictureUrl}";
            }
            return string.Empty;
        }
    }
}
