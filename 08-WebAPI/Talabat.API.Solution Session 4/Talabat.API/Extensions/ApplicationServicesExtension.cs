using Microsoft.AspNetCore.Mvc;
using StackExchange.Redis;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository.Basket_Repository;
using Talabat.Repository.Generic_Repository;

namespace Talabat.API.Extensions
{
    public static class ApplicationServicesExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            
            services.AddAutoMapper(typeof(MappingProfile));
            
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {
                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(e => e.Value.Errors)
                                                         .Select(e => e.ErrorMessage)
                                                         .ToArray();
                    var response = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(response);
                };
            });

            services.AddScoped(typeof(IBasketRepository), typeof(BasketRepository));

            return services;
        }
    }
}
