using KamersInVlaanderen;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GuestRoomWPF.Converter
{
    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");
            
            try
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
           
                if (value != null)
                {
                    var url = (List<ImageURL>)value;
                    if(url.ToArray().Length > 0)
                    {
                        img.UriSource = new Uri(url.ToArray()[0].URL);
                    }
                    else
                    {
                        img.UriSource = new Uri("http://www.visituganda.com/uploads/noimage.png");
                    }
                }
                img.EndInit();
                return img;
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
