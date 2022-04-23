using Domain.Settings;

namespace Application.Repositery.Service
{
    public interface IMailService
    {
        Task SendAsync(MailRequest mailRequest);
    }
}
