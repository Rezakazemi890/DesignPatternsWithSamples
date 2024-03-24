namespace DesignPattern.Creational;

/// <summary>
/// The Prototype Design Pattern is a creational pattern that allows you to create new objects by copying an existing object,
/// known as the prototype. This pattern is useful when creating an object is more expensive than copying an existing one.
/// </summary>
public abstract class Prototype
{
    internal interface ICloneableShape
    {
        ICloneableShape Clone();
        void Draw();
    }

    internal class Circle : ICloneableShape
    {
        internal int Radius { get; init; }

        public ICloneableShape Clone()
        {
            return new Circle { Radius = this.Radius };
        }

        public void Draw()
        {
            Console.WriteLine($"Drawing a circle with radius {Radius}");
        }
    }
}