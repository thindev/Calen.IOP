using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class JobTypeConvertUtil
    {
        public static JobTypeVM FromDto(jobType dto, JobTypeVM vm = null)
        {
            if (vm == null)
            {
                vm = new JobTypeVM();
            }
            vm.Code = dto.code;
            vm.Description = dto.description;
            vm.Id = dto.id;
            vm.Name = dto.name;
            return vm;
        }
        public static jobType ToDto(JobTypeVM vm)
        {
            jobType dto = new jobType();
            dto.code = vm.Code;
            dto.description = vm.Description;
            dto.id = vm.Id;
            dto.name = vm.Name;
            return dto;
        }
    }
}
