namespace DesignPattern.Creational;

/// <summary>
/// This is useful when exactly one object is needed to coordinate actions across the system.
/// </summary>
public class Singleton
{
    static Singleton _instance;

    private Singleton()
    {
    }
    
    public static Singleton GetInstance()
    {
        if (_instance == null) {
            _instance = new Singleton();
        }
        return _instance;
    }
}