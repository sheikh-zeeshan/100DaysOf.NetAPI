using MegaApp.Application.Interfaces.Persistance;
using MegaApp.Persistance.Common;
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

            options.UseSqlite(configuration.GetConnectionString("MegaAppDB")
        // , providerOptions => providerOptions.EnableRetryOnFailure(3)

        ));

        services.AddScoped(typeof(IGenericRepository<>), typeof(BaseRepository<>));

        services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
        services.AddScoped<ILeaveAllocationRepository, LeaveAllocationRepository>();
        services.AddScoped<ILeaveRequestRepository, LeaveRequestRepository>();

        return services;
    }
}