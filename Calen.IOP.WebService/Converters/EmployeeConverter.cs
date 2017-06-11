using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calen.IOP.WebService.Converters
{
    public class EmployeeConverter
    {
        public employee Convert(Employee v)
        {
            employee em = new employee();
            em.address = v.Address;
            
            return em;
        }
    }
}
