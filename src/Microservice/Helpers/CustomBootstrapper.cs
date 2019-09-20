using Microservice.Config;
using Nancy;
using Nancy.Configuration;
using Nancy.Diagnostics;
using System;
using System.Collections.Generic;
using System.Text;

namespace WidgetMicroservice.Helpers
{
    public sealed class CustomBootstrapper : DefaultNancyBootstrapper
    {
        private readonly ISettings settings;

        public CustomBootstrapper()
        {
            settings = new Settings();                
        }

        public override void Configure(INancyEnvironment environment)
        {
            environment.Diagnostics(settings.DiagnosticsEnabled, settings.DiagnosticsPassword, settings.DiagnosticsPath);
            base.Configure(environment);
        }


    }
}
