using Calen.IOP.Client.ViewModel;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.Client.Desktop.ConvertUtil
{
    public static class DepartmentConvertUtil
    {
        public static DepartmentVM FromDto(DepartmentVM parent, department d)
        {
            DepartmentVM vm = new DepartmentVM();
            vm.Id = d.id;
            vm.Code = d.code;
            vm.Description = d.description;
            if (d.jobPositions != null)
            {
                foreach (jobPosition jp in d.jobPositions)
                {
                    JobPositionVM jpVm = JobPositionConvertUtil.FromDto(jp);
                    jpVm.Department = vm;
                    vm.JobPositions.Add(jpVm);
                }
            }
            if (d.leader != null)
            {
                vm.Leader = new EmployeeVM();
                // vm.Leader
            }
            vm.Name = d.name;

            vm.ParentDepartment = parent;
            if(d.subDepartments!=null)
            {
                foreach(department subD in d.subDepartments)
                {
                    DepartmentVM subVM = FromDto(vm, subD);
                    vm.SubDepartments.Add(subVM);
                }
            }
            return vm;
        }

        public static department ToDto(DepartmentVM value,bool keepTree=false)
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
                    d.jobPositions.Add(JobPositionConvertUtil.ToDto(jp));
                }
            }
            d.parentDepartmentId = value.ParentDepartment?.Id;
            if (value.Leader != null)
            {
               // EmployeeConverter emConverter = new EmployeeConverter();
               // d.leader = emConverter.Convert(value.Leader);
            }
            if(keepTree&&value.SubDepartments!=null&&value.SubDepartments.Count>0)
            {
                d.subDepartments = new List<department>();
                foreach(var item in value.SubDepartments)
                {
                    d.subDepartments.Add(ToDto(item, true));
                }
            }
            return d;
        }
    }
}
