using Guestroom.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Guestroom.Converters
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            /*if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");*/

            try
            {
                string convertedUrl= null;
                Image img = new Image();
                //BitmapImage img = new BitmapImage();
                //img.BeginInit();

                if (value != null)
                {
                    var url = (List<ImageURL>)value;
                    if (url.ToArray().Length > 0)
                    {
                        convertedUrl = url.ToArray()[0].URL;
                        //img.UriSource = new Uri(url.ToArray()[0].URL);
                    }
                    else
                    {
                        convertedUrl = "http://www.visituganda.com/uploads/noimage.png";
                        //img.UriSource = new Uri("http://www.visituganda.com/uploads/noimage.png");
                    }
                }
                //img.EndInit();
                //return img;
                return convertedUrl;
            }
            catch
            {
                return null;
                //return DependencyProperty.UnsetValue;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}