using System.Text;

namespace DesignPattern.Creational;

/// <summary>
/// The builder pattern is an object creation software design pattern
/// with the intentions of finding a solution to the telescoping constructor anti-pattern.
/// </summary>
public abstract class Builder
{
    internal class Burger
    {
        private readonly int _size;
        private readonly bool _cheese;
        private readonly bool _pepperoni;
        private readonly bool _lettuce;
        private readonly bool _tomato;

        internal Burger(BurgerBuilder builder)
        {
            this._size = builder.Size;
            this._cheese = builder.Cheese;
            this._pepperoni = builder.Pepperoni;
            this._lettuce = builder.Lettuce;
            this._tomato = builder.Tomato;
        }

        internal string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append($"This is {this._size} cm Burger. have cheese: {this._cheese} - have pepperoni: {this._pepperoni} - have lettuce: {this._lettuce} - have tomato: {this._tomato}");
            return sb.ToString();
        }
    }

    internal class BurgerBuilder {
        internal readonly int Size;
        internal bool Cheese;
        internal bool Pepperoni;
        internal bool Lettuce;
        internal bool Tomato;

        internal BurgerBuilder(int size)
        {
            this.Size = size;
        }

        internal BurgerBuilder AddCheese()
        {
            this.Cheese = true;
            return this;
        }

        internal BurgerBuilder AddPepperoni()
        {
            this.Pepperoni = true;
            return this;
        }

        internal BurgerBuilder AddLettuce()
        {
            this.Lettuce = true;
            return this;
        }

        internal BurgerBuilder AddTomato()
        {
            this.Tomato = true;
            return this;
        }

        internal Burger Build()
        {
            return new Burger(this);
        }
    }
}