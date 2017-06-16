using Calen.IOP.Client.Desktop.ConvertUtil;
using Calen.IOP.DTO.Json;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calen.IOP.Client.Desktop.ViewModel
{
    public class DepartmentManager:ViewModelBase
    {
        ObservableCollection<DepartmentViewModel> _rootDepartments = new ObservableCollection<DepartmentViewModel>();

        public ObservableCollection<DepartmentViewModel> RootDepartments { get => _rootDepartments;  }
        public bool IsBusy { get => _isBusy; set { Set(() => IsBusy, ref _isBusy, value); } }

       

        bool _isBusy;
        #region Commands
        ICommand _refreshDepartmentsCommand;
        public ICommand RefreshDepartmentsCommand
        {
            get
            {
                if (_refreshDepartmentsCommand == null)
                {
                    _refreshDepartmentsCommand = new RelayCommand(RefreshDepartmentsExcute);
                }
                return _refreshDepartmentsCommand;
            }
        }

        private void RefreshDepartmentsExcute()
        {
            
            this.RefreshDepartmentsAsync();

        }
        #endregion

        private async void RefreshDepartmentsAsync()
        {
            _rootDepartments.Clear();
            this.IsBusy = true;
            ICollection<department> ds=await AppCxt.Current.RestDataPortal.GetDepartmentTreeAsync();
            this.IsBusy = false;
            if (ds!=null)
            {
                foreach (department d in ds)
                {
                    DepartmentViewModel vm = DepartmentConverter.FromDto(null,d);
                    _rootDepartments.Add(vm);
                }
            }
           
        }
    }
}
