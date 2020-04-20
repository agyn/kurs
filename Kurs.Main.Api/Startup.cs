using System;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Kurs.Shared.Api;
using Kurs.Main.Api.Startups;

namespace Kurs.Main.Api
{
    public class Startup : SharedStartup
    {
         public Startup(IConfiguration configuration, IHostingEnvironment env) : base(configuration, env)
        {
        }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISOptions>(options => { options.ForwardClientCertificate = false; });
            var containerBuilder = new Autofac.ContainerBuilder();
            containerBuilder.RegisterModule<AutofacModule>();
            return base.ConfigureServices(services, containerBuilder,ServiceLifetime.Scoped);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            app.UseRscAuth();
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            base.Configure(app, loggerFactory);
        }
    }
}
