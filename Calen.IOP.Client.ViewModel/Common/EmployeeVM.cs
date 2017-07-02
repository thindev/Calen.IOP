using Calen.IOP.Client.ViewModel.Common;
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
        private bool _isVirtual;
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

        public override EmployeeVM DeepClone()
        {
            throw new NotImplementedException();
        }
    }
}