using Application.Config;
using Application.Repositery.Service;
using Domain.Settings;
using MailKit.Security;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;

namespace Application
{
    public class MailService : IMailService
    {
        public MailConfiguration _config { get; }
        public ILogger<MailService> _logger { get; }

        public MailService(IOptions<MailConfiguration> config, ILogger<MailService> logger)
        {
            _config = config.Value;
            _logger = logger;
        }

        public async Task SendAsync(MailRequest request)
        {
            try
            {
                var email = new MimeMessage { Sender = MailboxAddress.Parse(request.From ?? _config.From) };
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder { HtmlBody = request.Body };
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                await smtp.ConnectAsync(_config.Host, _config.Port, SecureSocketOptions.StartTls);
                await smtp.AuthenticateAsync(_config.UserName, _config.Password);
                await smtp.SendAsync(email);
                await smtp.DisconnectAsync(true);
            }
            catch (Exception)
            {
                // ignored
            }
        }
    }
}
