using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
     class EmployeeConverter
    {
        public employee Convert(Employee v)
        {
            employee em = new employee();
            em.address = v.Address;
            
            return em;
        }
    }
}
