using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DataAccess.Entities
{
    public class PersonBase : EntityBase
    {
        public string IdCardCode { get; set; }
        public SexTypes Sex { get; set; }
        public string MobileNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        public BirthdayTypes? BirthDayType { get; set; }
        public EducationLevels? Education { get; set; }
        public string UserId { get; set; }
        public string Passwrod { get; set; }
        public string Nationality { get; set; }
        public string PermissionIds { get; set; }
        public string UserRoleIds { get; set; }
        public string WeChat { get; set; }
        public string QQ { get; set; }
        public string PictureUrl { get; set; }
    }
}
