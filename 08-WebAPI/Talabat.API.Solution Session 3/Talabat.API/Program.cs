using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Talabat.API.Errors;
using Talabat.API.Extensions;
using Talabat.API.Helpers;
using Talabat.API.Middlewares;
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

            webApplicationbuilder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(webApplicationbuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            webApplicationbuilder.Services.AddSwaggerServices();         // instead of adding the services here
           
            webApplicationbuilder.Services.AddApplicationServices();     // instead of adding the services here

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
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                var logger = loggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "An error occured during applying the migrations");
            }


            #region Configure Middlewares

            app.UseMiddleware<ExceptionMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.AddSwaggerMiddlewares();              // instead of adding the services here
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseStatusCodePagesWithReExecute("/errors/{0}");         

            app.MapControllers();

            #endregion

            app.Run();
        }
    }
}
