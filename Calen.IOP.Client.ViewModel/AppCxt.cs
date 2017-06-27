using Calen.IOP.DataPortal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.Client.ViewModel
{
    public class AppCxt
    {
        static AppCxt _current = new AppCxt();
        public AppCxt()
        {
            _dataPortal = new RestDataPortal(@"http://localhost:6917/api/");
            _optionsSettings = new OptionsSettingVM();
        }
        public static AppCxt Current
        {
            get { return _current; }
        }

        public IDataPortal DataPortal { get => _dataPortal;}
        public OptionsSettingVM OptionsSettings { get => _optionsSettings;}
       

        IDataPortal _dataPortal;

        OptionsSettingVM _optionsSettings;
#if WINDOWS_WPF
        WindowViewControllerVM _windowController = new WindowViewControllerVM();
        public WindowViewControllerVM WindowController { get => _windowController; }
#endif
    }
}
