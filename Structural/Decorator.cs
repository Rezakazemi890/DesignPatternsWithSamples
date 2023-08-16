namespace DesignPattern.Structural;

/// <summary>
/// The decorator pattern is a design pattern that allows behavior to be added to an individual object,
/// either statically or dynamically, without affecting the behavior of other objects from the same class.
/// </summary>
public class Decorator
{
    public interface IPizza
    {
        string GetDescription();
        double GetCost();
    }
    
    public class PlainPizza : IPizza
    {
        public string GetDescription() => "Plain Pizza";
        public double GetCost() => 150000;
    }

    public abstract class PizzaDecorator : IPizza
    {
        protected IPizza _pizza;

        public PizzaDecorator(IPizza pizza)
        {
            _pizza = pizza;
        }
        public abstract string GetDescription();
        public abstract double GetCost();
    }
    
    public class CheeseDecorator : PizzaDecorator
    {
        public CheeseDecorator(IPizza pizza) : base(pizza)
        {
        }
        public override string GetDescription() => _pizza.GetDescription() + "+ Cheese";
        public override double GetCost() => _pizza.GetCost() + 40000;
    }

    public class TomatoDecorator : PizzaDecorator
    {
        public TomatoDecorator(IPizza pizza) : base(pizza)
        {
        }
        public override string GetDescription() => _pizza.GetDescription() + "+ Tomato";
        public override double GetCost() => _pizza.GetCost() + 30000;
    }
}