namespace DesignPattern.Behavioral;

/// <summary>
/// The command pattern is a behavioral design pattern in which an object is used to encapsulate all
/// information needed to perform an action or trigger an event at a later time.
/// This information includes the method name, the object that owns the method and values for the method parameters.
/// </summary>
public abstract class Command
{
    internal interface ICommand
    {
        void Execute();
    }

    internal class Light
    {
        public static void TurnOn()
        {
            Console.WriteLine("Light is on");
        }

        public static void TurnOff()
        {
            Console.WriteLine("Light is off");
        }
    }

    internal class Tv
    {
        public static void TurnOn()
        {
            Console.WriteLine("TV is on");
        }

        public static void TurnOff()
        {
            Console.WriteLine("TV is off");
        }
    }

    internal class LightOnCommand : ICommand
    {
        private readonly Light _light;

        internal LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Light.TurnOn();
        }
    }

    internal class LightOffCommand : ICommand
    {
        private readonly Light _light;

        internal LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            Light.TurnOff();
        }
    }

    internal class TvOnCommand : ICommand
    {
        private readonly Tv _tv;

        internal TvOnCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            Tv.TurnOn();
        }
    }

    internal class TvOffCommand : ICommand
    {
        private readonly Tv _tv;

        internal TvOffCommand(Tv tv)
        {
            _tv = tv;
        }

        public void Execute()
        {
            Tv.TurnOff();
        }
    }

    internal class RemoteControl
    {
        private readonly List<ICommand> _onCommands = new List<ICommand>();
        private readonly List<ICommand> _offCommands = new List<ICommand>();

        internal void SetCommand(ICommand onCommand, ICommand offCommand)
        {
            _onCommands.Add(onCommand);
            _offCommands.Add(offCommand);
        }

        internal void PressOnButton(int slot)
        {
            _onCommands[slot].Execute();
        }

        internal void PressOffButton(int slot)
        {
            _offCommands[slot].Execute();
        }
    }
}