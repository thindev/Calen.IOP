using Calen.IOP.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class BirthdayTypeToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is BirthdayTypes)) return "";
            string re= "未知";
            BirthdayTypes type = (BirthdayTypes)value;
            switch(type)
            {
                case BirthdayTypes.SolarCalendar:
                    re = "公历生日";
                    break;
                case BirthdayTypes.LunarCalendar:
                    re = "农历生日";
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
