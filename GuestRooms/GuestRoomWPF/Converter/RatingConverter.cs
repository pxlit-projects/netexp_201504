using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace GuestRoomWPF.Converter
{
    class RatingConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            /*if (targetType != typeof(Double))
                throw new InvalidOperationException("Target type must be string.");*/

            try
            {
                if (value != null)
                {
                    double num = (double)value;
                    if (num >= 0)
                    {
                        return num.ToString("0.00");
                    }
                }
                return "NA";
            }
            catch
            {
                return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
