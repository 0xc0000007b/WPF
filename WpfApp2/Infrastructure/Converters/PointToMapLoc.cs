using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using MapControl;

namespace WpfApp2.Infrastructure.Converters;
[MarkupExtensionReturnType(typeof(PointToMapLoc))]
[ValueConversion(typeof(Point), typeof(Location))]
public class PointToMapLoc : Converter
{
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is Point p)) return null;
        return new Location(p.X, p.Y);
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (!(value is Location l)) return null;
        return new Point((int)l.Latitude, (int)l.Longitude);
    }
}