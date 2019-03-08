using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PetStore.Data;

namespace PetStore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // migrate the database. Best practice = in Main, using service scope
            MigrateDatabase(host);

            // run the web app
            host.Run();
        }

        private static void MigrateDatabase(IWebHost host)
        {
            // use service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    // retrieve the DbContext
                    var context = scope.ServiceProvider.GetService<PetStoreContext>();
                    // run any outstanding migrations
                    context.Database.Migrate();
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
