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
    public class JobPosition : EntityBase
    {
        public virtual Department Department { get; set; }
        public virtual JobPostionLevel Level { get; set; }
        public virtual JobType JobType { get; set; }
    }
}
