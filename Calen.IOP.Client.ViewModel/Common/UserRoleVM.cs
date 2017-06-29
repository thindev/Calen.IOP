using Calen.IOP.Client.ViewModel.ConvertUtil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class UserRoleVM : EntityVMBase<UserRoleVM>
    {
        ObservableCollection<string> _functionIds=new ObservableCollection<string>();

        public ObservableCollection<string> FunctionIds { get => _functionIds; }

        public override UserRoleVM DeepClone()
        {
            var dto = UserRoleConvertUtil.ToDto(this);
            var vm = UserRoleConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}
