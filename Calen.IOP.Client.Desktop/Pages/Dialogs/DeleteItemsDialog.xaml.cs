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
    /// DeleteItemsDialog.xaml 的交互逻辑
    /// </summary>
    public partial class DeleteItemsDialog : UserControl, IDeleteItemsDialog
    {
        public bool RecursiveDelete { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        CustomDialog dialog;
        bool result;

        public DeleteItemsDialog()
        {
            InitializeComponent();
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            result = true;
            DialogCoordinator.Instance.HideMetroDialogAsync(Constants.MAIN_DIALOG, dialog);
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            result = false;
            DialogCoordinator.Instance.HideMetroDialogAsync(Constants.MAIN_DIALOG, dialog);
        }

        public async Task<bool> ShowDialog<T>(IEnumerable<T> items)where T:EntityVMBase
        {
            dialog = new CustomDialog() { Title = "确定要删除所选的"+items.Count()+"项记录吗？" };
            dialog.Content = this;
            await DialogCoordinator.Instance.ShowMetroDialogAsync(Constants.MAIN_DIALOG, dialog);
            await dialog.WaitUntilUnloadedAsync();
            return result;
        }
    }
}
