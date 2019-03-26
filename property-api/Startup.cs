﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using property_api.V1.UseCase;
using property_api.V1.Gateways;
using property_api.V1.Infrastructure;
using AutoMapper;
using property_api.V1.Domain;
using property_api.V1.Factory;

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
            ConfigurePropertyFactory(services);            
            ConfigureDbContext(services);
            RegisterGateWays(services);
            RegisterUseCases(services);
        }

        private static void ConfigurePropertyFactory(IServiceCollection services)
        {
            var mappingConfig = new MapperConfiguration(cfg => { cfg.CreateMap<UhProperty, Property>(); });
            var propertyFactory = new PropertyFactory(mappingConfig.CreateMapper());
            services.AddSingleton(propertyFactory);
        }

        private static void ConfigureDbContext(IServiceCollection services)
        {
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

            app.UseMvc();
        }
    }
}
