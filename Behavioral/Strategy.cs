namespace DesignPattern.Behavioral;

/// <summary>
/// he strategy pattern (also known as the policy pattern) is a behavioural software design
/// pattern that enables an algorithm's behavior to be selected at runtime.
/// </summary>
public abstract class Strategy
{
    internal interface IPaymentStrategy
    {
        void ProcessPayment(double amount);
    }

    internal class CreditCardPaymentStrategy : IPaymentStrategy
    {
        private readonly string _cardNumber;

        internal CreditCardPaymentStrategy(string cardNumber)
        {
            _cardNumber = cardNumber;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing credit card payment of {amount}T using card number {_cardNumber}");
        }
    }

    internal class PayPalPaymentStrategy : IPaymentStrategy
    {
        private readonly string _email;

        internal PayPalPaymentStrategy(string email)
        {
            _email = email;
        }

        public void ProcessPayment(double amount)
        {
            Console.WriteLine($"Processing PayPal payment of {amount}T using email {_email}");
        }
    }

    internal class ShoppingCart
    {
        private IPaymentStrategy _paymentStrategy = null!;

        internal void SetPaymentStrategy(IPaymentStrategy paymentStrategy)
        {
            _paymentStrategy = paymentStrategy;
        }

        internal void Checkout(double totalAmount)
        {
            _paymentStrategy.ProcessPayment(totalAmount);
            Console.WriteLine($"Payment of {totalAmount}T successfully processed.");
        }
    }
}