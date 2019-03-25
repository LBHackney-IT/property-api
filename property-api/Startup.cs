using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using property_api.V1.UseCase;
using property_api.V1.Gateways;
using property_api.V1.Infrastructure;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using Swashbuckle.AspNetCore.SwaggerUI;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;

namespace property_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Title = $"Hackney Property API - {Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}",
                    Version = "v1",
                    Description = "This is the Hackney Property API which allows client applications to securely retrieve property information for a given property reference"
                });

                var security = new Dictionary<string, IEnumerable<string>>
                {
                    { "Token", Enumerable.Empty<string>() }
                };

                c.AddSecurityDefinition("Token",
                  new ApiKeyScheme
                  {
                      In = "header",
                      Description = "Your Hackney API Key",
                      Name = "X-Api-Key",
                      Type = "apiKey"
                  }
                );

                c.AddSecurityRequirement(security);

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            ConfigureDbContext(services);
            RegisterGateWays(services);
            RegisterUseCases(services);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            // var connectionString = Environment.GetEnvironmentVariable("UH_URL");

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder()
                .UseSqlServer("Data Source=localhost;Initial Catalog=uhsimulator;user id=sa;password=Rooty-Tooty;");

            services.AddSingleton<IUHContext>(s => new UhContext(builder.Options));
        }

        private static void RegisterGateWays(IServiceCollection services)
        {
            services.AddSingleton<IPropertyGateway, PropertyGateway>();
        }

        private static void RegisterUseCases(IServiceCollection services)
        {
            services.AddSingleton<IGetPropertyUseCase, GetPropertyUseCase>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger();

            app.UseMvc();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Property API V1");
            });
        }
    }
}
