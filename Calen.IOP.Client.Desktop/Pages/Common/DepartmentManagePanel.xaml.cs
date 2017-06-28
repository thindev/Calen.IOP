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
using Calen.IOP.Client.ViewModel;
using MahApps.Metro.Controls.Dialogs;
using Calen.IOP.Client.Desktop.Pages.Dialogs;

namespace Calen.IOP.Client.Desktop.Pages
{
    /// <summary>
    /// DepartmentManagePanel.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentManagePanel : UserControl,IDeleteItemsDialog
    {
        public DepartmentManagePanel()
        {
            InitializeComponent();
            this.DataContext= _departmentManager = new DepartmentManagerVM();
            _departmentManager.RefreshItemsCommand.Execute(null);
            _departmentManager.DeleteItemsDialog = this;
        }

        public DepartmentManagerVM _departmentManager;
        IDialogCoordinator _dialogCoordinator = DialogCoordinator.Instance;

        bool _recursiveDelete = false;
        public bool RecursiveDelete { get => _recursiveDelete; set => _recursiveDelete = value; }

        public void SetTitle(string tile)
        {
            this.tb_Title.Text = tile;
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            if (_departmentManager.IsInDesignMode) return;
            _departmentManager.SelectedItem = e.NewValue as DepartmentVM;
        }

        public async Task<bool> ShowDialog<T>(IEnumerable<T> vms)where T:EntityVMBase
        {
            if (vms.Count() == 0) return false;
            CustomDialog dialog = new CustomDialog() { Title = "确定要删除("+vms.ElementAt(0).Name+")吗？"};
            DepartmentDeleteDialog content = new DepartmentDeleteDialog();
            dialog.Content = content;
            content.CloseHandler = () =>
              {
                  _dialogCoordinator.HideMetroDialogAsync(Constants.MAIN_DIALOG, dialog);
              };
            await _dialogCoordinator.ShowMetroDialogAsync(Constants.MAIN_DIALOG, dialog);
            await dialog.WaitUntilUnloadedAsync();
            this.RecursiveDelete = content.RecursiveDelete;
            return !content.IsCancel;

        }

       
    }
    
}
