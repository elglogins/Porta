using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Porta.Interfaces.Repositories;
using Porta.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Porta.Tests
{
    public class TestStartup
    {
        public TestStartup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                //.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                //.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IRoutesRepository, TestRoutesRepository>();
            services.AddTransient<ILookupRoutesRepository, LookupRoutesRepository>();
            services.AddTransient<IIgnoredRoutesRepository, IgnoredRoutesRepository>();

            //services.AddTransient();
            //services.Replace(ServiceDescriptor.Scoped<IService, MockedService>());
        }

        public void Configure(IApplicationBuilder app)
        {
            // your usual registrations there
        }
    }
}
