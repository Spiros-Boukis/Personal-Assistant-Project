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
    public class SmartHomeItemDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is SmartHomeItem)
            {
                SmartHomeItem parameteritem = item as SmartHomeItem;




                if (parameteritem.Type==1)
                {
                    return element.FindResource("lightBulbTemplate") as DataTemplate;
                }
                else if (parameteritem.Type==2) 
                {
                    return element.FindResource("temperatureTemplate") as DataTemplate;
                }

            }
            return element.FindResource("ReadEmailPreviewTemplate") as DataTemplate;
        }

    }
}
