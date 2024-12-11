using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{

    public class EmailService
    {
        private readonly string _smtpServer = "smtp.mail.ru"; // SMTP-сервер Mail.ru
        private readonly int _smtpPort = 587; // Порт для Mail.ru
        private readonly string _smtpUsername = "24workspase24sup24@mail.ru"; // Ваш email
        private readonly string _smtpPassword = "dZ7zznKdkhqNe8aL5SKg"; // Ваш пароль

        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            using (var smtpClient = new SmtpClient(_smtpServer))
            {
                smtpClient.Port = _smtpPort;
                smtpClient.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
                smtpClient.EnableSsl = true; // Используйте SSL для безопасности

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(_smtpUsername),
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true // Указывает, что тело письма в формате HTML
                };
                mailMessage.To.Add(toEmail);

                await smtpClient.SendMailAsync(mailMessage);
            }
        }
    }
}