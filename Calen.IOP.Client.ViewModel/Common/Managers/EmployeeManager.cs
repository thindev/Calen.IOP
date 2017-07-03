using Calen.IOP.Client.ViewModel.Common.Criteria;
using Calen.IOP.DataPortal;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Managers
{
    public class EmployeeManager:ManagerBase<EmployeeVM>
    {
        EmployeeCriteriaVM _employeeCriteria = new EmployeeCriteriaVM() { PageIndex = 1, PageSize = 20 };

        public EmployeeCriteriaVM EmployeeCriteria { get => _employeeCriteria; }

        private IDataPortal GetDataPortal()
        {
            return AppCxt.Current.DataPortal;
        }
        protected override void RefreshItemsExcute()
        {
            this.RefreshItemsAsync();
        }
        

        private async void RefreshItemsAsync()
        {
            this.IsBusy = true;
           // GetDataPortal().FetchEmployees(this.EmployeeCriteria);
        }
    }
}
