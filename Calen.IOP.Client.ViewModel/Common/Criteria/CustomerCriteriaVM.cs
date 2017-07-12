using Calen.IOP.DTO;
using Calen.IOP.DTO.Common;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common.Criteria
{
    public class CustomerCriteriaVM: ViewModelBase
    {
        int _pageSize;
        int _pageIndex;
        int _totalCount;
        int _pageCount;
        int[] _pagesList;
        string _customerCode;
        string _customerName;
        CustomerType _customerType;

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
        public string CustomerCode { get => _customerCode; set { Set(() => CustomerCode, ref _customerCode, value); } }

        public string CustomerName { get => _customerName; set { Set(() => CustomerName, ref _customerName, value); } }

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

        public CustomerType CustomerType { get => _customerType; set { Set(()=>CustomerType,ref _customerType,value); } }

        public criteriaForCustomer ToDto()
        {
            criteriaForCustomer dto = new criteriaForCustomer()
            {
                customerCode = this.CustomerCode,
                customerName = this.CustomerName,
                pageIndex = this.PageIndex,
                pageSize = this.PageSize,
                customerType = this.CustomerType
            };
            return dto;
        }
    }
}
