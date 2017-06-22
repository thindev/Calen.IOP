using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
     class DepartmentConverter:ConverterBase
    {
        public DepartmentConverter(IOPContext ctx):base(ctx)
        {
        }
        public department ToDto(Department value)
        {
            department d = new department();
            d.description = value.Description;
            d.id = value.Id;
            d.code = value.Code;
            d.name = value.Name;
            if (value.JobPositions != null)
            {
                d.jobPositions = new List<jobPosition>();
                JobPositionConverter jpConverter = new JobPositionConverter(DbContext);
                var jps = value.JobPositions.OrderBy(j => j.Index);
                foreach (var jp in jps)
                {
                    d.jobPositions.Add(jpConverter.ToDto(jp));
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

        public Department FromDto(department d, Department target=null)
        {
            if(target==null)
            target = new Department();
            target.Code = d.code;
            target.Description = d.description;
            target.Id = d.id;
            if(d.leader!=null)
            {
                target.Leader = DbContext.Employees.Find(target.Leader.Id);
            }
            target.Name = d.name;
            if(!string.IsNullOrEmpty(d.parentDepartmentId))
            {
                target.ParentDepartment = DbContext.Departments.Find(d.parentDepartmentId);
            }
            if(d.jobPositions!=null)
            {
                if(target.JobPositions==null)
                {
                    target.JobPositions = new List<JobPosition>();
                }
                string[] jobPositonIds = d.jobPositions.Select(p => p.id).ToArray();
                IEnumerable<JobPosition> toDeletes = target.JobPositions.Where(p => !jobPositonIds.Contains(p.Id));
                DbContext.JobPositions.RemoveRange(toDeletes);
                List<JobPosition> jpList = new List<JobPosition>();
                foreach (var jp in d.jobPositions)
                {
                    JobPositionConverter jpCvt = new JobPositionConverter(DbContext);
                    JobPosition jobP = jpCvt.FromDto(jp);
                    jobP.Department = target;
                    jpList.Add(jobP);
                }
                foreach(var item in jpList)
                {
                    var entity = DbContext.JobPositions.Find(item.Id);
                    if(entity==null)
                    {
                        DbContext.JobPositions.Add(item);
                    }
                    else
                    {
                        DbContext.Entry(entity).CurrentValues.SetValues(item);
                    }
                }
            }
            return target;
        }

        public ICollection<department> ConvertToDtoTree(ICollection<Department> values)
        {
            List<department> departments = new List<department>();
            foreach(var v in values)
            {
                departments.Add(this.ToDto(v));
            }
            List<department> dptCopy = departments.ToList();
            foreach(var d in dptCopy)
            {
                ICollection<department> subDs = departments.Where(x => x.parentDepartmentId == d.id).OrderBy(p=>p.code).ToList();
                d.subDepartments = subDs;
            }
            return departments.Where(x => string.IsNullOrEmpty(x.parentDepartmentId)).ToList();
        }
    }



     class JobPositionConverter:ConverterBase
    {
        public JobPositionConverter(IOPContext ctx) : base(ctx)
        {
        }

        public jobPosition ToDto(JobPosition v)
        {
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.index = v.Index;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
        public JobPosition FromDto(jobPosition dto)
        {
            JobPosition jobP = new JobPosition();
            jobP.Description = dto.description;
            jobP.Id = dto.id;
            jobP.Index = dto.index;
            jobP.Name = dto.name;
            return jobP;
        }
    }
}
