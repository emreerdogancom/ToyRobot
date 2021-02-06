using ToyRobot.Core.Abstract.Robot;

namespace ToyRobot.Core.Abstract.Command
{
    /// <summary>
    /// Movement interface
    /// </summary>
    public interface IMovementCommand : ICommand
    {
        bool Invoke(IRobot Robot);
    }
}
