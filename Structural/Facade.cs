namespace DesignPattern.Structural;

/// <summary>
/// A facade is an object that provides a simplified interface
/// to a larger body of code, such as a class library.
/// </summary>
public class Facade
{
    public interface ISubsystem
    {
        void Operation();
    }

    public class SubsystemA : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem A: Performing operation A");
        }
    }

    public class SubsystemB : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem B: Performing operation B");
        }
    }

    public class SubsystemC : ISubsystem
    {
        public void Operation()
        {
            Console.WriteLine("Subsystem C: Performing operation C");
        }
    }

    public class FacadeOperator
    {
        private ISubsystem _subsystemA = new SubsystemA();
        private ISubsystem _subsystemB = new SubsystemB();
        private ISubsystem _subsystemC = new SubsystemC();

        public void PerformOperations()
        {
            Console.WriteLine("Facade is performing complex operations:");
            _subsystemA.Operation();
            _subsystemB.Operation();
            _subsystemC.Operation();
        }
    }
}