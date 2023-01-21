using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp2.Infrastructure.Converters;

    [ValueConversion(typeof(Point), typeof(string))]
public class LocationPointToStr : Converter
{
    public override object  Convert(object value, Type t, object p, CultureInfo c)
    {

        if (!(value is Point point)) return null;

        return $"Lat: {point.X}; Long: {point.Y}";
    }

    public override object ConvertBack(object value, Type t, object p, CultureInfo c)
    {
        var str = value as string;
        if (str is null) return null;
        var splitedStr = str.Split(';');
        var latStr = splitedStr[0].Split(';')[1];
        var longStr = splitedStr[1].Split(';')[1];
        var lat = double.Parse(latStr);
        var lng = double.Parse(longStr);
        return new Point((int)lat, (int)lng);
    }
}