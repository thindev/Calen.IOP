using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class jobPosition:entityDtoBase
    {
        public int employeesCount { get; set; }

        public string departmentId { get; set; }
        public jobPositionLevel level { get; set; }
        public jobType jobType { get; set; }
    }
}
