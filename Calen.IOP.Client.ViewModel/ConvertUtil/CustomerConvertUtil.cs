using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class CustomerConvertUtil
    {
        public static customer ToDto(CustomerVM vm)
        {
            customer em = new customer()
            {
                address = vm.Address,
                birthday = vm.Birthday,
                birthdayType = vm.BirthdayType,
                code = vm.Code,
                description = vm.Description,
                education = vm.Education,
                email = vm.Email,
                id = vm.Id,
                idCardCode = vm.IdCardCode,
                mobileNumber = vm.MobileNumber,
                name = vm.Name,
                passWord = vm.PassWord,
                sex = vm.Sex,
                nationality = vm.Nationality,
                userId = vm.UserId,
                permissionIds = vm.PermissionIds.ToArray(),
                userRoleIds = vm.UserRoleIds.ToArray(),
                pictureUrl = vm.PictureUrl,
                WeChat = vm.WeChat,
                QQ = vm.QQ,
                advisors = vm.Advisors.Select(p => new entityDtoBase() { code = p.Code, description = p.Description, id = p.Id, name = p.Name }).ToArray(),
                comeFrom = vm.ComeFrom,
                customerType = vm.CustomerType,
                introducer = vm.Introducer,
                salesmen = vm.Salesmen.Select(p => new entityDtoBase() { code = p.Code, description = p.Description, id = p.Id, name = p.Name }).ToArray(),


            };
            return em;
        }
        public static CustomerVM FromDto(customer dto)
        {
            CustomerVM vm = new CustomerVM()
            {
                Address = dto.address,
                Birthday = dto.birthday,
                BirthdayType = dto.birthdayType,
                Code = dto.code,
                ComeFrom = dto.comeFrom,
                CustomerType = dto.customerType,
                Description = dto.description,
                Education = dto.education,
                Email = dto.email,
                Id = dto.id,
                IdCardCode = dto.idCardCode,
                Introducer = dto.introducer,
                MobileNumber = dto.mobileNumber,
                Name = dto.name,
                Nationality = dto.nationality,
                PassWord = dto.passWord,
                PictureUrl = dto.pictureUrl,
                QQ = dto.QQ,
                Sex = dto.sex,
                UserId = dto.userId,
                WeChat = dto.WeChat

            };
             if (dto.userRoleIds != null)
            {
                foreach (var item in dto.userRoleIds)
                {
                    vm.UserRoleIds.Add(item);
                }
            }
            if (dto.permissionIds != null)
            {
                foreach (var item in dto.permissionIds)
                {
                    vm.PermissionIds.Add(item);
                }
            }
            if(dto.salesmen!=null)
            {
                foreach(var p in dto.salesmen)
                {
                    var e = new EntityVMBase() { Code = p.code, Description = p.description, Id = p.id, Name = p.name };
                    vm.Salesmen.Add(e);
                }
            }
            if (dto.advisors != null)
            {
                foreach (var p in dto.advisors)
                {
                    var e = new EntityVMBase() { Code = p.code, Description = p.description, Id = p.id, Name = p.name };
                    vm.Advisors.Add(e);
                }
            }
            return vm;
        }
    }
}
