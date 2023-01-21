using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp2.Infrastructure.Converters;

public class CompositeConverter : Converter
{

    public IValueConverter First { get; set; }
    public IValueConverter Second { get; set; }

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var firstRes = First?.Convert(value, targetType, parameter, culture) ?? value;
        var secondRes = First?.Convert(firstRes, targetType, parameter, culture) ?? firstRes;

        return secondRes;
    }

    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var secondBackRes = Second?.ConvertBack(value, targetType, parameter, culture) ?? value;
        var firstBackRes = First?.ConvertBack(secondBackRes, targetType, parameter, culture) ?? secondBackRes;
        return firstBackRes;
    }
}