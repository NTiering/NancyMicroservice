using Microsoft.Extensions.Configuration;
using Nancy.Hosting.Self;
using System;
using Microservice.Config;
using System.Threading;

namespace Microservice
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            var setting = new Settings();
                       
            using (var host = new NancyHost(new Uri($"http://localhost:{setting.PortNumber}")))
            {
                host.Start();
                Console.WriteLine($"Running {setting.EntityName} on http://localhost:{setting.PortNumber}");
                Thread.Sleep(Timeout.Infinite);
            }
        }
    }
}
