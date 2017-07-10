using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.DTO
{
    public enum SexTypes
    {
        Unknown = 0,
        Male = 1,
        Female = 2
    }
    public enum BirthdayTypes
    {
        /// <summary>
        /// 公历
        /// </summary>
        SolarCalendar = 0,
        /// <summary>
        /// 农历
        /// </summary>
        LunarCalendar =1
    }
    public enum EducationLevels
    {
        Unknown = 0,
        /// <summary>
        /// 小学
        /// </summary>
        PrimarySchool = 1,
        /// <summary>
        /// 初中
        /// </summary>
        JuniorMiddleSchool = 2,
        /// <summary>
        /// 高中
        /// </summary>
        SeniorHighSchool = 3,
        /// <summary>
        /// 大专
        /// </summary>
        JuniorCollege = 4,
        /// <summary>
        /// 本科
        /// </summary>
        Undergraduate = 5,
        /// <summary>
        /// 硕士
        /// </summary>
        MasterLevel = 6,
        /// <summary>
        /// 博士
        /// </summary>
        DoctorLevel = 7,
        /// <summary>
        /// 博士后
        /// </summary>
        Postdoctor = 8
    }

    /// <summary>
    /// 
    /// </summary>
    public enum ServeStates
    {
        Unknown = 0,
        /// <summary>
        /// 在
        /// </summary>
        InServe = 1,
        /// <summary>
        /// 试
        /// </summary>
        ProbationaryPeriod = 2,
        /// <summary>
        /// 假
        /// </summary>
        Onleave = 3,
        /// <summary>
        /// 离
        /// </summary>
        Resignation = 9
    }

    public enum VipCardTypes
    {
        ValidateByDays = 1,//时效,按天数算
        ValidateByTimes = 2,//频次，按次数算
    }
    public enum VipCardStates
    {
        Available = 1,//在用
        Obsolete = 2,//停用
        ComingSoon=3,//即将推出
    }
}
