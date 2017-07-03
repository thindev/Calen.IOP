using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Criteria
{
    public class EmployeeCriteriaVM:ViewModelBase
    {
        int _pageSize;
        int _pageIndex;
        int _totalCount;
        string _employeeCode;
        string _employeeName;

        public int PageSize { get => _pageSize; set { Set(() => PageSize, ref _pageSize, value); } }
        public int PageIndex { get => _pageIndex; set { Set(() => PageIndex, ref _pageIndex, value); } }
        public int TotalCount { get => _totalCount; set { Set(() => TotalCount, ref _totalCount, value); } }
        public string EmployeeCode { get => _employeeCode; set { Set(() => EmployeeCode, ref _employeeCode, value); } }

        public string EmployeeName { get => _employeeName; set { Set(() => EmployeeName, ref _employeeName, value); } }
    }
}
