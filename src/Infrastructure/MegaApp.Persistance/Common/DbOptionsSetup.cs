using MegaApp.Application.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace MegaApp.Persistance.Common;

public class DbOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    private const string _configSectionName = "DbOptions";
    private readonly IConfiguration _configuration;

    public DbOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        options.ConnectionString = _configuration.GetConnectionString("Database");

        _configuration.GetSection(_configSectionName).Bind(options);
    }
}