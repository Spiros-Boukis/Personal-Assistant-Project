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
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl
    {

        public List<Contact> contacts;

        public Contacts()
        {
            InitializeComponent();

            List<Contact> contacts = new List<Contact>();

            contacts.Add(new Contact("Μαρία","6906849572"));
            contacts.Add(new Contact("Φίλιππος", "6944687190"));
            contacts.Add(new Contact("Γιώργος", "6911196811"));

            contactsListView.ItemsSource = contacts;
        }
    }
}
