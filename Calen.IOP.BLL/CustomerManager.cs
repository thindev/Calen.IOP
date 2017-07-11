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
    public class CustomerManager
    {
        public resultForCustomers QueryEmployees(criteriaForCustomer criteria)
        {
            using (IOPContext db = new IOPContext())
            {
                int pageSize = criteria.pageSize;
                int pageIndex = criteria.pageIndex;
                criteria.customerCode = criteria.customerCode == null ? "" : criteria.customerCode;
                criteria.customerName = criteria.customerName == null ? "" : criteria.customerName;
                int totalCount = 0;
                CustomerConverter converter = new CustomerConverter(db);
                IList<Customer> list = Utils.LoadPageItems<Customer, string>(db, pageSize, pageIndex, out totalCount, e => e.Code.Contains(criteria.customerCode) && e.Name.Contains(criteria.customerName)&&(criteria.customerType&e.CustomerType)>0, e => e.Code, true).ToList();
                resultForCustomers result = new resultForCustomers();
                result.customers = list.Select(i => converter.ToDto(i)).ToArray();
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
                foreach (var item in items)
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
                    model.ServingRecords.Clear();
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
    }
}
