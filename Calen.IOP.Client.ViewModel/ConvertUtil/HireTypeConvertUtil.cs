using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class HireTypeConvertUtil
    {
        public static HireTypeVM FromDto(hireType dto,HireTypeVM vm=null)
        {
            if(vm==null)
            {
                vm = new HireTypeVM();
            }
            vm.Code = dto.code;
            vm.Description = dto.code;
            vm.Id = dto.id;
            vm.Name = dto.name;
            return vm;
        }
        public static hireType ToDto(HireTypeVM vm)
        {
            hireType dto = new hireType();
            dto.code = vm.Code;
            dto.description = vm.Description;
            dto.id = vm.Id;
            dto.name = vm.Name;
            return dto;
        }
    }
}
