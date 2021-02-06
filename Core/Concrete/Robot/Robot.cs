using System;
using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Abstract.Command;
using ToyRobot.Core.Concrete.Robot.Base;
using ToyRobot.Core.Enum;

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


        public override bool PlaceParser(string input)
        {
            String[] Params = input?.Split(new string[] { " ", "," }, StringSplitOptions.None);

            if (Helpers.Validation.IsEnumerable<RobotCommand>(Params[0]) == null)
                return false;

            if (Helpers.Validation.IsEnumerable<RobotCommand>(Params[0]) != RobotCommand.Place)
                return false;

            if (Helpers.Validation.IsNumeric(Params[1]) == null)
                return false;

            if (Helpers.Validation.IsNumeric(Params[2]) == null)
                return false;

            if (Helpers.Validation.IsEnumerable<RobotDirection>(Params[3]) == null)
                return false;

            Place(
                    Convert.ToInt32(Params[1]),
                    Convert.ToInt32(Params[2]),
                    (RobotDirection)Helpers.Validation.IsEnumerable<RobotDirection>(Params[3])
                 );

            return true;
        }
    }
}
