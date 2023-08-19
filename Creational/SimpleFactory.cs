namespace DesignPattern.Creational;

/// <summary>
/// A factory is an object for creating other objects
/// – formally a factory is a function or method that returns objects of
/// a varying prototype or class from some method call
/// </summary>
public class SimpleFactory
{
    public interface IDesk
    {
        int GetHeight();
        int GetWidth();
        int GetLength();
    }

    public class WoodenDesk : IDesk
    {
        private int Height { get; set; }
        private int Width { get; set; }
        private int Length { get; set; }

        public WoodenDesk(int height, int width, int length)
        {
            this.Height = height;
            this.Width = width;
            this.Length = length;
        }

        public int GetHeight()
        {
            return this.Height;
        }

        public int GetWidth()
        {
            return this.Width;
        }

        public int GetLength()
        {
            return this.Length;
        }
    }

    public static class DeskFactory
    {
        public static IDesk MakeDesk(int height, int width, int length)
        {
            return new WoodenDesk(height, width, length);
        }
    }
}