namespace DesignPattern.Creational;

/// <summary>
/// This is useful when exactly one object is needed to coordinate actions across the system.
/// </summary>
internal class Singleton
{
    private static Singleton _instance = null!;

    private Singleton()
    {
    }
    
    public static Singleton GetInstance()
    {
        return _instance ??= new Singleton();
    }
}