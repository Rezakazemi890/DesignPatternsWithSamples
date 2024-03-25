namespace DesignPattern.Structural;

/// <summary>
/// The Bridge Design Pattern is a structural pattern that separates the abstraction from its implementation,
/// allowing them to vary independently. It helps in avoiding a permanent binding between an abstraction and
/// its implementation.
/// </summary>
public abstract class Bridge
{
    internal abstract class Shape
    {
        protected readonly IDrawApi DrawApi;

        protected Shape(IDrawApi drawApi)
        {
            this.DrawApi = drawApi;
        }

        internal abstract void Draw();
    }

    internal interface IDrawApi
    {
        void DrawCircle(int radius, int x, int y);
    }

    internal class DrawApi1 : IDrawApi
    {
        public void DrawCircle(int radius, int x, int y)
        {
            Console.WriteLine($"Drawing Circle[Api1] with radius {radius} at ({x}, {y})");
        }
    }

    internal class BridgeCircle : Shape
    {
        private readonly int _x, _y, _radius;

        internal BridgeCircle(int x, int y, int radius, IDrawApi drawApi)
            : base(drawApi)
        {
            this._x = x;
            this._y = y;
            this._radius = radius;
        }

        internal override void Draw()
        {
            DrawApi.DrawCircle(_radius, _x, _y);
        }
    }
}