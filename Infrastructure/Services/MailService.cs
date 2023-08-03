using Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using GenericEmailService;

namespace Infrastructure.Services
{
    public class MailService : IMailService
    {
        public async Task SendMailAsync(List<string> emails, string body, string subject, List<Attachment>? attachments)
        {
            SendEmailModel sendEmailModel = new()
            {
                Body = body,
                Attachments = attachments,
                Emails = emails,
                Email = "",
                Html = true,
                Password = "",
                Port = 587,
                Smtp = "",
                SSL = true,
                Subject = subject
            };
            await EmailService.SendEmailAsync(sendEmailModel);
        }
    }
}
