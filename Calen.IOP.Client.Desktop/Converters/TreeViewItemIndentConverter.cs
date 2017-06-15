using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    class TreeViewItemIndentConverter : IValueConverter
    {
        public double Indent { get; set; }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = value as TreeViewItem;
            if (null == item)
                return new Thickness(0);
            Thickness t= new Thickness(Indent * GetDepth(item), 0, 0, 0);
            return t;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

         int GetDepth( TreeViewItem item)
        {
            FrameworkElement elem = item;
            FrameworkElement parent = UtilMethods.FindAncestor<FrameworkElement>(elem);
            while (parent != null)
            {
                parent = UtilMethods.FindAncestor<FrameworkElement>(elem);
                var tvi = parent as TreeViewItem;
                if (null != tvi)
                {
                    return GetDepth(tvi) + 1;
                }

                elem = parent;
            }
            return 0;
        }

    }
    
}
