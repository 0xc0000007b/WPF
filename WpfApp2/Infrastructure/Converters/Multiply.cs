using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace WpfApp2.Infrastructure.Converters;

public class Multiply : Converter
{
    [ConstructorArgument("Coeff")]
    public double Coeff { get; set; } = 1;

    public Multiply()
    {
        
    }

    public Multiply(double coeff) => this.Coeff = Coeff;
    
    public override object Convert(object value, Type t, object p, CultureInfo c)
    {
        if (value is null) return null;
        var x = System.Convert.ToDouble(value,c);
        return x * Coeff;
    }

    public override object ConvertBack(object value, Type t, object p, CultureInfo c)
    {
        if (value is null) return null;
        var x = System.Convert.ToDouble(value,c);
        return x / Coeff;
    }
}