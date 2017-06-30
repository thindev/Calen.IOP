using Calen.IOP.DataAccess;
using Calen.IOP.DataAccess.Entities;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
    class JobPositionConverter : ConverterBase<JobPosition, jobPosition>
    {
        JobPositionLevelConverter _levelConverter;
        JobTypeConverter _typeConverter;
        public JobPositionConverter(IOPContext ctx) : base(ctx)
        {
             _levelConverter = new JobPositionLevelConverter(ctx);
            _typeConverter = new JobTypeConverter(ctx);
        }

        public override jobPosition ToDto(JobPosition v)
        {
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.code = v.Code;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            if(v.Level!=null)
            {
                jp.level = _levelConverter.ToDto(v.Level);
            }
            if(v.JobType!=null)
            {
                jp.jobType = _typeConverter.ToDto(v.JobType);
            }
            return jp;
        }
        public override JobPosition FromDto(jobPosition dto)
        {

            JobPosition jobP = new JobPosition()
            {
                Description = dto.description,
                Id = dto.id,
                Code = dto.code,
                Name = dto.name,
            };
            if(dto.level!=null)
            {
                jobP.Level = _levelConverter.FromDto(dto.level);
            }
            if (dto.jobType != null)
            {
                jobP.JobType = _typeConverter.FromDto(dto.jobType);
            }
            return jobP;
        }
    }
}
