using System;
using System.Linq;
using System.Collections.Generic;

namespace LifeGame.Model
{
    public class Cells
    {
        private List<Cell> cells = new List<Cell>();
        private const int Max_Column = 9;
        private const int Max_Row = 9;

        public Cells()
        {
            this.Make();
        }


        public int MaxColumn => Max_Column;

        public int MaxRow => Max_Row; 


        private void Make()
        {
            for(var column = 0; column <= Max_Column; column++)
            {
                for(var row = 0; row <= Max_Row; row++)
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
            foreach(Cell cell in this.cells)
            {
                var neighbor = cell.Point.GetNeighborhood();
                var alives = 
                        this.cells.Where(c => neighbor.Contains(c.Point) && c.IsAlive).Count();

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
