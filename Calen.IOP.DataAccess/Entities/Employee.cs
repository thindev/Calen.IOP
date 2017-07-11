using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class Employee:PersonBase
    {
        public byte[] Image { get; set; }
        public ServeStates ServeState { get; set; }
        /// <summary>
        /// 是否虚拟的
        /// </summary>
        public bool IsVirtual { get; set; }
        public virtual Department Department { get; set; }
        public virtual ICollection<ServingRecord> ServingRecords { get; set; }
    }
}
