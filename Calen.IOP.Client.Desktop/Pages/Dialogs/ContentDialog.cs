using MahApps.Metro.Controls.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calen.IOP.Client.Desktop.Pages.Dialogs
{
    public class ContentDialog:CustomDialog
    {
        public ContentDialog()
        {
            this.Loaded += ContentDialog_Loaded;
            this.Unloaded += ContentDialog_Unloaded;
        }
        FrameworkElement fe;
        private void ContentDialog_Unloaded(object sender, System.Windows.RoutedEventArgs e)
        {
            fe.MouseDown -= Fe_MouseDown;
            this.Loaded -= ContentDialog_Loaded;
            this.Unloaded -= ContentDialog_Unloaded;
        }

        private void Fe_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            Window.GetWindow(fe).DragMove();
        }

        private void ContentDialog_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            fe = (this.Parent as FrameworkElement).Parent as FrameworkElement;
            fe.MouseDown += Fe_MouseDown;
        }
    }
}
