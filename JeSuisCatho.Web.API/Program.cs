using System;
using System.Net;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace JeSuisCatho.Web.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
             .UseKestrel(options =>
        {
            options.Listen(IPAddress.Loopback, 5001);  // http:localhost:5000
            options.Listen(IPAddress.Any, 80);         // http:*:80
            options.Listen(IPAddress.Loopback, 443, listenOptions =>
            {
                listenOptions.UseHttps("www.jesuiscatho.org.pfx", "changeit");
            });
        })
        .UseStartup<Startup>();
	

    }
}

