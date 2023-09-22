using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace NocdeskFirstLevalApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                 .CaptureStartupErrors(true) // the default
                 .UseSetting("detailedErrors", "true")
                .UseIISIntegration()
                .UseStartup<Startup>()
                //.UseUrls("http://localhost:5007") // for linux
                .Build();
    }
}
