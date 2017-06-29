using Calen.IOP.Client.ViewModel.ConvertUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionLevelVM : EntityVMBase<JobPositionLevelVM>
    {
        public override JobPositionLevelVM DeepClone()
        {
            var dto = JobPositionLevelConvertUtil.ToDto(this);
            var vm = JobPositionLevelConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}
