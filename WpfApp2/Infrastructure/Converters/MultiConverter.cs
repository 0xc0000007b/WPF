using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp2.Infrastructure.Converters;

public abstract  class MultiConverter : IMultiValueConverter
{
    public abstract object Convert(object[] v, Type t, object p, CultureInfo c);

    public virtual object[] ConvertBack(object v, Type[] t, object p, CultureInfo c)
    {
        throw new NotSupportedException();
    }
}