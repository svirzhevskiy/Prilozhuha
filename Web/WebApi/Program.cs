using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database;
using Database.Seeders;
using WebApi.Managers;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var seeders = new List<Action<AppDbContext, IServiceProvider, ILogger<AppDbContext>>>
            {
                (context, serviceProvider, logger) => new RoleSeeder().Seed(context, serviceProvider, logger),
                (context, serviceProvider, logger) => new UserSeeder().Seed(context, serviceProvider, logger),
                (context, serviceProvider, logger) => new PostSeeder().Seed(context, serviceProvider, logger),
            };

            CreateHostBuilder(args).Build().MigrateDatabase(seeders).Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
