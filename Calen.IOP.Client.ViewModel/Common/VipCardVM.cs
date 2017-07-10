using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common
{
    public class VipCardVM : EntityVMBase<VipCardVM>
    {
        int _validityDayCount;
        double _price;
        VipCardStates _state;
        VipCardTypes _cardType;
        DateTime? _releaseTime;

        public int ValidityDayCount { get => _validityDayCount; set { Set(() => ValidityDayCount, ref _validityDayCount, value); } }
        public double Price { get => _price; set { Set(() => Price, ref _price, value); } }
        public VipCardStates State { get => _state;
            set { Set(() => State, ref _state, value); } }
        public DateTime? ReleaseTime { get => _releaseTime; set { Set(() => ReleaseTime, ref _releaseTime, value); } }

        public VipCardTypes CardType { get => _cardType; set { Set(() => CardType, ref _cardType, value); } }

        public override VipCardVM DeepClone()
        {
            var dto = VipCardConvertUtil.ToDto(this);
            var vm = VipCardConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}
