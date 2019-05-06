using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.Security;

namespace MailSender.WPFTest
{
    public class EmailSendServiceClass
    {
        public SmtpClient client;
        public MailMessage mail;
        public EmailSendServiceClass()
        {    
        }

        /// <summary>
        /// Метод для отправки сообщения 
        /// </summary>
        public void SendMailMessage(string mailFrom, string mailTo, string mailSub, string mailBody, string smtpServer, int port, string username, SecureString password)
        {
            try
            {
                using (mail = new MailMessage())
                {
                    mail.From = new MailAddress(mailFrom);
                    mail.To.Add(new MailAddress(mailTo));

                    mail.Subject = mailSub;
                    mail.Body = mailBody;

                    using (client = new SmtpClient(smtpServer, port))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential(username, password);

                        client.Send(mail);
                    }
                }
            }
            catch 
            {
                throw new Exception();
            }
        }
    }
}
