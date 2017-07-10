using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class vipCard:entityDtoBase
    {
        public int validityDayCount { get; set; }
        public double price { get; set; }
        public double state { get; set; }
        public DateTime releaseTime { get; set; }
    }
}
