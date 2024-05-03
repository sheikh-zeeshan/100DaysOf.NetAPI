


namespace MegaApp.Application.Models;

public class EmailMessage
{
    public string To { get; set; }

    public string Subject { get; set; }

    public string Body { get; set; }
}

public class EmailSettings
{
    public string ApiKey { get; set; }
    public string FromAddress { get; set; }
    public string FromName { get; set; }
}