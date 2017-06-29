using Calen.IOP.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Calen.IOP.DataAccess;
using Calen.IOP.DTO.Common;

namespace Calen.IOP.BLL.Converters
{
    class JobPositionLevelConverter : ConverterBase<JobPostionLevel, jobPositionLevel>
    {
        public JobPositionLevelConverter(IOPContext ctx) : base(ctx)
        {

        }

        public override JobPostionLevel FromDto(jobPositionLevel dto)
        {

            JobPostionLevel target = new JobPostionLevel()
            {
                Code = dto.code,
                Description = dto.description,
                Id = dto.id,
                Name = dto.name,
            };
       
           
            return target;
        }

        public override jobPositionLevel ToDto(JobPostionLevel model)
        {
            jobPositionLevel dto = new jobPositionLevel()
            {
                code = model.Code,
                description = model.Description,
                id = model.Id,
                name = model.Name
            };
            return dto;
        }
    }
}
