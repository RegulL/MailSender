using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;
using System.Windows.Forms;
using MailSender.lib.Data.Linq2SQL;

namespace MailSender.lib
{
    /// <summary>
    /// Реализация планировщика
    /// </summary>
    public class MailScheduler
    {
        DispatcherTimer timer = new DispatcherTimer();
        MailSenderService mailSenderService;

        DateTime dtSend;
        IQueryable<Recepient> recepients;

        // Метод для конвертации строки в TimeSpan
        public TimeSpan GetSendTime(string strSendTime)
        {
            TimeSpan timeSpan = new TimeSpan();
            try
            {
                timeSpan = TimeSpan.Parse(strSendTime);
            }
            catch { }
            return timeSpan;
        }


        /// <summary>
        /// Методы реализующие отправку сообщения в установленное время 
        /// SendEmails запускает таймер и заполняет поля переданными аргументами
        /// Timer_tick непосредственно сравниваает дату и время, и при совпадении отправляет письмо
        /// </summary> 
        public void SendEmails(DateTime dtSend, MailSenderService mailSenderService, IQueryable<Recepient> recepients)
        {
            this.mailSenderService = mailSenderService;
            this.dtSend = dtSend;
            this.recepients = recepients;
            timer.Tick += Timer_Tick;
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (dtSend.ToShortDateString() == DateTime.Now.ToShortDateString())
            {
                mailSenderService.SendMails(recepients);
                timer.Stop();
                MessageBox.Show("Письма отправлены");
            }
        }
    }
}
