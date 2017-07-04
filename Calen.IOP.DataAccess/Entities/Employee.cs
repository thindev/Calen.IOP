using Calen.IOP.DTO;
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
        public EducationLevels Education { get; set; }
        public ServeStates ServeState { get; set; }
        public string UserId { get; set; }
        public string Passwrod { get; set; }
        public string Nationality { get; set; }
        /// <summary>
        /// 是否虚拟的
        /// </summary>
        public bool IsVirtual { get; set; }
        public virtual Department Department { get; set; }
        public ICollection<ServingRecord> ServingRecords { get; set; }
    }
}
