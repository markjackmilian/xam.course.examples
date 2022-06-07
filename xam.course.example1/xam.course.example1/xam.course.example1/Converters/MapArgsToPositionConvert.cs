using System;
using System.Globalization;
using Xamarin.Forms;
using Xamarin.Forms.Maps;

namespace xam.course.example1.Converters
{
    public class MapArgsToPositionConvert  : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var args = (MapClickedEventArgs)value;
            return args.Position;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}