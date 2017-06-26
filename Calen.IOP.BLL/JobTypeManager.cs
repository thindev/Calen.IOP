using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System.Collections.Generic;
using Calen.IOP.BLL.Converters;
using System.Linq;

namespace Calen.IOP.BLL
{
    public class JobTypeManager
    {
        public int AddJobTypes(ICollection<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                List<JobType> jtList = new List<JobType>();
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach(var jt in jobTypes)
                {
                    var model = new JobType();
                    jtList.Add(model);
                }
                db.JobTypes.AddRange(jtList);
              return  db.SaveChanges();
            }
        }
        public ICollection<jobType> GetAllJobTypes()
        {
            using (IOPContext db = new IOPContext())
            {
                List<JobType> jtList = db.JobTypes.ToList();
                ICollection<jobType> jobTypes = new List<jobType>();
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jtList)
                {
                    var dto = new jobType();
                    jobTypes.Add(dto);
                }
                return jobTypes;
            }
        }

        public int DeleteJobTypes(ICollection<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                List<JobType> jtList = new List<JobType>();
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jobTypes)
                {
                    var model = new JobType();
                    jtList.Add(model);
                }
                db.JobTypes.RemoveRange(jtList);
                return db.SaveChanges();
            }
        }
        public int UpdateJobTypes(ICollection<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jobTypes)
                {
                    var model = new JobType();
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
    }
}
