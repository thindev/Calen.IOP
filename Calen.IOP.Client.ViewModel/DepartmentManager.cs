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
        bool _isEditingNewItem;

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

        
        protected override void AddExcute()
        {
            DepartmentViewModel vm = new DepartmentViewModel() { Id = Guid.NewGuid().ToString() };
            vm.ParentDepartment = this.SelectedItem;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            _isEditingNewItem = true;
        }
        protected override void SaveExcute()
        {
            if(_isEditingNewItem)
            {
                this.AddDepartmentAsync();
            }
        }

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
        private async void AddDepartmentAsync()
        {
            if (IsInDesignMode) return;
            this.IsBusy = true;
             await AppCxt.Current.RestDataPortal.AddDepartment(DepartmentConverter.ToDto(this.CurrentEditingItem));
            this.IsBusy = false;
            this.IsEditing = false;
            this.CurrentEditingItem = null;
            this._isEditingNewItem = false;
            this.RefreshDepartmentsAsync();
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
