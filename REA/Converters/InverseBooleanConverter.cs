using System.Globalization;

namespace REA.Converters {
    public class InverseBooleanConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            if (value is bool booleanValue) {
                return !booleanValue; // Return the inverse of value
            }

            return value; // If the value is not a boolean, just return the original value
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
