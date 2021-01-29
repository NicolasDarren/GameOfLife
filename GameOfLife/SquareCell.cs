namespace GameOfLife
{
    public class SquareCell
    {
        private bool _isAlive;
        public int X { get; }
        public int Y { get; }

        public SquareCell(bool isAlive = false, int x = 0, int y = 0)
        {
            _isAlive = isAlive;
            X = x;
            Y = y;
        }

        public void Tick(int numberOfLivingNeighbors)
        {
            if (IsAlive())
            {
                if (numberOfLivingNeighbors < 2)
                    _isAlive = false;

                if (numberOfLivingNeighbors > 3)
                    _isAlive = false;
            }
            else
            {
                if (numberOfLivingNeighbors == 3)
                    _isAlive = true;
            }
        }

        public bool IsAlive()
        {
            return _isAlive;
        }
    }
}
