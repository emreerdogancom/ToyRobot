using ToyRobot.Core.Abstract.Board;

namespace ToyRobot.Core.Concrete.Board
{
    public class Board : IBoard
    {
        public int Width { get; }
        public int Height { get; }


        public Board(int width, int height)
        {
            Width = width;
            Height = height;
        }

        /// <summary>
        /// Place or Next Movement is valid on the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public bool IsValidPosition(int x, int y)
        {
            return (x < Width && y < Height) && (x > -1 && y > -1);
        }
    }
}
