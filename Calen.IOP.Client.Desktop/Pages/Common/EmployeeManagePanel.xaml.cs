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
        }
        DoubleAnimation _expandAnimation;
        DoubleAnimation _collapseAnimation;
        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
