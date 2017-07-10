using Calen.IOP.Client.ViewModel;
using Calen.IOP.Client.ViewModel.Common;
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

namespace Calen.IOP.Client.Desktop.Pages.Widgets
{
    /// <summary>
    /// JobPositionSelector.xaml 的交互逻辑
    /// </summary>
    public partial class PermissionSelector : UserControl
    {
        List<FunctionVM> _funcTree;
        UserRoleManagerVM _userRoleManager;
        public PermissionSelector()
        {
            InitializeComponent();
            _userRoleManager = new UserRoleManagerVM();
            _userRoleManager.RefreshItemsCommand.Execute(null);
            _funcTree = AppCxt.Current.FunctionManager.CloneFunctionTree();
            this.funTree.ItemsSource = _funcTree;
            this.brd_popup.DataContext = _userRoleManager;
            this.popup.Opened += Popup_Opened;
        }

        private void Popup_Opened(object sender, EventArgs e)
        {
            this.ResetUI(this.TargetEmployee);
        }

        public static readonly DependencyProperty IsReadOnlyProperty = TextBox.IsReadOnlyProperty.AddOwner(typeof(PermissionSelector));
        public static readonly DependencyProperty TargetEmployeeProperty = DependencyProperty.Register("TargetEmployee", typeof(EmployeeVM), typeof(PermissionSelector), new PropertyMetadata(null, TargetEmployeeChanged));
        public EmployeeVM TargetEmployee
        {
            get { return (EmployeeVM)GetValue( TargetEmployeeProperty); }
            set { SetValue(TargetEmployeeProperty, value); }
        }

        private static void TargetEmployeeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //PermissionSelector jps = (PermissionSelector)d;
            //EmployeeVM value = e.NewValue as EmployeeVM;
            //jps.ResetUI(value);
        }

        private void ResetUI(EmployeeVM vm)
        {
            if (vm != null)
            {
                foreach (var item in _funcTree)
                {
                    this.CheckFunc(vm,item);
                }
                this.SetText(vm);
            }
        }

        void CheckFunc(EmployeeVM vm,FunctionVM item)
        {
            
            if (vm.PermissionIds.Contains(item.Id))
                item.IsChecked = true;
            else
                item.IsChecked = false;
            List<string> idsInRoles = new List<string>();
            foreach(string id in vm.UserRoleIds)
            {
               var ur= _userRoleManager.ItemList.FirstOrDefault(p=>p.Id==id);
                if(ur!=null)
                {
                    idsInRoles= idsInRoles.Union(ur.FunctionIds).ToList();
                }
            }
            if (idsInRoles.Contains(item.Id))
            {
                item.IsChecked = true;
                item.IsReadOnly = true;
            } 
            else
            {
                item.IsReadOnly = false;
            }

            foreach (FunctionVM sub in item.SubFunctions)
            {
                CheckFunc(vm, sub);
            }
        }

        void SetText(EmployeeVM vm)
        {
            List<string> names = new List<string>();
            foreach (var item in _funcTree)
            {
                GetName(names, vm, item);
            }
            this.txb.Text = string.Join(",", names);
        }
        void GetName(List<string> names,EmployeeVM vm,FunctionVM item)
        {
            if (vm.PermissionIds.Contains(item.Id))
                names.Add(item.Name);
            foreach(var sub in item.SubFunctions)
            {
                GetName(names, vm, sub);
            }
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }


        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.TargetEmployee.PermissionIds.Clear();
            foreach (var item in _funcTree)
            {
                GetId(item);
            }
            this.SetText(this.TargetEmployee);
            this.popup.IsOpen = false;
            
        }

       

        void GetId(FunctionVM item)
        {
            if (item.IsChecked)
            {
                this.TargetEmployee.PermissionIds.Add(item.Id);
            }
            foreach(var sub in item.SubFunctions)
            {
                GetId(sub);
            }
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            if(this.TargetEmployee!=null)
            {
                this.ResetUI(this.TargetEmployee);
            }
            this.popup.IsOpen = false;
        }

        private void txb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!this.IsReadOnly)
                this.tgb.IsChecked = true;
        }
    }
}
