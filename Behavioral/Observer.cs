namespace DesignPattern.Behavioral;

/// <summary>
/// An object, called the subject, maintains a list of its dependents,
/// called observers, and notifies them automatically of any state changes,
/// usually by calling one of their methods.
/// </summary>
public abstract class Observer
{
    internal interface IObserver
    {
        void Update(float temperature);
    }

    private interface ISubject
    {
        void Attach(IObserver observer);
        void Detach(IObserver observer);
        void NotifyObservers();
    }

    internal class ConcreteObserver : IObserver
    {
        private readonly string _name;

        internal ConcreteObserver(string name)
        {
            _name = name;
        }

        public void Update(float temperature)
        {
            Console.WriteLine($"{_name} received temperature update: {temperature}°C");
        }
    }

    internal class WeatherStation : ISubject
    {
        private readonly List<IObserver> _observers = new List<IObserver>();
        private float _temperature;

        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
        }

        internal void SetTemperature(float temperature)
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