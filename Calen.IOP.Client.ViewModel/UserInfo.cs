using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calen.IOP.Client.ViewModel
{
    public class UserInfoVM:ViewModelBase
    {
        private EmployeeVM _detail;
        string _userId;
        string _password;
        DateTime _loginTime;
        string _promptContent;
        public UserInfoVM()
        {

        }
        void InitCommands()
        {
            LoginCommand = new RelayCommand(LoginExcute,LoginPredicate);
        }

        private bool LoginPredicate()
        {
            return ((!string.IsNullOrEmpty(this.UserId)) && (!string.IsNullOrEmpty(this.Password)));
        }

        private void LoginExcute()
        {
            
        }

        public ICommand LoginCommand { get; private set; }
        public EmployeeVM Detail { get => _detail; set { Set(() => Detail, ref _detail, value); } }

        public string UserId { get => _userId; set { Set(() => UserId, ref _userId, value); } }
        public string Password { get => _password; set { Set(() => Password, ref _password, value); } }
        public DateTime LoginTime { get => _loginTime; set { Set(() => LoginTime, ref _loginTime, value); } }

        public string PromptContent
        {
            get
            {
                return this._promptContent;
            }
            set
            {
                if (this._promptContent == value)
                {
                    return;
                }
                this._promptContent = value;
                base.RaisePropertyChanged(() => this.PromptContent);
                if (!string.IsNullOrEmpty(value))
                {
                    bool isPass = true;

                    var task = Task.Run(() =>
                    {
                        System.Threading.Thread.Sleep(3000);
                        if (isPass)
                        {
                            this.PromptContent = null;
                        }
                    });
                }
            }
        }

        private string MD5Encrypt(string input, Encoding encode)
        {
            if (string.IsNullOrEmpty(input))
            {
                return "";
            }
            System.Security.Cryptography.MD5 md5 = new MD5CryptoServiceProvider();

            byte[] t = md5.ComputeHash(encode.GetBytes(input));

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < t.Length; i++)

                sb.Append(t[i].ToString("x").PadLeft(2, '0'));

            return sb.ToString();

        }
    }
}
