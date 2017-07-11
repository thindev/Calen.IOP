using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.Client.ViewModel.ConvertUtil;
using Calen.IOP.DTO;
using System;
using System.Collections.ObjectModel;
#if WINDOWS_WPF
using System.Windows.Media.Imaging;
#endif

namespace Calen.IOP.Client.ViewModel
{
    public class EmployeeVM : PersonBaseVM<EmployeeVM>
    {
        
        private bool _isVirtual;
        private ServeStates? _serveState;
        private BitmapImage _image;
        private DepartmentVM _department;
        private ObservableCollection<ServingRecordVM> _servingRecords = new ObservableCollection<ServingRecordVM>();

        public ServeStates? ServeState { get => _serveState; set { Set(() => ServeState, ref _serveState, value); } }
        public ObservableCollection<ServingRecordVM> ServingRecords { get => _servingRecords; }
        public bool IsVirtual { get => _isVirtual; set { Set(() => IsVirtual, ref _isVirtual, value); } }
        public DepartmentVM Department { get => _department; set { Set(() => Department, ref _department, value); } }
        public BitmapImage Image { get => _image; set { Set(() => Image, ref _image, value); } }

        public override EmployeeVM DeepClone()
        {
            var dto = EmployeeConvertUtil.ToDto(this);
            var vm = EmployeeConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}