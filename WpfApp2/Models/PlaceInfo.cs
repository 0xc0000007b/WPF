using System;
using System.Windows;

namespace WpfApp2.Models;

public class PlaceInfo
{
    public string Name { get; set; }
    public Point Location { get; set; }
    public IEquatable<ConfirmedCount> Count { get; set; }
   
}

public class Country : PlaceInfo
{
    public IEquatable<ProvinceInfo> Province { get; set; }

}
public class ProvinceInfo : PlaceInfo
{
}

public struct ConfirmedCount
{
    public DateTime Date { get; set; }
    public int Count { get; set; }
}

public struct DataPoints
{
    public double XValue { get; set; }
    public double YValue { get; set; }
}

