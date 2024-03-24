namespace DesignPattern.Behavioral;

/// <summary>
/// The Visitor Design Pattern is a behavioral design pattern that allows you to define
/// a new operation without changing the classes of the elements on which it operates.
/// It achieves this by separating the concerns of the algorithm from the elements on which it operates.
/// This pattern is useful when you have a set of classes with a fixed structure,
/// but you want to perform different operations on them without modifying their code.
/// </summary>
public abstract class Visitor
{
    internal interface IShape
    {
        void Accept(IVisitor visitor);
    }

    internal class Circle : IShape
    {
        internal double Radius { get; set; }

        internal Circle(double radius)
        {
            Radius = radius;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitCircle(this);
        }
    }

    internal class Square : IShape
    {
        internal double Side { get; set; }

        internal Square(double side)
        {
            Side = side;
        }

        public void Accept(IVisitor visitor)
        {
            visitor.VisitSquare(this);
        }
    }

    internal interface IVisitor
    {
        void VisitCircle(Circle circle);
        void VisitSquare(Square square);
    }

    internal class AreaCalculator : IVisitor
    {
        public void VisitCircle(Circle circle)
        {
            var area = Math.PI * Math.Pow(circle.Radius, 2);
            Console.WriteLine($"Area of Circle with radius {circle.Radius}: {area}");
        }

        public void VisitSquare(Square square)
        {
            var area = Math.Pow(square.Side, 2);
            Console.WriteLine($"Area of Square with side {square.Side}: {area}");
        }
    }
}