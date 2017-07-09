using Calen.IOP.Client.ViewModel.Common;
using Calen.IOP.DTO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class ServingRecordsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string re = "";
            IList<ServingRecordVM> list = (IList<ServingRecordVM>)value;
            if(list!=null)
            {
                re = string.Join(",",list.Select(p=>p.JobPosition.Name));
            }
            return re;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
