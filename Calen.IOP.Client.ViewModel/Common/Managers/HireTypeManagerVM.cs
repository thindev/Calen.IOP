using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Calen.IOP.Client.ViewModel
{
    public class HireTypeManagerVM:ManagerBase<HireTypeVM>
    {
       
        protected override void RefreshItemsExcute()
        {
            if (this.IsInDesignMode) return;
            this.RefreshItemsAsync();
        }
        protected override void AddExecute()
        {
            this.AddItem();
        }
        private async void AddItem()
        {
            HireTypeVM vm = new HireTypeVM() { Id = Guid.NewGuid().ToString() };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick=  await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if(isSaveClick)
            {
                hireType[] hts = new hireType[] { HireTypeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddHireTypes(hts);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
        private async void RefreshItemsAsync()
        {
            this.ItemList.Clear();
            IsBusy = true;
            ICollection<hireType> hireTypes= await AppCxt.Current.DataPortal.GetAllHireTypesAsync();
            IsBusy = false;
            foreach(var item in hireTypes)
            {
                HireTypeVM vm = HireTypeConvertUtil.FromDto(item);
                this.ItemList.Add(vm);
            }
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
                if(items.Count == 0)
                {
                    items.Add(this.SelectedItem);
                }
                bool isSureToDelete = await this.DeleteItemsDialog.ShowDialog(items);
                if (isSureToDelete)
                {
                    List<hireType> list = items.Select(p => HireTypeConvertUtil.ToDto(p)).ToList();
                    this.IsBusy = true;
                    int result = await AppCxt.Current.DataPortal.DeleteHireTypes(list);
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
            HireTypeVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = false;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                hireType[] hts = new hireType[] { HireTypeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateHireTypes(hts);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
    }
}
