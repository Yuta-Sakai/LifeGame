using System;
using System.Collections.Generic;


namespace LifeGame.Model
{
    public class Point
    {
        private Settings settings;

        private int row;
        private int column;
        private int maxRow;
        private int maxColumn;

        public Point(int column, int row)
        {
            this.settings = Settings.GetInstance();

            this.maxRow = settings.MaxRow();
            this.maxColumn = settings.MaxColumun();

            Func<int, int, int> validate = (value, max) =>
            {
                int validated = value;

                if (value < 0 )
                {
                    validated = max + value;
                }

                if(value >= max)
                {
                    validated = value - max;
                }

                return validated;
            };


            this.row = validate(row, this.maxRow);
            this.column = validate(column, this.maxColumn);
        }

        public int Row => this.row;

        public int Column => this.column;
       
        public bool Equals(Point point)
        {
            return point.Column == this.column && point.Row == this.row;
        }




        private Point Offset(int column, int row)
        {
            var offsetColumn = this.column + column;
            var offsetRow = this.row + row;

            return new Point(offsetColumn, offsetRow);
        }



        public List<Point> GetNeighborhood()
        {
            var list = new List<Point>();

            Action<int, int> addlist = 
                                (column, row) => list.Add(this.Offset(column, row));


            for(var c = -1; c <= 1; c++)
            {
                for(var r = -1; r <= 1; r++)
                {
                    if(!(c == 0 && r == 0))
                    {
                        addlist(c, r);
                    }
                }
            }

            return list;
        }
    }
}
