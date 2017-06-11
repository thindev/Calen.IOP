using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class Department
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public virtual Department ParentDepartment { get; set; }
        public virtual ICollection<Department> SubDepartments { get; set; }
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
