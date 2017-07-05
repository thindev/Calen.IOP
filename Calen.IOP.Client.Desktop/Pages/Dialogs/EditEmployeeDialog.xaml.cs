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
    public partial class EditEmployeeDialog : UserControl, IEditItemDialog
    {
        private ContentDialog _dialog;
        private bool _result;

        public EditEmployeeDialog()
        {
            InitializeComponent();
        }

        public async Task<bool> ShowDialogAsync<T>(T vm) where T : EntityVMBase
        {
            rootLayout.DataContext = vm;
            _dialog = new ContentDialog() { Title = "添加新项" };
            _dialog.VerticalAlignment = VerticalAlignment.Center;
            _dialog.HorizontalAlignment = HorizontalAlignment.Center;
            _dialog.Content = this;
            await DialogCoordinator.Instance.ShowMetroDialogAsync(Constants.MAIN_DIALOG, _dialog);
            await _dialog.WaitUntilUnloadedAsync();
            return _result;
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            _result = true;
            DialogCoordinator.Instance.HideMetroDialogAsync(Constants.MAIN_DIALOG, _dialog);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            _result = false;
            DialogCoordinator.Instance.HideMetroDialogAsync(Constants.MAIN_DIALOG, _dialog);
        }
    }
}
