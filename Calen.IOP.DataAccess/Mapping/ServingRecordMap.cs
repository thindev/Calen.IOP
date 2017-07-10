using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Mapping
{
    public class ServingRecordMap : EntityTypeConfiguration<ServingRecord>
    {
        public ServingRecordMap()
        {
            this.HasRequired(e => e.Employee).WithMany(e => e.ServingRecords);
        }
    }
}
