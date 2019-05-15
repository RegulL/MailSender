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
using MailSender.Components;
using MailSender.lib;
using MailSender.lib.Data;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender
{
    /// <summary>
    /// Логика взаимодействия для MailSender.xaml
    /// </summary>
    public partial class MailSenderWPF : Window
    {
        public MailSenderWPF()
        {
            InitializeComponent();
        }

        private void OnExitClick(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void TabItemControl_LeftButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemControl tabItemControl)) return;

            tabItemControl.LeftButtonVisible = MainTabControl.SelectedIndex > 0;
            if (tabItemControl.LeftButtonVisible)
            {
                MainTabControl.SelectedIndex--;
                tabItemControl.RightButtonVisible = true;
            }
        }

        private void TabItemControl_RightButtonClick(object sender, EventArgs e)
        {
            if (!(sender is TabItemControl tabItemControl)) return;

            tabItemControl.RightButtonVisible = MainTabControl.SelectedIndex < MainTabControl.Items.Count - 1;

            if (tabItemControl.RightButtonVisible)
            {
                MainTabControl.SelectedIndex++;
                tabItemControl.LeftButtonVisible = true;
            }
        }

        private void toShedulerClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void sendAtOnce(object sender, RoutedEventArgs e)
        {
            if (tbMailText.Text == String.Empty)
            {
                MainTabControl.SelectedIndex = 2;
                ErrorWindow errorWindow = new ErrorWindow("Письмо не заполнено!");
                errorWindow.Owner = this;
                errorWindow.Show();
                return;
            }
            string strLogin = (cbServers.SelectedItem as Server).Login;
            string strPassword = (cbServers.SelectedItem as Server).Password;
            if (String.IsNullOrEmpty(strLogin))
            {
                MessageBox.Show("Введите логин");
                return;
            }
            if (String.IsNullOrEmpty(strPassword))
            {
                MessageBox.Show("Введите пароль");
                return;
            }            
            MailSenderService senderService = new MailSenderService(strLogin, strPassword);
            senderService.SendMails((IQueryable<Recepient>)dgRecepients.ItemsSource);
        }

        private void btnSendClick(object sender, RoutedEventArgs e)
        {
            MailScheduler mailScheduler = new MailScheduler();
            TimeSpan tsSend = mailScheduler.GetSendTime(toolkit_TimePicker.Text);
            if (tsSend == new TimeSpan())
            {
                MessageBox.Show("Некоректный формат даты");
                return;
            }
            DateTime dtSend = (cldSchedulDateTimes.SelectedDate ?? DateTime.Today).Add(tsSend);
            if (dtSend < DateTime.Now)
            {
                MessageBox.Show("Неверно введена дата");
                return;
            }
            MailSenderService mailSenderService = new MailSenderService(cbSenders.Text, cbSenders.SelectedValue.ToString());
            mailScheduler.SendEmails(dtSend, mailSenderService, (IQueryable<Recepient>)dgRecepients.ItemsSource);
        }
    }
}
