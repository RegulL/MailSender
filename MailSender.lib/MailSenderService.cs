using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib
{
    /// <summary>
    /// Класс реализует отправку писем
    /// </summary>
    public class MailSenderService
    {
        private string strLogin;
        private string strPassword;
        private string strSmtp = "smtp.mail.com";
        private int iSmtpPort = 587;
        private string strBody;
        private string strSubject = $"Subject {DateTime.Now}";

        public MailSenderService(string Login, string Password)
        {
            strLogin = Login;
            strPassword = Password;
        }

        /// <summary>
        /// SendMail отправляет письмо на конкретный адрес
        /// SendMails в качестве аргумента принимает все адреса находящиеся в базе данных в таблице Recepients
        /// </summary>
        
        private void SendMail(string mail, string name)
        {
            using(MailMessage mm = new MailMessage(strLogin, mail))
            {
                mm.Subject = strSubject;
                mm.Body = "Hello World!";
                SmtpClient sc = new SmtpClient(strSmtp, iSmtpPort);
                sc.EnableSsl = true;
                sc.DeliveryMethod = SmtpDeliveryMethod.Network;
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential(strLogin,strPassword);
                try
                {
                    sc.Send(mm);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                }
            }
        }
        public void SendMails(IQueryable<Recepient> recepients)
        {
            foreach (var item in recepients)
            {
                SendMail(item.Email, item.Name);
            }
        }
    }
}
