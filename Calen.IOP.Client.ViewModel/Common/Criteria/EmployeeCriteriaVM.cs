using Calen.IOP.DTO.Common;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Criteria
{
    public class EmployeeCriteriaVM:ViewModelBase
    {
        int _pageSize;
        int _pageIndex;
        int _totalCount;
        int _pageCount;
        int[] _pagesList;
        string _employeeCode;
        string _employeeName;

        public int PageSize { get => _pageSize;
            set
            {
                if (_pageSize != value)
                {
                    _pageSize = value;
                    if (_pageSize < 1) _pageSize = 1;
                    this.PageCount = (int)Math.Ceiling((double)_totalCount / _pageSize);
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
                    this.PageCount =(int)Math.Ceiling((double)_totalCount / _pageSize);
                    RaisePropertyChanged(() => TotalCount);
                }
            }
        }
        public string EmployeeCode { get => _employeeCode; set { Set(() => EmployeeCode, ref _employeeCode, value); } }

        public string EmployeeName { get => _employeeName; set { Set(() => EmployeeName, ref _employeeName, value); } }

        public int PageCount { get => _pageCount;

            set {
                if(value!=_pageCount)
                {
                    List<int> list = new List<int>();
                    for(int i=1;i<=value;i++)
                    {
                        list.Add(i);
                    }
                    PagesList = list.ToArray();
                    Set(() => PageCount, ref _pageCount, value);
                }
            } }

        public int[] PagesList { get => _pagesList; set { Set(() => PagesList, ref _pagesList, value); } }

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
