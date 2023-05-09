using Application.Services;
using Data.Context;
using Data.Repositories;
using Domain.Commands.Handlers;
using Domain.Queries.Handlers;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>  
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<ITaskRepository, TasksRepository>();
        
        services.AddTransient<ICommandsTaskHandler, CommandsTaskHandler>();
        services.AddTransient<IQueriesTaskHandler, QueriesTaskHandler>();

        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ITasksServices, TasksService>();
        
        return services;
    }
}