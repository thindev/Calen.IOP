using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common
{
    public class ServingRecordVM:ViewModelBase
    {
        private string _id;
        private DateTime? _beginTime;
        private DateTime? _endTime;
        private bool _isConcurrent;
        private bool _isCurrent;
        private JobPositionVM _jobPosition;
        private EmployeeVM _employee;

        public string Id { get => _id; set { Set(() => Id, ref _id, value); } }
        public DateTime? BeginTime { get => _beginTime; set { Set(() => BeginTime, ref _beginTime, value); } }
        public DateTime? EndTime { get => _endTime; set { Set(() => EndTime, ref _endTime, value); } }
        public bool IsConcurrent { get => _isConcurrent; set { Set(() => IsConcurrent, ref _isConcurrent, value); } }
        public bool IsCurrent { get => _isCurrent; set { Set(() => IsCurrent, ref _isCurrent, value); } }
        public JobPositionVM JobPosition { get => _jobPosition; set { Set(() => JobPosition, ref _jobPosition, value); } }

        public EmployeeVM Employee { get => _employee; set { Set(() => Employee, ref _employee, value); } }
    }
}
