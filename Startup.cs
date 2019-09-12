using AspNetCore.RouteAnalyzer;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace heroku_dot_net_core_app
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();

            // dodanie do kontekstu połączenie z bazą danych
            services.AddMvc().AddJsonOptions(options => {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
            services.AddAutoMapper();
            services.AddRouteAnalyzer();
        }

        public void Configure(IApplicationBuilder application, IHostingEnvironment environment, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            application.UseCors(c => c
                .AllowAnyOrigin()
                .AllowCredentials()
                .AllowAnyHeader()
                .AllowAnyMethod()
            );

            if (environment.IsDevelopment())
            {
                application.UseDeveloperExceptionPage();
            }
            else
            {
                application.UseHttpsRedirection();
            }

            application.UseMvc(routes => {
                routes.MapRouteAnalyzer("/routes");
            });
        }
    }
}
