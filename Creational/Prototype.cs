namespace DesignPattern.Creational;

/// <summary>
/// The Prototype Design Pattern is a creational pattern that allows you to create new objects by copying an existing object,
/// known as the prototype. This pattern is useful when creating an object is more expensive than copying an existing one.
/// </summary>
public class Prototype
{
    public interface ICloneableShape
    {
        ICloneableShape Clone();
        void Draw();
    }

    public class Circle : ICloneableShape
    {
        public int Radius { get; set; }

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