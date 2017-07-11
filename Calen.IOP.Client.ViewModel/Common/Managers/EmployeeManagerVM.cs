using Calen.IOP.Client.ViewModel.Common.Criteria;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DataPortal;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Managers
{
    public class EmployeeManagerVM : ManagerBase<EmployeeVM>
    {
        EmployeeCriteriaVM _employeeCriteria = new EmployeeCriteriaVM() { PageIndex = 1, PageSize = 20 };

        public EmployeeManagerVM()
        {
            _employeeCriteria.PropertyChanged += _employeeCriteria_PropertyChanged;
        }

        private void _employeeCriteria_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if(e.PropertyName== "PageSize")
            {
                this.RefreshItemsCommand.Execute(null);
            }
            if (e.PropertyName == "PageIndex")
            {
                this.RefreshItemsCommand.Execute(null);
            }
        }

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
            this.ItemList.Clear();
            this.IsBusy = true;
           resultForEmployees result=await  GetDataPortal().FetchEmployees(this.EmployeeCriteria.ToDto());
            this.IsBusy = false;
            this.EmployeeCriteria.TotalCount = result.totalCount;
            if(result.employees!=null)
            {
                foreach(employee item in result.employees)
                {
                    var vm = EmployeeConvertUtil.FromDto(item);
                    this.ItemList.Add(vm);
                }
            }
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

        protected override bool EditPredicate()
        {
           return this.SelectedItem != null;
        }
        protected async override void EditExecute()
        {
            EmployeeVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync(vm);
            if (isSaveClick)
            {
                employee[] items = new employee[] { EmployeeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateEmployees(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
        protected override bool DeletePredicate()
        {
            return this.SelectedItem != null;
        }
        protected async override void DeleteExecute()
        {
            var items = this.ItemList.Where(x => x.IsSelected).ToList();
            if (items.Count == 0)
            {
                items.Add(this.SelectedItem);
            }
            bool toDelete = await this.DeleteItemsDialog?.ShowDialog(items);
            if (toDelete)
            {
                var list = items.Select(x => EmployeeConvertUtil.ToDto(x)).ToList();
                this.IsBusy = true;
                int count = await GetDataPortal().DeleteEmployees(list);
                this.IsBusy = false;
                if (count > 0)
                {
                    this.RefreshItemsAsync();
                }
            }
        }

        protected override bool ToFirstPagePredicate()
        {
            return this.EmployeeCriteria.PageIndex > 1;
        }
        protected override bool ToLastPagePredicate()
        {
            return this.EmployeeCriteria.PageIndex < EmployeeCriteria.PageCount;
        }
        protected override void ToFirstPageExecute()
        {
            this.EmployeeCriteria.PageIndex = 1;
        }
        protected override void ToLastPageExecute()
        {
            this.EmployeeCriteria.PageIndex = EmployeeCriteria.PageCount;
        }
        protected override bool ToNextPagePredicate()
        {
            return EmployeeCriteria.PageIndex < EmployeeCriteria.PageCount;
        }
        protected override bool ToPrePagePredicate()
        {
            return EmployeeCriteria.PageIndex > 1;
        }
        protected override void ToNextPageExecute()
        {
            EmployeeCriteria.PageIndex += 1;
        }
        protected override void ToPrePageExecute()
        {
            EmployeeCriteria.PageIndex -= 1;
        }

    }
}
