namespace DesignPattern.Behavioral;

/// <summary>
/// The mediator pattern defines an object that encapsulates how a set of objects interact.
/// This pattern is considered to be a behavioral pattern due to the way
/// it can alter the program's running behavior.
/// </summary>
public abstract class Mediator
{
    // Mediator
    internal interface IAirTrafficControl
    {
        void RegisterAircraft(IAircraft aircraft);
        void SendWarningMessage(string message, IAircraft aircraft);
    }

    // Concrete Mediator
    internal class AirTrafficControl : IAirTrafficControl
    {
        private readonly List<IAircraft> _aircraftList = new List<IAircraft>();

        public void RegisterAircraft(IAircraft aircraft)
        {
            _aircraftList.Add(aircraft);
        }

        public void SendWarningMessage(string message, IAircraft sender)
        {
            Console.WriteLine($"ATC: {message}");
            var index = 0;
            for (; index < _aircraftList.Count; index++)
            {
                var aircraft = _aircraftList[index];
                if (aircraft != sender)
                {
                    aircraft.ReceiveWarning(message);
                }
            }
        }
    }

    //Colleague
    internal interface IAircraft
    {
        void SendWarning(string message);
        void ReceiveWarning(string message);
    }

    // Concrete Colleague
    internal class Aircraft : IAircraft
    {
        private readonly string _callSign;
        private readonly IAirTrafficControl _atc;

        internal Aircraft(string callSign, IAirTrafficControl atc)
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