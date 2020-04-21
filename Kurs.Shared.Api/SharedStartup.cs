using System;
using System.Security.Cryptography.X509Certificates;
using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using Kurs.Shared.Data.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace Kurs.Shared.Api
{
    public class SharedStartup
    {
        public readonly string IasAllowSpecificOrigins = "IasAllowSpecificOrigins";
        public SharedStartup(IConfiguration configuration, IHostingEnvironment env)
        {
            var configurationBuilder = new ConfigurationBuilder();
            configurationBuilder
                .AddJsonFile("appsettings.shared.json")
                .AddJsonFile($"appsettings.shared.{env.EnvironmentName.Trim()}.json")
                .AddConfiguration(configuration);

            Configuration = configurationBuilder.Build();
            // if (Configuration["Serilog:WriteTo:2:Args:pathFormat"] != null)
            //     Configuration["Serilog:WriteTo:2:Args:pathFormat"] =
            //         Configuration["Serilog:WriteTo:2:Args:pathFormat"].Replace("{Application}", env.ApplicationName);
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; set; }
        //        private bool _withAuth = false;

        protected IServiceProvider ConfigureServices<TAutofacModule>(
            IServiceCollection services,
            ContainerBuilder containerBuilder = null,
            ServiceLifetime? dbContextLifeTime = null
        ) where TAutofacModule : IModule, new()
        {
            if (containerBuilder == null) containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<TAutofacModule>();
            return ConfigureServices(services, containerBuilder, dbContextLifeTime);
        }

        protected IServiceProvider ConfigureServices(
            IServiceCollection services,
            ContainerBuilder containerBuilder = null,
            ServiceLifetime? dbContextLifeTime = null
        )
        {
            if (dbContextLifeTime != null)
            {
                var connectionStr = Configuration.GetConnectionString("DefaultConnection");
                services.AddDbContext<KursContext>(
                options => options.UseSqlServer(connectionStr), dbContextLifeTime.Value);
            }

            services.AddCors(options =>
            {
                options.AddPolicy(IasAllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:4200")
                            .AllowCredentials().AllowAnyHeader().AllowAnyMethod();
                    });
            });

            services.AddMvc();
            services.AddSwaggerDocument();
            
            var certPath = Configuration["IdentityConfig:CertPath"];
            var certPass = Configuration["IdentityConfig:CertPass"];
            var cert = new X509Certificate2(certPath, certPass);

            services.AddRscAuth(Configuration, cert);
            containerBuilder.RegisterInstance(cert);

            if (containerBuilder == null)
                containerBuilder = new ContainerBuilder();

            containerBuilder.Populate(services);
            containerBuilder.RegisterInstance(Configuration);
            ApplicationContainer = containerBuilder.Build();
            return new AutofacServiceProvider(ApplicationContainer);
        }

        protected void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            app.UseCors(IasAllowSpecificOrigins);
            app.UseSwagger();
            app.UseSwaggerUi3(config => config.TransformToExternalPath = (internalUiRoute, request) =>
 {
     if (internalUiRoute.StartsWith("/") == true && internalUiRoute.StartsWith(request.PathBase) == false)
     {
         return request.PathBase + internalUiRoute;
     }
     else
     {
         return internalUiRoute;
     }
 });
            app.UseStaticFiles();
            app.UseMvc();
        }
    }
}