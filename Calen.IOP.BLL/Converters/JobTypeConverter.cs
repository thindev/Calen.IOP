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
    class JobTypeConverter : ConverterBase<JobType, jobType>
    {
        public JobTypeConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override JobType FromDto(jobType dto)
        {
            JobType target = new JobType()
            {
                Code = dto.code,
                Description = dto.description,
                Id = dto.id,
                Name = dto.name,
            };
            return target;
        }

        public override jobType ToDto(JobType model)
        {
            jobType dto = new jobType()
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
