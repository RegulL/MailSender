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
            try
            {
                // Create a message.
                using (MailMessage message = new MailMessage())
                {
                    message.From = new MailAddress("mailFrom");
                    message.To.Add(new MailAddress("mailTo"));

                    message.Subject = "Заголовок";
                    message.Body = $"Сообщение {DateTime.Now}";

                    // Create a client.
                    using (SmtpClient client = new SmtpClient("smtp.mail.com", 587))
                    {
                        client.EnableSsl = true;
                        client.Credentials = new NetworkCredential("UserName", "password");
                        client.Send(message);
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
            Console.WriteLine("Сообщение отправленно!");
            Console.ReadLine();
        }
    }
}
