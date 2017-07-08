using Calen.IOP.Client.Desktop.Animations;
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

namespace Calen.IOP.Client.Desktop.Pages.Common
{
    /// <summary>
    /// EmployeeManagePanel.xaml 的交互逻辑
    /// </summary>
    public partial class EmployeeManagePanel : UserControl
    {
        public EmployeeManagePanel()
        {
            InitializeComponent();
            var fun = new CubicEase() { EasingMode = EasingMode.EaseInOut };
            _expandAnimation = new GridLengthAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(300)), FillBehavior=FillBehavior.Stop ,EasingFunction=fun};
            _collapseAnimation = new GridLengthAnimation() { Duration = new Duration(TimeSpan.FromMilliseconds(300)), To =new GridLength(0), EasingFunction=fun };
            _collapseAnimation.Completed += _collapseAnimation_Completed;
            _expandAnimation.Completed += _expandAnimation_Completed;
            _lastWidth = rightColumn.Width;
            this.Button_Click(null, null);
        }

        GridLength _lastWidth;
        bool _isExpanded;
        private void _expandAnimation_Completed(object sender, EventArgs e)
        {
            _isExpanded = true;
        }

        private void _collapseAnimation_Completed(object sender, EventArgs e)
        {
            _isExpanded = false;   
        }

        GridLengthAnimation _expandAnimation;
        GridLengthAnimation _collapseAnimation;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
          //  if (_isExpanded)
            {
                _lastWidth = rightColumn.Width;
                _collapseAnimation.From = _lastWidth;
                this.rightColumn.BeginAnimation(ColumnDefinition.WidthProperty, _collapseAnimation);
            }
        }

        private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!_isExpanded)
            {
                _expandAnimation.To = _lastWidth;
                _expandAnimation.From = rightColumn.Width;
                this.rightColumn.BeginAnimation(ColumnDefinition.WidthProperty, _expandAnimation);
            }
        }
    }
}
