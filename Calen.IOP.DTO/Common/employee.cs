using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO.Common
{
    public class employee:entityDtoBase
    {
        public string idCardCode { get; set; }
        public int sex { get; set; }
        public string nationality { get; set; }
        public string mobileNumber { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public DateTime? birthDay { get; set; }
        public string image { get; set; }
        public int education { get; set; }
        public int serveState { get; set; }
        public string userId { get; set; }
        public string passWord { get; set; }
        public string[] userRoleIds { get; set; }
        public string[] permissionIds { get; set; }
        public bool isVirtual { get; set; }
        public string  departmentId { get; set; }
        public string departmentName { get; set; }
        public servingRecord[] servingRecords { get; set; }
      
    }
}
