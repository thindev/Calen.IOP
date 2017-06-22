using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class JobPositionConvertUtil
    {
        public static JobPositionVM FromDto(jobPosition v)
        {
            JobPositionVM vm = new JobPositionVM();
            vm.Description = v.description;
            vm.EmployeesCount = v.employeesCount;
            vm.Id = v.id;
            vm.Index = v.index;
            vm.Name = v.name;
            return vm;
        }
        public static jobPosition ToDto(JobPositionVM v)
        {
            if(string.IsNullOrEmpty(v.Id))
            {
                v.Id = Guid.NewGuid().ToString();
            }
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.index = v.Index;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
        
    }
}
