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
        public int AddJobTypes(IEnumerable<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                List<JobType> jtList = new List<JobType>();
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach(var jt in jobTypes)
                {
                    var model = jtC.FromDto(jt);
                    jtList.Add(model);
                }
                db.JobTypes.AddRange(jtList);
              return  db.SaveChanges();
            }
        }
        public IEnumerable<jobType> GetAllJobTypes()
        {
            using (IOPContext db = new IOPContext())
            {
                List<JobType> jtList = db.JobTypes.ToList();
                ICollection<jobType> jobTypes = new List<jobType>();
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jtList)
                {
                    var dto = jtC.ToDto(jt);
                    jobTypes.Add(dto);
                }
                return jobTypes;
            }
        }

        public int DeleteJobTypes(IEnumerable<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jobTypes)
                {
                    var model = jtC.FromDto(jt);
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
        public int UpdateJobTypes(IEnumerable<jobType> jobTypes)
        {
            using (IOPContext db = new IOPContext())
            {
                JobTypeConverter jtC = new JobTypeConverter(db);
                foreach (var jt in jobTypes)
                {
                    var model = jtC.FromDto(jt);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
    }
}
