using System;
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


            /* !!!
             * Need a new class for ForEach
             * Param string[] commands
             * Return Value RobotResultModel
             */
            foreach (string item in commands)
            {
                if (string.IsNullOrEmpty(item))
                    continue;


                string command = item;

                /* Only specific comamnd (PLACE) */
                if (
                    item.Length > 4 &&
                    string.Equals(item.Substring(0, 5), RobotCommand.Place.ToString(), StringComparison.OrdinalIgnoreCase)
                    )
                    command = item.Substring(0, 5);


                /* 
                 * Func checks each command if it is available, If needs a new command, just add new command to enum class 
                 */
                RobotCommand CommandType;
                if (Helpers.Validation.IsEnumerable<RobotCommand>(command) == null)
                    continue;
                

                /* Set valid command type to variable */
                CommandType = (RobotCommand)Helpers.Validation.IsEnumerable<RobotCommand>(command);


                /* If command is "PLACE" */
                if (CommandType == RobotCommand.Place)
                {
                    var _ = Robot.PlaceParser(item);
                    if (!_)
                        return null;
                }


                /* If command is "LEFT" */
                if (CommandType == RobotCommand.Left)
                {
                    var _ = Robot.ExecuteMovementCommand(new TurnLeftMovementCommand());
                    if (!_)
                    {
                        /* Custom Exception Management (ExecuteMovementCommand) */
                    }
                }


                /* If command is "RIGHT" */
                if (CommandType == RobotCommand.Right)
                {
                    var _ = Robot.ExecuteMovementCommand(new TurnRightMovementCommand());
                    if (!_)
                    {
                        /* Custom Exception Management (ExecuteMovementCommand) */
                    }
                }


                /* If command is "MOVE" */
                if (CommandType == RobotCommand.Move)
                {
                    var _ = Robot.ExecuteMovementCommand(new ForwardMovementCommand());
                    if (!_)
                    {
                        /* Custom Exception Management (ExecuteMovementCommand) */
                    }
                }
                    

                /* Yell */
                if (CommandType == RobotCommand.Report)
                {
                    /* 
                    * !!!
                    * Robot always yell now 
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
