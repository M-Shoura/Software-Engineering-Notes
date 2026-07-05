using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.API.Errors;
using Talabat.API.Helpers;
using Talabat.API.Middlewares;
using Talabat.Core.Entities.Products;
using Talabat.Core.Repositories.Contract;
using Talabat.Repository;
using Talabat.Repository.Data;

namespace Talabat.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationbuilder = WebApplication.CreateBuilder(args);
            
            #region Configure Services

            webApplicationbuilder.Services.AddControllers();           
            
            webApplicationbuilder.Services.AddEndpointsApiExplorer();    
            webApplicationbuilder.Services.AddSwaggerGen();              

            webApplicationbuilder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(webApplicationbuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            webApplicationbuilder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));


            // webApplicationbuilder.Services.AddAutoMapper(m=>m.AddProfile(new MappingProfile()));
            // webApplicationbuilder.Services.AddScoped<ProductPictureUrlResolver>();
            // or
            webApplicationbuilder.Services.AddAutoMapper(typeof(MappingProfile));



            // Handling Validation Errors
            webApplicationbuilder.Services.Configure<ApiBehaviorOptions>(options =>
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


            #endregion

            var app = webApplicationbuilder.Build();


            
            using var scope = app.Services.CreateScope();             
            var services = scope.ServiceProvider;
            
            var _dbContext = services.GetRequiredService<StoreDbContext>();
            
            try
            {
                await _dbContext.Database.MigrateAsync();      
                await StoreContextSeed.SeedAsync(_dbContext);  
            }
            catch (Exception ex)
            {
               var loggerFactory = services.GetRequiredService<ILoggerFactory>();   // DI is enabled when "AddControllers() in services"
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex,"An error occured during applying the migrations");
            }


            #region Configure Middlewares

            // app.UseDeveloperExceptionPage();     // by default used with .Net 6 and later

            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();      
                app.UseSwaggerUI();    
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            // First create a new controller "ErrorsController"
            
            // app.UseStatusCodePagesWithRedirects("/errors/{0}");        // two requests because of redirecting
            // or
            app.UseStatusCodePagesWithReExecute("/errors/{0}");           // one request with the same URL

            app.MapControllers();            
             
            #endregion

            app.Run();
        }
    }
}
