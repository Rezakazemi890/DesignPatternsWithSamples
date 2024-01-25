namespace DesignPattern.Structural;

/// <summary>
/// The Composite Design Pattern is a structural pattern that lets you compose objects into tree structures to
/// represent part-whole hierarchies. It allows clients to treat individual objects and compositions of objects
/// uniformly.
/// </summary>
public class Composite
{
    public interface IGraphic
    {
        void Draw();
    }

    public class CompositeCircle : IGraphic
    {
        public void Draw()
        {
            Console.WriteLine("Drawing Circle");
        }
    }

    public class CompositeGraphic : IGraphic
    {
        private readonly List<IGraphic> graphics = new List<IGraphic>();

        public void Add(IGraphic graphic)
        {
            graphics.Add(graphic);
        }

        public void Draw()
        {
            Console.WriteLine("Drawing Composite Graphic");
            foreach (var graphic in graphics)
            {
                graphic.Draw();
            }
        }
    }
}