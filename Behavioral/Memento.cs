namespace DesignPattern.Behavioral;

/// <summary>
/// The Memento Design Pattern is a behavioral pattern
/// that allows an object's internal state to be captured and restored.
/// It is useful for implementing undo mechanisms or preserving the state of an object at a certain point in time.
/// </summary>
public abstract class Memento
{
    internal class Mementos
    {
        internal string State { get; private set; }

        internal Mementos(string state)
        {
            State = state;
        }
    }

    internal class Originator
    {
        internal string State { get; set; }

        internal Mementos CreateMemento()
        {
            return new Mementos(State);
        }

        internal void RestoreMemento(Mementos memento)
        {
            State = memento.State;
        }
    }

    internal class Caretaker
    {
        internal Mementos Memento { get; set; }
    }
}
