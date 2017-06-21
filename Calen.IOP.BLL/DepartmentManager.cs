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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="departments"></param>
        /// <param name="recursive">是否把所有子级的也删除</param>
        /// <returns></returns>
        public int DeleteDepartments(ICollection<department> departments,bool recursive)
        {
            using (IOPContext cxt = new IOPContext())
            {
                foreach (var item in departments)
                {
                    Department d = cxt.Departments.Find(item.id);
                    if (d == null) continue;
                    DeleteDepartment(cxt, d, recursive);
                }
                return cxt.SaveChanges();
            }
        }

        private void DeleteDepartment(IOPContext cxt, Department d, bool recursive)
        {
            cxt.JobPositions.RemoveRange(d.JobPositions);
            if (recursive)
            {
                if(d.SubDepartments.Count()>0)
                {
                    var items = d.SubDepartments.ToArray();
                    foreach (var item in items)
                    {
                        DeleteDepartment(cxt, item, recursive);
                    }
                }
            }
            else
            {
                d.SubDepartments.Clear();
            }
            cxt.Entry(d).State = System.Data.Entity.EntityState.Deleted;
        }
        
       
    }
}
