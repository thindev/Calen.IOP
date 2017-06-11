using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.WebService.Converters
{
    public class DepartmentConverter
    {
        public department Convert(Department value)
        {
            department d = new department();
            d.description = value.Description;
            d.id = value.Id;
            d.name = value.Name;
            if (value.JobPositions != null)
            {
                d.jobPositions = new List<jobPosition>();
                JobPositionConverter jpConverter = new JobPositionConverter();
                foreach (var jp in value.JobPositions)
                {
                    d.jobPositions.Add(jpConverter.Converter(jp));
                }
            }
            d.parentDepartmentId = value.ParentDepartment?.Id;
            if(value.Leader!=null)
            {
                EmployeeConverter emConverter = new EmployeeConverter();
                d.leader = emConverter.Convert(value.Leader);
            }
            return d;
        }
        public ICollection<department> ConvertToTree(ICollection<Department> values)
        {
            List<department> departments = new List<department>();
            foreach(var v in values)
            {
                departments.Add(this.Convert(v));
            }
            List<department> dptCopy = departments.ToList();
            foreach(var d in dptCopy)
            {
                ICollection<department> subDs = departments.Where(x => x.parentDepartmentId == d.id).ToList();
                d.subDepartments = subDs;
            }
            return departments.Where(x => string.IsNullOrEmpty(x.parentDepartmentId)).ToList();
        }
    }



    public class JobPositionConverter
    {
        public jobPosition Converter(JobPosition v)
        {
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
    }
}
