using System;
using System.Collections.Generic;
using System.Windows;

namespace WpfApp2.Models;

public class PlaceInfo
{
    public string Name { get; set; }
    public Point Location { get; set; }
    public IEnumerable<ConfirmrdCounts> Count { get; set; }
   
}






