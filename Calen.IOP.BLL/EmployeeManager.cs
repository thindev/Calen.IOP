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
    public class EmployeeManager
    {
        public resultForEmployees QueryEmployees( criteriaForEmployees criteria)
        {
            using (IOPContext db = new IOPContext())
            {
                int pageSize = criteria.pageSize;
                int pageIndex = criteria.pageIndex;
                criteria.employeeCode = criteria.employeeCode == null ? "" : criteria.employeeCode;
                criteria.employeeName = criteria.employeeName == null ? "" : criteria.employeeName;
                int totalCount=0;
                EmployeeConverter converter = new EmployeeConverter(db);
                IList<Employee> list =  Utils.LoadPageItems<Employee, string>(db, pageSize, pageIndex, out totalCount, e => e.Code.Contains(criteria.employeeCode) && e.Name.Contains(criteria.employeeName), e => e.Code, true).ToList();
                resultForEmployees result = new resultForEmployees();
                result.employees= list.Select(i => converter.ToDto(i)).ToArray();
                result.totalCount = totalCount;
                result.currentIndex = result.currentIndex;
                return result;
            }
        }

        public int AddEmployees(IEnumerable<employee> items)
        {
            using (IOPContext db = new IOPContext())
            {
                EmployeeConverter converter = new EmployeeConverter(db);
                foreach(var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Added;
                }
                return db.SaveChanges();
            }
        }
        public int UpdateEmployees(IEnumerable<employee> items)
        {
            using (IOPContext db = new IOPContext())
            {
                EmployeeConverter converter = new EmployeeConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
        public int DeleteEmployees(IEnumerable<employee> items)
        {
            using (IOPContext db = new IOPContext())
            {
                EmployeeConverter converter = new EmployeeConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
    }
}
