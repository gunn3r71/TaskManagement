using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TaskManagement.Domain.Commands;
using TaskManagement.Domain.Handlers;
using TaskManagement.Domain.Repositories;
using TaskManagement.Infrastructure.Repositories;
using TaskManagement.Shared.Handlers.Contracts;

namespace TaskManagement.API.Extensions
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            //DataContext
            services.ConfigureDatabase(configuration);

            //Repositories
            services.AddScoped<IToDoRepository, ToDoRepository>();

            //Command Handlers
            services.AddScoped<ICommandHandler<CreateToDoCommand>, CreateToDoCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateToDoCommand>, UpdateToDoCommandHandler>();
            services.AddScoped<ICommandHandler<MarkToDoAsDoneCommand>, MarkToDoAsDoneCommandHandler>();
            services.AddScoped<ICommandHandler<MarkToDoAsUndoneCommand>, MarkToDoAsUndoneCommandHandler>();

            return services;
        }
    }
}