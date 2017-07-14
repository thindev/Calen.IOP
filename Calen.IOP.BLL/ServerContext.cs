using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL
{
    public class ServerContext
    {
        static ServerContext _current;
        static ServerContext()
        {
            _current = new ServerContext();
        }

        public static ServerContext Current { get => _current;}
    }
}
