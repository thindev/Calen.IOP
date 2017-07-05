using Calen.IOP.Client.ViewModel.Common.Criteria;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DataPortal;
using Calen.IOP.DTO.Common;
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
           // this.IsBusy = true;
           // GetDataPortal().FetchEmployees(this.EmployeeCriteria);
        }
        protected override void AddExecute()
        {
            this.AddItemAsyc();
        }
        private async void AddItemAsyc()
        {
            EmployeeVM vm = new EmployeeVM() { Id = Guid.NewGuid().ToString() };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync(vm);
            if (isSaveClick)
            {
                employee[] items = new employee[] { EmployeeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddEmployees(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
    }
}
