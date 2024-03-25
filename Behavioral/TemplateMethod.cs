namespace DesignPattern.Behavioral;

/// <summary>
/// The Template Method Design Pattern is a behavioral design pattern that defines the skeleton of
/// an algorithm in a method in the base class but lets subclasses override specific steps of the
/// algorithm without changing its structure. This pattern promotes code reuse by providing a common
/// template for an algorithm while allowing individual steps to be implemented by subclasses.
/// </summary>
public abstract class TemplateMethod
{
    internal abstract class BeverageTemplate
    {
        // The template method that defines the algorithm
        internal void PrepareBeverage()
        {
            BoilWater();
            Brew();
            PourInCup();
            AddCondiments();
        }
        
        protected abstract void Brew();
        protected abstract void AddCondiments();
        
        private static void BoilWater()
        {
            Console.WriteLine("Boiling water");
        }

        private static void PourInCup()
        {
            Console.WriteLine("Pouring into cup");
        }
    }

    internal class Tea : BeverageTemplate
    {
        protected override void Brew()
        {
            Console.WriteLine("Steeping the tea");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding lemon");
        }
    }

    internal class Coffee : BeverageTemplate
    {
        protected override void Brew()
        {
            Console.WriteLine("Dripping coffee through filter");
        }

        protected override void AddCondiments()
        {
            Console.WriteLine("Adding sugar and milk");
        }
    }
}