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
    public partial class UserRoleSelector : UserControl
    {
        ListCollectionView lcv;
        public UserRoleSelector()
        {
            InitializeComponent();
            _viewModel = new UserRoleManagerVM();
            _viewModel.ItemList.CollectionChanged += ItemList_CollectionChanged;
            _viewModel.RefreshItemsCommand.Execute(null);
            lcv = new ListCollectionView(_viewModel.ItemList);
            lcv.IsLiveFiltering = true;
            lcv.LiveFilteringProperties.Add("IsSelected");
            lcv.Filter = (p) =>
            {
                return (p as UserRoleVM).IsSelected;
            };
            this.list_selected.ItemsSource = lcv;
            this.brd_popup.DataContext = _viewModel;
            this.list_forSelect.ItemsSource = _viewModel.ItemList;
            this.popup.Opened += Popup_Opened;
        }

        private void Popup_Opened(object sender, EventArgs e)
        {
            _viewModel.RefreshItemsCommand.Execute(null);
        }

        private void ItemList_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            var vm = this.TargetEmployee;
            if (vm == null) return;
            if (e.NewItems != null)
            {
                foreach (UserRoleVM item in e.NewItems)
                {
                    if (vm.UserRoleIds.Contains(item.Id))
                        item.IsSelected = true;
                    else
                        item.IsSelected = false;
                }
            }
            if (e.OldItems != null)
            {
                foreach (UserRoleVM item in e.OldItems)
                {
                    if (vm.UserRoleIds.Contains(item.Id))
                        item.IsSelected = true;
                    else
                        item.IsSelected = false;
                }
            }
            this.SetText();
        }

        UserRoleManagerVM _viewModel;
        public static readonly DependencyProperty IsReadOnlyProperty = TextBox.IsReadOnlyProperty.AddOwner(typeof(UserRoleSelector));
        public static readonly DependencyProperty TargetEmployeeProperty = DependencyProperty.Register("TargetEmployee", typeof(EmployeeVM), typeof(UserRoleSelector), new PropertyMetadata(null));
        public EmployeeVM TargetEmployee
        {
            get { return (EmployeeVM)GetValue( TargetEmployeeProperty); }
            set { SetValue(TargetEmployeeProperty, value); }
        }

       

       

        void SetText()
        {
            EmployeeVM vm = this.TargetEmployee;
            List<string> names = new List<string>();
            foreach (var item in _viewModel.ItemList)
            {
                if (vm.UserRoleIds.Contains(item.Id))
                names.Add(item.Name);
            }
            this.txb.Text = string.Join(",", names);
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }


        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.TargetEmployee.UserRoleIds.Clear();
            foreach (var item in _viewModel.ItemList)
            {
                if(item.IsSelected)
                {
                    this.TargetEmployee.UserRoleIds.Add(item.Id);
                }
            }
            this.SetText();
            this.popup.IsOpen = false;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false;
        }

        private void txb_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (!this.IsReadOnly)
                this.tgb.IsChecked = true;
        }
    }
}
