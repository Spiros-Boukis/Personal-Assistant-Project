using Personal_Assistant.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using Xceed.Wpf.AvalonDock.Controls;

namespace Personal_Assistant.Helpers
{
    public class  ViewsHelpers
    {


        public static J FindSelectedItemsControlItemContentByChild<T, J>(ItemsControl _itemsControl, T child) where T : DependencyObject where J : SmartHomeItem
        {
            J _selected = null;
            var temp = _itemsControl.FindLogicalChildren<T>();
            var itemsList = _itemsControl.FindVisualChildren<ContentPresenter>();

            if (itemsList.Count() > 0)
                foreach (var listviewitem in itemsList)
                {
                    //if is "selected" listview item
                    if (listviewitem.FindVisualChildren<T>().Contains(child))
                    {
                        _selected = listviewitem.Content as J;
                        var j = 0;
                        return _selected;
                    }
                }
            return null;
        }

        public static J FindSelectedListViewItemContentByChild<T, J>(ItemsControl _itemsControl, T child) where T : DependencyObject where J : SmartHomeItem
        {
            J _selected = null;
            var temp = _itemsControl.FindLogicalChildren<T>();
            var itemsList = _itemsControl.FindVisualChildren<ContentPresenter>();

            if (itemsList.Count() > 0)
                foreach (var listviewitem in itemsList)
                {
                    //if is "selected" listview item
                    if (listviewitem.FindVisualChildren<T>().Contains(child))
                    {
                        _selected = listviewitem.Content as J;
                        var j = 0;
                        return _selected;
                    }
                }
            return null;
        }


    }
}
