using System;
using System.Globalization;
using Xamarin.Forms;

namespace xam.course.example1.Converters
{
    public class SelectedRadioButtonItemConverter  : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var stringValue = (string)value;
            var parameterValue = (string)parameter;

            return stringValue == parameterValue ? Color.Purple : Color.LightGray;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}