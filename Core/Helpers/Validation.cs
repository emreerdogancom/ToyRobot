namespace ToyRobot.Core.Helpers
{
    public static class Validation
    {
        /// <summary>
        /// Numeric Parse
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int? IsNumeric(string input)
        {
            int? result = null;
            int res;
            var success = int.TryParse(input, out res);
            return success ? res : result;
        }

        /// <summary>
        /// Dynamic Enumaration Parse
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="input"></param>
        /// <returns></returns>
        public static T? IsEnumerable<T>(string input) where T : struct
        {
            T EnumType;
            var success = System.Enum.TryParse<T>(input, true, out EnumType);

            return success ? EnumType : null;
        }
    }

}
