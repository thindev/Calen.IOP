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
    class UserRoleConverter : ConverterBase<UserRole, userRole>
    {
        public UserRoleConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override UserRole FromDto(userRole dto)
        {
            var model = new UserRole()
            {
                Code = dto.code,
                Description = dto.description,
                FunctionIds = dto.functionIds,
                Id = dto.id,
                Name = dto.name
            };
            return model;
        }

        public override userRole ToDto(UserRole model)
        {
            return new userRole()
            {
                code = model.Code,
                description = model.Description,
                functionIds = model.FunctionIds,
                id = model.Id,
                name = model.Name,
            };
        }
    }
}
