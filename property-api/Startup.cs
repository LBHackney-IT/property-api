using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using property_api.V1.UseCase;
using property_api.V1.Data;
using property_api.V1.Gateways;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.IO;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Versioning;
using property_api.Versioning;
using property_api.V1.Factory;
using property_api.V1.UseCase.GetPropertyChildren;
using property_api.V1.UseCase.GetPropertyChildren.Impl;
using property_api.V1.Helpers;

namespace property_api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private static List<ApiVersionDescription> _apiVersions { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
           
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSingleton<IApiVersionDescriptionProvider, DefaultApiVersionDescriptionProvider>();

            
            ConfigureApiVersioningAndSwagger(services);
            ConfigurePropertyFactory(services);
            ConfigureDbContext(services);
            RegisterGateWays(services);
            RegisterUseCases(services);
        }

        private static void ConfigureApiVersioningAndSwagger(IServiceCollection services)
        {
            services.AddApiVersioning(o =>
            {
                o.DefaultApiVersion = new ApiVersion(1, 0);
                o.AssumeDefaultVersionWhenUnspecified = true; // assume that the caller wants the default version if they don't specify
                o.ApiVersionReader = new UrlSegmentApiVersionReader(); // read the version number from the url segment header)
            });

            services.AddSwaggerGen(c =>
            {
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

                //Looks at the APIVersionAttribute [ApiVersion("x")] on controllers and decides whether or not
                //to include it in that version of the swagger document
                //Controllers must have this [ApiVersion("x")] to be included in swagger documentation!!
                c.DocInclusionPredicate((docName, apiDesc) =>
                {
                    var versions = apiDesc.ControllerAttributes()
                        .OfType<ApiVersionAttribute>()
                        .SelectMany(attr => attr.Versions).ToList();

                    var any = versions.Any(v => $"{v.GetFormattedApiVersion()}" == docName);
                    return any;
                });

                //Get every ApiVersion attribute specified and create swagger docs for them
                foreach (var apiVersion in _apiVersions)
                {
                    var version = $"v{apiVersion.ApiVersion.ToString()}";
                    c.SwaggerDoc(version, new Info
                    {
                        Title = $"property-api {version}",
                        Version = version,
                        Description = "This is the Hackney Property API which allows client applications to securely retrieve property information for a given property reference."
                    });
                }

                c.CustomSchemaIds(x => x.FullName);
                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                if (File.Exists(xmlPath))
                    c.IncludeXmlComments(xmlPath);

            });
        }

        private static void ConfigurePropertyFactory(IServiceCollection services)
        {
            var mappingConfig = PropertyHelper.ConfigureMapper();
            var propertyFactory = new PropertyFactory(mappingConfig.CreateMapper());
            services.AddSingleton(propertyFactory);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
            var connectionString = Environment.GetEnvironmentVariable("UH_URL");

            DbContextOptionsBuilder builder = new DbContextOptionsBuilder()
                .UseSqlServer(connectionString);

            services.AddScoped<IUHContext>(s => new UhContext(builder.Options));
        }

        private static void RegisterGateWays(IServiceCollection services)
        {
            services.AddTransient<IPropertyGateway, PropertyGateway>();
            services.AddTransient<IGetPropertyChildrenGateway, PropertyGateway>();

        }

        private static void RegisterUseCases(IServiceCollection services)
        {
            services.AddTransient<IGetPropertyUseCase, GetPropertyUseCase>();
            services.AddTransient<IGetPropertyChildrenUseCase, GetPropertyChildrenUseCase>();
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

            var api = app.ApplicationServices.GetService<IApiVersionDescriptionProvider>();
            //Get All ApiVersions,
            _apiVersions = api.ApiVersionDescriptions.Select(s => s).ToList();
            //Swagger ui to view the swagger.json file
            app.UseSwaggerUI(c =>
            {
                foreach (var apiVersionDescription in _apiVersions)
                {
                    //Create a swagger endpoint for each swagger version
                    c.SwaggerEndpoint($"{apiVersionDescription.GetFormattedApiVersion()}/swagger.json",
                        $"property-api {apiVersionDescription.GetFormattedApiVersion()}");
                }
            });

            app.UseSwagger();

            app.UseMvc(routes =>
            {
                // SwaggerGen won't find controllers that are routed via this technique.
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

        }
    }
}
