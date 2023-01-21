using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace WpfApp2.Models;

public class Country : PlaceInfo
{
        private Point? _location;

        public override Point Location
        {
                get
                {
                        if (_location != null)
                                return (Point)_location;

                        if (Province is null) return default;

                        var averageX = Province.Average(p => p.Location.X);
                        var averageY = Province.Average(p => p.Location.Y);

                        return (Point)(_location = new Point((int)averageX, (int)averageY));
                }
                set => _location = value;
        }
        public IEnumerable<PlaceInfo> Province { get; set; }

}