﻿using Personal_Assistant.CustomControls;
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
using System.Xml.Linq;

namespace Personal_Assistant.Tabs
{
    /// <summary>
    /// Interaction logic for EmailTab.xaml
    /// </summary>
    public partial class EmailTab : UserControl
    {

        public List<EmailEntry> Emails;
        public List<EmailEntry> SentEmails;
        public EmailTab()
        {
            InitializeComponent();

            Emails = new List<EmailEntry>();
            Emails.Add(new EmailEntry("qwer@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?",false));
            Emails.Add(new EmailEntry("scammer@hotmail.com", "myemail@hotmail.com", "Important announchemtne", "blablablabla", false));
            Emails.Add(new EmailEntry("abla@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?", true));
            Emails.Add(new EmailEntry("qwer@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?",true));

            emailsListView.ItemsSource = Emails;
            emailsListView.Items.Refresh();

            SentEmails = new List<EmailEntry>();
            SentEmails.Add(new EmailEntry("myemail@hotmail.com", "qwer@hotmail.com", "Hey there", "Hi friend how are you?", true));
            SentEmails.Add(new EmailEntry("myemail@hotmail.com", "scammer@hotmail.com", "Important announchemtne", "Not Today!!!", true));
            

            sentemailsListView.ItemsSource = SentEmails;
            sentemailsListView.Items.Refresh();

        }

        private void emailsListView_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            StackPanel test = (StackPanel)sender;

            var index = emailsListView.SelectedIndex;

            Emails.ElementAt(index).IsRead = true;

            //emailsListView.Items.Refresh();

            
            TextBox text = (TextBox)test.FindName("mailBody");


            if (text.Visibility == Visibility.Visible)
            {
                text.Visibility = Visibility.Collapsed;
            }
            else
            {
                text.Visibility = Visibility.Visible;
            }

            

           

        }

        private void newEmailClick(object sender, RoutedEventArgs e)
        {
            Window window = new Window
            {
                Title = "My User Control Dialog",
                Content = new ComposeEmailControl(this)
            };

            ComposeEmailControl temp = (ComposeEmailControl)window.Content;
            var test = temp.TestVar;
            
            window.ShowDialog();
        }
    }
}
