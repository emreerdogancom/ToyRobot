using System;

namespace ToyRobot.Core.Helpers
{
    public static class Parser
    {
        public static string[] Commands(string input)
        {
            if (input == null || input.Length <= 0)
            {
                //throw new ArgumentNullException("input cannot be empty");
                return null;
            }

            /* Cleaning, pattern also can be applied */
            input = input.Replace("\"", string.Empty).Trim();


            /* Splitting to find each command */
            var commands = input?.Split("\\n", StringSplitOptions.None);
            if (commands == null || commands.Length <= 0)
            {
                return null;
            }

            return commands;
        }
    }
}
