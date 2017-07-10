using Calen.IOP.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class VipCardStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is VipCardStates)) return "";
            string re= "未知";
            VipCardStates type = (VipCardStates)value;
            switch(type)
            {
                case VipCardStates.Available:
                    re = "在售";
                    break;
                case VipCardStates.ComingSoon:
                    re = "即将发售";
                    break;
                case VipCardStates.Obsolete:
                    re = "停售";
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
