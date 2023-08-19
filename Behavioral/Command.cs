namespace DesignPattern.Behavioral;

/// <summary>
/// The command pattern is a behavioral design pattern in which an object is used to encapsulate all
/// information needed to perform an action or trigger an event at a later time.
/// This information includes the method name, the object that owns the method and values for the method parameters.
/// </summary>
public class Command
{
    public interface ICommand
    {
        void Execute();
    }

    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("Light is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("Light is off");
        }
    }

    public class Tv
    {
        public void TurnOn()
        {
            Console.WriteLine("TV is on");
        }

        public void TurnOff()
        {
            Console.WriteLine("TV is off");
        }
    }

    public class LightOnCommand : ICommand
    {
        private readonly Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    public class LightOffCommand : ICommand
    {
        private readonly Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }

    public class TvOnCommand : ICommand
    {
        private readonly Tv _tv;

        public TvOnCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOn();
        }
    }

    public class TvOffCommand : ICommand
    {
        private readonly Tv _tv;

        public TvOffCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            _tv.TurnOff();
        }
    }

    public class RemoteControl
    {
        private readonly List<ICommand> _onCommands = new List<ICommand>();
        private readonly List<ICommand> _offCommands = new List<ICommand>();

        public void SetCommand(ICommand onCommand, ICommand offCommand)
        {
            _onCommands.Add(onCommand);
            _offCommands.Add(offCommand);
        }

        public void PressOnButton(int slot)
        {
            _onCommands[slot].Execute();
        }

        public void PressOffButton(int slot)
        {
            _offCommands[slot].Execute();
        }
    }
}