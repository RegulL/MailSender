using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MailSender.WPFTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MailSenderTest: Window
    {
        public EmailSendServiceClass emailSendService;
        public MailSenderTest()
        {
            emailSendService = new EmailSendServiceClass();
            InitializeComponent();
            //Инициализация Текстбоксов полями из статического класса
            mailSubject.Text = StaticVariables.messageSub;
            mailBody.Text = StaticVariables.messageBody;
            port.Text = StaticVariables.clientPort.ToString();
            SmtpServer.Text = StaticVariables.smtpClient;
        }

        private void OnSendButtonClick(object sender, RoutedEventArgs e)
        {
            try
            {
                //Отправитель сообщения
                string mail_from = user.Text;
                //Адресат
                string mail_to = mailTo.Text;
                //Заголовок
                string mail_sub = mailSubject.Text;
                //Текст сообщения
                string mail_body = mailBody.Text;
                //SMTP-сервер и порт
                string smtp_server = SmtpServer.Text;
                int smtp_port = Int32.Parse(port.Text);
                //Вызов метода из класса EmailSendServiceClass для отправки сообщения  
                emailSendService.SendMailMessage(mail_from,mail_to,mail_sub,mail_body,smtp_server,smtp_port, mail_from, password.SecurePassword);
                //Вызов окна "Сообщение отправлено" если не было исключений
                SuccessWindow successWindow = new SuccessWindow();
                successWindow.Owner = this;
                successWindow.Show();
            }
            catch(Exception ex)
            {
                //Окно ошибки с текстом исключения
                ErrorWindow errorWindow = new ErrorWindow(ex.Message);
                errorWindow.Owner = this;
                errorWindow.Show();
            }
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
