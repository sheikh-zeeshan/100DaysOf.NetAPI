

using MegaApp.Application.Interfaces.Logging;

using Microsoft.Extensions.Logging;

namespace MegaApp.Infrastructure.Logger;


public class LoggerAdapter<T> : IAppLogger<T>
{
    readonly ILogger<T> _logger;
    public LoggerAdapter(ILoggerFactory loggerFactory)
    {
        _logger = loggerFactory.CreateLogger<T>();
    }
    public void LogInformation(string message, params object[] args)
    {
        throw new NotImplementedException();
    }

    public void LogWarning(string message, params object[] args)
    {
        throw new NotImplementedException();
    }
}