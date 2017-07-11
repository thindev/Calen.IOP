using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class employee:personBase
    {
        public ServeStates? serveState { get; set; }
        public string image { get; set; }
        public bool isVirtual { get; set; }
        public string  departmentId { get; set; }
        public string departmentName { get; set; }
        public servingRecord[] servingRecords { get; set; }
      
    }
}
