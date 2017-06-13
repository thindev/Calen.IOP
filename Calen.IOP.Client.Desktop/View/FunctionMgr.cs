using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calen.IOP.Client.Desktop.View
{
    public class FunctionMgr : DependencyObject
    {
        public static readonly DependencyProperty FunctionIdProperty = DependencyProperty.RegisterAttached("FunctionId", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null));
        public static readonly DependencyProperty FunctionNameProperty = DependencyProperty.RegisterAttached("FunctionName", typeof(string), typeof(FunctionMgr), new PropertyMetadata(null, FunctionNameChanged));

        private static void FunctionNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
           
        }

        public static void SetFunctionId(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionIdProperty, value);
        }
      
        public static string GetFunctionId(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionIdProperty);
        }

        public static void SetFunctionName(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionNameProperty, value);
        }

        public static string GetFunctionName(DependencyObject obj)
        {
            return (string)obj.GetValue(FunctionNameProperty);
        }
    }
}
