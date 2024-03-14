using MegaApp.Application.Models;
using Microsoft.Extensions.Options;

using Microsoft.Extensions.Configuration;

namespace MegaApp.Persistance.Common;

public class DbOptionsSetup : IConfigureOptions<DbOptions>
{
    const string _configSectionName = "DbOptions";
    readonly IConfiguration _configuration;

    public DbOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public void Configure(DbOptions options)
    {
        options.ConnectionString = _configuration.GetConnectionString("Database");

        _configuration.GetSection(_configSectionName).Bind(options);

    }
}

