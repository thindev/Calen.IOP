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
    public class DepartmentManagerVM:ManagerBase<DepartmentVM>
    {
      
        bool _isEditingNewItem;
        string _lastPresentDepartmentId;
        
        

      
       
        


      
        protected override void RefreshItemsExcute()
        {
            this.RefreshDepartmentsAsync();
        }

        protected override void AddExecute()
        {
            DepartmentVM vm = new DepartmentVM() { Id = Guid.NewGuid().ToString(), IsEditing = true };
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
            return this.DeleteItemsDialog != null && this.SelectedItem != null;
        }
        protected override void DeleteExecute()
        {
            this.TryDeleteSelectedAsync();
        }
        private async void TryDeleteSelectedAsync()
        {
            if(this.DeleteItemsDialog!=null)
            {
                bool shouldDelete= await this.DeleteItemsDialog.ShowDialog(new DepartmentVM[] { this.SelectedItem });
                bool recursive = this.DeleteItemsDialog.RecursiveDelete;
                if (shouldDelete)
                {
                    department dto = DepartmentConvertUtil.ToDto(this.SelectedItem,recursive);
                    this.IsBusy = true;
                    await AppCxt.Current.DataPortal.DeleteDepartments(new department[] { dto }, recursive);
                    this.IsBusy = false;
                    this.RefreshDepartmentsAsync();
                }
            }
        }

        protected override void EditExecute()
        {
            this.CurrentEditingItem = this.SelectedItem.DeepClone();
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
            department[] ds = new department[] { DepartmentConvertUtil.ToDto(this.CurrentEditingItem) };
            await AppCxt.Current.DataPortal.UpdateDepartments(ds);
            this.IsBusy = false;
            this.ClearEditingState();
            this.RefreshDepartmentsAsync();
        }

        protected override void CancelExecute()
        {
            this.ClearEditingState();
        }

        protected override void ClearEditingState()
        {
            _lastPresentDepartmentId = this.CurrentEditingItem.Id;
            this._isEditingNewItem = false;
            base.ClearEditingState();
        }

        private async void RefreshDepartmentsAsync()
        {
            if (IsInDesignMode) return;
            ItemList.Clear();
            this.IsBusy = true;
            ICollection<department> ds=await AppCxt.Current.DataPortal.GetDepartmentTreeAsync();
            this.IsBusy = false;
            if (ds!=null)
            {
                foreach (department d in ds)
                {
                    DepartmentVM vm = DepartmentConvertUtil.FromDto(null,d);
                    ItemList.Add(vm);
                }
            }
            

            //刷新后，设置原来选中的项
                bool isFound=false;
                foreach(var root in ItemList)
                {
                    isFound = this.FindSelectedItem(root);
                    if (isFound)//找上次的选中项，并将其选中
                    {
                        break;
                    }
                }
                if (!isFound&&this.ItemList.Count > 0)//没有选中项，默认选中第一项
                {
                    this.ItemList[0].IsSelected = true;
                }
           
        }
        private async void AddDepartmentAsync()
        {
            if (IsInDesignMode) return;
            this.IsBusy = true;
            department[] ds = new department[] { DepartmentConvertUtil.ToDto(this.CurrentEditingItem) };
             await AppCxt.Current.DataPortal.AddDepartments(ds);
            this.IsBusy = false;
            this.ClearEditingState();
            this.RefreshDepartmentsAsync();
        }


        bool FindSelectedItem(DepartmentVM vm)
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



        public async static Task<ICollection<DepartmentVM>> GetDepartmentTreeAsync()
        {
            List<DepartmentVM> treeRoots = new List<DepartmentVM>();
            ICollection<department> ds = await AppCxt.Current.DataPortal.GetDepartmentTreeAsync();
            if (ds != null)
            {
                foreach (department d in ds)
                {
                    DepartmentVM vm = DepartmentConvertUtil.FromDto(null, d);
                    treeRoots.Add(vm);
                }
            }
            return treeRoots;
        }

        

       
        
    }

   
}
