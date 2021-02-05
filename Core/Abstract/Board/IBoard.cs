namespace ToyRobot.Core.Abstract.Board
{
    /// <summary>
    /// Board Interface
    /// </summary>
    public interface IBoard
    {
        int Width { get; }
        int Height { get; }

        /// <summary>
        /// Place or Next Movement is valid on the board
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        bool IsValidPosition(int x, int y);
    }
}
