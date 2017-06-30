using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class servingRecord
    {
        public string id { get; set; }
        public DateTime? beginTime { get; set; }
        public DateTime? endTime { get; set; }
        public bool isConcurrent { get; set; }
        public bool isCurrent { get; set; }
        public string employeeId { get; set; }
        public jobPosition jobPosition { get; set; }
    }
}
