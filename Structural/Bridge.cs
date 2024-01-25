namespace DesignPattern.Structural;

/// <summary>
/// The Bridge Design Pattern is a structural pattern that separates the abstraction from its implementation,
/// allowing them to vary independently. It helps in avoiding a permanent binding between an abstraction and
/// its implementation.
/// </summary>
public class Bridge
{
    public abstract class Shape
    {
        protected IDrawApi drawApi;

        protected Shape(IDrawApi drawApi)
        {
            this.drawApi = drawApi;
        }

        public abstract void Draw();
    }

    public interface IDrawApi
    {
        void DrawCircle(int radius, int x, int y);
    }

    public class DrawApi1 : IDrawApi
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle[Api1] with radius {radius} at ({x}, {y})");
        }
    }

    public class BridgeCircle : Shape
    {
        private int x, y, radius;

        public BridgeCircle(int x, int y, int radius, IDrawApi drawApi)
            : base(drawApi)
        {
            this.x = x;
            this.y = y;
            this.radius = radius;
        }

        public override void Draw()
        {
            drawApi.DrawCircle(radius, x, y);
        }
    }
}