using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class Customer : PersonBase
    {
        public ComeFromType ComeFrom{get;set;}
        public string Introducer { get; set; }
        public CustomerType CustomerType { get; set; }
        public virtual ICollection<Employee> Salesmen { get; set; }
        public virtual ICollection<Employee> Advisors { get; set; }
    }
}
