using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EmailSmtp
{
    public class GmailSMTPEmail : ISmtpEmail
    {
        public string ToEmail { get; set; }
        public string FromEmail { get; set; }
        public string FromPassword { get; set; }
        public int Port { get; set; }
        public MailMessage? message { get; set; }

        public void includeBody(string body)
        {
            if (message != null)
            {
                message.Body = body;
            }
            else
            {
                message = new MailMessage();
                message.Body = body;
            }
        }
        public void includeSubject(string subject)
        {
            if (message != null)
            {
                message.Subject = subject;
            }
            else
            {
                message = new MailMessage();
                message.Subject = subject;
            }
        }

        public void sendEmail()
        {
            message.From =new MailAddress(FromEmail);
            message.To.Add(new MailAddress(ToEmail));
            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = Port,
                Credentials = new NetworkCredential(FromEmail,FromPassword),
                EnableSsl = true,
            };
            smtpClient.Send(message);
        }
    }
}
