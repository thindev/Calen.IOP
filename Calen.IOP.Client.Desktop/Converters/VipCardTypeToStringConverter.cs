using Calen.IOP.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class VipCardTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is VipCardTypes)) return "";
            string re= "未知";
            VipCardTypes type = (VipCardTypes)value;
            switch(type)
            {
                case VipCardTypes.ValidateByDays:
                    re = "时限卡";
                    break;
                case VipCardTypes.ValidateByTimes:
                    re = "频资卡";
                    break;
                default:
                    re = "未知";
                    break;
            }
            return re;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
