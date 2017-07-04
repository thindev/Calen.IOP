using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public static class Constants
    {
#if WINDOWS_WPF
        public const string MAIN_DIALOG = "MainDialog";
        private static ObservableCollection<string> _nationalitys=new ObservableCollection<string>()
        {"汉","壮","其它"
        };

        public static string MainDialog { get { return MAIN_DIALOG; } }
        public static ObservableCollection<string> Nationalitys { get { return _nationalitys; } }
#endif
    }
}
