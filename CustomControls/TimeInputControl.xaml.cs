using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for TimeInputControl.xaml
    /// </summary>
    public partial class TimeInputControl : UserControl
    {
        public TimeInputControl()
        {
            InitializeComponent();
        }

        private void Hours_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex hoursRegex = new Regex("2[0-4]|1[0-9]|[1-9]");
            var res =  !hoursRegex.IsMatch(e.Text);
            e.Handled = res;

        }

        private void Minutes_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex minsRegex = new Regex("^[0-59]");
            e.Handled = minsRegex.IsMatch(e.Text);
        }
    }
}
