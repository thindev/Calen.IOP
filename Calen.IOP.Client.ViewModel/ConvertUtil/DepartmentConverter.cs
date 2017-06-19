using Calen.IOP.Client.ViewModel;
using Calen.IOP.Client.ViewModel.ConvertUtil;
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
        public static DepartmentViewModel FromDto(DepartmentViewModel parent, department d)
        {
            DepartmentViewModel vm = new DepartmentViewModel();
            vm.Id = d.id;
            vm.Code = d.code;
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

            vm.ParentDepartment = parent;
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

        public static department ToDto(DepartmentViewModel value)
        {
            department d = new department();
            d.description = value.Description;
            d.id = value.Id;
            d.code = value.Code;
            d.name = value.Name;
            if (value.JobPositions != null)
            {
                d.jobPositions = new List<jobPosition>();
                
                foreach (var jp in value.JobPositions)
                {
                    d.jobPositions.Add(JobPositionConverter.ToDto(jp));
                }
            }
            d.parentDepartmentId = value.ParentDepartment?.Id;
            if (value.Leader != null)
            {
               // EmployeeConverter emConverter = new EmployeeConverter();
               // d.leader = emConverter.Convert(value.Leader);
            }
            return d;
        }
    }
}
