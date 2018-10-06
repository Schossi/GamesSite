using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using GamesSiteMain.Services;

namespace GamesSiteMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = BuildWebHost(args);            

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                services.GetRequiredService<ILogger<Program>>().LogInformation("Seeding database...");

                try
                {
                    services.GetRequiredService<IDBSeeder>().SeedAsync().GetAwaiter().GetResult();
                }
                catch (Exception ex)
                {
                    services.GetRequiredService<ILogger<Program>>().LogError(ex, "An error occurred while seeding the database.");
                }
            }
            
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
