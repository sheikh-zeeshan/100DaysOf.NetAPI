


using MegaApp.Application.Interfaces.Email;
using MegaApp.Application.Models;
using MegaApp.Infrastructure.EmailService;
using MegaApp.Infrastructure.Logger;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MegaApp.Infrastructure;
public static class InfrastrctureServiceRegistation
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {

        services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
        services.AddTransient<IEmailSender, EmailSender>();

        services.AddScoped(typeof(ILogger<>), typeof(LoggerAdapter<>));


        return services;
    }
}

