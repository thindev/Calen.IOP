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
        public DepartmentVM Department { get => _department; set { Set(() => Department, ref _department, value); } }

        public int EmployeesCount { get => _employeesCount; set { Set(()=>EmployeesCount, ref _employeesCount, value); } }
        public override JobPositionVM DeepClone()
        {
            jobPosition temp = JobPositionConvertUtil.ToDto(this);
            JobPositionVM vm = JobPositionConvertUtil.FromDto(temp);
            base.CopyStateValues(vm);
            return vm;
            
        }
    }
}