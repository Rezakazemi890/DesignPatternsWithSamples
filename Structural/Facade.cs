namespace DesignPattern.Structural;

/// <summary>
/// A facade is an object that provides a simplified interface
/// to a larger body of code, such as a class library.
/// </summary>
public abstract class Facade
{
    private interface ISubsystem
    {
        void Operation();
    }

    private class SubsystemA : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem A: Performing operation A");
        }
    }

    private class SubsystemB : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem B: Performing operation B");
        }
    }

    private class SubsystemC : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem C: Performing operation C");
        }
    }

    internal class FacadeOperator
    {
        private readonly ISubsystem _subsystemA = new SubsystemA();
        private readonly ISubsystem _subsystemB = new SubsystemB();
        private readonly ISubsystem _subsystemC = new SubsystemC();

        internal void PerformOperations()
        {
            Console.WriteLine("Facade is performing complex operations:");
            _subsystemA.Operation();
            _subsystemB.Operation();
            _subsystemC.Operation();
        }
    }
}