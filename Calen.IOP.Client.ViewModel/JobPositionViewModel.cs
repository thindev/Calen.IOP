using GalaSoft.MvvmLight;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionViewModel:ViewModelBase
    {

         string _description;
         string _id;
         string _name;
         DepartmentViewModel _department;
        int _employeesCount;

        public string Description { get => _description; set { Set(() => Description, ref _description, value); } }
        public string Id { get => _id; set { Set(() => Id, ref _id, value); } }
        public string Name { get => _name; set { Set(() => Name, ref _name, value); } }
        public DepartmentViewModel Department { get => _department; set { Set(() => Department, ref _department, value); } }

        public int EmployeesCount { get => _employeesCount; set { Set(()=>EmployeesCount, ref _employeesCount, value); } }
    }
}