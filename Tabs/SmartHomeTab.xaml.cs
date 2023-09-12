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

namespace Personal_Assistant.Tabs
{
    /// <summary>
    /// Interaction logic for SmartHomeTab.xaml
    /// </summary>
    public partial class SmartHomeTab : UserControl
    {
        List<SmartHomeItem> items;

        public SmartHomeTab()
        {
            InitializeComponent();

            items = new List<SmartHomeItem>();
            items.Add(new SmartHomeItem(1));
            items.Add(new SmartHomeItem(1));
            items.Add(new SmartHomeItem(2));

            smartHomeListView.ItemsSource = items;

        }
    }
}
