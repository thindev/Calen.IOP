using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calen.IOP.Client.Desktop.Controls
{
    /// <summary>
    /// BusyIndicator.xaml 的交互逻辑
    /// </summary>
    public partial class BusyIndicator : UserControl
    {
        public static readonly DependencyProperty IsBusyProperty = DependencyProperty.Register("IsBusy", typeof(bool), typeof(BusyIndicator), new PropertyMetadata(false, new PropertyChangedCallback(IsBusyPropertyChangedCallback)));
        public bool IsBusy
        {
            get { return (bool)GetValue(IsBusyProperty); }
            set { base.SetValue(IsBusyProperty, value); }
        }
        private static void IsBusyPropertyChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BusyIndicator bi = (BusyIndicator)d;
            if (bi.IsBusy)
            {
                bi.Visibility = Visibility.Visible;
            }
            else
            {
                bi.Visibility = Visibility.Collapsed;
            }
        }

        public BusyIndicator()
        {
            InitializeComponent();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
