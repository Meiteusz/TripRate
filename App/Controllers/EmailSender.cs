using Controllers.Interfaces;
using MailKit.Net.Smtp;
using MimeKit;
using Models.DTO_s;
using System;
using System.Threading.Tasks;

namespace Controllers
{
    public class EmailSender : IEmailSender
    {
        private readonly EmailConfiguration _emailConfig;

        public EmailSender(EmailConfiguration emailConfig)
        {
            _emailConfig = emailConfig;
        }

        public async Task SendAsync(MimeMessage emailMessage)
        {
            using (var client = new SmtpClient())
            {
                try
                {
                    await client.ConnectAsync(_emailConfig.SmtpServer, _emailConfig.Port, true);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    await client.AuthenticateAsync(_emailConfig.UserName, _emailConfig.Password);

                    await client.SendAsync(emailMessage);
                }
                catch (Exception ex)
                {
                    throw;
                }
                finally
                {
                    await client.DisconnectAsync(true);
                    client.Dispose();
                }
            }
        }

        public MimeMessage CreateEmailMessage(EmailMessage emailMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_emailConfig.UserName, _emailConfig.From));
            message.To.AddRange(emailMessage.To);
            emailMessage.Subject = emailMessage.Subject;
            message.Body = new TextPart(MimeKit.Text.TextFormat.Text) { Text = emailMessage.Content };

            return message;
        }

        public async Task SendEmailAsync(EmailMessage emailMessage)
        {
            var message = CreateEmailMessage(emailMessage);

            await SendAsync(message);
        }
    }
}
