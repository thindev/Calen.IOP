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
            _restDataPortal = new RestDataPortal(@"http://localhost:6917/api/");
        }
        public static AppCxt Current
        {
            get { return _current; }
        }

        public RestDataPortal RestDataPortal { get => _restDataPortal;}

        RestDataPortal _restDataPortal;
    }
}
