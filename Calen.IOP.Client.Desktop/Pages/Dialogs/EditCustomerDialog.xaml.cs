using Calen.IOP.Client.ViewModel;
using MahApps.Metro.Controls.Dialogs;
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
    /// EditEmployeeDialog.xaml 的交互逻辑
    /// </summary>
    public partial class EditCustomerDialog : UserControl, IEditItemDialog
    {
        private DialogWindow _dialog;

        public EditCustomerDialog()
        {
            InitializeComponent();
        }

        public async Task<bool> ShowDialogAsync<T>(string title, T vm) where T : EntityVMBase
        {
            rootLayout.DataContext = vm;
            _dialog = new DialogWindow() { Title = title ,DialogResult=false};
            _dialog.VerticalAlignment = VerticalAlignment.Center;
            _dialog.HorizontalAlignment = HorizontalAlignment.Center;
            _dialog.Content = this;
            return _dialog.ShowDialog().Value;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            _dialog.DialogResult = true;
            _dialog.Close();
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            _dialog.DialogResult = false;
            _dialog.Close();
        }
    }
}
