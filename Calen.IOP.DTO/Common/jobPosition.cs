﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class jobPosition
    {
        public int employeesCount { get; set; }

        public string id { get; set; }
        public int index { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string departmentId { get; set; }
    }
}
