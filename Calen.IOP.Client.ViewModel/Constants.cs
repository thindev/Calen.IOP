using System;
using System.Collections.Generic;
using System.Text;

namespace Calen.IOP.Client.ViewModel
{
    public static class Constants
    {
#if WINDOWS_WPF
        public const string MAIN_DIALOG = "MainDialog";
        public static string MainDialog { get { return MAIN_DIALOG; } }
#endif
    }
}
