using Calen.IOP.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calen.IOP.BLL.Converters
{
    abstract class ConverterBase<T,DtoT>
    {
        protected IOPContext DbContext;
        public ConverterBase(IOPContext ctx)
        {
            DbContext = ctx;
        }

        public abstract DtoT ToDto(T model);
        public abstract T FromDto(DtoT dto);
        
    }
}
