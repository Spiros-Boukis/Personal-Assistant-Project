using Personal_Assistant.Model;
using Personal_Assistant.Tabs;
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

namespace Personal_Assistant.CustomControls
{
    /// <summary>
    /// Interaction logic for ContactMessagesControl.xaml
    /// </summary>
    public partial class ContactMessagesControl : UserControl
    {
        public List<ContactMessage> ContactMessages { get; set; }
        public ContactMessagesControl()
        {
            InitializeComponent();
            ContactMessages = new List<ContactMessage>();
            
        }

        private void send_Click(object sender, RoutedEventArgs e)
        {
            Contacts context = this.DataContext as Contacts;
            context.SendMessage(msgBody.Text);
            messagesListView.SelectedIndex = messagesListView.Items.Count - 1;
            messagesListView.ScrollIntoView(messagesListView.SelectedItem);


            scrollViewer.ScrollToEnd();
            msgBody.Text = string.Empty;
        }

        private void msgBody_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter) 
            {
                Contacts context = this.DataContext as Contacts;
                context.SendMessage(msgBody.Text);
                messagesListView.SelectedIndex = messagesListView.Items.Count - 1;
                messagesListView.ScrollIntoView(messagesListView.SelectedItem);


                scrollViewer.ScrollToEnd();
                msgBody.Text = string.Empty;
            }
        }
    }
}
