using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    /// <summary>
    /// 工作岗位
    /// </summary>
    public class JobPosition
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual Department Department { get; set; }
    }
}
