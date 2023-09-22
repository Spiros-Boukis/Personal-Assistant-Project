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
using Notifications.Wpf;
using System.Media;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Controls;

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

            ShowNotifications("Welcome",NotificationType.Information);
        }

        public void ShowNotifications(string notifyText,NotificationType type)
        {
            
            NotificationManager.Show(new NotificationContent { Title = "Ειδοποίηση", Message = notifyText, Type = type }, expirationTime: TimeSpan.FromSeconds(30));
            SystemSounds.Hand.Play();

        }

      
    }
}
