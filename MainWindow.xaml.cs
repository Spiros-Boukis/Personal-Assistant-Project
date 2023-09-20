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
        

        }

        public void ShowNotifications(string notifyText)
        {
           
           


            var grid = new Grid();
            var text_block = new TextBlock { Text = notifyText, Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Center };


            var panelBTN = new StackPanel { Height = 100, Width= 600 , Margin = new Thickness(0, 40, 0, 0) };
            var btn1 = new Button { Width = 200, Height = 40, Content = "Cancel" };
            var text = new TextBlock { Foreground = Brushes.White, Text = "Hello, world", Margin = new Thickness(0, 10, 0, 0), HorizontalAlignment = HorizontalAlignment.Center };
            panelBTN.VerticalAlignment = VerticalAlignment.Bottom;
            panelBTN.Children.Add(btn1);

            var row1 = new RowDefinition();
            var row2 = new RowDefinition();
            var row3 = new RowDefinition();

            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());
            grid.RowDefinitions.Add(new RowDefinition());


            grid.HorizontalAlignment = HorizontalAlignment.Center;
            grid.Children.Add(text_block);
            grid.Children.Add(text);
            grid.Children.Add(panelBTN);

            Grid.SetRow(panelBTN, 1);
            Grid.SetRow(text_block, 0);
            Grid.SetRow(text, 2);

            object content = grid;

            NotificationPanel testContent = new NotificationPanel();
            testContent.myText.Text = notifyText;

            
            var test = testContent.Content;
            testContent.Content = null;


            
            NotificationManager.Show(test,"WindowArea", TimeSpan.MaxValue);

            SystemSounds.Hand.Play();

        }

      
    }
}
