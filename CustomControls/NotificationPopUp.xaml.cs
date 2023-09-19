using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Personal_Assistant.CustomControls
{
    /// <summary>
    /// Interaction logic for NotificationPopUp.xaml
    /// </summary>
    public partial class NotificationPopUp : Popup
    {
        public NotificationPopUp()
        {
            InitializeComponent();
            this.IsOpen = false;
            this.Opened += Popupex_Opened;
        }

        private void Popupex_Opened(object? sender, EventArgs e)
        {
            DispatcherTimer time = new DispatcherTimer();
            time.Interval = TimeSpan.FromSeconds(3);
            time.Start();
            time.Tick += delegate
            {
                this.IsOpen = false;
                time.Stop();
            };
        }



    }
}
