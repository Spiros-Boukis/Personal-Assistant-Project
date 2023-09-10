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
    public class EmailPreviewStyleSelector : StyleSelector
    {
        public override Style SelectStyle(object item, DependencyObject container)
        {
            FrameworkElement element = container as FrameworkElement;

            if (element != null && item != null && item is EmailEntry)
            {
                EmailEntry parameteritem = item as EmailEntry;

                if(parameteritem.IsRead)
                {
                    return element.FindResource("ReadEmailPreviewStyleTemplate") as Style;
                }
                else
                {
                    return element.FindResource("UnreadEmailPreviewStyleTemplate") as Style;
                }
                
            }
            return element.FindResource("ReadEmailPreviewStyleTemplate") as Style;
        }
    }
}
