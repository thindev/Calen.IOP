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
    public class VipCardManager
    {
        public int AddVipCards(IEnumerable<vipCard> items)
        {
            using (IOPContext db = new IOPContext())
            {
                List<VipCard> list = new List<VipCard>();
                VipCardConverter converter = new VipCardConverter(db);
                foreach (var item in items)
                {
                    var model = converter.FromDto(item);
                    list.Add(model);
                }
                db.VipCards.AddRange(list);
                return db.SaveChanges();
            }
        }
        public IEnumerable<vipCard> GetAllVipCards()
        {
            using (IOPContext db = new IOPContext())
            {
                List<VipCard> list = db.VipCards.ToList();
                ICollection<vipCard> items = new List<vipCard>();
                VipCardConverter converter = new VipCardConverter(db);
                foreach (var item in list)
                {
                    var dto = converter.ToDto(item);
                    items.Add(dto);
                }
                return items;
            }
        }

        public int DeleteVipCards(IEnumerable<string> Ids)
        {
            using (IOPContext db = new IOPContext())
            {
                foreach (var id in Ids)
                {
                    var model = db.VipCards.Find(id);
                    if(model!=null)
                    {
                        db.Entry(model).State = System.Data.Entity.EntityState.Deleted;
                    }
                }
                return db.SaveChanges();
            }
        }
        public int UpdateVipCards(IEnumerable<vipCard> items)
        {
            using (IOPContext db = new IOPContext())
            {
                VipCardConverter converter = new VipCardConverter(db);
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
