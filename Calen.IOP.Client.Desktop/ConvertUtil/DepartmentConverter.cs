using Calen.IOP.Client.Desktop.ViewModel;
using Calen.IOP.DTO.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.Client.Desktop.ConvertUtil
{
    public static class DepartmentConverter
    {
        public static DepartmentViewModel FromDto(DepartmentViewModel pd, department d)
        {
            DepartmentViewModel vm = new DepartmentViewModel();
            vm.Id = d.id;
            vm.Description = d.description;
            if (d.jobPositions != null)
            {
                foreach (jobPosition jp in d.jobPositions)
                {

                }
            }
            if (d.leader != null)
            {
                vm.Leader = new EmployeeViewModel();
                // vm.Leader
            }
            vm.Name = d.name;

            vm.ParentDepartment = pd;
            if(d.subDepartments!=null)
            {
                foreach(department subD in d.subDepartments)
                {
                    DepartmentViewModel subVM = FromDto(vm, subD);
                    vm.SubDepartments.Add(subVM);
                }
            }
            return vm;
        }
    }
}
