﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;

namespace Calen.IOP.BLL.Converters
{
    class HireTypeConverter : ConverterBase<HireType,hireType>
    {
        public HireTypeConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override HireType FromDto(hireType dto)
        {
            HireType target = new HireType()
            {
                Code = dto.code,
                Description = dto.description,
                Id = dto.id,
                Name = dto.name
            };
            
            return target;
        }

        public override hireType ToDto(HireType model)
        {
            hireType ht = new hireType()
            {
                code = model.Code,
                description = model.Description,
                id = model.Id,
                name = model.Name
            };
            return ht;
        }
    }
}
