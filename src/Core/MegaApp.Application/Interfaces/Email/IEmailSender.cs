

using MegaApp.Application.Models;

namespace MegaApp.Application.Interfaces.Email;


public interface IEmailSender
{
    Task<bool> SendEmail(EmailMessage email);
}

