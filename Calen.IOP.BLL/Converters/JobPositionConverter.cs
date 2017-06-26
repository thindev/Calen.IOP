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
        public JobPositionConverter(IOPContext ctx) : base(ctx)
        {
        }

        public override jobPosition ToDto(JobPosition v)
        {
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.code = v.Code;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
        public override JobPosition FromDto(jobPosition dto, JobPosition jobP = null)
        {
            if (jobP == null)
            {
                jobP = new JobPosition();
            }
            jobP.Description = dto.description;
            jobP.Id = dto.id;
            jobP.Code = dto.code;
            jobP.Name = dto.name;
            return jobP;
        }
    }
}
