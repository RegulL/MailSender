using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Static Class for variables to create Smtp-Client
    /// </summary>
    public static class StaticVariables
    {
        public static string smtpClient = "smtp.mail.com";
        public static int clientPort = 587;
        public static string mailFrom = "sender@yandex.ru";
        public static string mailTo = "email@yandex.rus";
        public static string messageSub = "Заголовок";
        public static string messageBody = $"Сообщение от {DateTime.Now}";
        public static string userName = String.Empty;
        public static string password = String.Empty;
    }
}
