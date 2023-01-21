using System;
using System.Collections.Generic;

namespace WpfApp2.Models;

public class Country : PlaceInfo
{
        public IEnumerable<PlaceInfo> Province { get; set; }

}