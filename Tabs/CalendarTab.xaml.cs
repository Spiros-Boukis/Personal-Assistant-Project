using Personal_Assistant.CustomControls;
using Personal_Assistant.Helpers;
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
    /// Interaction logic for CalendarTab.xaml
    /// </summary>
    /// 
    
    public partial class CalendarTab : UserControl
    {
        public Dictionary<string, List<AppointmentEntry>> Appointments;



        Style s;


        public CalendarTab()
        {
            InitializeComponent();
            
            newAppointmentControl.Visibility = Visibility.Collapsed;
            Appointments = new Dictionary<string, List<AppointmentEntry>>();
            var today = DateTime.Today.ToShortDateString();
            var threedaysLater = DateTime.Today.AddDays(3).ToShortDateString();
            Appointments.Add(today, new List<AppointmentEntry>());
            Appointments.Add(threedaysLater, new List<AppointmentEntry>());
            var temp = Appointments[today];
            temp.Add(new AppointmentEntry("Giatros stis 17:00", "", 1,new DateTime(1000, 1, 1, 15,00,00)));
            temp.Add(new AppointmentEntry("Cafe me ton giannis stis 21:00", "", 0, new DateTime(1000, 1, 1, 21, 45, 00)));
            var temp1 = Appointments[threedaysLater];
            temp1.Add(new AppointmentEntry("Klirosi stis 10", "", 0, new DateTime(1000, 1, 1, 13, 10, 00)));
            temp1.Add(new AppointmentEntry("kati exw na kanw ", "", 0, new DateTime(1000, 1, 1, 22, 00, 00)));
            temp1.Add(new AppointmentEntry("Rantevou gia douleia", "", 1, new DateTime(1000, 1, 1, 5, 00, 00)));
            //timePicker.Text = "12:00";
            //timePicker.Value = "12:00";

            AppointmentsListView.ItemsSource = Appointments[today];
            AppointmentsListView.Items.Refresh();
            /*s = (Style)this.Resources["cdbKey"];
            foreach (var date in Appointments)
            {
                var _value = DateTime.Parse(date.Key);
                var _formattedDate = _value.Month.ToString()+"/"+_value.Day + "/" + _value.Year;
                

                DataTrigger dataTrigger = new DataTrigger() { Binding = new Binding("Date"), Value = _formattedDate };
                dataTrigger.Setters.Add(new Setter(CalendarDayButton.BackgroundProperty, Brushes.LightGreen));
                s.Triggers.Add(dataTrigger);
            }
            */
            CalendarControl.SelectedDate = DateTime.Today;
            timePicker.Value = DateTime.Now;

            DateHelper.Appointments = this.Appointments;

        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            var _date = CalendarControl.SelectedDate.Value.ToShortDateString();
            currentDate.Content = _date;
            //CalendarControl.SelectedDates.Add(_date);
            var test = _date;
            if (Appointments.ContainsKey(_date))
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
                var _date = CalendarControl.SelectedDate.Value.ToShortDateString();

                var test = _date.ToString();
                var prompt = MessageBox.Show("Θέλετε να διαγράψετε αυτό το ραντεβού?", "Διαγραφή", MessageBoxButton.YesNo);
                if (prompt == MessageBoxResult.Yes)
                {
                    AppointmentEntry item = (AppointmentEntry)AppointmentsListView.SelectedItem;

                    Appointments[test].Remove(item);
                    var temp = Appointments[test];
                    AppointmentsListView.ItemsSource = temp;
                    AppointmentsListView.Items.Refresh();
                    if (Appointments[test].Count==0) 
                    {
                        Appointments.Remove(test);
                        var tempDate = CalendarControl.SelectedDate.Value;
                        CalendarControl.DisplayDate = tempDate.AddMonths(1);
                        CalendarControl.DisplayDate = tempDate;
                    }
                }
                else
                { }
            }
        }

        private void NewAppointment_Click(object sender, RoutedEventArgs e)
        {
            if (newAppointmentControl.Visibility.Equals(Visibility.Collapsed))
            {
                newAppointmentControl.Visibility = Visibility.Visible;
            }
        }

        private void saveNewAppointment(object sender, RoutedEventArgs e)
        {
            var time = timePicker.Value;
            var entry = new AppointmentEntry();
            entry.Title = newEntryText.Text;
            entry.Description = "";
            var item = priorityComboBox.SelectedItem as FrameworkElement;
            entry.Type = 0;
            if (item.Name=="normal")
            {
                entry.Type = 0;
            }
            if (item.Name == "important")
            {
                entry.Type = 1;
            }
            if (item.Name == "deadline")
            {
                entry.Type = 2;
            }

            entry.Time = time;
    
            var selectedDate = CalendarControl.SelectedDate.Value;
            var _formattedDate = selectedDate.Month.ToString() + "/" + selectedDate.Day + "/" + selectedDate.Year;
            var _date = CalendarControl.SelectedDate.Value.ToShortDateString();
            
            if (Appointments.ContainsKey(_date))
            {
                Appointments[_date].Add(entry);
            }
            else
            {
                Appointments.Add(_date, new List<AppointmentEntry>());
                Appointments[_date].Add(entry);
                var tempDate = CalendarControl.SelectedDate.Value;
                CalendarControl.SelectedDate = DateTime.Now.AddMonths(1).ToUniversalTime();
                CalendarControl.SelectedDate = tempDate;
                //aTrigger dataTrigger = new DataTrigger() { Binding = new Binding("Date"), Value = _formattedDate };
                //aTrigger.Setters.Add(new Setter(CalendarDayButton.BackgroundProperty, Brushes.LightGreen));
                // s.Triggers.Add(dataTrigger);

                CalendarControl.DisplayDate = tempDate.AddMonths(1);
                CalendarControl.DisplayDate = tempDate;

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
            var _date = CalendarControl.SelectedDate.Value.ToShortDateString();
            return _date;
            //CalendarControl.SelectedDates.Add(_date);
            //var test = _date.DayOfYear.ToString() + _date.Year.ToString();
            //return test;
        }

        private void calendarStackPanel_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Delete)
            {
                var _date = CalendarControl.SelectedDate.Value.ToShortDateString();

                var test = _date.ToString();
                var prompt = MessageBox.Show("Θέλετε να διαγράψετε αυτό το ραντεβού?", "Διαγραφή", MessageBoxButton.YesNo);
                if (prompt == MessageBoxResult.Yes)
                {
                    AppointmentEntry item = (AppointmentEntry)AppointmentsListView.SelectedItem;

                    Appointments[test].Remove(item);
                    var temp = Appointments[test];
                    AppointmentsListView.ItemsSource = temp;
                    AppointmentsListView.Items.Refresh();
                    if (Appointments[test].Count == 0)
                    {
                        Appointments.Remove(test);
                        var tempDate = CalendarControl.SelectedDate.Value;
                        CalendarControl.DisplayDate = tempDate.AddMonths(1);
                        CalendarControl.DisplayDate = tempDate;
                    }
                }
                else
                { }
            }
            else if(e.Key == Key.Insert) 
            {
                if (newAppointmentControl.Visibility.Equals(Visibility.Collapsed))
                {
                    newAppointmentControl.Visibility = Visibility.Visible;
                }

                else if (newAppointmentControl.Visibility.Equals(Visibility.Visible))
                {
                    newAppointmentControl.Visibility = Visibility.Collapsed;
                }
            }



        }
    }
}
