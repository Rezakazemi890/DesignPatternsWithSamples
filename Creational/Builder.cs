using System.Text;

namespace DesignPattern.Creational;

/// <summary>
/// The builder pattern is an object creation software design pattern
/// with the intentions of finding a solution to the telescoping constructor anti-pattern.
/// </summary>
public class Builder
{
    public class Burger
    {
        private int _size;
        private bool _cheese;
        private bool _pepperoni;
        private bool _lettuce;
        private bool _tomato;

        public Burger(BurgerBuilder builder)
        {
            this._size = builder.Size;
            this._cheese = builder.Cheese;
            this._pepperoni = builder.Pepperoni;
            this._lettuce = builder.Lettuce;
            this._tomato = builder.Tomato;
        }

        public string GetDescription()
        {
            var sb = new StringBuilder();
            sb.Append($"This is {this._size} cm Burger. have cheese: {this._cheese} - have pepperoni: {this._pepperoni} - have lettuce: {this._lettuce} - have tomato: {this._tomato}");
            return sb.ToString();
        }
    }

    public class BurgerBuilder {
        public int Size;
        public bool Cheese;
        public bool Pepperoni;
        public bool Lettuce;
        public bool Tomato;

        public BurgerBuilder(int size)
        {
            this.Size = size;
        }

        public BurgerBuilder AddCheese()
        {
            this.Cheese = true;
            return this;
        }

        public BurgerBuilder AddPepperoni()
        {
            this.Pepperoni = true;
            return this;
        }

        public BurgerBuilder AddLettuce()
        {
            this.Lettuce = true;
            return this;
        }

        public BurgerBuilder AddTomato()
        {
            this.Tomato = true;
            return this;
        }

        public Burger Build()
        {
            return new Burger(this);
        }
    }
}