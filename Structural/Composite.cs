namespace DesignPattern.Structural;

/// <summary>
/// The Composite Design Pattern is a structural pattern that lets you compose objects into tree structures to
/// represent part-whole hierarchies. It allows clients to treat individual objects and compositions of objects
/// uniformly.
/// </summary>
public abstract class Composite
{
    internal interface IGraphic
    {
        void Draw();
    }

    internal class CompositeCircle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    internal class CompositeGraphic : IGraphic
    {
        private readonly List<IGraphic> _graphics = new List<IGraphic>();

        internal void Add(IGraphic graphic)
        {
            _graphics.Add(graphic);
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Composite Graphic");
            foreach (var graphic in _graphics)
            {
                graphic.Draw();
            }
        }
    }
}