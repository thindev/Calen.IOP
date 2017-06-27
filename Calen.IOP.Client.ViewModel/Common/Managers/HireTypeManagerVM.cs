using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class HireTypeManagerVM:ManagerBase<HireTypeVM>
    {
       
        protected override void RefreshItemsExcute()
        {
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
            bool isSaveClick=  await this.EditItemDialog?.ShowDialog(vm);
            if(isSaveClick)
            {
                hireType[] hts = new hireType[] { HireTypeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddHireTypes(hts);
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
    }
}
