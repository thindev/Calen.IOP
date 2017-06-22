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

namespace Calen.IOP.Client.Desktop.Pages.Dialogs
{
    /// <summary>
    /// DepartmentDeleteDialog.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentDeleteDialog : UserControl
    {
        public DepartmentDeleteDialog()
        {
            InitializeComponent();
        }
        public bool RecursiveDelete { get { return this.checkBox.IsChecked.Value; } }
        public bool IsCancel { get; private set; }

        public Action CloseHandler { get; set; }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.IsCancel = false;
            this.CloseHandler?.Invoke();
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.IsCancel = true;
            this.CloseHandler?.Invoke();
        }
    }
}
