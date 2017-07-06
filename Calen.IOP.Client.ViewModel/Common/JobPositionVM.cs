using System;
using GalaSoft.MvvmLight;
using Calen.IOP.DTO.Common;
using Calen.IOP.Client.ViewModel.ConvertUtil;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionVM:EntityVMBase<JobPositionVM>
    {

         DepartmentVM _department;
        int _employeesCount;
        JobPositionLevelVM _jobPositionLevel;
        JobTypeVM _jobType;
        bool _isConCurrent;
        public DepartmentVM Department { get => _department; set { Set(() => Department, ref _department, value); } }

        public int EmployeesCount { get => _employeesCount; set { Set(()=>EmployeesCount, ref _employeesCount, value); } }

        public JobPositionLevelVM JobPositionLevel { get => _jobPositionLevel; set { Set(()=>JobPositionLevel,ref _jobPositionLevel,value); } }
        public JobTypeVM JobType { get => _jobType; set { Set(()=>JobType,ref _jobType,value); } }

        public bool IsConCurrent { get => _isConCurrent; set { Set(() => IsConCurrent, ref _isConCurrent, value); } }

        public override JobPositionVM DeepClone()
        {
            jobPosition temp = JobPositionConvertUtil.ToDto(this);
            JobPositionVM vm = JobPositionConvertUtil.FromDto(temp);
            base.CopyStateValues(vm);
            vm.IsConCurrent = this.IsConCurrent;
            return vm;
            
        }
    }
}