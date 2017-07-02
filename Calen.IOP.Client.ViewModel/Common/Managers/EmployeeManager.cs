using Calen.IOP.Client.ViewModel.Common.Criteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Managers
{
    public class EmployeeManager:ManagerBase<EmployeeVM>
    {
        EmployeeCriteriaVM _employeeCriteria = new EmployeeCriteriaVM() { PageIndex = 1, PageSize = 20 };
        protected override void RefreshItemsExcute()
        {
            base.RefreshItemsExcute();
        }
    }
}
