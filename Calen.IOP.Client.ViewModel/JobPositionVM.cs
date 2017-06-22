using System;
using GalaSoft.MvvmLight;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionVM:ViewModelBase
    {

         string _description;
         string _id;
        int _index;
         string _name;
         DepartmentVM _department;
        int _employeesCount;

        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public string Id { get => _id; set { Set(() => Id, ref _id, value); } }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public DepartmentVM Department { get => _department; set { Set(() => Department, ref _department, value); } }

        public int EmployeesCount { get => _employeesCount; set { Set(()=>EmployeesCount, ref _employeesCount, value); } }

        public int Index { get => _index; set { Set(() => Index, ref _index, value); } }

        public JobPositionVM DeepClone()
        {
            JobPositionVM j = new JobPositionVM()
            {
                _department = this._department,
                _description = this._description,
                _employeesCount = this._employeesCount,
                _id = this._id,
                _index = this._index,
                _name = this._name,
            };
            return j;
        }
    }
}