using ToyRobot.Core.Abstract.Board;
using ToyRobot.Core.Abstract.Robot;
using ToyRobot.Core.Concrete.Commands.Movement;
using ToyRobot.Core.Concrete.Robot;
using ToyRobot.Core.Enum;
using ToyRobot.Models;

namespace ToyRobot.Core.Game
{
    public class RobotGame
    {
        private readonly IRobot Robot;

        public RobotGame(IBoard board)
        {
            Robot = new Robot(board);
        }

        public RobotResultModel Start(string input)
        {
            var commands = Helpers.Parser.Commands(input);
            if (commands == null)
                return null;


            /* Command List */
            foreach (string item in commands)
            {
                if (string.IsNullOrEmpty(item))
                    continue;

                string command = "";

                if (item.Length == 4)
                    command = item;

                if (item.Length > 4)
                    command = item.Substring(0, 5);


                RobotCommand CommandType;
                if (Helpers.Validation.IsEnumerable<RobotCommand>(command) == null)
                {
                    continue;
                }

                CommandType = (RobotCommand)Helpers.Validation.IsEnumerable<RobotCommand>(command);

                /* Set Place */
                if (CommandType == RobotCommand.Place)
                    Robot.Place(item);

                /* Turn Left */
                if (CommandType == RobotCommand.Left)
                    Robot.ExecuteMovementCommand(new TurnLeftMovementCommand());

                /* Turn Right */
                if (CommandType == RobotCommand.Right)
                    Robot.ExecuteMovementCommand(new TurnRightMovementCommand());

                /* Move Forward */
                if (CommandType == RobotCommand.Move)
                    Robot.ExecuteMovementCommand(new ForwardMovementCommand());

                /* Yell */
                if (CommandType == RobotCommand.Report)
                {
                    /* 
                    * !!!
                    * Robot always Reports 
                    */
                }
            }


            if (Robot != null && Robot.HasPosition())
                return new RobotResultModel(Robot.Position.CurrentX, Robot.Position.CurrentY, Robot.Position.CurrentDirection);
            else
                return null;
        }
    }
}
