namespace DesignPattern.Structural;

/// <summary>
/// The Flyweight Design Pattern is a structural pattern that minimizes memory usage or computational
/// expenses by sharing as much as possible with related objects. It is particularly useful
/// when you have a large number of similar objects.
/// </summary>
public abstract class Flyweight
{
    internal interface IShape
    {
        void Draw(int x, int y);
    }

    private class FlyweightCircle : IShape
    {
        private readonly int _radius;

        internal FlyweightCircle(int radius)
        {
            this._radius = radius;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing Circle with radius {_radius} at ({x}, {y})");
        }
    }

    internal class ShapeFactory
    {
        private readonly Dictionary<string, IShape> _shapes = new Dictionary<string, IShape>();

        internal IShape GetShape(string key)
        {
            if (!_shapes.ContainsKey(key))
            {
                // Create and cache the flyweight object if not already present
                _shapes[key] = new FlyweightCircle(int.Parse(key));
            }

            return _shapes[key];
        }
    }
}