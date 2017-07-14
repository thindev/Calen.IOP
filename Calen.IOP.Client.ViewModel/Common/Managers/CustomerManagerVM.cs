using Calen.IOP.Client.ViewModel.Common.Criteria;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DataPortal;
using Calen.IOP.DTO;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Managers
{
    public class CustomerManagerVM : ManagerBase<CustomerVM>
    {
        CustomerCriteriaVM _customerCriteria = new CustomerCriteriaVM() { PageIndex = 1, PageSize = 20 };
        public CustomerType CustomerType { get; set; }
        public CustomerManagerVM()
        {
            _customerCriteria.PropertyChanged += _employeeCriteria_PropertyChanged;
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

        public CustomerCriteriaVM CustomerCriteria { get => _customerCriteria; }

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
            this.CustomerCriteria.CustomerType = this.CustomerType;
           resultForCustomers result=await  GetDataPortal().FetchCustomers(this.CustomerCriteria.ToDto());
            this.IsBusy = false;
            this.CustomerCriteria.TotalCount = result.totalCount;
            if(result.customers!=null)
            {
                foreach(customer item in result.customers)
                {
                    var vm = CustomerConvertUtil.FromDto(item);
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
            CustomerVM vm = new CustomerVM() { Id = Guid.NewGuid().ToString() , CustomerType = this.CustomerType };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                customer[] items = new customer[] { CustomerConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddCustomers(items);
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
            CustomerVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                customer[] items = new customer[] { CustomerConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateCustomers(items);
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
                var list = items.Select(x => x.Id).ToList();
                this.IsBusy = true;
                int count = await GetDataPortal().DeleteCustomers(list);
                this.IsBusy = false;
                if (count > 0)
                {
                    this.RefreshItemsAsync();
                }
            }
        }

        protected override bool ToFirstPagePredicate()
        {
            return this.CustomerCriteria.PageIndex > 1;
        }
        protected override bool ToLastPagePredicate()
        {
            return this.CustomerCriteria.PageIndex < CustomerCriteria.PageCount;
        }
        protected override void ToFirstPageExecute()
        {
            this.CustomerCriteria.PageIndex = 1;
        }
        protected override void ToLastPageExecute()
        {
            this.CustomerCriteria.PageIndex = CustomerCriteria.PageCount;
        }
        protected override bool ToNextPagePredicate()
        {
            return CustomerCriteria.PageIndex < CustomerCriteria.PageCount;
        }
        protected override bool ToPrePagePredicate()
        {
            return CustomerCriteria.PageIndex > 1;
        }
        protected override void ToNextPageExecute()
        {
            CustomerCriteria.PageIndex += 1;
        }
        protected override void ToPrePageExecute()
        {
            CustomerCriteria.PageIndex -= 1;
        }

    }
}
