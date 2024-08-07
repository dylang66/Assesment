using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace EmailSmtp
{
    public interface ISmtpEmail
    {
        string ToEmail { set; get; }
        string FromEmail { set; }
        string FromPassword { set; }

        int Port { get; set; }

        MailMessage message { get; set; }
        void sendEmail();

        void includeBody(string body);

        void includeSubject(string subject);
    }
}
