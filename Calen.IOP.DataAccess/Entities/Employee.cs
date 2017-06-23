using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class Employee : EntityBase
    {
        public string IdCardNum { get; set; }
        public SexTypes Sex { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public byte[] Image { get; set; }
        public EducationLevel Education { get; set; }


        public virtual Department Department { get; set; }
        public ICollection<ServingRecord> ServingRecords { get; set; }
    }

    public enum SexTypes
    {
        Unknowed=0,
        Male = 1,
        Female =2
    }
    public enum EducationLevel
    {
        /// <summary>
        /// 小学
        /// </summary>
        PrimarySchool,
        /// <summary>
        /// 初中
        /// </summary>
        JuniorMiddleSchool,
        /// <summary>
        /// 高中
        /// </summary>
        SeniorHighSchool,
        /// <summary>
        /// 大专
        /// </summary>
        JuniorCollege,
        /// <summary>
        /// 本科
        /// </summary>
        Undergraduate,
        /// <summary>
        /// 硕士
        /// </summary>
        MasterLevel,
        /// <summary>
        /// 博士
        /// </summary>
        DoctorLevel,
        /// <summary>
        /// 博士后
        /// </summary>
        Postdoctor
    }

    /// <summary>
    /// 在职状态
    /// </summary>
    public enum ServeState
    {
        /// <summary>
        /// 在职
        /// </summary>
        InServe=0,
        /// <summary>
        /// 试用期
        /// </summary>
        ProbationaryPeriod=1,
        /// <summary>
        /// 离职
        /// </summary>
        Resignation=9
    }
}
