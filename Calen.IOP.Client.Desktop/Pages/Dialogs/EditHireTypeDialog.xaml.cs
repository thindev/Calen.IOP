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
    /// EditHireTypeDialog.xaml 的交互逻辑
    /// </summary>
    public partial class EditHireTypeDialog : UserControl,IEditItemDialog<HireTypeVM>
    {
        public EditHireTypeDialog()
        {
            InitializeComponent();
        }
        CustomDialog dialog;
        bool result;
        public async Task<bool> ShowDialog(HireTypeVM vm)
        {
            rootLayout.DataContext = vm;
            dialog = new CustomDialog() { Title = "添加新项" };
            dialog.VerticalAlignment = VerticalAlignment.Center;
            dialog.HorizontalAlignment = HorizontalAlignment.Center;
            dialog.Content = this;
            await DialogCoordinator.Instance.ShowMetroDialogAsync(Constants.MAIN_DIALOG, dialog, (new MetroDialogSettings()));
            await dialog.WaitUntilUnloadedAsync();
            return result;
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
    }
}
