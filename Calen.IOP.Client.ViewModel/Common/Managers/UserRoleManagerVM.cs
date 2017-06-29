using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DataPortal;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class UserRoleManagerVM:ManagerBase<UserRoleVM>
    {
        IDataPortal GetDataPortal()
        {
            return AppCxt.Current.DataPortal;
        }
        public IConfirmDialog ConfirmDialog { get; set; }
        public List<FunctionVM> FunctionTree { get; set; }
        UserRoleVM _itemBackup;
        public override UserRoleVM SelectedItem
        {
            get => _selectedItem;
            set
            {
                if(_selectedItem!=value)
                {
                    _selectedItem = value;
                    PresentItem = _selectedItem;
                    if (_selectedItem == null)
                    {
                        this.FunctionTree = null;
                    }
                    else
                    {
                        if (this.FunctionTree == null)
                        {
                            this.FunctionTree = AppCxt.Current.FunctionManager.CloneFunctionTree(_selectedItem.FunctionIds);
                        }
                        else
                        {
                            AppCxt.Current.FunctionManager.UpdateFunctionTreeCheckedState(this.FunctionTree,_selectedItem.FunctionIds);
                        }
                            
                    }
                    RaisePropertyChanged(() => SelectedItem);
                }
                
            }
        }
        
        protected override void RefreshItemsExcute()
        {
            this.RefreshItemsAsync();
        }
        private async void RefreshItemsAsync()
        {
            this.ItemList.Clear();
            this.IsBusy = true;
            var items =await GetDataPortal().GetAllUserRolesAsync();
            this.IsBusy = false;
            foreach(var item in items)
            {
                var vm = UserRoleConvertUtil.FromDto(item);
                this.ItemList.Add(vm);
            }
            if(this.SelectedItem!=null)
            {
                this.SelectedItem = this.ItemList.FirstOrDefault(p => p.Id == this.SelectedItem.Id);
            }
        }

        protected override void AddExecute()
        {
            this.IsEditing = true;
            UserRoleVM vm = new UserRoleVM() { Id = Guid.NewGuid().ToString() };
            vm.IsNew = true;
            vm.IsEditing = true;
            vm.IsDirty = true;
            this.ItemList.Add(vm);
            this.SelectedItem = vm;
            this.CurrentEditingItem = vm;
        }
        protected async override void SaveExecute()
        {
            var item = this.ItemList.First(x => x.IsDirty);
            var items = new userRole[] { UserRoleConvertUtil.ToDto(item) };
            int result = 0;
            int index = this.ItemList.IndexOf(item);
            if (item.IsNew)
            {
                this.IsBusy = true;
                result =await GetDataPortal().AddUserRoles(items);
                this.IsBusy = false;
            }
            else
            {
                this.IsBusy = true;
                result = await GetDataPortal().UpdateUserRoles(items);
                this.IsBusy = false;
            }
     
            this.ClearEditingState();
            if (result<=0)
            {
                if (item.IsNew)
                {
                    this.ItemList.Remove(item);
                }
                else
                {
                    this.ItemList[index] = _itemBackup;
                }
            }
        }
        protected async override void CancelExecute()
        {
            bool toCancel = await this.ConfirmDialog?.ShowDialog("确定要取消所作的更改吗？", "取消后本次编辑的更改将不保存！");
            if(toCancel)
            {
                var item = this.ItemList.First(x => x.IsDirty);
                if(item.IsNew)
                {
                    this.ItemList.Remove(item);
                }
                else
                {
                    int index = this.ItemList.IndexOf(item);
                    this.ItemList[index] = _itemBackup;
                }
            }
            this.ClearEditingState();
        }
        protected override bool EditPredicate()
        {
            return this.SelectedItem != null;
        }
        protected override void EditExecute()
        {
            _itemBackup= this.SelectedItem;
            int index = this.ItemList.IndexOf(_itemBackup);
            this.ItemList[index] = this.SelectedItem.DeepClone();
            this.SelectedItem = this.ItemList[index];
            this.IsEditing = true;
            this.CurrentEditingItem = SelectedItem;
            this.CurrentEditingItem.IsDirty = true;
            this.CurrentEditingItem.IsEditing = true;
            this.CurrentEditingItem.IsNew = false;
        }
        protected override bool DeletePredicate()
        {
            return this.SelectedItem != null;
        }
        protected async override void DeleteExecute()
        {
            var items = this.ItemList.Where(x => x.IsSelected).ToList();
            if(!items.Contains(this.SelectedItem))
            {
                items.Add(this.SelectedItem);
            }
            bool toDelete = await this.DeleteItemsDialog?.ShowDialog(items);
            if(toDelete)
            {
                var list = items.Select(x => UserRoleConvertUtil.ToDto(x)).ToList();
                this.IsBusy = true;
                int count= await GetDataPortal().DeleteUserRoles(list);
                this.IsBusy = false;
                if(count>0)
                {
                    this.RefreshItemsAsync();
                }
            }
        }
    }
}
