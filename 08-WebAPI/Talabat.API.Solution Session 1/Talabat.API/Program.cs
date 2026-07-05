using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
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

            webApplicationbuilder.Services.AddControllers();              // for API project only
            // builder.Services.AddControllersWithViews();     // for MVC project only
            // builder.Services.AddRazorPages();               // for Razor Pages project only
            // builder.Services.AddMvc();                      // for All project


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            webApplicationbuilder.Services.AddEndpointsApiExplorer();     // For Swagger
            webApplicationbuilder.Services.AddSwaggerGen();               // For Swagger


            // to avoid installing the package again "Microsoft.EntityFrameworkCore.SqlServer" , we addedd a project reference here in
            // API to the Repository project
            webApplicationbuilder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(webApplicationbuilder.Configuration.GetConnectionString("DefaultConnection"));
            });


            // webApplicationbuilder.Services.AddScoped<IGenericRepository<Product>,GenericRepository<Product>>();
            // webApplicationbuilder.Services.AddScoped<IGenericRepository<ProductBrand>,GenericRepository<ProductBrand>>();
            // webApplicationbuilder.Services.AddScoped<IGenericRepository<ProductCategory>,GenericRepository<ProductCategory>>();
            // or 
            webApplicationbuilder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            #endregion

            var app = webApplicationbuilder.Build();

            using var scope = app.Services.CreateScope();              // using => Unmanaged Code , not controller by the CLR
            var services = scope.ServiceProvider;
            
            // ASK the CLR for creating an object from the DbContext but Explicitly
            var _dbContext = services.GetRequiredService<StoreDbContext>();
            
            try
            {
                await _dbContext.Database.MigrateAsync();      // don't miss changing the main function to by async Task ... 
                await StoreContextSeed.SeedAsync(_dbContext);  // Data Seeding
            }
            catch (Exception ex)
            {
                // Logging the error in a good way .. same as writing on the Kestrel console screen
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();   // DI is enabled when "AddControllers() in services"
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex,"An error occured during applying the migrations");
            }


            #region Configure Middlewares

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();      // for swagger
                app.UseSwaggerUI();    // for swagger
            }

            app.UseHttpsRedirection();       // redirecting http request to https


            // in MVC : 
            // app.UseRouting();                      // Matches request to an endpoint
            // app.UseEndPoints( endpoints =>         // Execute the matched endpoint
            // {
            //     endpoints.MapControllerRoute(
            //        name: "default",
            //        pattern: "{controller}/{action}/{id?}"
            //     )
            // }); 

            // in APIs : 
            // because we handle the Routing in Each controller using the [Route] attribute data annotation (this is the most common used
            // way , if we want to use the MVC last way then no problem )

            // app.UseRouting();                    
            // app.UseEndPoints(endpoints =>        
            // {
            //     endpoints.MapControllers();      // executed the routing that is in the controller itself
            // });

            // in .Net 6 .. why using the previous much code ? app.MapControllers(); does the same !

            app.MapControllers();                  // rely on the attribute [Route] in the controller
             
            #endregion

            app.Run();
        }
    }
}
