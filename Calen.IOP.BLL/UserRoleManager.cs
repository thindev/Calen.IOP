using Calen.IOP.BLL.Converters;
using Calen.IOP.DataAccess;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL
{
    public class UserRoleManager
    {
        public IEnumerable<userRole> GetAllUserRoles()
        {
            using (IOPContext db = new IOPContext())
            {
                UserRoleConverter converter = new UserRoleConverter(db);
                var list = db.UserRoles.ToList();
                return list.Select(p => converter.ToDto(p)) ;
            }
        }
        public int AddUserRoles(IEnumerable<userRole> items)
        {
            using (IOPContext db = new IOPContext())
            {
                UserRoleConverter converter = new UserRoleConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Added;
                }
              return  db.SaveChanges();
            }
        }
        public int UpdateUserRoles(IEnumerable<userRole> items)
        {
            using (IOPContext db = new IOPContext())
            {
                UserRoleConverter converter = new UserRoleConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
        public int DeleteUserRoles(IEnumerable<userRole> items)
        {
            using (IOPContext db = new IOPContext())
            {
                UserRoleConverter converter = new UserRoleConverter(db);
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
