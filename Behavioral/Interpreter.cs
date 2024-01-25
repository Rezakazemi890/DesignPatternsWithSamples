namespace DesignPattern.Behavioral;

/// <summary>
/// The Interpreter Design Pattern is a behavioral pattern that defines a grammar for interpreting
/// the sentences of a language and provides an interpreter to interpret those sentences.
/// </summary>
public class Interpreter
{
    public class Context
    {
        public string Input { get; set; }
        public int Output { get; set; }
    }

    public interface IExpression
    {
        void Interpret(Context context);
    }

    public class NumberExpression : IExpression
    {
        private readonly int number;

        public NumberExpression(int number)
        {
            this.number = number;
        }

        public void Interpret(Context context)
        {
            context.Output = number;
        }
    }

    public class AddExpression : IExpression
    {
        private readonly IExpression left;
        private readonly IExpression right;

        public AddExpression(IExpression left, IExpression right)
        {
            this.left = left;
            this.right = right;
        }

        public void Interpret(Context context)
        {
            left.Interpret(context);
            int leftValue = context.Output;

            right.Interpret(context);
            int rightValue = context.Output;

            context.Output = leftValue + rightValue;
        }
    }
}