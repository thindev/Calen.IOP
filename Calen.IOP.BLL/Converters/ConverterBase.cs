using Calen.IOP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
    class ConverterBase
    {
        protected IOPContext DbContext;
        public ConverterBase(IOPContext ctx)
        {
            DbContext = ctx;
        }
    }
}
