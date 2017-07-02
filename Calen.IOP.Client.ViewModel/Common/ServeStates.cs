using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common
{
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
}
