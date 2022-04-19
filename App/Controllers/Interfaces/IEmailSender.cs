using MimeKit;
using Models.DTO_s;
using System.Threading.Tasks;

namespace Controllers.Interfaces
{
    public interface IEmailSender
    {
        Task SendAsync(MimeMessage emailMessage);
        MimeMessage CreateEmailMessage(EmailMessage emailMessage);
        Task SendEmailAsync(EmailMessage emailMessage);
    }
}
