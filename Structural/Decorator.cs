namespace DesignPattern.Structural;

/// <summary>
/// The decorator pattern is a design pattern that allows behavior to be added to an individual object,
/// either statically or dynamically, without affecting the behavior of other objects from the same class.
/// </summary>
public abstract class Decorator
{
    internal interface IPizza
    {
        string GetDescription();
        double GetCost();
    }

    internal class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Pizza";
        public double GetCost() => 150000;
    }

    internal abstract class PizzaDecorator : IPizza
    {
        protected readonly IPizza Pizza;

        protected PizzaDecorator(IPizza pizza)
        {
            Pizza = pizza;
        }
        public abstract string GetDescription();
        public abstract double GetCost();
    }

    internal class CheeseDecorator : PizzaDecorator
    {
        internal CheeseDecorator(IPizza pizza) : base(pizza)
        {
        }
        public override string GetDescription() => Pizza.GetDescription() + "+ Cheese";
        public override double GetCost() => Pizza.GetCost() + 40000;
    }

    internal class TomatoDecorator : PizzaDecorator
    {
        internal TomatoDecorator(IPizza pizza) : base(pizza)
        {
        }
        public override string GetDescription() => Pizza.GetDescription() + "+ Tomato";
        public override double GetCost() => Pizza.GetCost() + 30000;
    }
}