using Calen.IOP.Client.ViewModel.ConvertUtil;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class JobTypeVM : EntityVMBase<JobTypeVM>
    {
        public override JobTypeVM DeepClone()
        {
            var dto = JobTypeConvertUtil.ToDto(this);
            var vm = JobTypeConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}
