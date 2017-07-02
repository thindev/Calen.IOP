using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
     class DepartmentConverter:ConverterBase<Department,department>
    {
        
        public DepartmentConverter(IOPContext ctx):base(ctx)
        {
        }
        public override department ToDto(Department value)
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
                var jps = value.JobPositions.OrderBy(j => j.Code);
                foreach (var jp in jps)
                {
                    d.jobPositions.Add(jpConverter.ToDto(jp));
                }
            }
            d.parentDepartmentId = value.ParentDepartment?.Id;
            if(value.Leader!=null)
            {
               // EmployeeConverter emConverter = new EmployeeConverter();
               // d.leader = emConverter.Convert(value.Leader);
            }
            return d;
        }

        public override Department FromDto(department d)
        {
            Department target = DbContext.Departments.Find(d.id);
            if(target==null)
            {
                target = new Department();
                target.Id = d.id;
            }
            target.Code = d.code;
            target.Description = d.description;
            
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

        public Department FromDto(department d, Department target)
        {
            if (target == null)
                target = new Department();
            target.Code = d.code;
            target.Description = d.description;
            target.Id = d.id;
            if (d.leader != null)
            {
                target.Leader = DbContext.Employees.Find(target.Leader.Id);
            }
            target.Name = d.name;
            if (!string.IsNullOrEmpty(d.parentDepartmentId))
            {
                target.ParentDepartment = DbContext.Departments.Find(d.parentDepartmentId);
            }
            if (d.jobPositions != null)
            {
                if (target.JobPositions == null)
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
                foreach (var item in jpList)
                {
                    var entity = DbContext.JobPositions.Find(item.Id);
                    if (entity == null)//add jobpostion to db
                    {
                       entity= DbContext.JobPositions.Add(item);
                    }
                    else //up jobpostion 
                    {
                        DbContext.Entry(entity).CurrentValues.SetValues(item);
                    }

                    //update jobpoistionlevels
                    if(item.Level!=null)
                    {
                        var level = DbContext.JobPositionLevels.Find(item.Level.Id);
                        if(level!=null)
                        {
                            entity.Level = level;
                        }
                    }
                    //update jobType
                    if(item.JobType!=null)
                    {
                        var type = DbContext.JobTypes.Find(item.JobType.Id);
                        if(type!=null)
                        {
                            entity.JobType = type;
                        }
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



    
}
