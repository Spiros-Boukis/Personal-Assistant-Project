using Personal_Assistant.Model;
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

            livingRoomListView.ItemsSource = items;

            BedroomListView.ItemsSource = items2;

        }

        private void image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Image _image = (Image)sender;
            var test = _image.Source.ToString();
            var test1 = 1;
           
            if(_image.Source.ToString() == "pack://application:,,,/Resources/Images/SmartHome/bulb_on.png")
            {
                _image.Source = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_off.png" +
                "", UriKind.Relative));
            }
            else if (_image.Source.ToString() == "pack://application:,,,/Resources/Images/SmartHome/bulb_off.png")
            {
                _image.Source = new BitmapImage(new Uri("/Resources/Images/SmartHome/bulb_on.png" +
                "", UriKind.Relative));
            }
            
        }

        private void livingRoomList_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(livingRoomListView.Visibility == Visibility.Visible) 
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
    }
}
