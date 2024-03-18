using System.Net;
using System.Net.Mail;

using MailProvider.Services.Interfaces;

using Microsoft.Extensions.Configuration;

namespace MailProvider.Services;

public class EmailSender : IEmailSender
{
    private readonly IConfiguration _configuration;

    public EmailSender(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public Task SendEmailAsync(string email, string subject, string message)
    {
        // TODO: Provide proper default email credetials (as ENV) before deployment
        var mail = _configuration["Email:UsernameKey"];
        var pwd = _configuration["Email:PassKey"];

        // TODO: Provide proper SMTP credetials before deployment
        var client = new SmtpClient("", 587)
        {
            EnableSsl = true,
            Credentials = new NetworkCredential(mail, pwd)
        };


        return client.SendMailAsync(
            new MailMessage(from: mail, to: email, subject, message)
            {
                IsBodyHtml = true
            });
    }
}