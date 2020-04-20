using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Kurs.Shared.Api
{
    public static class StartupExtensions
    { 
         public static IServiceCollection AddRscAuth(this IServiceCollection services, IConfiguration configuration)
        {
//            services.AddIdentity<User, RefRole>()
//                .AddDefaultTokenProviders();
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear();
            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(cfg =>
                {
                    cfg.RequireHttpsMetadata = false;
                    cfg.SaveToken = true;
                    cfg.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = "IdentityConfig:Issuer",
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Key!!!1110_][poiuytrewq9513578426")),
                        ValidateAudience = false,
                    };
                });

            return services;
        }

        public static IApplicationBuilder UseRscAuth(this IApplicationBuilder app)
        {
            app.UseAuthentication();

            return app;
        }
    }
}