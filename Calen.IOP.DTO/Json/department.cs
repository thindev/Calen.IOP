using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Json
{
    public class department
    {
        public string id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public employee leader { get; set; }
        public string parentDepartmentId { get; set; }
        public  ICollection<department> subDepartments { get; set; }
        public ICollection<jobPosition> jobPositions { get; set; }
    }
}
