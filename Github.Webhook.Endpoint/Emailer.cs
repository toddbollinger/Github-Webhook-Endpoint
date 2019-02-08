using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace Github.Webhook.Endpoint
{
    public interface IEmailer
    {
        void SendEmail(string subject, string body);
    }
    public class Emailer : IEmailer
    {
        private readonly IConfiguration _configuration;
        public Emailer(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void SendEmail(string subject, string body)
        {
            var settingsSection = _configuration.GetSection("EmailerSettings");
            var settings = settingsSection.Get<EmailerSettings>();

            MailMessage m = new MailMessage()
            {
                From = new MailAddress(settings.EmailFrom),
                Subject = subject,
                Body = body,
                IsBodyHtml = false
            };

            var toArray = settings.EmailTo.Split(',').Where(x => !string.IsNullOrWhiteSpace(x)).Select(x => new MailAddress(x.Trim()));
            foreach (MailAddress to in toArray)
            {
                m.To.Add(to);
            }

            SmtpClient SMTPServer = new SmtpClient(settings.SMTPHost)
            {
                Port = settings.SMTPPort,
                EnableSsl = settings.SMTPUseSSL,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new System.Net.NetworkCredential(settings.SMTPUser, settings.SMTPPassword)
            };

            try
            {
                SMTPServer.Send(m);
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Email send failed.");
            }
        }
    }
}
