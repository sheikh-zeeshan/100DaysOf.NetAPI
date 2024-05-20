using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Persistance.Common;
using MegaApp.Persistance.DatabaseContext;
using MegaApp.Persistance.DatabaseContext.Configurations;
using MegaApp.Persistance.Repositories;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MegaApp.Persistance;

public static class PersistanceServiceRegistation
{
    public static IServiceCollection AddPersistanceServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContextPool<MegaDbContext>
        (options =>

          options.UseSqlite(configuration.GetConnectionString("DefaultConnectionString")/* , providerOptions => providerOptions.EnableRetryOnFailure(3)*/)
        //options.UseSqlServer("Data Source=.\\SQLEXPRESS;Initial Catalog=MegaApp;integrated security=true;MultipleActiveResultSets=True;Encrypt=False")
        );

        services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();
        services.AddScoped<ITenantRepository, TenantRepository>();

        return services;
    }
}


/*
public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices
        (this IServiceCollection services, IConfiguration configuration)

    {
        services.AddDbContext<MegaDbContext>(options =>
            options.UseSqlite(configuration.GetConnectionString("BlogBbContext") ??
                throw new InvalidOperationException("connection string 'BlogBbContext not found '"))
        );

        services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));
        return services;

    }
}*/