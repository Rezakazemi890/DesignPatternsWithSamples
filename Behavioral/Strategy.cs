namespace DesignPattern.Behavioral;

/// <summary>
/// he strategy pattern (also known as the policy pattern) is a behavioural software design
/// pattern that enables an algorithm's behavior to be selected at runtime.
/// </summary>
public class Strategy
{
    public interface IPaymentStrategy
    {
        void ProcessPayment(double amount);
    }

    public class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private string _cardNumber;

        public CreditCardPaymentStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}T using card number {_cardNumber}");
        }
    }

    public class PayPalPaymentStrategy : IPaymentStrategy
    {
        private string _email;

        public PayPalPaymentStrategy(string email)
        {
            _email = email;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}T using email {_email}");
        }
    }

    public class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy;

        public void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        public void Checkout(double totalAmount)
        {
            _paymentStrategy.ProcessPayment(totalAmount);
            Console.WriteLine($"Payment of {totalAmount}T successfully processed.");
        }
    }
}