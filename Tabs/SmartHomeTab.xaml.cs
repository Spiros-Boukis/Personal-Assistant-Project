using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
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
    public partial class SmartHomeTab : UserControl
    {
        List<SmartHomeItem> items;
        List<SmartHomeItem> items2;

        public SmartHomeTab()
        {
            InitializeComponent();

            items = new List<SmartHomeItem>();
            items.Add(new SmartHomeItem(1,"Κεντρικό Φως","Online"));
            items.Add(new SmartHomeItem(1,"Λαμπατέρ Σαλονιού", "Online"));
            items.Add(new SmartHomeItem(2, "Θερμοκρασία Χώρου", "Online"));

            items2 = new List<SmartHomeItem>();
            items2.Add(new SmartHomeItem(1, "Φως κομοδίνου", "Offline"));
            items2.Add(new SmartHomeItem(2,"Θερμοκρασία Δωματίου", "Offline"));
            items2.Add(new SmartHomeItem(1,"Κεντρικά φώτα ", "Online"));

            //livingRoomListView.ItemsSource = items;

            Binding b = new Binding();
            b.Source = items;
            
            
            b.Mode= BindingMode.OneWay;
            livingRoomListView.SetBinding(ListView.ItemsSourceProperty, b);

            livingRoomListView.ItemsSource = items;

            BedroomListView.ItemsSource = items2;
            var t = new Thread(DoWork);
            t.Start();
            


            
            
            
       
        }

       private void DoWork()
        {
            while(true)
            {
                Thread.Sleep(5000);

                foreach (SmartHomeItem item in items)
                {
                    if (item.Type == 2 && item.Status=="Online")
                    {
                        double newTemp = 0; ;
                        var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                        random = random * 0.01;
                        var choice = RandomNumberGenerator.GetInt32(1, 2);
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
                }

                foreach (SmartHomeItem item in items2 )
                {
                    if (item.Type == 2 && item.Status == "Online") 
                    {
                        double newTemp = 0; ;
                        var random = (double)RandomNumberGenerator.GetInt32(0, 100);
                        random = random * 0.01;
                        var choice = RandomNumberGenerator.GetInt32(1, 2);
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
        }


        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image _image = (Image)sender;

            var test = _image.Source.ToString();
            var test1 = 1;


            var temp = livingRoomListView.FindVisualChildren<Image>();
            if (temp.Count() > 0)
                if (temp.Contains(_image))
                {
                    SmartHomeItem selected = livingRoomListView.SelectedItem as SmartHomeItem;
                    foreach(var item in items)
                    {
                        if(item.Id == selected.Id)
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
                }


           /* if (item.Id == selected.Id)
            {
                if (_image.Source.ToString() == "pack://application:,,,/Resources/Images/SmartHome/bulb_on.png")
                {
                    _image.Source = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_off.png" +
                    "", UriKind.Relative));
                }
                else if (_image.Source.ToString() == "pack://application:,,,/Resources/Images/SmartHome/bulb_off.png")
                {
                    _image.Source = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_on.png" +
                    "", UriKind.Relative));
                }
           */

            }

        private void livingRoomList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SmartHomeItem item = livingRoomListView.SelectedItem as SmartHomeItem;
            if(item.Status == "Online")
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
            else
            {
                MessageBox.Show("Η συσκευή είναι ανενεργή...");
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
    }
}
