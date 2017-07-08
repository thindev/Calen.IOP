using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Mapping
{
    public class EmployeeMap:EntityTypeConfiguration<Employee>
    {
        public EmployeeMap()
        {
            this.ToTable("Employees");
            this.HasKey(e => e.Id);
            this.Property(e => e.Id).HasMaxLength(128);
            this.Property(e => e.Name).HasMaxLength(128);
            this.Property(e => e.Sex).IsRequired();
            this.Property(e => e.BirthDay).IsOptional();
            this.Property(e => e.Image).IsOptional();
            this.HasOptional(e => e.Department).WithMany(d => d.Employees).WillCascadeOnDelete(false);
            this.HasMany(e => e.ServingRecords).WithRequired(d=>d.Employee);
        }
    }
}
