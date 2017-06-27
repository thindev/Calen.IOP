using Calen.IOP.Client.ViewModel;
using Calen.IOP.DataPortal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// DepartmentSelector.xaml 的交互逻辑
    /// </summary>
    public partial class DepartmentSelector : UserControl
    {
        public static readonly DependencyProperty SelectedDepartmentProperty = DependencyProperty.Register("SelectedDepartment", typeof(DepartmentVM), typeof(DepartmentSelector), new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault, SelectedDepartmentChanged));
        protected ObservableCollection<DepartmentVM> ItemList=new ObservableCollection<DepartmentVM>();

        private static void ExcludedDepartmentChanged(DependencyObject d,  DependencyPropertyChangedEventArgs e)
        {
            
        }



        ObservableCollection<DepartmentVM> _departmentTree = new ObservableCollection<DepartmentVM>();
        public static readonly DependencyProperty IsReadOnlyProperty = TextBox.IsReadOnlyProperty.AddOwner(typeof(DepartmentSelector));

        private static void SelectedDepartmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DepartmentSelector ds = (DepartmentSelector)d;
            if (ds.SelectedDepartment != null)
                ds.txb.Text = ds.SelectedDepartment.Name;
            else
                ds.txb.Text = string.Empty;
        }
        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }
        public DepartmentVM SelectedDepartment
        {
            get { return (DepartmentVM) GetValue(SelectedDepartmentProperty); }
            set { SetValue(SelectedDepartmentProperty, value); }
        }
        void SetSelectedItem()
        {
            if (this.SelectedDepartment == null) return;
            foreach(DepartmentVM dv in this.DepartmentTree)
            {
                this.FindDepartment(dv);
            }
        }
        void FindDepartment(DepartmentVM vm)
        {
            if (vm.Id == this.SelectedDepartment.Id)
            {
                vm.IsSelected = true;
                return ;
            }
            else
            {
                if (vm.SubDepartments == null) return ;
                foreach(DepartmentVM dv in vm.SubDepartments)
                {
                    FindDepartment(vm);
                }
            }
        }

        public DepartmentSelector()
        {
            InitializeComponent();
        }

        protected bool IsDataLoaded=false;

        public ObservableCollection<DepartmentVM> DepartmentTree { get => _departmentTree; }

        private void Popup_Opened(object sender, EventArgs e)
        {
            if (!IsDataLoaded)
            {
                this.RefreshDepartments();
            }
            else
            {
                SetSelectedItem();
            }
        }

        protected async void RefreshDepartments()
        {
            this.ItemList.Clear();
            this.busyCtrl.IsBusy = true;
            ICollection<DepartmentVM> ds = await DepartmentManagerVM.GetDepartmentTreeAsync();
            foreach(var item in ds)
            {
                ItemList.Add(item);
            }
            this.busyCtrl.IsBusy = false;
            this.treeView.ItemsSource = ItemList;
            IsDataLoaded = true;
            this.SetSelectedItem();
            this.OnRefreshFinished();
        }

        protected virtual void OnRefreshFinished()
        {

        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false;
            DepartmentVM vm = (DepartmentVM)this.treeView.SelectedItem;
            if(vm!=null)
            {
                this.SelectedDepartment = vm;
            }
            
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            this.popup.IsOpen = false;
        }

        private void btn_refresh_Click(object sender, RoutedEventArgs e)
        {
            this.RefreshDepartments();
        }
    }
}
