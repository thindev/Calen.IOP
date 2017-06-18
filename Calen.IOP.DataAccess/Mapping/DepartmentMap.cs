using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Mapping
{
    public class DepartmentMap:EntityTypeConfiguration<Department>
    {
        public DepartmentMap()
        {
            this.ToTable("Departments");
            //primary key
            this.HasKey(e => e.Id);

            //property restritions
            this.Property(e => e.Id).HasMaxLength(128);
            this.Property(e => e.Name).HasMaxLength(256);
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.Code).HasMaxLength(128);
           

            //
            this.HasOptional(e => e.ParentDepartment).WithMany(e => e.SubDepartments);
            this.HasMany(e => e.Employees).WithOptional(x => x.Department);
            this.HasMany(e => e.JobPositions).WithOptional(x => x.Department);
            this.HasOptional(e => e.Leader);
        }
    }
}
