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
    /// Interaction logic for ComposeEmailControl.xaml
    /// </summary>
    public partial class ComposeEmailControl : UserControl
    {
        public int TestVar { get; set; }
        private EmailTab container { get; set; }
        public ComposeEmailControl(EmailTab mailTab)
        { 
            InitializeComponent();
            container = mailTab;
            TestVar = 1;
        }

        private void email_sendclick(object sender, RoutedEventArgs e)
        {
            var toMail = ToText.Text;
            var titleMail = TitleText.Text;
            var bodyMail = BodyText.Text;

            container.SentEmails.Add(new Model.EmailEntry("mymail@hotmail.com", toMail,titleMail, bodyMail, true,DateTime.Now));
            MessageBox.Show("Το μήνυμα ηλεκτρονικού ταχυδρομείου στάλθηκε με επιτυχία!!!");
            
            container.sentemailsListView.Items.Refresh();

            Window _parent = (Window)this.Parent;
            _parent.Close();
            
        }

        private void email_cancelclick(object sender, RoutedEventArgs e)
        {
            Window _parent = (Window)this.Parent;
            _parent.Close();
        }
    }
}
