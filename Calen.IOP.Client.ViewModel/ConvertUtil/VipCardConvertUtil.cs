using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class VipCardConvertUtil
    {
        public static VipCardVM FromDto(vipCard dto, VipCardVM vm = null)
        {
            if (vm == null)
            {
                vm = new VipCardVM();
            }
            vm.Code = dto.code;
            vm.Description = dto.description;
            vm.Id = dto.id;
            vm.Name = dto.name;
            vm.Price = dto.price;
            vm.ReleaseTime = dto.releaseTime;
            vm.State = dto.state;
            vm.ValidityDayCount = dto.validityDayCount;
            vm.CardType = dto.cardType;
            return vm;
        }
        public static vipCard ToDto(VipCardVM vm)
        {
            vipCard dto = new vipCard()
            {
                code = vm.Code,
                description = vm.Description,
                id = vm.Id,
                name = vm.Name,
                price = vm.Price,
                releaseTime = vm.ReleaseTime,
                state = vm.State,
                validityDayCount = vm.ValidityDayCount,
                cardType = vm.CardType
            };
            return dto;
        }
    }
}
