



using MegaApp.Application.Interfaces.Email;
using MegaApp.Application.Models;

using Microsoft.Extensions.Options;

using SendGrid;
using SendGrid.Helpers.Mail;

namespace MegaApp.Infrastructure.EmailService;


public class EmailSender : IEmailSender
{
    public EmailSettings _emailSettings { get; }
    public EmailSender(IOptions<EmailSettings> settings)
    {
        _emailSettings = settings.Value;
    }
    public async Task<bool> SendEmail(EmailMessage email)
    {
        var client = new SendGridClient(_emailSettings.ApiKey);
        var to = new EmailAddress(email.To);
        var from = new EmailAddress
        {
            Email = _emailSettings.FromAddress,
            Name = _emailSettings.FromName
        };

        var message = MailHelper.CreateSingleEmail(from, to, email.Subject, email.Body, email.Body);
        var response = await client.SendEmailAsync(message);

        return response.IsSuccessStatusCode; // response.StatusCode == System.Net.HttpStatusCode.OK || response.StatusCode == System.Net.HttpStatusCode.Accepted;


    }
}