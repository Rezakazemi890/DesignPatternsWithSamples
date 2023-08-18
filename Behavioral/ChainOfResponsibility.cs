namespace DesignPattern.Behavioral;

/// <summary>
/// The chain-of-responsibility pattern is a design pattern consisting of a source
/// of command objects and a series of processing objects. Each processing object
/// contains logic that defines the types of command objects that it can handle;
/// the rest are passed to the next processing object in the chain.
/// </summary>
public class ChainOfResponsibility
{
    public interface IHelpDeskHandler
    {
        void HandleTicket(HelpDeskTicket ticket);
    }

    public class LevelOneSupport : IHelpDeskHandler
    {
        private readonly IHelpDeskHandler _nextHandler = new LevelTwoSupport();

        public void HandleTicket(HelpDeskTicket ticket)
        {
            if (ticket.Severity <= 1)
            {
                Console.WriteLine($"Support Level 1 handled the ticket. with Desc: {ticket.Description}");
            }
            else
            {
                _nextHandler.HandleTicket(ticket);
            }
        }
    }

    private class LevelTwoSupport : IHelpDeskHandler
    {
        private readonly IHelpDeskHandler _nextHandler = new LevelThreeSupport();

        public void HandleTicket(HelpDeskTicket ticket)
        {
            if (ticket.Severity > 1 && ticket.Severity <= 3)
            {
                Console.WriteLine($"Support Level 2 handled the ticket. with Desc: {ticket.Description}");
            }
            else
            {
                _nextHandler.HandleTicket(ticket);
            }
        }
    }

    private class LevelThreeSupport : IHelpDeskHandler
    {
        public void HandleTicket(HelpDeskTicket ticket)
        {
            Console.WriteLine(ticket.Severity > 3
                ? $"Support Level 3 handled the ticket. with Desc: {ticket.Description}"
                : $"Support Level 3 cannot handle this ticket. with Desc: {ticket.Description}");
        }
    }

    public record HelpDeskTicket(int Severity, string Description);
}