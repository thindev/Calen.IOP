using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class employee:entityDtoBase
    {
        public int sex { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime? birthDay { get; set; }
        public string image { get; set; }
        public int education { get; set; }
        public string  departmentId { get; set; }
        public ICollection<string> currentPositions { get; set; }
      
    }
}
