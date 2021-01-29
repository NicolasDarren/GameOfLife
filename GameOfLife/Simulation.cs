using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Simulation
    {
        private List<SquareCell> _cells = new List<SquareCell>();

        public SquareCell GetCell(int x, int y)
        {
            return _cells.FirstOrDefault(cell => cell.X == x && cell.Y == y);
        }

        public SquareCell AddCell(int x, int y, bool isAlive = true)
        {
            var squareCell = new SquareCell(isAlive, x, y);
            _cells.Add(squareCell);
            return squareCell;
        }

        public void Seed(int x, int y)
        {
            const int radius = 5;
            var random = new Random();

            for (int i = x-radius; i < x+radius; i++)
            {
                for (int j = y-radius; j < y+radius; j++)
                {
                    _cells.Add(new SquareCell((random.Next(0, 100) % 2 == 0), i, j));
                }
            }
        }

        public IEnumerable<SquareCell> GetCells(int x1, int y1, int x2, int y2)
        {
            return _cells.Where(cell => cell.X >= x1 && cell.X < x2 &&
                                        cell.Y >= y1 && cell.Y < y2);
        }

        public void Tick()
        {
            foreach (var pair in _cells.ToArray().Select(c =>
                new
                {
                    cell = c,
                    livingNeighbors = GetCells(c.X - 1, c.Y - 1, c.X + 1, c.Y + 1)
                        .Count(n => n.X != c.X && n.Y != c.Y && n.IsAlive())
                }))
            {
                pair.cell.Tick(pair.livingNeighbors);
            }
        }
    }
}
