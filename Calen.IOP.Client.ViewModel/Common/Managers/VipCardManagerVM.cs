using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
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
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync(vm);
            if (isSaveClick)
            {
                vipCard[] items = new vipCard[] { VipCardConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddVipCards(items);
                this.ClearEditingState();
               // this.RefreshItemsAsync();
            }
        }
    }
}
