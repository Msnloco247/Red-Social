using Red_Social1.Core.Application.Dtos.Email;
using Red_Social1.Core.Domain.Settings;


namespace Red_Social1.Core.Application.Interfaces.Services
{
    public interface IEmailService
    {
        public MailSettings MailSettings { get; }
        Task SendAsync(EmailRequest request);
    }
}
