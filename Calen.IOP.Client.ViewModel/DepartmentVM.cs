using GalaSoft.MvvmLight;
#if WINDOWS_WPF
using RelayCommand = GalaSoft.MvvmLight.CommandWpf.RelayCommand;
#else
using RelayCommand = GalaSoft.MvvmLight.Command.RelayCommand;
#endif
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Calen.IOP.DTO.Common;
using Calen.IOP.Client.Desktop.ConvertUtil;

namespace Calen.IOP.Client.ViewModel
{
    public class DepartmentVM:EntityVMBase<DepartmentVM>
    {
        
        EmployeeVM _leader;
        DepartmentVM _parentDepartment;
        ObservableCollection<DepartmentVM> _subDepartments=new ObservableCollection<DepartmentVM>();
        ObservableCollection<JobPositionVM> _jobPositions=new ObservableCollection<JobPositionVM>();

        JobPositionVM _selectedJobPostion;
        ICommand _addJobPositionCommand;
        ICommand _removeJobPositionCommand;

       
        public DepartmentVM ParentDepartment { get => _parentDepartment; set { Set(() => ParentDepartment, ref _parentDepartment, value); } }
        public ObservableCollection<DepartmentVM> SubDepartments { get => _subDepartments; }
        public EmployeeVM Leader { get => _leader; set => _leader = value; }
        public ObservableCollection<JobPositionVM> JobPositions { get => _jobPositions;  }
       


        #region For view control
        bool _isSelected;
        bool _isEditing;
        
        public bool IsSelected { get => _isSelected; set { Set(()=>IsSelected,ref _isSelected,value); } }

        public bool IsEditing { get => _isEditing; set { Set(() => IsEditing, ref _isEditing, value); } }

        #endregion

        public JobPositionVM SelectedJobPostion { get => _selectedJobPostion; set { Set(() => SelectedJobPostion, ref _selectedJobPostion, value); } }

        public ICommand AddJobPositionCommand {
            get
            {
                if(_addJobPositionCommand==null)
                {
                    _addJobPositionCommand = new RelayCommand(AddJobPositionExecute, AddJobPositionPredicate);
                }
                return _addJobPositionCommand;
            }
        }

        private bool AddJobPositionPredicate()
        {
            return true;
        }

        private void AddJobPositionExecute()
        {
            string[] indexes = this.JobPositions.Select(p => p.Code).ToArray();
            string index = string.Empty;
            if(indexes.Length>0)
            {
               index= indexes.Max() + 1;
            }
            
            JobPositionVM vm = new JobPositionVM();
            vm.Id = Guid.NewGuid().ToString();
            vm.Code = index;
            this.JobPositions.Add(vm);
            this.SelectedJobPostion = vm;
        }

        public ICommand RemoveJobPositionCommand
        {
            get
            {
                if (_removeJobPositionCommand == null)
                {
                    _removeJobPositionCommand = new RelayCommand(RemoveJobPositionExecute, RemoveJobPositionPredicate);

                }
                return _removeJobPositionCommand;
            }
        }

        private bool RemoveJobPositionPredicate()
        {
            return this.SelectedJobPostion != null;
        }

        private void RemoveJobPositionExecute()
        {
            this.JobPositions.Remove(this.SelectedJobPostion);
            this.SelectedJobPostion = null;
        }

        public override DepartmentVM DeepClone()
        {

            department temp = DepartmentConvertUtil.ToDto(this,false);
            DepartmentVM dp = DepartmentConvertUtil.FromDto(this.ParentDepartment, temp);
            return dp;
            /**
            DepartmentVM t = new DepartmentVM()
            {
                _code = this._code,
                _description = this._description,
                _id = this._id,
                _isEditing = this._isEditing,
                _isSelected = this._isSelected,
                //_jobPositions = this._jobPositions,//clone outside
                _leader = this._leader,
                _name = this._name,
                _parentDepartment = this._parentDepartment,
                // _subDepartments=_subDepartments,//don't need to clone subdepatments

            };
            //clone jobPositions
            foreach(JobPositionVM jp in this.JobPositions)
            {
                t.JobPositions.Add(jp.DeepClone());
            }
            return t;
    **/
        }

    }
}
