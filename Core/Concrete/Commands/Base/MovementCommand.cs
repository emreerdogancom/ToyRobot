using System;
using ToyRobot.Core.Abstract.Command;
using ToyRobot.Core.Enum;
using ToyRobot.Core.Abstract.Robot;

namespace ToyRobot.Core.Concrete.Commands.Base
{
    public abstract class MovementCommand : IMovementCommand
    {

        /// <summary>
        /// Degree for Turn Right(-90) and Left(90)
        /// </summary>
        protected const int deg = 90;
        protected const int degRight = -deg;
        protected const int degLeft = deg;


        public MovementCommand()
        {

        }

        public abstract bool Invoke(IRobot Robot);

        /// <summary>
        /// Base method for turning arround
        /// </summary>
        /// <param name="degree"></param>
        /// <returns></returns>
        protected RobotDirection Turn(Func<int> degree, RobotDirection CurrentDirection)
        {
            int i = 0;
            i = (int)CurrentDirection;
            i += degree();
            i = ((i %= 360) <= 0) ? i + 360 : i;

            return (RobotDirection)i;
        }
    }
}
