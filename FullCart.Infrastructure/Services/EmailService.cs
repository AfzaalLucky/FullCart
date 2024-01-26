using FullCart.Application.DTOs.Email;
using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces;
using FullCart.Domain.Settings;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Linq;

namespace FullCart.Infrastructure.Services
{
    public class EmailService : IEmailService
    {
        public MailSettings mailSettings { get; }

        public EmailService(IOptions<MailSettings> mailSettings)
        {
            this.mailSettings = mailSettings.Value;
        }

        public async Task SendAsync(EmailRequest request)
        {
            try
            {
                // create message
                var email = new MimeMessage();
                email.Sender = new MailboxAddress(mailSettings.DisplayName, request.From ?? mailSettings.EmailFrom);
                email.To.Add(MailboxAddress.Parse(request.To));
                email.Subject = request.Subject;
                var builder = new BodyBuilder();
                builder.HtmlBody = request.Body;
                email.Body = builder.ToMessageBody();
                using var smtp = new SmtpClient();
                smtp.Connect(mailSettings.SmtpHost, mailSettings.SmtpPort, SecureSocketOptions.StartTls);
                smtp.Authenticate(mailSettings.SmtpUser, mailSettings.SmtpPass);
                await smtp.SendAsync(email);
                smtp.Disconnect(true);

            }
            catch (System.Exception ex)
            {
                throw new ApiException(ex.Message);
            }
        }
    }
}
