namespace DesignPattern.Behavioral;

/// <summary>
/// The mediator pattern defines an object that encapsulates how a set of objects interact.
/// This pattern is considered to be a behavioral pattern due to the way
/// it can alter the program's running behavior.
/// </summary>
public class Mediator
{
    // Mediator
    public interface IAirTrafficControl
    {
        void RegisterAircraft(IAircraft aircraft);
        void SendWarningMessage(string message, IAircraft aircraft);
    }

    // Concrete Mediator
    public class AirTrafficControl : IAirTrafficControl
    {
        private List<IAircraft> _aircraftList = new List<IAircraft>();

        public void RegisterAircraft(IAircraft aircraft)
        {
            _aircraftList.Add(aircraft);
        }

        public void SendWarningMessage(string message, IAircraft sender)
        {
            Console.WriteLine($"ATC: {message}");
            foreach (var aircraft in _aircraftList)
            {
                if (aircraft != sender)
                {
                    aircraft.ReceiveWarning(message);
                }
            }
        }
    }

    //Colleague
    public interface IAircraft
    {
        void SendWarning(string message);
        void ReceiveWarning(string message);
    }

    // Concrete Colleague
    public class Aircraft : IAircraft
    {
        private readonly string _callSign;
        private readonly IAirTrafficControl _atc;

        public Aircraft(string callSign, IAirTrafficControl atc)
        {
            _callSign = callSign;
            _atc = atc;
            _atc.RegisterAircraft(this);
        }
        
        public void SendWarning(string message)
        {
            _atc.SendWarningMessage(message, this);
        }

        public void ReceiveWarning(string message)
        {
            Console.WriteLine($"{_callSign} received warning: {message}");
        }
    }
}