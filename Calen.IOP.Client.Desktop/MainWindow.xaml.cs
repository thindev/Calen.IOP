using Calen.IOP.Client.Desktop.View;
using Calen.IOP.Client.ViewModel;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calen.IOP.Client.Desktop
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            var fun = new CubicEase() { EasingMode = EasingMode.EaseInOut };
            _expandAnimation = new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(200)), FillBehavior=FillBehavior.Stop,AccelerationRatio=0.9};
            _collapseAnimation=new DoubleAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(200)),To=this.leftPanel.CollapsedWidth ,AccelerationRatio=0.9};
            _collapseAnimation.Completed += _collapseAnimation_Completed;
            _expandAnimation.Completed += _expandAnimation_Completed; ;
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            FrameworkElement fe = (FrameworkElement)base.GetVisualChild(0);
            fe.LayoutTransform = AppCxt.Current.OptionsSettings.ScaleTransform;
        }

        private void _expandAnimation_Completed(object sender, EventArgs e)
        {
            this.leftColumn.Width = new GridLength(_lastLeftWidth);
            this.leftPanel.Width = double.NaN;
        }

      

        private void _collapseAnimation_Completed(object sender, EventArgs e)
        {
            this.gridSplitter.Visibility = Visibility.Collapsed;
            this.leftPanel.Margin = new Thickness(0);
            this.leftPanel.HideMenu();
        }

        DoubleAnimation _expandAnimation;
        DoubleAnimation _collapseAnimation;
       

        private void leftPanel_SelectedNewItem(object sender, RoutedPropertyChangedEventArgs<TreeViewItem> e)
        {
            TreeViewItem tv = e.NewValue;
            if(tv!=null)
            {
                Uri uri = FunctionMgr.GetFunctionPageUri(tv);
                string name = FunctionMgr.GetFunctionName(tv);
                this.contentContainer.GoToPage(uri,name);
            }
        }

        private void leftPanel_Expanded(object sender, RoutedEventArgs e)
        {
            _expandAnimation.To = _lastLeftWidth-this.leftPanel.CollapsedWidth;
           // this.leftColumn.Width = new GridLength(_lastLeftWidth);
            this.gridSplitter.Visibility = Visibility.Visible;
            this.leftPanel.Margin = new Thickness(0,0,gridSplitter.Width,0);
            this.leftPanel.BeginAnimation(FrameworkElement.WidthProperty, _expandAnimation);
        }

        double _lastLeftWidth;
        private void leftPanel_Collapsed(object sender, RoutedEventArgs e)
        {
            _lastLeftWidth = this.leftColumn.ActualWidth;
            this.leftPanel.Width = _lastLeftWidth-this.leftPanel.CollapsedWidth;
            if (_lastLeftWidth < 40)
                _lastLeftWidth = 40;
            this.leftColumn.Width = GridLength.Auto;//new GridLength(this.leftPanel.CollapsedWidth);
            this.leftPanel.BeginAnimation(FrameworkElement.WidthProperty, _collapseAnimation);
        }
    }
}
