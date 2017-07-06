using Calen.IOP.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class ServeStateToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string re= "未知";
            ServeStates type = (ServeStates)value;
            switch(type)
            {
                case ServeStates.InServe:
                    re = "在";
                    break;
                case ServeStates.Onleave:
                    re = "休假";
                    break;
                case ServeStates.ProbationaryPeriod:
                    re = "试用";
                    break;
                case ServeStates.Resignation:
                    re = "离";
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
