using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC___Session_1
{
	public class Program
	{
		// Entry Point
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();                   // Creates the Kestrel , then Builds it , then Runs it 
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();                // The configurations of the kestrel is in the startup class , the CLR creates an
																	 // object from startup class and executes the two methods inside this class and then
																	 // the application is ready for getting requests

				});
		
		// Note : When running the application using the IIS Express Profile , the kestrel will be in the background but we won't have concole
		//        screen (black screen). But when running the application using the Kestrel profile then we will have the concole screen (black screen)
		//        of the Kestrel 

	}
}
