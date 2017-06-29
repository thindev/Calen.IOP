using Calen.IOP.Client.ViewModel.ConvertUtil;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class UserRoleVM : EntityVMBase<UserRoleVM>
    {
        List<string> _functionIds=new List<string>();

        public List<string> FunctionIds { get => _functionIds; internal set => _functionIds = value; }

        public override UserRoleVM DeepClone()
        {
            var dto = UserRoleConvertUtil.ToDto(this);
            var vm = UserRoleConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}
