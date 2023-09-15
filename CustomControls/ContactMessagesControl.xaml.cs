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
    }
}
