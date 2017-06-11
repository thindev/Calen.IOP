using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Mapping
{
    public class JobPositionMap:EntityTypeConfiguration<JobPosition>
    {
        public JobPositionMap()
        {
            HasKey(e => e.Id);
        }
    }
}
