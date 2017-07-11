using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class resultForCustomers
    {
        public int totalCount { get; set; }
        public int currentIndex { get; set; }
        public customer[] customers { get; set; }
    }
}
