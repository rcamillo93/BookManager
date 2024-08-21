namespace BookManager.Core.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string subject, string content, string toEmail, string toName);
    }
}