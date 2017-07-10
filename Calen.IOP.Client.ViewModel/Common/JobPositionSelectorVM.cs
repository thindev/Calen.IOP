using Calen.IOP.Client.Desktop.ConvertUtil;
using Calen.IOP.DTO.Common;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace Calen.IOP.Client.ViewModel.Common
{
    public class JobPositionSelectorVM:ViewModelBase
    {
        private ObservableCollection<JobPositionVM> _jobPositionList = new ObservableCollection<JobPositionVM>();
        private ObservableCollection<DepartmentVM> _departmentTreeRoots = new ObservableCollection<DepartmentVM>();
        bool _isBusy;
        EmployeeVM _targetEmployee;
        ICommand _refreshDataCommand;
        ICommand _confirmCommand;
        ICommand _cancelCommand;
        
        public ObservableCollection<JobPositionVM> JobPositionList { get => _jobPositionList;}
        public ObservableCollection<DepartmentVM> DepartmentTreeRoots { get => _departmentTreeRoots; }
        public ICommand RefreshDataCommand
        {
            get
            {
                if(_refreshDataCommand==null)
                {
                    _refreshDataCommand = new RelayCommand(ReFreshDataExcute);
                }
                return _refreshDataCommand;
            }
        }

        public bool IsBusy { get => _isBusy; set { Set(() => IsBusy, ref _isBusy, value); } }

        public ICommand ConfirmCommand
        {
            get
            {
                if(_confirmCommand==null)
                {
                    _confirmCommand = new RelayCommand(ConfirmExcute, ConfirmPredicate);
                }
                return _confirmCommand;
            }
        }

        private bool ConfirmPredicate()
        {
            return true;
        }

        private void ConfirmExcute()
        {
            var list = this.JobPositionList.Where(p => p.IsSelected).ToList();
            _targetEmployee.ServingRecords.Clear();
            foreach(var item in list)
            {
                var sr = new ServingRecordVM();
                sr.Employee = _targetEmployee;
                sr.Id = Guid.NewGuid().ToString();
                sr.IsCurrent = true;
                sr.JobPosition = item;
                _targetEmployee.ServingRecords.Add(sr);
            }
        }

        public ICommand CancelCommand
        {
            get
            {
                if(_cancelCommand==null)
                {
                    _cancelCommand = new RelayCommand(CancelExcute, CancelPredicate);
                }
                return _cancelCommand;
            }
        }

        private bool CancelPredicate()
        {
            return true;
        }

        private void CancelExcute()
        {
            
        }

        private async void ReFreshDataExcute()
        {
            this.DepartmentTreeRoots.Clear();
            this.JobPositionList.Clear();
            this.IsBusy = true;
            IEnumerable<department> departments=await AppCxt.Current.DataPortal.GetDepartmentTreeAsync();
            this.IsBusy = false;
            if (departments != null)
            {
                foreach (department d in departments)
                {
                    DepartmentVM vm = DepartmentConvertUtil.FromDto(null, d);
                    this.DepartmentTreeRoots.Add(vm);
                }
            }
            foreach(var item in this.DepartmentTreeRoots)
            {
                this.SelectJobPositions(item);
            }
        }

        void SelectJobPositions(DepartmentVM d)
        {
            foreach(var item in d.JobPositions)
            {
                JobPositionList.Add(item);
                if (_targetEmployee != null)
                {
                    item.IsSelected = (_targetEmployee.ServingRecords.FirstOrDefault(p => p.JobPosition != null && p.JobPosition.Id == item.Id) != null);
                }
            }
            foreach(var sd in d.SubDepartments)
            {
                SelectJobPositions(sd);
            }
        }

        public void SetTargetEmployee(EmployeeVM em)
        {
            if (em == null) return;
            _targetEmployee = em;
            foreach(var item in JobPositionList)
            {
                item.IsSelected = (_targetEmployee.ServingRecords.FirstOrDefault(p => p.JobPosition != null && p.JobPosition.Id == item.Id) != null);
            }
        }
    }
}
