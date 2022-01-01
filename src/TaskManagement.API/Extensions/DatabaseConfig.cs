using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Infrastructure;

namespace TaskManagement.API.Extensions
{
    public static class DatabaseConfig
    {
        public static IServiceCollection ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<TaskManagementContext>(x =>
            {
                x.UseInMemoryDatabase("ToDo");
            });

            //services.AddDbContext<TaskManagementContext>(x =>
            //{
            //    x.UseSqlServer(connectionString, o =>
            //    {
            //    });
            //});

            return services;
        }
    }
}