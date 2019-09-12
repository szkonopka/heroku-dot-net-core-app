using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using System;

namespace heroku_dot_net_core_app
{
    class Program
    {
        static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls("http://localhost:5000")
            .Build();
    }
}
