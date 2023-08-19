namespace DesignPattern.Behavioral;

/// <summary>
/// An object, called the subject, maintains a list of its dependents,
/// called observers, and notifies them automatically of any state changes,
/// usually by calling one of their methods.
/// </summary>
public class Observer
{
    public interface IObserver
    {
        void Update(float temperature);
    }

    public interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyObservers();
    }

    public class ConcreteObserver : IObserver
    {
        private string _name;

        public ConcreteObserver(string name)
        {
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} received temperature update: {temperature}°C");
        }
    }

    public class WeatherStation : ISubject
    {
        private List<IObserver> _observers = new List<IObserver>();
        private float _temperature;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void SetTemperature(float temperature)
        {
            _temperature = temperature;
            NotifyObservers();
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_temperature);
            }
        }
    }
}