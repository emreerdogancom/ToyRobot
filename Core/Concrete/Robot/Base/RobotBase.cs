using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Abstract.Command;
using ToyRobot.Core.Abstract.Robot;
using ToyRobot.Core.Enum;

namespace ToyRobot.Core.Concrete.Robot.Base
{
    public abstract class RobotBase : IRobot
    {
        public RobotBase(IBoard Board)
        {
            this.Board = Board;
        }

        public IBoard Board { get; }
        public RobotPosition Position { get; set; } = null;


        /// <summary>
        /// Put the robot to board (Base Validation)
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="direction"></param>
        protected bool Place(int x, int y, RobotDirection direction)
        {
            if (Board == null)
                return false;

            if (x < 0 || y < 0)
                return false;

            if (!Board.IsValidPosition(x, y))
                return false;


            Position ??= new RobotPosition(x, y, direction);
            return true;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public abstract bool PlaceParser(string input);


        /// <summary>
        /// Execute external command classes. It should inherited from IMovementCommand (Base Validation)
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public virtual bool ExecuteMovementCommand(IMovementCommand command)
        {
            return HasPosition();
        }


        /// <summary>
        /// Robot should have actual position
        /// </summary>
        /// <returns>Result of position validation</returns>
        public bool HasPosition()
        {
            if (Position == null)
                return false;

            if (Position.CurrentX < 0 || Position.CurrentY < 0)
                return false;

            return true;
        }
    }
}
