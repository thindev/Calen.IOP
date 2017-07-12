using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Calen.IOP.Client.ViewModel
{
    public class JobTypeManagerVM : ManagerBase<JobTypeVM>
    {
       
        protected override void RefreshItemsExcute()
        {
            if (this.IsInDesignMode) return;
            this.RefreshItemsAsync();
        }
        protected override void AddExecute()
        {
            this.AddItem();
        }
        private async void AddItem()
        {
            JobTypeVM vm = new JobTypeVM() { Id = Guid.NewGuid().ToString() };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick=  await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if(isSaveClick)
            {
                jobType[] items = new jobType[] { JobTypeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddJobTypes(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
        private async void RefreshItemsAsync()
        {
            this.ItemList.Clear();
            IsBusy = true;
            ICollection<jobType> items= await AppCxt.Current.DataPortal.GetAllJobTypesAsync();
            IsBusy = false;
            foreach(var item in items)
            {
                JobTypeVM vm = JobTypeConvertUtil.FromDto(item);
                this.ItemList.Add(vm);
            }
        }
        protected override bool DeletePredicate()
        {
            return this.SelectedItem != null;
        }
        protected override void DeleteExecute()
        {
            this.DeleteItemsAsync();
        }
        private async void DeleteItemsAsync()
        {

            if (this.DeleteItemsDialog != null)
            {
                var items = this.ItemList.Where(p => p.IsSelected).ToList();
                if(items.Count == 0)
                {
                    items.Add(this.SelectedItem);
                }
                bool isSureToDelete = await this.DeleteItemsDialog.ShowDialog(items);
                if (isSureToDelete)
                {
                    List<jobType> list = items.Select(p => JobTypeConvertUtil.ToDto(p)).ToList();
                    this.IsBusy = true;
                    int result = await AppCxt.Current.DataPortal.DeletJobTypes(list);
                    if (result > 0)
                    {
                        this.RefreshItemsAsync();
                    }
                }
            }
        }
        protected override bool EditPredicate()
        {
            return this.SelectedItem != null;
        }
        protected override void EditExecute()
        {
            this.EditItem();
        }

        private async void EditItem()
        {
            JobTypeVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = false;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync("添加", vm);
            if (isSaveClick)
            {
                jobType[] items = new jobType[] { JobTypeConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateJobTypes(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
    }
}
