using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public static class ServingRecordConvertUtil
    {
        public static servingRecord ToDto(ServingRecordVM vm)
        {
            servingRecord dto = new servingRecord()
            {
                beginTime = vm.BeginTime,
                employeeId = vm.Employee?.Id,
                endTime = vm.EndTime,
                id = vm.Id,
                isConcurrent = vm.IsConcurrent,
                isCurrent = vm.IsCurrent,
                jobPosition = vm.JobPosition == null ? null : JobPositionConvertUtil.ToDto(vm.JobPosition),

            };
            return dto;
        }
        public static ServingRecordVM FromDto(servingRecord dto)
        {
            ServingRecordVM vm = new ServingRecordVM()
            {
                BeginTime = dto.beginTime,
                EndTime = dto.endTime,
                Id = dto.id,
                IsConcurrent = dto.isConcurrent,
                IsCurrent = dto.isCurrent,
                JobPosition = dto.jobPosition == null ? null : JobPositionConvertUtil.FromDto(dto.jobPosition),

            };
            return vm;
        }
    }
}
