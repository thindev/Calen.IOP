using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class UserRoleConvertUtil
    {
        public static UserRoleVM FromDto(userRole dto)
        {
            var vm=new  UserRoleVM()
            {
                Code = dto.code,
                Description = dto.description,
                Id = dto.id,
                Name = dto.name,

            };
            if (dto.functionIds != null && dto.functionIds.Length > 0)
            {
                var ids = dto.functionIds.Split(',');
                foreach (var id in ids)
                {
                    vm.FunctionIds.Add(id);
                }
            }
            return vm;
        }
        public static userRole ToDto(UserRoleVM vm)
        {
            userRole dto = new userRole()
            {
                code = vm.Code,
                description = vm.Description,
                functionIds = string.Join(",", vm.FunctionIds),
                id = vm.Id,
                name = vm.Name,

            };
            return dto;
        }
    }
}
