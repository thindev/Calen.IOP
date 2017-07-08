using Calen.IOP.DTO.Common;
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
        int _pageCount;
        string _employeeCode;
        string _employeeName;

        public int PageSize { get => _pageSize;
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    if (_pageSize < 1) _pageSize = 1;
                    this.PageCount = _totalCount / _pageSize;
                    RaisePropertyChanged(() => PageSize);
                }
            }
        }
        public int PageIndex { get => _pageIndex; set { Set(() => PageIndex, ref _pageIndex, value); } }
        public int TotalCount { get => _totalCount;
            set
            {
                if(_totalCount!=value)
                {
                    _totalCount = value;
                    this.PageCount = _totalCount / _pageSize;
                    RaisePropertyChanged(() => TotalCount);
                }
            }
        }
        public string EmployeeCode { get => _employeeCode; set { Set(() => EmployeeCode, ref _employeeCode, value); } }

        public string EmployeeName { get => _employeeName; set { Set(() => EmployeeName, ref _employeeName, value); } }

        public int PageCount { get => _pageCount; set { Set(()=>PageCount,ref _pageCount,value); } }

        public criteriaForEmployees ToDto()
        {
            criteriaForEmployees dto = new criteriaForEmployees()
            {
                employeeCode = this.EmployeeCode,
                employeeName = this.EmployeeName,
                pageIndex = this.PageIndex,
                pageSize = this.PageSize
            };
            return dto;
        }
    }
}
