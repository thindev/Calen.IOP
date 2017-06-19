using Calen.IOP.Client.Desktop.ConvertUtil;
using Calen.IOP.DTO.Json;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
#if WINDOWS_WPF
using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;
#else
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;
#endif
namespace Calen.IOP.Client.ViewModel
{
    public class DepartmentManager:ManagerBase<DepartmentViewModel>
    {
        ObservableCollection<DepartmentViewModel> _rootDepartments = new ObservableCollection<DepartmentViewModel>();

        public ObservableCollection<DepartmentViewModel> RootDepartments { get => _rootDepartments;  }
       
        public ICommand RefreshDepartmentsCommand
        {
            get
            {
                if (_refreshDepartmentsCommand == null)
                {
                    _refreshDepartmentsCommand = new RelayCommand(RefreshDepartmentsExcute);
                }
                return _refreshDepartmentsCommand;
            }
        }

       
#region Commands
        ICommand _refreshDepartmentsCommand;
       

        private void RefreshDepartmentsExcute()
        {
            this.RefreshDepartmentsAsync();
        }
#endregion

        private async void RefreshDepartmentsAsync()
        {
            if (IsInDesignMode) return;
            _rootDepartments.Clear();
            this.IsBusy = true;
            ICollection<department> ds=await AppCxt.Current.RestDataPortal.GetDepartmentTreeAsync();
            this.IsBusy = false;
            if (ds!=null)
            {
                foreach (department d in ds)
                {
                    DepartmentViewModel vm = DepartmentConverter.FromDto(null,d);
                    _rootDepartments.Add(vm);
                }
            }
            if(this.SelectedItem!=null)
            {
                foreach(var root in _rootDepartments)
                {
                    this.FindSelectedItem(root);
                }
            }


        }

        void FindSelectedItem(DepartmentViewModel vm)
        {
            if(vm.Id==SelectedItem.Id)
            {
                vm.IsSelected = true;
                return;
            }
            else
            {
                if(vm.SubDepartments!=null)
                {
                    this.FindSelectedItem(vm);
                }
            }
        }

        public async static Task<ICollection<DepartmentViewModel>> GetDepartmentTreeAsync()
        {
            List<DepartmentViewModel> treeRoots = new List<DepartmentViewModel>();
            ICollection<department> ds = await AppCxt.Current.RestDataPortal.GetDepartmentTreeAsync();
            if (ds != null)
            {
                foreach (department d in ds)
                {
                    DepartmentViewModel vm = DepartmentConverter.FromDto(null, d);
                    treeRoots.Add(vm);
                }
            }
            return treeRoots;
        }
    }
}
