using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Managers
{
    public class VipCardManagerVM:ManagerBase<VipCardVM>
    {
        protected override void AddExecute()
        {
            this.AddItem();
        }
        private async void AddItem()
        {
            VipCardVM vm = new VipCardVM() { Id = Guid.NewGuid().ToString() };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                vipCard[] items = new vipCard[] { VipCardConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddVipCards(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
        private async void RefreshItemsAsync()
        {
            this.ItemList.Clear();
            IsBusy = true;
            IEnumerable<vipCard> items = await AppCxt.Current.DataPortal.FetchAllVipCards();
            IsBusy = false;
            foreach (var item in items)
            {
                VipCardVM vm = VipCardConvertUtil.FromDto(item);
                this.ItemList.Add(vm);
            }
        }
        protected override void RefreshItemsExcute()
        {
            if (this.IsInDesignMode) return;
            this.RefreshItemsAsync();
        }
        protected override bool DeletePredicate()
        {
            return this.SelectedItem != null;
        }
        protected override void DeleteExecute()
        {
            this.DeleteItemsAsync();
        }
        private async void DeleteItemsAsync()
        {

            if (this.DeleteItemsDialog != null)
            {
                var items = this.ItemList.Where(p => p.IsSelected).ToList();
                if (items.Count==0)
                {
                    items.Add(this.SelectedItem);
                }
                bool isSureToDelete = await this.DeleteItemsDialog.ShowDialog(items);
                if (isSureToDelete)
                {
                    List<string> list = items.Select(p => VipCardConvertUtil.ToDto(p).id).ToList();
                    this.IsBusy = true;
                    int result = await AppCxt.Current.DataPortal.DeleteVipCards(list);
                    if (result > 0)
                    {
                        this.RefreshItemsAsync();
                    }
                }
            }
        }
        protected override bool EditPredicate()
        {
            return this.SelectedItem != null;
        }
        protected override void EditExecute()
        {
            this.EditItem();
        }

        private async void EditItem()
        {
            VipCardVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = false;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                vipCard[] items = new vipCard[] { VipCardConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateVipCards(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
    }
}
