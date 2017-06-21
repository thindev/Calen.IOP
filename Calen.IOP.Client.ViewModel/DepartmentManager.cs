using Calen.IOP.Client.Desktop.ConvertUtil;
using Calen.IOP.DTO.Common;
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
        string _lastPresentDepartmentId;
        

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

        
        protected override void AddExecute()
        {
            DepartmentViewModel vm = new DepartmentViewModel() { Id = Guid.NewGuid().ToString(), IsEditing = true };
            vm.ParentDepartment = this.SelectedItem;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            _isEditingNewItem = true;
        }
        protected override bool EditPredicate()
        {
            return this.SelectedItem != null;
        }

        protected override bool DeletePredicate()
        {
            return this.DeleteDepartmentDialog != null && this.SelectedItem != null;
        }
        protected override void DeleteExecute()
        {
            this.TryDeleteSelectedAsync();
        }
        private async void TryDeleteSelectedAsync()
        {
            if(this.DeleteDepartmentDialog!=null)
            {
                bool shouldDelete= await this.DeleteDepartmentDialog.ShowDialog(this.SelectedItem);
                bool recursive = this.DeleteDepartmentDialog.RecursiveDelete;
                if (shouldDelete)
                {
                    department dto = DepartmentConverter.ToDto(this.SelectedItem,recursive);
                    this.IsBusy = true;
                    await AppCxt.Current.DataPortal.DeleteDepartments(new department[] { dto }, recursive);
                    this.IsBusy = false;
                    this.RefreshDepartmentsAsync();
                }
            }
        }

        protected override void EditExecute()
        {
            this.CurrentEditingItem = this.SelectedItem;
            this.IsEditing = true;
            this._isEditingNewItem = false;
            this.CurrentEditingItem.IsEditing = true;
        }
        protected override void SaveExecute()
        {
            if(_isEditingNewItem)
            {
                this.AddDepartmentAsync();
            }
            else
            {
                this.UpdateDepartmentAsync();
            }
        }

        private async void UpdateDepartmentAsync()
        {
            if (IsInDesignMode) return;
            this.IsBusy = true;
            department[] ds = new department[] { DepartmentConverter.ToDto(this.CurrentEditingItem) };
            await AppCxt.Current.DataPortal.UpdateDepartments(ds);
            this.IsBusy = false;
            this.StopEditingState();
            this.RefreshDepartmentsAsync();
        }

        protected override void CancelExecute()
        {
            this.StopEditingState();

        }

        private void StopEditingState()
        {
            this.IsEditing = false;
            this._isEditingNewItem = false;
            _lastPresentDepartmentId = this.CurrentEditingItem.Id;
            this.CurrentEditingItem.IsEditing = false;
            this.CurrentEditingItem = null;
            this.PresentItem = this.SelectedItem;
        }

        private async void RefreshDepartmentsAsync()
        {
            if (IsInDesignMode) return;
            _rootDepartments.Clear();
            this.IsBusy = true;
            ICollection<department> ds=await AppCxt.Current.DataPortal.GetDepartmentTreeAsync();
            this.IsBusy = false;
            if (ds!=null)
            {
                foreach (department d in ds)
                {
                    DepartmentViewModel vm = DepartmentConverter.FromDto(null,d);
                    _rootDepartments.Add(vm);
                }
            }
            

            //刷新后，设置原来选中的项
                bool isFound=false;
                foreach(var root in _rootDepartments)
                {
                    isFound = this.FindSelectedItem(root);
                    if (isFound)//找上次的选中项，并将其选中
                    {
                        break;
                    }
                }
                if (!isFound&&this._rootDepartments.Count > 0)//没有选中项，默认选中第一项
                {
                    this._rootDepartments[0].IsSelected = true;
                }
           
        }
        private async void AddDepartmentAsync()
        {
            if (IsInDesignMode) return;
            this.IsBusy = true;
            department[] ds = new department[] { DepartmentConverter.ToDto(this.CurrentEditingItem) };
             await AppCxt.Current.DataPortal.AddDepartments(ds);
            this.IsBusy = false;
            this.StopEditingState();
            this.RefreshDepartmentsAsync();
        }


        bool FindSelectedItem(DepartmentViewModel vm)
        {
            if(vm.Id==_lastPresentDepartmentId)
            {
                vm.IsSelected = true;
                return true;
            }
            else
            {
                if(vm.SubDepartments!=null)
                {
                    foreach (var sVm in vm.SubDepartments)
                    {
                        this.FindSelectedItem(sVm);
                    }
                }
                return false;
            }
        }



        public async static Task<ICollection<DepartmentViewModel>> GetDepartmentTreeAsync()
        {
            List<DepartmentViewModel> treeRoots = new List<DepartmentViewModel>();
            ICollection<department> ds = await AppCxt.Current.DataPortal.GetDepartmentTreeAsync();
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

        

        public IDeleteDepartmentDialog DeleteDepartmentDialog { get; set; }


    }

    public interface IDeleteDepartmentDialog
    {
        Task<bool> ShowDialog(DepartmentViewModel vm);
        /// <summary>
        /// true:删除所有子级，false:不删子级
        /// </summary>
        bool RecursiveDelete { get; set; }
    }
}
