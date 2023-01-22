using System;
using System.Globalization;
using System.Windows.Data;

namespace WpfApp2.Infrastructure.Converters;

public class ToArray : MultiConverter
{
    public override object Convert(object[] v, Type t, object p, CultureInfo c)
    {
        var returnColl = new CompositeCollection();
        foreach (var val in v)
            returnColl.Add(val);
        
        return returnColl;
    }

    // public override object[] ConvertBack(object v, Type[] t, object p, CultureInfo c) => v as object[]
}