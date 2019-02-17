using System;
using System.Linq;
using System.Collections.Generic;

namespace LifeGame.Model
{
    public class Cells
    {
        private List<Cell> cells = new List<Cell>();
        private int maxColumn;
        private int maxRow;


        public Cells()
        {
            var setting = Settings.GetInstance();
            this.maxColumn = setting.MaxColumun();
            this.maxRow = setting.MaxRow();

            this.Make();
        }


        public int MaxColumn()
        {
            return maxColumn;
        }


        public int MaxRow()
        {
            return this.maxRow;
        }


        private void Make()
        {
            for(var column = 0; column < maxColumn; column++)
            {
                for(var row = 0; row < maxRow; row++)
                {
                    var point = new Point(column, row);
                    cells.Add(new Cell(point));
                }

            }
        }



        public Cell GetCell(Point point)
        {
            return cells.Find(cell => cell.Point.Equals(point));
        }



        private void SetNextIsAliveOrDead()
        {
            var pointComparer = new PointComparer();

            foreach(Cell cell in this.cells)
            {
                var neighbor = cell.Point.GetNeighborhood();

                var alives = this.cells
                                .Where(c => neighbor.Contains(c.Point, pointComparer) && c.IsAlive).Count();

                cell.SetNextIsAliveOrDead(alives);
            }
        }



        public void Next()
        {
            this.SetNextIsAliveOrDead();
            this.cells.ForEach(cell => cell.Next());
        }

    }
}
