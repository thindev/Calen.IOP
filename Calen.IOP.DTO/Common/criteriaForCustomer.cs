using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class criteriaForCustomer
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public string customerCode { get; set; }
        public string customerName { get; set; }
        public CustomerType customerType { get; set; }
    }
}
