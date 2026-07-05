using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using StackExchange.Redis;
using System.Text;
using Talabat.API.Extensions;
using Talabat.API.Middlewares;
using Talabat.Core.Entities.Identity;
using Talabat.Core.Services.Contract;
using Talabat.Repository.Generic_Repository.Data;
using Talabat.Repository.Identity;
using Talabat.Service.AuthService;

namespace Talabat.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var webApplicationbuilder = WebApplication.CreateBuilder(args);

            #region Configure Services

            webApplicationbuilder.Services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;  // default .Serialize
            });

            webApplicationbuilder.Services.AddDbContext<StoreDbContext>(options =>
            {
                options.UseSqlServer(webApplicationbuilder.Configuration.GetConnectionString("DefaultConnection"));
            });

            webApplicationbuilder.Services.AddSwaggerServices();

            webApplicationbuilder.Services.AddApplicationServices();


            // For Redis (scoped as the DbContext , will be changed in the last session when implementing caching)
            webApplicationbuilder.Services.AddScoped<IConnectionMultiplexer>((serviceProvider) =>
            {
                var connectionString = webApplicationbuilder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connectionString);
            });


            webApplicationbuilder.Services.AddDbContext<ApplicationIdentityDbContext>(options =>
            {
                options.UseSqlServer(webApplicationbuilder.Configuration.GetConnectionString("IdentityConnection"));
            });


            // Register for 3 Services : User manager , Sign In manager , Role manager , and can change the identity system configurations : 
            webApplicationbuilder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                // options.Password.RequiredUniqueChars = 2 ;
                // options.Password.RequireNonAlphanumeric = true ;
                // options.Password.RequireDigit = true ;

                // we will not configure this here .. we will put a regular expression in the RegisterDTO used in the Register Endpoint
                // Why ? 
                // Because Configurations written here are executed when "CreateUser" at the last step in executing the endpoint .. so
                // it's better to write a regular expression in the RegisterDTO so that the endpoint will not be executed if the password
                // doesn't match the REGEX
            }).AddEntityFrameworkStores<ApplicationIdentityDbContext>();



            webApplicationbuilder.Services.AddAuthServices(webApplicationbuilder.Configuration);

            #endregion

            var app = webApplicationbuilder.Build();



            using var scope = app.Services.CreateScope();
            var services = scope.ServiceProvider;

            var _dbContext = services.GetRequiredService<StoreDbContext>();
            var _IdentityDbContext = services.GetRequiredService<ApplicationIdentityDbContext>();

            try
            {
                await _dbContext.Database.MigrateAsync();
                await StoreContextSeed.SeedAsync(_dbContext);
                await _IdentityDbContext.Database.MigrateAsync();   // Update Identity Database

                var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>();
                await ApplicationIdentityDataSeed.SeedUsersAsync(_userManager);
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
                app.AddSwaggerMiddlewares();
            }


            app.UseStatusCodePagesWithReExecute("/errors/{0}");
            app.UseHttpsRedirection();
            app.UseStaticFiles();


            app.MapControllers();

            app.UseAuthentication();
            app.UseAuthorization();

            #endregion

            app.Run();
        }
    }
}
