namespace BookManager.Infrastructure.Notifications
{
    public interface IEmailService
    {
        Task SendEmailAsync(string to, string body);
    }
}
