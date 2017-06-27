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
            return vm;
            //JobPositionVM j = new JobPositionVM()
            //{
            //    _department = this._department,
            //    _description = this._description,
            //    _employeesCount = this._employeesCount,
            //    _id = this._id,
            //    _code = this._code,
            //    _name = this._name,
            //};
            //return j;
        }
    }
}