using ToyRobot.Core.Enum;

namespace ToyRobot.Core.Concrete.Robot
{
    public class RobotPosition
    {
        public int CurrentX { get; set; }
        public int CurrentY { get; set; }
        public RobotDirection CurrentDirection { get; set; }

        /// <summary>
        /// Set actual position for robot
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        /// <param name="direction"></param>
        public RobotPosition(int X, int Y, RobotDirection direction)
        {
            CurrentX = X;
            CurrentY = Y;
            CurrentDirection = direction;
        }
    }

}
