namespace DesignPattern.Behavioral;

/// <summary>
/// The Iterator Design Pattern is a behavioral pattern that provides a way to access the elements of
/// an aggregate object sequentially without exposing its underlying representation.
/// </summary>
public abstract class Iterator
{
    private interface IAggregate
    {
        IIterator GetIterator();
    }

    internal interface IIterator
    {
        bool HasNext();
        object Next();
    }

    internal class ConcreteAggregate : IAggregate
    {
        private readonly object[] _items = new object[] { "Item 1", "Item 2", "Item 3" };

        public IIterator GetIterator()
        {
            return new ConcreteIterator(this);
        }

        internal int Count => _items.Length;

        internal object this[int index] => _items[index];
    }

    private class ConcreteIterator : IIterator
    {
        private readonly ConcreteAggregate _aggregate;
        private int _currentIndex = 0;

        internal ConcreteIterator(ConcreteAggregate aggregate)
        {
            this._aggregate = aggregate;
        }

        public bool HasNext()
        {
            return _currentIndex < _aggregate.Count;
        }

        public object Next()
        {
            if (HasNext())
            {
                return _aggregate[_currentIndex++];
            }
            else
            {
                throw new InvalidOperationException("End of collection reached.");
            }
        }
    }
}