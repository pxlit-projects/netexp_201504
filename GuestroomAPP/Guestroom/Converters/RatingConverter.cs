using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Guestroom.Converters
{
    public class RatingConverter : IValueConverter
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
                return null;//return DependencyProperty.UnsetValue; TODO
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
