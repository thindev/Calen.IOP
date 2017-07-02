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
        public string IdCardCode { get; set; }
        public SexTypes Sex { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public byte[] Image { get; set; }
        public EducationLevel Education { get; set; }
        public ServeStates ServeState { get; set; }
        public string UserId { get; set; }
        public string Passwrod { get; set; }
        /// <summary>
        /// 是否虚拟的
        /// </summary>
        public bool IsVirtual { get; set; }


        public virtual Department Department { get; set; }
        public ICollection<ServingRecord> ServingRecords { get; set; }
    }

    public enum SexTypes
    {
        Unknown=0,
        Male = 1,
        Female =2
    }
    public enum EducationLevel
    {
        Unknown=0,
        /// <summary>
        /// 小学
        /// </summary>
        PrimarySchool=1,
        /// <summary>
        /// 初中
        /// </summary>
        JuniorMiddleSchool=2,
        /// <summary>
        /// 高中
        /// </summary>
        SeniorHighSchool=3,
        /// <summary>
        /// 大专
        /// </summary>
        JuniorCollege=4,
        /// <summary>
        /// 本科
        /// </summary>
        Undergraduate=5,
        /// <summary>
        /// 硕士
        /// </summary>
        MasterLevel=6,
        /// <summary>
        /// 博士
        /// </summary>
        DoctorLevel=7,
        /// <summary>
        /// 博士后
        /// </summary>
        Postdoctor=8
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ServeStates
    {
        Unknown=0,
        /// <summary>
        /// 在
        /// </summary>
        InServe=1,
        /// <summary>
        /// 试
        /// </summary>
        ProbationaryPeriod=2,
        /// <summary>
        /// 假
        /// </summary>
        Onleave = 3,
        /// <summary>
        /// 离
        /// </summary>
        Resignation =9
    }
}
