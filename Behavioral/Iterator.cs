namespace DesignPattern.Behavioral;

/// <summary>
/// The Iterator Design Pattern is a behavioral pattern that provides a way to access the elements of
/// an aggregate object sequentially without exposing its underlying representation.
/// </summary>
public class Iterator
{
    public interface IAggregate
    {
        IIterator GetIterator();
    }

    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    public class ConcreteAggregate : IAggregate
    {
        private readonly object[] items;

        public ConcreteAggregate()
        {
            items = new object[] { "Item 1", "Item 2", "Item 3" };
        }

        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        public int Count
        {
            get { return items.Length; }
        }

        public object this[int index] => items[index];
    }

    public class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate aggregate;
        private int currentIndex = 0;

        public ConcreteIterator(ConcreteAggregate aggregate)
        {
            this.aggregate = aggregate;
        }

        public bool HasNext()
        {
            return currentIndex < aggregate.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                return aggregate[currentIndex++];
            }
            else
            {
                throw new InvalidOperationException("End of collection reached.");
            }
        }
    }
}