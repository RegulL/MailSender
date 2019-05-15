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

namespace MailSender.Components
{
    /// <summary>
    /// Логика взаимодействия для TabItemControl.xaml
    /// </summary>
    public partial class TabItemControl : UserControl
    {
        public event EventHandler LeftButtonClick;
        protected virtual void OnLeftButtonClick(EventArgs e) => LeftButtonClick?.Invoke(this, e);

        public event EventHandler RightButtonClick;
        protected virtual void OnRightButtonClick(EventArgs e) => RightButtonClick?.Invoke(this, e);

        public bool LeftButtonVisible
        {
            get => LeftArrow.Visibility == Visibility.Visible;
            set => LeftArrow.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public bool RightButtonVisible
        {
            get => RightArrow.Visibility == Visibility.Visible;
            set => RightArrow.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }
        public TabItemControl()
        {
            InitializeComponent();
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            if (!(e.Source is Button button)) return;
            switch (button.Name)
            {
                case "LeftArrow":
                    OnLeftButtonClick(EventArgs.Empty);
                    break;
                case "RightArrow":
                    OnRightButtonClick(EventArgs.Empty);
                    break;
            }
        }
    }
}
