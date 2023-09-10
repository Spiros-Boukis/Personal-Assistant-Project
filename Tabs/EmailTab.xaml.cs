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
    /// Interaction logic for EmailTab.xaml
    /// </summary>
    public partial class EmailTab : UserControl
    {

        public List<EmailEntry> Emails;
        public EmailTab()
        {
            InitializeComponent();

            Emails = new List<EmailEntry>();
            Emails.Add(new EmailEntry("qwer@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?"));
            Emails.Add(new EmailEntry("scammer@hotmail.com", "myemail@hotmail.com", "Important announchemtne", "blablablabla"));
            Emails.Add(new EmailEntry("abla@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?"));
            Emails.Add(new EmailEntry("qwer@hotmail.com", "myemail@hotmail.com", "Hey there", "Hi friend how are you?"));

            emailsListView.ItemsSource = Emails;
            emailsListView.Items.Refresh();

        }

        private void emailsListView_SelectionChanged(object sender, MouseButtonEventArgs e)
        {
            StackPanel test =(StackPanel) sender;
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
    }
}
