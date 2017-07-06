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
    public partial class JobPositionSelector : UserControl
    {
        public JobPositionSelector()
        {
            InitializeComponent();
            _viewModel = new JobPositionSelectorVM();
            _viewModel.RefreshDataCommand.Execute(null);
            ListCollectionView lcv = new ListCollectionView(_viewModel.JobPositionList);
            lcv.Filter = (p) =>
            {
                return (p as JobPositionVM).IsSelected;
            };
            this.list_selected.ItemsSource = lcv;
            treeView.ItemsSource = _viewModel.DepartmentTreeRoots;
            this.brd_popup.DataContext = _viewModel;
        }
        JobPositionSelectorVM _viewModel;
        public static readonly DependencyProperty IsReadOnlyProperty = TextBox.IsReadOnlyProperty.AddOwner(typeof(JobPositionSelector));
        public static readonly DependencyProperty TargetEmployeeProperty = DependencyProperty.Register("TargetEmployee", typeof(EmployeeVM), typeof(JobPositionSelector), new PropertyMetadata(null, TargetEmployeeChanged));
        public EmployeeVM TargetEmployee
        {
            get { return (EmployeeVM)GetValue( TargetEmployeeProperty); }
            set { SetValue(TargetEmployeeProperty, value); }
        }

        private static void TargetEmployeeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            JobPositionSelector jps = (JobPositionSelector)d;
            EmployeeVM value = e.NewValue as EmployeeVM;
            jps._viewModel.SetTargetEmployee(value);
            if(value!=null)
            {
                jps.SetText(value);
            }
        }
        void SetText(EmployeeVM vm)
        {
            List<string> names = new List<string>();
            foreach (var item in vm.ServingRecords)
            {
                if (item.JobPosition == null) continue;
                names.Add(item.JobPosition.Name);
            }
            this.txb.Text = string.Join(",", names);
        }

        public bool IsReadOnly
        {
            get { return (bool)GetValue(IsReadOnlyProperty); }
            set { SetValue(IsReadOnlyProperty, value); }
        }

        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            DepartmentVM department = e.NewValue as DepartmentVM;
            if(department==null)
            {
                this.list_forSelect.ItemsSource = null;
            }
            else
            {
                this.list_forSelect.ItemsSource = department.JobPositions;
            }
           
        }

        private void btn_ok_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.ConfirmCommand.Execute(null);
            this.SetText(this.TargetEmployee);
            this.popup.IsOpen = false;
        }

        private void btn_cancel_Click(object sender, RoutedEventArgs e)
        {
            _viewModel.CancelCommand.Execute(null);
            this.popup.IsOpen = false;
        }
    }
}
