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
    public class DepartmentManager
    {
        public IEnumerable<department> GetDepartmentTree()
        {
            using (IOPContext cxt = new IOPContext())
            {
                List<Department> departments = cxt.Departments.ToList();
                DepartmentConverter depCvt = new DepartmentConverter(cxt);
                return depCvt.ConvertToDtoTree(departments);
            }
        }



        public int AddDepartments(IEnumerable<department> departments)
        {
            if (departments == null)
            {
                return 0;
            }
            using (IOPContext cxt = new IOPContext())
            {
                List<Department> dList = new List<Department>();
                DepartmentConverter depCvt = new DepartmentConverter(cxt);
                foreach (var d in departments)
                {
                    Department dep = depCvt.FromDto(d);
                    dList.Add(dep);
                }
                cxt.Departments.AddRange(dList);
                return cxt.SaveChanges();
            }
        }

        public int UpdateDepartments(department[] departments)
        {
            if (departments == null)
            {
                return 0;
            }
            using (IOPContext cxt = new IOPContext())
            {
                DepartmentConverter depCvt = new DepartmentConverter(cxt);
                foreach (var d in departments)
                {
                    Department dep = depCvt.FromDto(d, cxt.Departments.Find(d.id));
                    cxt.Entry(dep).State = System.Data.Entity.EntityState.Modified;
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
       
    }
}
