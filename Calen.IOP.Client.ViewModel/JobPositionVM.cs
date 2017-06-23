using System;
using GalaSoft.MvvmLight;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionVM:ViewModelBase
    {

         string _description;
         string _id;
        string _code;
         string _name;
         DepartmentVM _department;
        int _employeesCount;

        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public string Id { get => _id; set { Set(() => Id, ref _id, value); } }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public DepartmentVM Department { get => _department; set { Set(() => Department, ref _department, value); } }

        public int EmployeesCount { get => _employeesCount; set { Set(()=>EmployeesCount, ref _employeesCount, value); } }

        public string Code { get => _code; set { Set(() => Code, ref _code, value); } }

        public JobPositionVM DeepClone()
        {
            JobPositionVM j = new JobPositionVM()
            {
                _department = this._department,
                _description = this._description,
                _employeesCount = this._employeesCount,
                _id = this._id,
                _code = this._code,
                _name = this._name,
            };
            return j;
        }
    }
}