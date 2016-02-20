using System;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace GuestRoomWPF.Converter
{
    class ImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            if (targetType != typeof(ImageSource))
                throw new InvalidOperationException("Target type must be System.Windows.Media.ImageSource.");


            try
            {
                BitmapImage img = new BitmapImage();
                img.BeginInit();
           
                //img.UriSource = new Uri("/JoeCoffeeStore.StockManagement.App;component/Images/coffee" + value + ".jpg", UriKind.Relative);
                img.UriSource = new Uri("http://images.visitflanders.org/original/2723261/e26389f6-8b74-4aaa-877b-b3c056e5571c.jpg");
                img.EndInit();
                return img;
            }
            catch (Exception ex)
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
