using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.Client.ViewModel
{
    public class DepartmentViewModel:ViewModelBase
    {
        string _id;
        string _code;
        string _name;
        string _description;
        EmployeeViewModel _leader;
        DepartmentViewModel _parentDepartment;
        ObservableCollection<DepartmentViewModel> _subDepartments=new ObservableCollection<DepartmentViewModel>();
        ObservableCollection<JobPositionViewModel> _jobPositions=new ObservableCollection<JobPositionViewModel>();

        public string Id { get => _id; set => _id = value; }
        public string Name { get => _name; set { Set(() => Id, ref _name, value); } }
        public string Description {get => _description; set { Set(() => Description ,ref _description,value); } }
        public DepartmentViewModel ParentDepartment { get => _parentDepartment; set { Set(() => ParentDepartment, ref _parentDepartment, value); } }
        public ObservableCollection<DepartmentViewModel> SubDepartments { get => _subDepartments; }
        public EmployeeViewModel Leader { get => _leader; set => _leader = value; }
        public ObservableCollection<JobPositionViewModel> JobPositions { get => _jobPositions;  }
        public string Code { get => _code; set { Set(() => Code, ref _code, value); } }
    }
}
