using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    /// <summary>
    /// 任职记录
    /// </summary>
    public class ServingRecord
    {
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual Employee Employee {get;set;}
    }
}
