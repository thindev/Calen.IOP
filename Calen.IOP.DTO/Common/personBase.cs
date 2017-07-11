using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class personBase:entityDtoBase
    {
        public string idCardCode { get; set; }
        public SexTypes sex { get; set; }
        public string nationality { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime? birthday { get; set; }
        public BirthdayTypes? birthdayType { get; set; }
        public EducationLevels? education { get; set; }
        
        public string userId { get; set; }
        public string passWord { get; set; }
        public string[] userRoleIds { get; set; }
        public string[] permissionIds { get; set; }
        public string WeChat { get; set; }
        public string QQ { get; set; }
        public string pictureUrl { get; set; }
    }
}
