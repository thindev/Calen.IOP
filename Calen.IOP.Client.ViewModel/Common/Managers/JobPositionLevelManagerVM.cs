using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO.Common;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace Calen.IOP.Client.ViewModel
{
    public class JobPositionLevelManagerVM : ManagerBase<JobPositionLevelVM>
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
            JobPositionLevelVM vm = new JobPositionLevelVM() { Id = Guid.NewGuid().ToString() };
            vm.IsDirty = true;
            vm.IsEditing = true;
            vm.IsNew = true;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick=  await this.EditItemDialog?.ShowDialogAsync(vm);
            if(isSaveClick)
            {
                jobPositionLevel[] items = new jobPositionLevel[] { JobPositionLevelConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.AddJobPositionLevels(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
        private async void RefreshItemsAsync()
        {
            this.ItemList.Clear();
            IsBusy = true;
            ICollection<jobPositionLevel> items= await AppCxt.Current.DataPortal.GetAllJobPositionLevelsAsync();
            IsBusy = false;
            foreach(var item in items)
            {
                JobPositionLevelVM vm = JobPositionLevelConvertUtil.FromDto(item);
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
                if(!items.Contains(this.SelectedItem))
                {
                    items.Add(this.SelectedItem);
                }
                bool isSureToDelete = await this.DeleteItemsDialog.ShowDialog(items);
                if (isSureToDelete)
                {
                    List<jobPositionLevel> list = items.Select(p => JobPositionLevelConvertUtil.ToDto(p)).ToList();
                    this.IsBusy = true;
                    int result = await AppCxt.Current.DataPortal.DeletJobPositionLevels(list);
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
            JobPositionLevelVM vm = this.SelectedItem.DeepClone();
            vm.IsDirty = false;
            vm.IsEditing = true;
            vm.IsNew = false;
            this.IsEditing = true;
            this.CurrentEditingItem = vm;
            bool isSaveClick = await this.EditItemDialog?.ShowDialogAsync(vm);
            if (isSaveClick)
            {
                jobPositionLevel[] items = new jobPositionLevel[] { JobPositionLevelConvertUtil.ToDto(vm) };
                int count = await AppCxt.Current.DataPortal.UpdateJobPositionLevels(items);
                this.ClearEditingState();
                this.RefreshItemsAsync();
            }
        }
    }
}
