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
    class VipCardConverter : ConverterBase<VipCard, vipCard>
    {
        public VipCardConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override VipCard FromDto(vipCard dto)
        {
            VipCard model = DbContext.VipCards.Find(dto.id);
            if(model==null)
            {
                model = new VipCard() { Id = dto.id };
            }
            model.Description = dto.description;
            model.Code = dto.code;
            model.Id = dto.id;
            model.Name = dto.name;
            model.Price = dto.price;
            model.ReleaseTime = dto.releaseTime;
            model.State = dto.state;
            model.ValidityDayCount = dto.validityDayCount;
            return model;
        }

        public override vipCard ToDto(VipCard model)
        {
            vipCard dto = new vipCard()
            {
                code = model.Code,
                description = model.Description,
                id = model.Id,
                name = model.Name,
                price = model.Price,
                releaseTime = model.ReleaseTime,
                state = model.State,
                validityDayCount = model.ValidityDayCount,

            };
            return dto;
        }
    }
}
