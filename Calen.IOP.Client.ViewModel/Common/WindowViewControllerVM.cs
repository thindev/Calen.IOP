#if WINDOWS_WPF
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public class WindowViewControllerVM:ViewModelBase
    {
        bool _isOptionsSettingVisible;

        public bool IsOptionsSettingVisible { get => _isOptionsSettingVisible; set { Set(() => IsOptionsSettingVisible, ref _isOptionsSettingVisible, value); } }
    }
}
#endif