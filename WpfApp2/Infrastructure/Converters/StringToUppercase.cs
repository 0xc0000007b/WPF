using System;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using WpfApp2.Infrastructure.Converters;

namespace WpfApp2.Infrastructure.Common;

public class StringToUppercase :  Converter
{
    
    public string Str { get; set; }
    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)=> value != null ? value.ToString().ToUpper() : null;
    
}