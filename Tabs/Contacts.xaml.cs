using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Xml.Linq;

namespace Personal_Assistant.Tabs
{
    /// <summary>
    /// Interaction logic for Contacts.xaml
    /// </summary>
    public partial class Contacts : UserControl 
    {

        public List<Contact> contacts;
        public Contact newContactItem;

        

        public Contacts()
        {
            InitializeComponent();

             contacts = new List<Contact>();

            contacts.Add(new Contact("Μαρία","6906849572"));
            contacts.Add(new Contact("Φίλιππος", "6944687190"));
            contacts.Add(new Contact("Γιώργος", "6911196811"));

            contactsListView.ItemsSource = contacts;
            newContactItem = new Contact();
            newContactControl.DataContext = newContactItem;
            newContactControl.Visibility = Visibility.Collapsed;
        }

        private void NewContact_Click(object sender, RoutedEventArgs e)
        {
            if(newContactControl.Visibility == Visibility.Visible)
                newContactControl.Visibility= Visibility.Collapsed;
            else if (newContactControl.Visibility == Visibility.Collapsed)
                newContactControl.Visibility = Visibility.Visible;
        }

        private void DeleteContact_Click(object sender, RoutedEventArgs e)
        {
            
            var item = contactsListView.SelectedItem as Contact;
            
            contacts.Remove(item);
            contactsListView.Items.Refresh();

        }

        private void saveNewContact(object sender, RoutedEventArgs e)
        {
            
            bool exists= false ;
            //check if number already exists
            foreach(var _contact in contacts)
            {
                if(_contact.PhoneNumber == newContactItem.PhoneNumber)
                {
                    exists = true;
                    
                }
            }

            if(exists)
            {
                MessageBox.Show("Υπάρχει ήδη καταχωρημένη εγγραφή για αυτόν τον αριθμό");
            }                
            else
            {
                contacts.Add(new Contact(newContactItem.Name,newContactItem.PhoneNumber));
                contactsListView.Items.Refresh();
              
                newContactItem.PhoneNumber = "";
                newContactItem.Name = "";
                newContactControl.Visibility=Visibility.Collapsed;
                
            }
            
        
        }
        private void cancelNewContact(object sender, RoutedEventArgs e)
        {
            newContactControl.Visibility = Visibility.Collapsed;
        }
    }
}
