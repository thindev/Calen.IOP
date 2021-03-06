﻿using Calen.IOP.BLL.Converters;
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
    public class HireTypeManager
    {
        public IEnumerable<hireType> GetAllHireTypes()
        {
            using (IOPContext db = new IOPContext())
            {
                HireTypeConverter converter = new HireTypeConverter(db);
                var hireTypes= db.HireTypes.ToList();
                ICollection<hireType> list = hireTypes.Select(p => converter.ToDto(p)).ToList();
                return list;
            }
        }
        public int AddHireTypes(IEnumerable<hireType> items)
        {
            using (IOPContext db = new IOPContext())
            {
                HireTypeConverter converter = new HireTypeConverter(db);
                IEnumerable<HireType> list = items.Select(p => converter.FromDto(p));
                db.HireTypes.AddRange(list);
               return db.SaveChanges();
            }
        }
        public int DeleteHireTypes(IEnumerable<hireType> items)
        {
            using (IOPContext db = new IOPContext())
            {
                HireTypeConverter converter = new HireTypeConverter(db);
                foreach(var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                }
                return db.SaveChanges();
            }
        }
        public int UpdateHireTypes(IEnumerable<hireType> items)
        {
            using (IOPContext db = new IOPContext())
            {
                HireTypeConverter converter = new HireTypeConverter(db);
                foreach(var item in items)
                {
                    var model = converter.FromDto(item);
                    db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                }
                return db.SaveChanges();
            }
        }
    }
}
