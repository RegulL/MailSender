using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;

namespace MailSender.ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            using (MailMessage message = new MailMessage())
            {
                message.From = new MailAddress("e-mail");
                message.To.Add(new MailAddress("e-mail"));

                message.Subject = "Заголовок";
                message.Body = "Текст сообщения";

                using (SmtpClient client = new SmtpClient("smtp.mail.com", 587))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential("UserName", "Password");
                    client.Send(message);
                }

            }
            Console.ReadLine();
        }
    }
}
