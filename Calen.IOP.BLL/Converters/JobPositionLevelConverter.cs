﻿using Calen.IOP.DataAccess.Entities;
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
            JobPostionLevel target = DbContext.JobPositionLevels.Find(dto.id);
            if (target == null)
                target = new JobPostionLevel();
            target.Code = dto.code;
            target.Description = dto.description;
            target.Id = dto.id;
            target.Name = dto.name;
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
