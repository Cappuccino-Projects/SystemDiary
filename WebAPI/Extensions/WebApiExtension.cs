using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebAPI.Options;

namespace WebAPI.Extensions
{
    public static class WebApiExtension
    {
        public static IServiceCollection AddWebAPI(this IServiceCollection services, WebApplicationBuilder builder, JWTOptions jwt)
        {

            var authConfiguration = builder.Configuration.GetSection("JWT");
            services.Configure<JWTOptions>(authConfiguration);

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.RequireHttpsMetadata = false;
                    options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidIssuer = jwt.Issuer,

                        ValidateAudience = true,
                        ValidAudience = jwt.Audience,

                        ValidateLifetime = true,

                        IssuerSigningKey = jwt.GetSymmericSecurityToken(),
                        ValidateIssuerSigningKey = true,
                    };
                });

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.SuppressConsumesConstraintForFormFileParameters = true;
                    options.SuppressInferBindingSourcesForParameters = true;
                    options.SuppressModelStateInvalidFilter = true;
                    options.SuppressMapClientErrors = true;
                });
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}