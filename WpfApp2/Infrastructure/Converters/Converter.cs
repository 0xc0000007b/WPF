using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp2.Infrastructure.Converters;


public abstract class Converter : IValueConverter
{
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException("Not supported");
    
}