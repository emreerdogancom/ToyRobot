using ToyRobot.Core.Enum;
using ToyRobot.Core.Abstract.Robot;
using ToyRobot.Core.Concrete.Commands.Base;

namespace ToyRobot.Core.Concrete.Commands.Movement
{
    public class ForwardMovementCommand : MovementCommand
    {
        public ForwardMovementCommand()
        {

        }

        /// <summary>
        /// Go forward mate
        /// </summary>
        /// <returns>True/False</returns>
        public override bool Invoke(IRobot Robot)
        {
            int X = Robot.Position.CurrentX;
            int Y = Robot.Position.CurrentY;

            /* 
             * !!!
             * I could not find more efficient logic here but I will continue to think on it
             * (((int)Robot.Position.CurrentDirection / deg) % 2 == 0)
             */

            /* Go for Apsis */
            if (Robot.Position.CurrentDirection == RobotDirection.East) X += 1;
            if (Robot.Position.CurrentDirection == RobotDirection.West) X -= 1;

            /* Go for Ordinat */
            if (Robot.Position.CurrentDirection == RobotDirection.North) Y += 1;
            if (Robot.Position.CurrentDirection == RobotDirection.South) Y -= 1;


            /* 
             * Only if next position is available 
             */
            if (!Robot.Board.IsValidPosition(X, Y))
                return false;

            /* Everything looks good. Set new position */
            Robot.Position.CurrentX = X;
            Robot.Position.CurrentY = Y;

            return true;
        }
    }
}
