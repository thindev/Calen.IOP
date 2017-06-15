using Calen.IOP.Client.Desktop.View;
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
        }

       

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
    }
}
