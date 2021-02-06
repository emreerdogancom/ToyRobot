using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Abstract.Command;
using ToyRobot.Core.Concrete.Robot;
using ToyRobot.Core.Enum;

namespace ToyRobot.Core.Abstract.Robot
{
    public interface IRobot
    {
        /// <summary>
        /// Board for robot
        /// new Board(5x5) or new Board(10x10)
        /// </summary>
        IBoard Board { get; }

        /// <summary>
        /// Position of robot
        /// </summary>
        RobotPosition Position { get; set; }

        /// <summary>
        /// Put the robot to board (Don't need to set public anymore)
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="direction"></param>
        //bool Place(int x, int y, RobotDirection direction);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        bool PlaceParser(string input);

        /// <summary>
        /// Execute command for movement
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        bool ExecuteMovementCommand(IMovementCommand command);

        /// <summary>
        /// Robot has actual position
        /// </summary>
        /// <returns></returns>
        bool HasPosition();
    }
}
