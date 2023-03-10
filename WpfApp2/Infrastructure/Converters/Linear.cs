using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp2.Infrastructure.Converters;

/// <summary>
/// Realize the Linear Covert
/// </summary>

[ValueConversion(typeof(double), typeof(double))] 
[MarkupExtensionReturnType(typeof(Linear))]
public class Linear : Converter
{
    [ConstructorArgument("K")]
    public double K { get; set; } = 1;
    [ConstructorArgument("B")]
    public double B { get; set; } = 0;

    public Linear()
    {
        
    }

    public Linear(double K) => this.K = K;


    public Linear(double K, double B) : this(K) => this.B = B;

    public override object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null) return null;
        var x = System.Convert.ToDouble(value, culture);
        return K * x + B;
    }
    public override object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is null) return null;
        var y = System.Convert.ToDouble(value, culture);
        return (y - B )/ K;
    }
}