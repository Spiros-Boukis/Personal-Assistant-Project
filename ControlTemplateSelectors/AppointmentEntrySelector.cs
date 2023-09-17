using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Personal_Assistant.ControlTemplateSelectors
{
    public class AppointmentEntrySelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is AppointmentEntry)
            {
                AppointmentEntry parameteritem = item as AppointmentEntry;

                if (parameteritem.Type == 0)
                    return element.FindResource("NormalAppointmentTemplate") as DataTemplate;
                else if (parameteritem.Type == 1)
                    return element.FindResource("ImportantAppointmentTemplate") as DataTemplate;
                else if (parameteritem.Type == 2)
                    return
                        element.FindResource("DeadlineAppointmentTemplate") as DataTemplate;
                else if (parameteritem.Type == 3)
                    return
                        element.FindResource("SportsAppointmentTemplate") as DataTemplate;
                else if (parameteritem.Type == 4)
                    return
                        element.FindResource("BasketballAppointmentTemplate") as DataTemplate;
                else if (parameteritem.Type == 5)
                    return
                        element.FindResource("TennisAppointmentTemplate") as DataTemplate;
            }

            return null;

        }
    }




}
