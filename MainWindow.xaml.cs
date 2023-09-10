using Microsoft.Win32;
using Personal_Assistant.CustomControls;
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

namespace Personal_Assistant
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public Dictionary<string, List<AppointmentEntry>> Appointments;
        public MainWindow()
        {
            InitializeComponent();
            newAppointmentControl.Visibility = Visibility.Collapsed;    
            Appointments = new Dictionary<string, List<AppointmentEntry>>();
            Appointments.Add("2732023", new List<AppointmentEntry>());
            Appointments.Add("2712023", new List<AppointmentEntry>());
            var temp = Appointments["2732023"];
            temp.Add(new AppointmentEntry("Giatros stis 17:00","",1));
            temp.Add(new AppointmentEntry("Cafe me ton giannis stis 21:00","",0));
            var temp1 = Appointments["2712023"];
            temp1.Add(new AppointmentEntry("Klirosi stis 10", "", 0));
            temp1.Add(new AppointmentEntry("kati exw na kanw ", "", 0));
            temp1.Add(new AppointmentEntry("Rantevou gia douleia", "", 1));
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            var _date = CalendarControl.SelectedDate.Value;
            CalendarControl.SelectedDates.Add(_date);
            var test = _date.DayOfYear.ToString() + _date.Year.ToString();
            if (Appointments.ContainsKey(test))
            {
                AppointmentsListView.ItemsSource = Appointments[test];
            }
            else
            {
                AppointmentsListView.ItemsSource = null;
            }
            Console.WriteLine(test);
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {

            Button _button = sender as Button;

            if (AppointmentsListView.SelectedItem == null)
            {
                MessageBox.Show("Πρέπει να διαλέξεις εγγραφή");
            }
            else
            {
                var _date = CalendarControl.SelectedDate.Value;
                CalendarControl.SelectedDates.Add(_date);
                var test = _date.DayOfYear.ToString() + _date.Year.ToString();
                var prompt = MessageBox.Show("Θέλετε να διαγράψετε αυτό το ραντεβού?", "Διαγραφή", MessageBoxButton.YesNo);
                if (prompt == MessageBoxResult.Yes)
                {
                    AppointmentEntry item = (AppointmentEntry)AppointmentsListView.SelectedItem;

                    Appointments[test].Remove(item);
                    var temp = Appointments[test];
                    AppointmentsListView.ItemsSource = temp;
                    AppointmentsListView.Items.Refresh();
                }
                else
                { }
            }
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            if(newAppointmentControl.Visibility.Equals(Visibility.Collapsed)) 
            {
                newAppointmentControl.Visibility = Visibility.Visible;
            }
        }

        private void saveNewAppointment(object sender, RoutedEventArgs e)
        {
            var entry = new AppointmentEntry();
            entry.Title = newEntryText.Text;
            entry.Description = "";
            entry.Type = 1;

            if(Appointments.ContainsKey(FormattedDate()))
            {
                Appointments[FormattedDate()].Add(entry);
            }
            else
            {
                Appointments.Add(FormattedDate(),new List<AppointmentEntry>());
                Appointments[FormattedDate()].Add(entry);
            }

            AppointmentsListView.ItemsSource = Appointments[FormattedDate()];
            AppointmentsListView.Items.Refresh();

            newAppointmentControl.Visibility = Visibility.Collapsed;

        }
        private void cancelNewAppointment(object sender, RoutedEventArgs e)
        {
            if (newAppointmentControl.Visibility.Equals(Visibility.Visible))
            {
                newAppointmentControl.Visibility = Visibility.Collapsed;
            }
        }

        private string FormattedDate()
        {
            var _date = CalendarControl.SelectedDate.Value;
            CalendarControl.SelectedDates.Add(_date);
            var test = _date.DayOfYear.ToString() + _date.Year.ToString();
            return test;
        }

    }
}
