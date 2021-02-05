using ToyRobot.Core.Abstract.Robot;
using ToyRobot.Core.Concrete.Commands.Base;

namespace ToyRobot.Core.Concrete.Commands.Movement
{
    public class TurnRightMovementCommand : MovementCommand
    {
        public TurnRightMovementCommand()
        {

        }

        /// <summary>
        /// Robot! Could you please turn to right?
        /// </summary>
        /// <returns></returns>
        public override bool Invoke(IRobot Robot)
        {
            Robot.Position.CurrentDirection = Turn(() => degRight, Robot.Position.CurrentDirection);

            return true;
        }
    }
}
