using Calen.IOP.Client.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Calen.IOP.Client.Desktop.Pages.Widgets
{
    public class ParentDepartmentSelector:DepartmentSelector
    {
        public static readonly DependencyProperty ChildDepartmentProperty = DependencyProperty.Register("ChildDepartment", typeof(DepartmentViewModel), typeof(ParentDepartmentSelector), new FrameworkPropertyMetadata(null, ChildDepartmentChanged));

        private static void ChildDepartmentChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ParentDepartmentSelector pds = (ParentDepartmentSelector)d;
            pds.IsDataLoaded = false;
        }

        public DepartmentViewModel ChildDepartment
        {
            get { return (DepartmentViewModel)GetValue(ChildDepartmentProperty); }
            set { SetValue(ChildDepartmentProperty, value); }
        }
        protected override void OnRefreshFinished()
        {
           if(this.ChildDepartment!=null)
            {
                var items = this.RootDepartments.ToList();
                foreach(var item in items)
                {
                    TryRemoveChildDepartmentFromTree(RootDepartments, item);
                }
            }
        }
        void TryRemoveChildDepartmentFromTree(ObservableCollection<DepartmentViewModel> list, DepartmentViewModel d)
        {
            var items = list.ToList();
            if(d.Id==this.ChildDepartment.Id)
            {
                list.Remove(d);
            }
            else if(d.SubDepartments!=null)
            {
                foreach(var item in items)
                {
                    TryRemoveChildDepartmentFromTree(d.SubDepartments, item);
                }
            }
        }
    }
}
