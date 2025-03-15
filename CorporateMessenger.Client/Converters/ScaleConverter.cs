using System.Globalization;
using System.Windows.Data;

namespace CorporateMessenger.Client.Converters
{
    public class ScaleConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is double actualWidth && double.TryParse(parameter?.ToString(), out double scale))
            {
                double fontSize = actualWidth * scale;

                // Ограничиваем максимальный размер шрифта до 24px
                return Math.Clamp(fontSize, 10, 24); // Минимум 10px, максимум 24px
            }
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
