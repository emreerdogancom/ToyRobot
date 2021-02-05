using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Abstract.Command;
using ToyRobot.Core.Concrete.Robot.Base;

namespace ToyRobot.Core.Concrete.Robot
{
    public class Robot : RobotBase
    {

        public Robot(IBoard board) : base(board)
        {
          
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public override bool ExecuteMovementCommand(IMovementCommand command)
        {
            if (!base.ExecuteMovementCommand(command))
                return false;

            return command.Invoke(this);
        }
    }
}
