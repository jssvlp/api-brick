using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using api_brick.Data;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace api_brick
{
    public class Program
    {
        public static void Main(string[] args)
        {
            
           CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {

            var host = WebHost.CreateDefaultBuilder(args)
         .UseStartup<Startup>()
         .Build();

            using (var scope = host.Services.CreateScope())
            {
                var db = scope.ServiceProvider.GetService<BrickDbContext>();
                db.Database.Migrate();
            }

            return host;

        }
     
            
    }
}
