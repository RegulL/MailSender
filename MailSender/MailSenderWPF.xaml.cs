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
    }
}
