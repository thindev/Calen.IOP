using Calen.IOP.Client.ViewModel.ConvertUtil;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class HireTypeVM : EntityVMBase<HireTypeVM>
    {
        public override HireTypeVM DeepClone()
        {
            var dto = HireTypeConvertUtil.ToDto(this);
            return HireTypeConvertUtil.FromDto(dto);
        }
    }
}
