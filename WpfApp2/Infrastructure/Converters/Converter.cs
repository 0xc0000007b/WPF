using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp2.Infrastructure.Converters;
[MarkupExtensionReturnType]

public abstract class Converter :  MarkupExtension, IValueConverter
{
    public override object ProvideValue(IServiceProvider sp) => this;
    public abstract object Convert(object value, Type targetType, object parameter, CultureInfo culture);

    public virtual object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotSupportedException("Not supported");
    
}