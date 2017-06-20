using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class JobPositionConverter
    {
        public static JobPositionViewModel FromDto(jobPosition v)
        {
            JobPositionViewModel vm = new JobPositionViewModel();
            vm.Description = v.description;
            vm.EmployeesCount = v.employeesCount;
            vm.Id = v.id;
            vm.Name = v.name;
            return vm;
        }
        public static jobPosition ToDto(JobPositionViewModel v)
        {
            if(string.IsNullOrEmpty(v.Id))
            {
                v.Id = Guid.NewGuid().ToString();
            }
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
        
    }
}
