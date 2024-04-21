
using MegaApp.Application.Models;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

//this is not in use right now
public class DatabaseOptionsSetup : IConfigureOptions<DatabaseOptions>
{
    const string ConfigSectionName = "DatabaseOptions";
    readonly IConfiguration _configuration;
    public DatabaseOptionsSetup(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void Configure(DatabaseOptions options)
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnectionString");

        options.ConnectionString = connectionString;

        _configuration.GetSection(ConfigSectionName).Bind(options);


    }
}
