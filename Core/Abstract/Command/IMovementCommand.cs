using ToyRobot.Core.Abstract.Robot;

namespace ToyRobot.Core.Abstract.Command
{
    /// <summary>
    /// Movement interface
    /// </summary>
    public interface IMovementCommand
    {
        bool Invoke(IRobot Robot);
    }
}
