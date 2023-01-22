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

        private IEnumerable<ConfirmrdCounts> _counts;

        public override IEnumerable<ConfirmrdCounts> Count
        {
                get
                {
                        if (_counts != null) return _counts;
                        var pointsCount = Province.FirstOrDefault()?.Count?.Count() ?? 0;
                        if (pointsCount == 0) return Enumerable.Empty<ConfirmrdCounts>();
                        var points = new ConfirmrdCounts[pointsCount];
                        var provincePoints = Province.Select(p => p.Count.ToArray()).ToArray();
                        
                        foreach (var province in provincePoints)
                                for (var i = 0; i < pointsCount; i++)
                                {
                                        if (points[i].Date == default) points[i] = province[i];
                                        else points[i].Count += province[i].Count;
                                }

                        return _counts = points;

                }
                
                set => _counts = (ConfirmrdCounts[])value;
        }
}