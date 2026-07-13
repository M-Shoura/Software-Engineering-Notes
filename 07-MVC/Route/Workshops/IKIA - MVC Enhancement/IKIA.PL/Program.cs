using IKIA.BLL.Common.Services.Attachments;
using IKIA.BLL.Common.Services.Emails;
using IKIA.BLL.Services.Departments;
using IKIA.BLL.Services.Employees;
using IKIA.DAL.Models.Identity;
using IKIA.DAL.Presistence.Data;
using IKIA.DAL.Presistence.UnitOfWork;
using IKIA.PL.Emails;
using IKIA.PL.Mapping;
using IKIA.PL.SMS;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Configuration;

namespace IKIA.PL
{
    public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.
			builder.Services.AddControllersWithViews();


			builder.Services.AddDbContext<ApplicationDbcontext>(optionsBuilder =>
			{
				optionsBuilder
				.UseLazyLoadingProxies()
				.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
			});




			// Now we will comment them because we will use the Unit Of Work , no requesting objects from the CLR of type Repositories again
			// builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
			// builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
			builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

			builder.Services.AddScoped<IDepartmentService, DepartmentService>();
			builder.Services.AddScoped<IEmployeeService, EmployeeService>();


			builder.Services.AddAutoMapper(m => m.AddProfile(new MappingProfile()));
			// or
			// builder.Services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

			builder.Services.AddTransient<IAttachmentService, AttachmentService>();


			// allowing the dependency injection for the User Manager service and SignIn Manager service and Role Manager service ...
			// and also the minor services (ex: service for hashing the password , ... )    
			// instead of adding the services one by one , we can add all the identity services to the dependency injection container
			// using : "AddIdentity<>()" which has 2 overloads  
			// First  => Adds the default identity system configurations for the specified user and role types and adds the 3 services + the
			//           mino services they depend on
			// Second => Adds and configures the identity system for the specified user and role types and adds the 3 services + the
			//           minor services they depend on

			builder.Services.AddIdentity<ApplicationUser, IdentityRole>((options) =>
			{
				options.Password.RequireNonAlphanumeric = true;
				options.Password.RequireUppercase = true;
				options.Password.RequireLowercase = true;
				options.Password.RequireDigit = true;
				options.Password.RequiredLength = 5;          // min length = 5

				options.User.RequireUniqueEmail = true;

				options.Lockout.MaxFailedAccessAttempts = 3;
				options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

			}).AddEntityFrameworkStores<ApplicationDbcontext>()
			  .AddDefaultTokenProviders();         // used for generating tokens for reset password , change email , .....	
			// register the Indentity stores (repositories) to the Dependency injection container (remeber : same as what we did with
			// the repositoreis beforet unit of work)
			// Note : we can add stores (Repositories) other than the default stores , we can add services other than the default services



			builder.Services.ConfigureApplicationCookie((option) => // these configurations are for the defaul schema "Identity.Application"
			{
				option.LoginPath = "/Account/SignIn";
				option.AccessDeniedPath = "/Home/Error";
				option.ExpireTimeSpan = TimeSpan.FromDays(1);
			});

			// builder.Services.AddAuthentication();  // this overload is called by "AddIdentity" , so we write it when using other overload
			// builder.Services.AddAuthentication("Identity.Application");   
			// builder.Services.AddAuthentication(options =>
			// {
			// 	options.DefaultAuthenticateScheme = "Identity.Application";
			// 	options.DefaultChallengeScheme = "Identity.Application";
			// });

			// The second is for changing the default schema only
			// The third is for changing the default schema and change other configurations


			builder.Services.AddTransient<IEmailService , EmailService>();




			// New Email
			builder.Services.Configure<NewEmailSettings>(builder.Configuration.GetSection("NewEmailSettings"));
			builder.Services.AddTransient<INewEmailService , NewEmailService>();


			// SMS 
			builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
			builder.Services.AddTransient<ISmsService ,  SmsService>();


			// External Login with Google
			builder.Services.AddAuthentication(o =>
			{
				o.DefaultAuthenticateScheme = GoogleDefaults.AuthenticationScheme;
				o.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
			}).AddGoogle(o =>
			{
				IConfiguration GoogleAuthSection = builder.Configuration.GetSection("Authentication:Google");
				o.ClientId = GoogleAuthSection["ClientId"];
				o.ClientSecret = GoogleAuthSection["ClientSecret"];
			});


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (!app.Environment.IsDevelopment())
			{
				app.UseExceptionHandler("/Home/Error");
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}



			app.UseHttpsRedirection();

			app.UseStaticFiles();

			app.UseRouting();

			app.UseAuthorization();
			app.UseAuthentication();

			app.MapControllerRoute(
				name: "default",
				pattern: "{controller=Home}/{action=Index}/{id?}");

			app.Run();
		}
	}
}
