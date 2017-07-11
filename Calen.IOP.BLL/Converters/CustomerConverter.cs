using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calen.IOP.DataAccess;

namespace Calen.IOP.BLL.Converters
{
    class CustomerConverter : ConverterBase<Customer, customer>
    {
        public CustomerConverter(IOPContext ctx) : base(ctx)
        {

        }

        public override Customer FromDto(customer dto)
        {
            Customer model = DbContext.Customers.Find(dto.id);
            if(model==null)
            {
                model = new Customer();
            }
            model.Address = dto.address;
            if(dto.advisors!=null&&dto.advisors.Length>0)
            {
                if (model.Advisors != null)
                {
                    model.Advisors.Clear();
                }
                else
                {
                    model.Advisors = new List<Employee>();
                }
                foreach(var item in dto.advisors)
                {
                    var m = DbContext.Employees.Find(item.id);
                    model.Advisors.Add(m);
                }
            }
            if (dto.salesmen != null && dto.salesmen.Length > 0)
            {
                if (model.Salesmen != null)
                {
                    model.Salesmen.Clear();
                }
                else
                {
                    model.Salesmen = new List<Employee>();
                }
                foreach (var item in dto.salesmen)
                {
                    var m = DbContext.Employees.Find(item.id);
                    model.Salesmen.Add(m);
                }
            }
            model.BirthDay = dto.birthday;
            model.BirthDayType = dto.birthdayType;
            model.Code = dto.code;
            model.ComeFrom = dto.comeFrom;
            model.CustomerType = dto.customerType;
            model.Description = dto.description;
            model.Education = dto.education;
            model.Email = dto.email;
            model.Id = dto.id;
            model.IdCardCode = dto.idCardCode;
            model.Introducer = dto.introducer;
            model.MobileNumber = dto.mobileNumber;
            model.Name = dto.name;
            model.Nationality = dto.nationality;
            model.Passwrod = dto.passWord;
            model.PermissionIds = dto.permissionIds == null ? null : string.Join(",",dto.permissionIds);
            model.PictureUrl = dto.pictureUrl;
            model.QQ = dto.QQ;
            model.Sex = dto.sex;
            model.UserId = dto.userId;
            model.UserRoleIds = dto.userRoleIds == null ? null : string.Join("", dto.userRoleIds);
            model.WeChat = dto.WeChat;
            return model;
        }

        public override customer ToDto(Customer model)
        {
            customer dto = new customer()
            {
                address = model.Address,
                WeChat = model.WeChat,
                userRoleIds = model.UserRoleIds == null ? null : model.UserRoleIds.Split(','),
                advisors = model.Advisors == null ? null : model.Advisors.Select(m => new entityDtoBase() { code = m.Code, description = model.Description, id = model.Id, name = model.Name }).ToArray(),
                id = model.Id,
                email = model.Email,
                education = model.Education,
                description = model.Description,
                birthday = model.BirthDay,
                birthdayType = model.BirthDayType,
                code = model.Code,
                comeFrom = model.ComeFrom,
                customerType = model.CustomerType,
                idCardCode = model.IdCardCode,
                introducer = model.Introducer,
                mobileNumber = model.MobileNumber,
                name = model.Name,
                nationality = model.Nationality,
                passWord = model.Passwrod,
                permissionIds = model.PermissionIds == null ? null : model.PermissionIds.Split(',').ToArray(),
                pictureUrl = model.PictureUrl,
                QQ = model.PictureUrl,
                salesmen = model.Salesmen == null ? null : model.Salesmen.Select(m => new entityDtoBase() { code = m.Code, description = model.Description, id = model.Id, name = model.Name }).ToArray(),
                sex = model.Sex,
                userId = model.UserId,

            };
            return dto;
        }
    }
}
