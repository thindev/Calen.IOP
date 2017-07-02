using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class criteriaForEmployees
    {
        public int pageSize { get; set; }
        public int pageIndex { get; set; }
        public string employeeCode { get; set; }
        public string employeeName { get; set; }
    }
}
