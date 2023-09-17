using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation;
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
            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 1);
            timer.Tick += _bulbTimerTick;
            timer.Start();


            items = new List<SmartHomeItem>();
            items.Add(new LightBulbItem("Κεντρικό Φως","Online"));
            items.Add(new LightBulbItem("Λαμπατέρ Σαλονιού", "Online"));
            items.Add(new TemperatureItem("Θερμοκρασία Χώρου", "Online"));

            items2 = new List<SmartHomeItem>();
            items2.Add(new LightBulbItem("Φως κομοδίνου", "Offline"));
            items2.Add(new TemperatureItem("Θερμοκρασία Δωματίου", "Online"));
            items2.Add(new LightBulbItem("Κεντρικά φώτα ", "Online"));

            //livingRoomListView.ItemsSource = items;

            Binding b = new Binding();
            b.Source = items;
            
            
            b.Mode= BindingMode.OneWay;
            livingRoomListView.SetBinding(ListView.ItemsSourceProperty, b);

            livingRoomListView.ItemsSource = items;

            BedroomListView.ItemsSource = items2;
            var t = new Thread(SimulateTemperatureChanges);
            t.Start();
            


            
            
            
       
        }

       private void SimulateTemperatureChanges()
        {
            while(true)
            {
                Thread.Sleep(5000);

                foreach (TemperatureItem item in items.Where(x => x.GetType()==typeof(TemperatureItem) && x.Status=="Online"))
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
                        livingRoomListView.Items.Refresh();
                    });                   
                }

                foreach (TemperatureItem item in items2.Where(x => x.GetType() == typeof(TemperatureItem) && x.Status == "Online"))
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
                        BedroomListView.Items.Refresh();
                    });
                }
            }
        }


        private void lightBulbClicked(object sender, MouseButtonEventArgs e)
        {
            Image _image = (Image)sender;

            var test = _image.Source.ToString();

            var temp = livingRoomListView.FindVisualChildren<Image>();
            if (temp.Count() > 0)
                if (temp.Contains(_image))
                {
                    LightBulbItem selected = livingRoomListView.SelectedItem as LightBulbItem;
                    foreach(var item in items.Where(x => x.Id== selected.Id && x.Status=="Online"))
                    {   
                        if (item.ImagePath == "/Resources/Images/SmartHome/bulb_on.png")
                            {
                                item.ImagePath = "/Resources/Images/SmartHome/bulb_off.png";
                                
                            }
                         else if (item.ImagePath == "/Resources/Images/SmartHome/bulb_off.png")
                            {
                                item.ImagePath = "/Resources/Images/SmartHome/bulb_on.png";
                            }
                            livingRoomListView.Items.Refresh();
                        
                    }
                }
            var temp1= BedroomListView.FindVisualChildren<Image>();
            if (temp1.Count() > 0)
                if (temp1.Contains(_image))
                {
                    LightBulbItem selected = BedroomListView.SelectedItem as LightBulbItem;
                    foreach(var item in items2.Where(x => x.Id == selected.Id && x.Status == "Online"))
                        {
                       
                            if (item.ImagePath == "/Resources/Images/SmartHome/bulb_on.png")
                            {
                                item.ImagePath = "/Resources/Images/SmartHome/bulb_off.png";

                            }
                            else if (item.ImagePath == "/Resources/Images/SmartHome/bulb_off.png")
                            {
                                item.ImagePath = "/Resources/Images/SmartHome/bulb_on.png";
                            }
                            BedroomListView.Items.Refresh();
                        
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

            if(Schedules.Count()>0)
            {
                foreach(var  schedule in Schedules.Where(x => x.isEnabled == true))
                {
                    if (DateTime.Now > schedule.TargetTime)
                    {
                        schedule.isEnabled = false;
                        var item = items.Where(x => x.Id == schedule.ItemId).FirstOrDefault();

                        if (item.ImagePath == "/Resources/Images/SmartHome/bulb_on.png")
                        {

                            item.ImagePath = "/Resources/Images/SmartHome/bulb_off.png";




                        }
                        else if (item.ImagePath == "/Resources/Images/SmartHome/bulb_off.png")
                        {

                            item.ImagePath = "/Resources/Images/SmartHome/bulb_on.png";
                        }

                 
                    }

                }


                
                    


                    
                


            }
           
        }



        private void SetBulbTimer_Click(object sender, RoutedEventArgs e)
        {
            
            
            
            Button _button = sender as Button;
            var temp = livingRoomListView.FindVisualChildren<Button>();
            if (temp.Count() > 0)
                if (temp.Contains(_button))
                {
                    LightBulbItem selected = livingRoomListView.SelectedItem as LightBulbItem;
                    foreach (var item in items.Where(x => x.Id == selected.Id))
                    {
                        timedItemID = selected.Id;
                        _tempDate = DateTime.Now.AddSeconds(10);
                        Schedules.Add(new TimerSchedule(_tempDate, timedItemID));
                        livingRoomListView.Items.Refresh();
                    }
                }

            

           
            
        }

        private void SetTimer_Click(object sender, RoutedEventArgs e)
        {


        }
    }
}
