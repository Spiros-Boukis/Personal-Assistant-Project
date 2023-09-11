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
    public class EmailPreviewStyleSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is EmailEntry)
            {
                EmailEntry parameteritem = item as EmailEntry;




                if(parameteritem.IsRead)
                {
                    return element.FindResource("ReadEmailPreviewTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("UnreadEmailPreviewTemplate") as DataTemplate;
                }
                
            }
            return element.FindResource("ReadEmailPreviewTemplate") as DataTemplate;
        }
    }


    public class SentEmailPreviewStyleSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is EmailEntry)
            {
                EmailEntry parameteritem = item as EmailEntry;




                if (parameteritem.IsRead)
                {
                    return element.FindResource("SentReadEmailPreviewTemplate") as DataTemplate;
                }
                else
                {
                    return element.FindResource("SentUnreadEmailPreviewTemplate") as DataTemplate;
                }

            }
            return element.FindResource("SentReadEmailPreviewTemplate") as DataTemplate;
        }
    }
}
