using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL
{
    public class DepartmentManager
    {
        public List<Department> GetAllDepartments()
        {
            using (IOPContext cxt = new IOPContext())
            {
                List<Department> ds= cxt.Departments.ToList();
                foreach(var d in ds)
                {
                    d.JobPositions.ToArray();//使关联的查询立刻执行
                }
                return ds;
            }
        }
        public int AddDepartments(ICollection<Department> departments)
        {
            using (IOPContext cxt = new IOPContext())
            {
                foreach(var d in departments)
                {
                    if (d.ParentDepartment != null)
                        d.ParentDepartment = cxt.Departments.FirstOrDefault(x => x.Id == d.ParentDepartment.Id);
                    cxt.Departments.Add(d);
                }
                return cxt.SaveChanges();
            }
        }

        public int DeleteDepartments(ICollection<Department> departments)
        {
            using (IOPContext cxt = new IOPContext())
            {
                cxt.Departments.RemoveRange(departments);
                return cxt.SaveChanges();
            }
        }
        public int UpdateDepartments(ICollection<Department> departments)
        {
            using (IOPContext cxt = new IOPContext())
            {
                foreach(var d in departments)
                {
                    cxt.Departments.Attach(d);
                    cxt.Entry(d).State = System.Data.Entity.EntityState.Modified;
                }
                return cxt.SaveChanges();
            }
        }
    }
}
