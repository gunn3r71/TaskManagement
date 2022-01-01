using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace TaskManagement.API.Extensions
{
    public static class SwaggerConfig
    {
        public static IServiceCollection AddCustomSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TaskManagement.API", Version = "v1" });
            });

            return services;
        }
    }
}