namespace DesignPattern.Structural;

/// <summary>
/// The Flyweight Design Pattern is a structural pattern that minimizes memory usage or computational
/// expenses by sharing as much as possible with related objects. It is particularly useful
/// when you have a large number of similar objects.
/// </summary>
public class Flyweight
{
    public interface IShape
    {
        void Draw(int x, int y);
    }

    public class FlyweightCircle : IShape
    {
        private readonly int radius;

        public FlyweightCircle(int radius)
        {
            this.radius = radius;
        }

        public void Draw(int x, int y)
        {
            Console.WriteLine($"Drawing Circle with radius {radius} at ({x}, {y})");
        }
    }

    public class ShapeFactory
    {
        private readonly Dictionary<string, IShape> shapes = new Dictionary<string, IShape>();

        public IShape GetShape(string key)
        {
            if (!shapes.ContainsKey(key))
            {
                // Create and cache the flyweight object if not already present
                shapes[key] = new FlyweightCircle(int.Parse(key));
            }

            return shapes[key];
        }
    }
}