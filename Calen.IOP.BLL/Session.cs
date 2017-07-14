using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL
{
    public class Session
    {
        public DateTime CreateTime { get; set; }
        public DateTime LastActiveTime { get; set; }
        public DateTime LoginTime { get; set; }
        public string UserId { get; set; }
    }
}
