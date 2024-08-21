using MimeKit.Text;
using MimeKit;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using BookManager.Core.Services;

namespace BookManager.Infrastructure.Notifications
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;        

        public EmailService(IConfiguration configuration)
        {           
            _configuration = configuration;
            _smtpServer = _configuration["SmtpSettings:Server"];
            _smtpPort = int.Parse(_configuration["SmtpSettings:Port"]);
            _smtpUser = _configuration["SmtpSettings:User"];
            _smtpPass = _configuration["SmtpSettings:Pass"];
        }

        public async Task SendEmailAsync(string subject, string content, string toEmail, string toName)
        {
            // Crie uma nova mensagem de e-mail
            var email = new MimeMessage();
            email.From.Add(new MailboxAddress("Book Manager", _smtpUser));
            email.To.Add(new MailboxAddress(toName, toEmail));
            email.Subject = subject;
                       
            email.Body = new TextPart(TextFormat.Html) { Text = content };
                        
            using (var smtp = new SmtpClient())
            {
                smtp.Connect(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                smtp.Authenticate(_smtpUser, _smtpPass);

                await smtp.SendAsync(email);
                smtp.Disconnect(true);
            }
        }
    }
}
