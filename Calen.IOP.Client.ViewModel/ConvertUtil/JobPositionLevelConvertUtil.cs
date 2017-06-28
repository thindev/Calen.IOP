using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class JobPositionLevelConvertUtil
    {
        public static JobPositionLevelVM FromDto(jobPositionLevel dto, JobPositionLevelVM vm = null)
        {
            if (vm == null)
            {
                vm = new JobPositionLevelVM();
            }
            vm.Code = dto.code;
            vm.Description = dto.description;
            vm.Id = dto.id;
            vm.Name = dto.name;
            return vm;
        }
        public static jobPositionLevel ToDto(JobPositionLevelVM vm)
        {
            jobPositionLevel dto = new jobPositionLevel();
            dto.code = vm.Code;
            dto.description = vm.Description;
            dto.id = vm.Id;
            dto.name = vm.Name;
            return dto;
        }
    }
}
