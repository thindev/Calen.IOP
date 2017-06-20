using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.ConvertUtil
{
    public class JobPositionConverter
    {
            public static JobPositionViewModel FromDto(jobPosition v)
            {
            return null;
            }
        public static jobPosition ToDto(JobPositionViewModel v)
        {
            jobPosition jp = new jobPosition();
            jp.description = v.Description;
            jp.id = v.Id;
            jp.name = v.Name;
            jp.departmentId = v.Department?.Id;
            return jp;
        }
        
    }
}
