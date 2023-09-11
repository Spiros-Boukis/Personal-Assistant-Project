using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Personal_Assistant.Helpers
{
    public class DateHelper
    {

        public static Dictionary<string, List<AppointmentEntry>> Appointments;

        public static DateTime GetDate(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(DateProperty);
        }

        public static void SetDate(DependencyObject obj, DateTime value)
        {
            obj.SetValue(DateProperty, value);
        }




        public static readonly DependencyProperty DateProperty =
            DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(DateHelper), new PropertyMetadata { PropertyChangedCallback = DatePropertyChanged });

        private static void DatePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var date = GetDate(d);
            SetHasEntries(d, CheckHasEntries(date));


        }


        private static bool CheckHasEntries(DateTime date)
        {
            var _formattedDate = date.Month.ToString() + "/" + date.Day + "/" + date.Year;
            if(_formattedDate=="11/08/2023")
            {
                Console.Write("");
            }
            if (!Appointments.ContainsKey(date.ToShortDateString()) || date<DateTime.Now)
            {
                return false;
            }
            else
            {
                return true;
            }

        }

        private static readonly DependencyPropertyKey HasEntriesPropertyKey =
        DependencyProperty.RegisterAttachedReadOnly("HasEntries", typeof(bool), typeof(DateHelper), new PropertyMetadata());

        public static readonly DependencyProperty HasEntriesProperty = HasEntriesPropertyKey.DependencyProperty;

        public static bool GetHasEntries(DependencyObject obj)
        {
            return (bool)obj.GetValue(HasEntriesProperty);
        }

        private static void SetHasEntries(DependencyObject obj, bool value)
        {
            obj.SetValue(HasEntriesPropertyKey, value);
        }


    }
}
