using System;
using System.Linq;
using System.Windows.Markup;

namespace WpfApp2.Infrastructure.Common;

public class StringToIntArray : MarkupExtension
{
    [ConstructorArgument("Str")]
    public string Str { get; set; }

    public StringToIntArray()
    {
        
    }

    public StringToIntArray(string str) => this.Str = str;

    public override object ProvideValue(IServiceProvider serviceProvider) =>
        Str.Split(new []{Sep}, StringSplitOptions.RemoveEmptyEntries)
            .DefaultIfEmpty()
            .Select(int.Parse)
            .ToArray();
    

    public char Sep { get; set; } = ';';
}