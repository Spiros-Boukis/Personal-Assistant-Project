using Microsoft.Win32;
using Personal_Assistant.CustomControls;
using Personal_Assistant.Model;
using System;
using System.IO;
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
using static System.Net.Mime.MediaTypeNames;
using Notification.Wpf;
using System.Media;

namespace Personal_Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        INotificationManager NotificationManager;
        public MainWindow(INotificationManager notificationManager)
        {
            InitializeComponent();

            NotificationManager = notificationManager;

           

        }




    }
}
