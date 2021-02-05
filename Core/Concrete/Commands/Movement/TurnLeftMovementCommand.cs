using ToyRobot.Core.Abstract.Robot;
using ToyRobot.Core.Concrete.Commands.Base;

namespace ToyRobot.Core.Concrete.Commands.Movement
{
    public class TurnLeftMovementCommand : MovementCommand
    {
        public TurnLeftMovementCommand()
        {

        }

        /// <summary>
        /// Robot! Could you please turn to left?
        /// </summary>
        /// <returns></returns>
        public override bool Invoke(IRobot Robot)
        {
            Robot.Position.CurrentDirection = Turn(() => degLeft, Robot.Position.CurrentDirection);

            return true;
        }
    }
}
