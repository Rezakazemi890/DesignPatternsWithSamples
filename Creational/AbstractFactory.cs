namespace DesignPattern.Creational;

/// <summary>
/// The abstract factory pattern provides a way to encapsulate a
/// group of individual factories that have a common theme without specifying their concrete classes
/// </summary>
public abstract class AbstractFactory
{
    internal interface IWindow
    {
        void GetDescription();
    }

    private class WoodenWindow : IWindow
    {
        public void GetDescription()
        {
            Console.WriteLine("I am a wooden Window");
        }
    }

    private class IronWindow : IWindow
    {
        public void GetDescription()
        {
            Console.WriteLine("I am a iron Window");
        }
    }

    internal interface IWindowFittingExpert
    {
        void GetDescription();
    }

    private class Welder : IWindowFittingExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("I can only fit iron Windows");
        }
    }

    private class Carpenter : IWindowFittingExpert
    {
        public void GetDescription()
        {
            Console.WriteLine("I can only fit wooden Windows");
        }
    }

    internal interface IWindowFactory
    {
        IWindow MakeWindow();
        IWindowFittingExpert MakeFittingExpert();
    }

    internal class WoodenWindowFactory : IWindowFactory
    {
        public IWindow MakeWindow()
        {
            return new WoodenWindow();
        }

        public IWindowFittingExpert MakeFittingExpert()
        {
            return new Carpenter();
        }
    }

    internal class IronWindowFactory : IWindowFactory
    {
        public IWindow MakeWindow()
        {
            return new IronWindow();
        }

        public IWindowFittingExpert MakeFittingExpert()
        {
            return new Welder();
        }
    }
}