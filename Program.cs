using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.FeatureManagement;


namespace WebAppFeatureFlag
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                  //.ConfigureWebHostDefaults(webBuilder =>
                  //{
                  //    webBuilder.UseStartup<Startup>();
                  //});
                  .ConfigureWebHostDefaults(webBuilder =>
                    webBuilder.ConfigureAppConfiguration(config =>
                    {
                    var settings = config.Build();
                    config.AddAzureAppConfiguration(options => options.Connect("Endpoint=https://tksglobalappconfig.azconfig.io;Id=KScU-lae-s0:QjirGBVmwBycUh5nX6zx;Secret=TvM74x0gehlPXMKxXNFKy1T1nciPNr0MzntRBbZAUjM=").UseFeatureFlags());
                    }).UseStartup<Startup>());
        }

    }

