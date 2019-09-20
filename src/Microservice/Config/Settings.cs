using Microservice.Helpers;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microservice.Config
{
    public interface ISettings 
    {
        string EntityName { get; }
        int PortNumber { get; }
        bool DiagnosticsEnabled { get; }
        string DiagnosticsPassword { get; }
        string DiagnosticsPath { get; }
    }

    public sealed class Settings : ISettings
    {
        private readonly IConfigurationRoot config;

        public Settings()
        {
            config = new ConfigurationBuilder()
                  .AddJsonFile("appsettings.json", true, true)
                  .Build();
        }

        public string EntityName => config["EntityName"];

        public int PortNumber => config["PortNumber"].AsInt(5000);

        public bool DiagnosticsEnabled => config["DiagnosticsEnabled"].AsBool();

        public string DiagnosticsPassword => config["DiagnosticsPassword"];

        public string DiagnosticsPath => config["DiagnosticsPath"];
    }
}
