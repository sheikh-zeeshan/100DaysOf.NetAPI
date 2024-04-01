namespace MegaApp.Application.Models;

public class DbOptions
{
    public string ConnectionString { get; set; }
    public int MaxRetryCount { get; set; }
    public int CommandTimeout { get; set; }
    public bool EnableDetailedErrors { get; set; }
    public bool EnableSensitiveDataLogging { get; set; }
}

/*
"DbOptions :{
    "MaxRetryCount:3,
    "CommandTimeout": 30,
    "EnableDetailedErrors:true,
    "EnableSensitiveDataLogging: true
}

*/