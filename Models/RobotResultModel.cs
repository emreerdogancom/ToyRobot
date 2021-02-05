using ToyRobot.Core.Enum;

namespace ToyRobot.Models
{

    public class RobotResultModel
    {
        /*
         * !!!
         * Missing Part
         * Status (ok, nok, invalid command ETC.)
         * Message (input cannot be empty, Wrong Command ETC.)
         */

        public int X { get; }
        public int Y { get; }
        public RobotDirection Direction { get; }
        public string DirectionText { get; }

        public RobotResultModel(int x, int y, RobotDirection direction)
        {
            X = x;
            Y = y;
            Direction = direction;
            DirectionText = direction.ToString();
        }
    }
}
