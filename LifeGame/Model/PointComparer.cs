using System;
using System.Collections.Generic;


namespace LifeGame.Model
{
    public class PointComparer : IEqualityComparer<Point>
    {

        public bool Equals(Point p1, Point p2)
        {
            return p1.Column == p2.Column && p1.Row == p2.Row;
        }


        public int GetHashCode(Point point)
        {
            return (point.Column ^ point.Row).GetHashCode();
        }

    }
}
