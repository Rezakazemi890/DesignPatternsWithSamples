namespace DesignPattern.Behavioral;

/// <summary>
/// The Memento Design Pattern is a behavioral pattern
/// that allows an object's internal state to be captured and restored.
/// It is useful for implementing undo mechanisms or preserving the state of an object at a certain point in time.
/// </summary>
public class Memento
{
    public class Mementos
    {
        public string State { get; private set; }

        public Mementos(string state)
        {
            State = state;
        }
    }

    public class Originator
    {
        public string State { get; set; }

        public Mementos CreateMemento()
        {
            return new Mementos(State);
        }

        public void RestoreMemento(Mementos memento)
        {
            State = memento.State;
        }
    }

    public class Caretaker
    {
        public Mementos Memento { get; set; }
    }
}
