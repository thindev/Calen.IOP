using Calen.IOP.DTO;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Calen.IOP.Client.Desktop.Converters
{
    public class EducationLevelToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string re= "未知";
            EducationLevels type = (EducationLevels)value;
            switch(type)
            {
                case EducationLevels.DoctorLevel:
                    re = "博";
                    break;
                case EducationLevels.JuniorCollege:
                    re = "专";
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
