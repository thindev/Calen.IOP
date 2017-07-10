using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class VipCard:EntityBase
    {
        public int ValidityDayCount { get; set; }
        public double Price { get; set; }
        public double State { get; set; }
        public DateTime ReleaseTime { get; set; }
    }
}
