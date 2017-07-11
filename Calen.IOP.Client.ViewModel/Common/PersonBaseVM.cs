using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel.Common
{
    public abstract class PersonBaseVM<T>:EntityVMBase<T>
    {
        private string _idCardCode;
        private SexTypes _sex;
        private string _mobileNumber;
        private string _email;
        private string _address;
        private DateTime? _birthday;
        private BirthdayTypes? _birthdayType;
        private EducationLevels? _education;
        private string _userId;
        private string _passWord;
        private string _nationality;
        private string _weChat;
        private string _QQ;
        private string _pictureUrl;


        private ObservableCollection<string> _userRoleIds = new ObservableCollection<string>();
        private ObservableCollection<string> _permissionIds = new ObservableCollection<string>();
        public string IdCardCode { get => _idCardCode; set { Set(() => IdCardCode, ref _idCardCode, value); } }
        public SexTypes Sex { get => _sex; set { Set(() => Sex, ref _sex, value); } }
        public string MobileNumber { get => _mobileNumber; set { Set(() => MobileNumber, ref _mobileNumber, value); } }
        public string Email { get => _email; set { Set(() => Email, ref _email, value); } }
        public string Address { get => _address; set { Set(() => Address, ref _address, value); } }
        public DateTime? Birthday { get => _birthday; set { Set(() => Birthday, ref _birthday, value); } }
        public EducationLevels? Education { get => _education; set { Set(() => Education, ref _education, value); } }
        public string UserId { get => _userId; set { Set(() => UserId, ref _userId, value); } }
        public string PassWord { get => _passWord; set { Set(() => PassWord, ref _passWord, value); } }
        public string Nationality { get => _nationality; set { Set(() => Nationality, ref _nationality, value); } }
        public ObservableCollection<string> UserRoleIds { get => _userRoleIds; }
        public ObservableCollection<string> PermissionIds { get => _permissionIds; }
        public BirthdayTypes? BirthdayType { get => _birthdayType; set { Set(() => BirthdayType, ref _birthdayType, value); } }

        public string WeChat { get => _weChat; set { Set(() => WeChat, ref _weChat, value); } }
        public string QQ { get => _QQ; set { Set(() => QQ, ref _QQ, value); } }
        public string PictureUrl { get => _pictureUrl; set { Set(()=>PictureUrl,ref _pictureUrl,value); } }
    }
}
