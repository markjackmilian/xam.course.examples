using System;
using System.Globalization;
using Xamarin.Forms;

namespace Course.RealTime.Converters
{
    public class ConnectedToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolvalue = (bool)value;

            return boolvalue ? Color.Green : Color.Red;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}