using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Text;
#if WINDOWS_WPF
using System.Windows;
using System.Windows.Media;
#endif

namespace Calen.IOP.Client.ViewModel
{
    public class OptionsSettingVM:ViewModelBase
    {
#if WINDOWS_WPF
        private ScaleTransform _scaleTransform = new ScaleTransform();
        public ScaleTransform ScaleTransform { get => _scaleTransform; set => _scaleTransform = value; }
#endif
    }
}
