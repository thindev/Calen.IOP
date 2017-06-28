using Calen.IOP.BLL.Converters;
using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL
{
    public class JobPositonLevelManager
    {
        public IEnumerable<jobPositionLevel> GetAllJobPositionLevels()
        {
            using (IOPContext db = new IOPContext())
            {
                JobPositionLevelConverter converter = new JobPositionLevelConverter(db);
                var items = db.JobPositionLevels.ToList();
                ICollection<jobPositionLevel> list = items.Select(p => converter.ToDto(p)).ToList();
                return list;
            }
        }
        public int AddJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            using (IOPContext db = new IOPContext())
            {
                JobPositionLevelConverter converter = new JobPositionLevelConverter(db);
                IEnumerable<JobPostionLevel> list = items.Select(p => converter.FromDto(p));
                db.JobPositionLevels.AddRange(list);
                return db.SaveChanges();
            }
        }
        public int DeleteJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            using (IOPContext db = new IOPContext())
            {
                JobPositionLevelConverter converter = new JobPositionLevelConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
        public int UpdateJobPositionLevels(IEnumerable<jobPositionLevel> items)
        {
            using (IOPContext db = new IOPContext())
            {
                JobPositionLevelConverter converter = new JobPositionLevelConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
    }
}
