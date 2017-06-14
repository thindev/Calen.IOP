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
        public static readonly DependencyProperty FunctionPageUriProperty = DependencyProperty.RegisterAttached("FunctionPageUri", typeof(Uri), typeof(FunctionMgr), new PropertyMetadata(null, FunctionNameChanged));


        private static List<FrameworkElement> _functionItemElements = new List<FrameworkElement>();
        private static void FunctionNameChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement fe = d as FrameworkElement;
            if(fe==null)
            {
                return;
            }
            if (e.NewValue!=null)
            {
               
                if(!_functionItemElements.Contains(fe))
                {
                    fe.Unloaded += Fe_Unloaded;
                    _functionItemElements.Add(fe);
                }
            }
            else
            {
                if (_functionItemElements.Contains(fe))
                {
                    fe.Unloaded -= Fe_Unloaded;
                    _functionItemElements.Remove(fe);
                }
            }
        }

        private static void Fe_Unloaded(object sender, RoutedEventArgs e)
        {
            FrameworkElement fe = sender as FrameworkElement;
            if (fe == null)
            {
                return;
            }
            fe.Unloaded -= Fe_Unloaded;
            if (_functionItemElements.Contains(fe))
            {
                _functionItemElements.Remove(fe);
            }
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

        public static void SetFunctionPageUri(DependencyObject obj, string value)
        {
            obj.SetValue(FunctionPageUriProperty, value);
        }

        public static Uri GetFunctionPageUri(DependencyObject obj)
        {
            return (Uri)obj.GetValue(FunctionPageUriProperty);
        }
    }
}
