namespace DesignPattern.Creational;

/// <summary>
/// the factory method pattern is a creational pattern that uses factory methods
/// to deal with the problem of creating objects without having to specify the exact
/// class of the object that will be created. This is done by creating objects by
/// calling a factory method—either specified in an interface and implemented by
/// child classes, or implemented in a base class and optionally overridden by
/// derived classes—rather than by calling a constructor.
/// </summary>
public abstract class FactoryMethod
{
    internal interface IChair
    {
        void CreateChair();
    }

    private class WoodenChair : IChair
    {
        public void CreateChair()
        {
            Console.WriteLine("Wooden Chair Created!");
        }
    }

    private class MetalChair : IChair
    {
        public void CreateChair()
        {
            Console.WriteLine("Metal Chair Created!");
        }
    }

    internal abstract class ChairSeller
    {
        protected abstract IChair ChairCreator();

        internal void SellChair()
        {
            var creator = this.ChairCreator();
            creator.CreateChair();
        }
    }

    internal class WoodenChairSeller : ChairSeller
    {
        protected override IChair ChairCreator()
        {
            return new WoodenChair();
        }
    }

    internal class MetalChairSeller : ChairSeller
    {
        protected override IChair ChairCreator()
        {
            return new MetalChair();
        }
    }
}