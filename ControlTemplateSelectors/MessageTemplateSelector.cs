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
    public class MessageTemplateSelector :  DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is ContactMessage)
            {
                ContactMessage parameteritem = item as ContactMessage;




                if (parameteritem.Type == 0)
                {
                    return element.FindResource("incomingTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("outgoingTemplate") as DataTemplate;
                }

            }
            return element.FindResource("incomingTemplate") as DataTemplate;
        }
    }
}
