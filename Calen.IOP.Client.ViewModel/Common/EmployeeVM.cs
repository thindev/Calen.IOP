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
    public class EmployeeVM : EntityVMBase<EmployeeVM>
    {
        private string _idCardCode;
        private SexTypes? _sex;
        private string _mobileNumber;
        private string _email;
        private string _address;
        private DateTime? _birthDay;
        private BitmapImage _image;
        private EducationLevels? _education;
        private ServeStates? _serveState;
        private string _userId;
        private string _passWord;
        private string _nationality;
        private bool _isVirtual;
        private ObservableCollection<string> _userRoleIds = new ObservableCollection<string>();
        private ObservableCollection<string> _permissionIds = new ObservableCollection<string>();
        private DepartmentVM _department;
        private ObservableCollection<ServingRecordVM> _servingRecords = new ObservableCollection<ServingRecordVM>();

        public string IdCardCode { get => _idCardCode; set { Set(() => IdCardCode, ref _idCardCode, value); } }
        public SexTypes? Sex { get => _sex; set { Set(() => Sex, ref _sex, value); } }
        public string MobileNumber { get => _mobileNumber; set { Set(() => MobileNumber, ref _mobileNumber, value); } }
        public string Email { get => _email; set { Set(() => Email, ref _email, value); } }
        public string Address { get => _address; set { Set(() => Address, ref _address, value); } }
        public DateTime? BirthDay { get => _birthDay; set { Set(() => BirthDay, ref _birthDay, value); } }
        public BitmapImage Image { get => _image; set { Set(() => Image, ref _image, value); } }
        public EducationLevels? Education { get => _education; set { Set(() => Education,ref _education, value); } }
        public ServeStates? ServeState { get => _serveState; set { Set(() => ServeState, ref _serveState, value); } }
        public string UserId { get => _userId; set { Set(() => UserId, ref _userId, value); } }
        public string PassWord { get => _passWord; set { Set(() => PassWord, ref _passWord, value); } }
        public bool IsVirtual { get => _isVirtual; set { Set(() => IsVirtual, ref _isVirtual, value); } }
        public DepartmentVM Department{ get => _department; set { Set(() => Department, ref _department, value); } }
        public ObservableCollection<ServingRecordVM> ServingRecords { get => _servingRecords;  }
        public string Nationality { get => _nationality; set { Set(() => Nationality, ref _nationality, value); } }

        public ObservableCollection<string> UserRoleIds { get => _userRoleIds; }
        public ObservableCollection<string> PermissionIds { get => _permissionIds; }

        public override EmployeeVM DeepClone()
        {
            var dto = EmployeeConvertUtil.ToDto(this);
            var vm = EmployeeConvertUtil.FromDto(dto);
            base.CopyStateValues(vm);
            return vm;
        }
    }
}