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
            //table name
            this.ToTable("Departments");
            //primary key
            HasKey(e => e.Id);
            //properties
            this.Property(e => e.Id).HasMaxLength(128);
            this.Property(e => e.Name).HasMaxLength(128);
            this.Property(e => e.Description).HasMaxLength(512);

            this.HasOptional(e => e.Department).WithMany(e => e.JobPositions);
        }
    }
}
