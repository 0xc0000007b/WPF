using System;
using System.Collections.Generic;
using System.Windows;
using Point = System.Drawing.Point;

namespace WpfApp2.Models;

public class PlaceInfo
{
    public string Name { get; set; }
    public virtual Point Location { get; set; }
    public IEnumerable<ConfirmrdCounts> Count { get; set; }
   
}






