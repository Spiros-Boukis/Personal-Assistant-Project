using MahApps.Metro.Controls;
using ModernWpf.Controls;
using Notification.Wpf;
using Personal_Assistant.Helpers;
using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
using Enterwell.Clients.Wpf.Notifications;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Xceed.Wpf.AvalonDock.Controls;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Windows.Controls.Image;
using ToggleSwitch = ModernWpf.Controls.ToggleSwitch;
using Application = System.Windows.Application;

namespace Personal_Assistant.Tabs
{
    /// <summary>
    /// Interaction logic for SmartHomeTab.xaml
    /// </summary>
    ///

    public class TimerSchedule
    {
        public DateTime TargetTime { get; set; }

        public bool isEnabled { get; set; }
        public Guid ItemId { get; set; }
        public TimerSchedule() { }



        public TimerSchedule(DateTime targetTime, Guid itemId)
        {
            TargetTime = targetTime;
            ItemId = itemId;
            isEnabled = true;
        }

    }

    public partial class SmartHomeTab : UserControl
    {
        List<SmartHomeItem> items;
        List<SmartHomeItem> items2;
        DispatcherTimer timer;
        TimeSpan Time;
        DateTime _tempDate;
        List<TimerSchedule> Schedules = new List<TimerSchedule>();
        Guid timedItemID;
        bool timerisSet = false;

    
        public SmartHomeTab()
        {
            InitializeComponent();
            

            DispatcherTimer timer = new DispatcherTimer();
            TimeSpan Time = TimeSpan.FromSeconds(15);
            timer = new DispatcherTimer(DispatcherPriority.Render);

            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += _bulbTimerTick;
            timer.Start();


            items = new List<SmartHomeItem>();
            items.Add(new LightBulbItem("Κεντρικό Φως", "Online",true));
            items.Add(new LightBulbItem("Λαμπατέρ Σαλονιού", "Online",false));
            items.Add(new TemperatureItem("Θερμοκρασία Χώρου", "Online"));
            items.Add(new LightBulbItem("Λαμπατέρ Σαλονιού", "Online",false));

            items2 = new List<SmartHomeItem>();
            items2.Add(new LightBulbItem("Φως κομοδίνου", "Offline",false));
            items2.Add(new TemperatureItem("Θερμοκρασία Δωματίου", "Online"));
            items2.Add(new LightBulbItem("Κεντρικά φώτα ", "Online", false));

            //livingRoomListView.ItemsSource = items;

            Binding b = new Binding();
            b.Source = items;


            b.Mode = BindingMode.OneWay;
            livingRoomListView.SetBinding(System.Windows.Controls.ListView.ItemsSourceProperty, b);

            livingRoomListView.ItemsSource = items;

            BedroomListView.ItemsSource = items2;
            var t = new Thread(SimulateTemperatureChanges);
            t.Start();







        }

        private void SimulateTemperatureChanges()
        {
            while (true)
            {
                Thread.Sleep(5000);

                foreach (TemperatureItem item in items.Where(x => x.GetType() == typeof(TemperatureItem) && x.Status == "Online" && !x.ScheduleEnabled))
                {
                    double newTemp = 0; ;
                    var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                    random = random * 0.01;
                    var choice = RandomNumberGenerator.GetInt32(1, 3);
                    if (choice == 1)
                    {
                        newTemp = item.Temperature + random;
                    }

                    if (choice == 2)
                    {
                        newTemp = item.Temperature - random;
                    }
                    item.Temperature = newTemp;
                    item.Temperature = Math.Round(item.Temperature, 2);
                }

                foreach (TemperatureItem item in items2.Where(x => x.GetType() == typeof(TemperatureItem) && x.Status == "Online" && !x.ScheduleEnabled))
                {
                    double newTemp = 0; ;
                    var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                    random = random * 0.01;
                    var choice = RandomNumberGenerator.GetInt32(1, 3);
                    if (choice == 1)
                    {
                        newTemp = item.Temperature + random;
                    }

                    if (choice == 2)
                    {
                        newTemp = item.Temperature - random;
                    }
                    item.Temperature = newTemp;
                    item.Temperature = Math.Round(item.Temperature, 2);
                    this.Dispatcher.Invoke(() =>
                    {

                    });
                }
            }
        }
        private void livingRoomList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
                if (livingRoomListView.Visibility == Visibility.Visible)
                {
                    livingRoomListView.Visibility = Visibility.Collapsed;
                }
                else
                {
                    livingRoomListView.Visibility = Visibility.Visible;
                }
           
            
        }
        private void bedRoomList_MouseDown(object sender, MouseButtonEventArgs e)
        {

            if (BedroomListView.Visibility == Visibility.Visible)
            {
                BedroomListView.Visibility = Visibility.Collapsed;
            }
            else
            {
                BedroomListView.Visibility = Visibility.Visible;
            }
        }

        public void _bulbTimerTick(object sender, EventArgs e)
        {
            DispatcherTimer timer = sender as DispatcherTimer;

               foreach (LightBulbItem item in items.Where(x => x.ScheduleEnabled == true && x.GetType()==typeof(LightBulbItem)))
                {
                   

                    if (DateTime.Now > item.ScheduleTargetTime)
                    {

                    var q = Application.Current.MainWindow as MainWindow;
                    item.ScheduleEnabled = false;

                    if (item.IsOn)
                    {
                        item.IsOn = false;
                        q.ShowNotifications("Η λειτουργία χρονοδιακόπτη για την συσκευή " + item.Description + " στο δωμάτιο " + "Living Room απενεργοποιήθηκε. Η λάμπα έχει σβήσει");

                    }
                    else
                    {
                        item.IsOn = true;
                        q.ShowNotifications("Η λειτουργία χρονοδιακόπτη για την συσκευή " + item.Description + " στο δωμάτιο " + "Living Room απενεργοποιήθηκε. Η λάμπα έχει Ανάψει");
                    }



                }
                }
            foreach (TemperatureItem item in items.Where(x => x.ScheduleEnabled == true && x.GetType()==typeof(TemperatureItem)) )
            {
                

                if (item.ScheduleType == 0)
                {
                    if (item.Temperature < item.TargetTemperature)
                    {
                        var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                        random = random * 0.01;
                        item.Temperature += random;
                        item.Temperature = Math.Round(item.Temperature, 2);
                    }
                    else //done 
                    { 
                        item.ScheduleEnabled = false;
                      
                            item.IsOn = false;
                        var q = Application.Current.MainWindow as MainWindow;

                        q.ShowNotifications("Η λειτουργία θερμοστάτη για την συσκευή " + item.Description + " στο δωμάτιο " + "Living Room απενεργοποιήθηκε. Η θερμοκρασία του χώρου είναι η επιθυμητή.");
                    }
                }
                else if (item.ScheduleType == 1)
                {
                    if (item.Temperature > item.TargetTemperature)
                    {
                        var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                        random = random * 0.01;
                        item.Temperature -= random;
                        item.Temperature = Math.Round(item.Temperature, 2);
                    }
                    else //done 
                    {
                        item.ScheduleEnabled = false;
                      
                         item.IsOn = false;
                        var q = Application.Current.MainWindow as MainWindow;
                        
                        q.ShowNotifications("Η λειτουργία θερμοστάτη για την συσκευή " +item.Description +" στο δωμάτιο "+"Living Room απενεργοποιήθηκε. Η θερμοκρασία του χώρου είναι η επιθυμητή.");
                    }
                }

           
                }
            }


        

        

        private void SetBulbTimer_Click(object sender, RoutedEventArgs e)
        { 
            Button _button = sender as Button;

            LightBulbItem _selected = ViewsHelpers.FindSelectedItemsControlItemContentByChild<Button, LightBulbItem>(livingRoomListView, _button);
           
                _selected.ScheduleEnabled = true;

  
                Schedules.Add(new TimerSchedule(_tempDate, timedItemID));        
        }

        private void SetTimer_Click(object sender, RoutedEventArgs e)
        {


        }

        private void image_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            Image _image = sender as Image;
            var source = _image.Source.ToString();
            _image.Source = new BitmapImage(new Uri(source));
        }

        private void ListViewItem_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
         //   ListViewItem item = (ListViewItem)sender;
            
         //  var index = livingRoomListView.Items.IndexOf(item);

         //   livingRoomListView.SelectedItem = item;   
        }

     
      


        private void LightBulbOnOff_SwitchToggled(object sender, RoutedEventArgs e)
        {
            ToggleSwitch _switch = sender as ToggleSwitch;

            

            LightBulbItem selected = Helpers.ViewsHelpers.FindSelectedItemsControlItemContentByChild<ToggleSwitch, LightBulbItem>(livingRoomListView, _switch);

            if (_switch.IsOn)
            {
                selected.ImagePath = "/Resources/Images/SmartHome/bulb_on.png";
            }
            else
            {
                selected.ImagePath = "/Resources/Images/SmartHome/bulb_off.png";
            }
         //   if (selected.ImagePath == "/Resources/Images/SmartHome/bulb_on.png")
           //     selected.ImagePath = "/Resources/Images/SmartHome/bulb_off.png";
           // else if (selected.ImagePath == "/Resources/Images/SmartHome/bulb_off.png")
            //    selected.ImagePath = "/Resources/Images/SmartHome/bulb_on.png";
        }

        private void ScheduleToggleClicked(object sender, RoutedEventArgs e)
        {
            ToggleSwitch Sender = sender as ToggleSwitch;
            var state = Sender.IsOn;


            
            SmartHomeItem item  = Helpers.ViewsHelpers.FindSelectedItemsControlItemContentByChild<ToggleSwitch, SmartHomeItem>(livingRoomListView, Sender);
            var type = item.GetType();
            
            if (type == typeof(LightBulbItem)) 
            {
                LightBulbItem lightBulbItem = (LightBulbItem)item; 
                if (state)  //if we are enabling the schedule
                {
                    lightBulbItem.ScheduleTargetTime = item.TimerTargetTime;
                    lightBulbItem.ScheduleEnabled = true;

                }
            }
            if (type == typeof(TemperatureItem))
            {
                TemperatureItem temperatureItem = (TemperatureItem)item;
                if (state)  //if we are enabling the schedule
                {
                    var setTemp = Int32.Parse(temperatureItem.SetTemperature);
                    temperatureItem.TargetTemperature = setTemp;
                    if (temperatureItem.TargetTemperature > temperatureItem.Temperature)
                    {
                        temperatureItem.ScheduleType = 0;
                        temperatureItem.ScheduleEnabled = true;
                    }
                    else if (temperatureItem.TargetTemperature < temperatureItem.Temperature)
                    {
                        temperatureItem.ScheduleType = 1;
                        temperatureItem.ScheduleEnabled = true;
                    }
                    
                   
                 

                }
            }


            
        }
    }
}
