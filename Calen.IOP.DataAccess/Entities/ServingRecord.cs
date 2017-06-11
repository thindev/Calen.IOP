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
        public string Id { get; set; }
        public DateTime? BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 是否兼任
        /// </summary>
        public bool IsConcurrent { get; set; }
        /// <summary>
        /// 是否当前有效
        /// </summary>
        public bool IsCurrent { get; set; }
        public virtual Employee Employee { get; set; }
        public virtual JobPosition JobPosition{get;set;}  
    }
}
