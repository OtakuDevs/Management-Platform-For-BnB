namespace MailProvider.Services.Interfaces;

public interface IEmailSender
{
    Task SendEmailAsync(string email, string subject, string message);
}