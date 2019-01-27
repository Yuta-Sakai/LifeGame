using System;
using System.Collections.Generic;


namespace LifeGame.Model
{
    public class Point
    {
        private int row;
        private int column;

        public Point(int column, int row)
        {
            this.row = row;
            this.column = column;
        }

        public int Row => this.row;

        public int Column => this.column;
       
        public bool Equals(Point point)
        {
            return point.Column == this.column && point.Row == this.row;
        }


        private Point GetOffset(int column, int row)
        {
            return new Point(this.column + column, this.row + row);
        }



        public List<Point> GetNeighborhood()
        {
            var list = new List<Point>();

            Action<int, int> addlist = 
                                (column, row) => list.Add(this.GetOffset(column, row));

            for(var c = -1; c <= 1; c++)
            {
                for(var r = -1; r <= 1; r++)
                {
                    addlist(c, r);
                }
            }

            return list;
        }
    }
}
