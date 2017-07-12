using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common
{
    public class CustomerVM : PersonBaseVM<CustomerVM>
    {
        ComeFromType _comeFrom;
        string _introducer;
        CustomerType _customerType;
        ObservableCollection<EntityVMBase> _salesmen = new ObservableCollection<EntityVMBase>();
        ObservableCollection<EntityVMBase> _advisors = new ObservableCollection<EntityVMBase>();

        public ObservableCollection<EntityVMBase> Salesmen { get => _salesmen; }
        public ObservableCollection<EntityVMBase> Advisors { get => _advisors;  }
        public ComeFromType ComeFrom { get => _comeFrom; set { Set(() => ComeFrom, ref _comeFrom, value); } }
        public string Introducer { get => _introducer; set { Set(()=>Introducer,ref _introducer,value); } }
        public CustomerType CustomerType { get => _customerType; set { Set(()=>CustomerType,ref _customerType,value); } }
        public override CustomerVM DeepClone()
        {
            var dto = CustomerConvertUtil.ToDto(this);
            var vm = CustomerConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }


}
