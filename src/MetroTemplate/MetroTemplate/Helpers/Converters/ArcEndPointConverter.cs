using Avalonia;
using Avalonia.Data;
using Avalonia.Data.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetroTemplate
{
    public class ArcEndPointConverter : IMultiValueConverter
    {
        public const string ParameterMidPoint = "MidPoint";

        public object Convert(IList<object> values, Type targetType, object parameter, CultureInfo culture)
        {
            var actualWidth = values[0].ExtractDouble();
            var value = values[1].ExtractDouble();
            var minimum = values[2].ExtractDouble();
            var maximum = values[3].ExtractDouble();

            if (new[] { actualWidth, value, minimum, maximum }.AnyNan())
                return null;

            if (values.Count == 5)
            {
                var fullIndeterminateScaling = values[4].ExtractDouble();
                if (!double.IsNaN(fullIndeterminateScaling) && fullIndeterminateScaling > 0.0)
                {
                    value = (maximum - minimum) * fullIndeterminateScaling;
                }
            }

            var percent = maximum <= minimum ? 1.0 : (value - minimum) / (maximum - minimum);
            if (Equals(parameter, ParameterMidPoint))
                percent /= 2;

            var degrees = 360 * percent;
            var radians = degrees * (Math.PI / 180);

            var centre = new Point(actualWidth / 2, actualWidth / 2);
            var hypotenuseRadius = (actualWidth / 2);

            var adjacent = Math.Cos(radians) * hypotenuseRadius;
            var opposite = Math.Sin(radians) * hypotenuseRadius;

            return new Point(centre.X + opposite, centre.Y - adjacent);
        }


        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    internal static class LocalEx
    {
        public static double ExtractDouble(this object value)
        {
            var d = value as double? ?? double.NaN;
            return double.IsInfinity(d) ? double.NaN : d;
        }


        public static bool AnyNan(this IEnumerable<double> values)
        {
            return values.Any(double.IsNaN);
        }
    }
}
