using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class customer:personBase
    {
        public ComeFromType comeFrom { get; set; }
        public string introducer { get; set; }
        public CustomerType customerType { get; set; }
        public  entityDtoBase[] salesmen { get; set; }
        public  entityDtoBase[] advisors { get; set; }
    }
}
