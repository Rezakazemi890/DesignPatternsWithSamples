namespace DesignPattern.Behavioral;

/// <summary>
/// The Interpreter Design Pattern is a behavioral pattern that defines a grammar for interpreting
/// the sentences of a language and provides an interpreter to interpret those sentences.
/// </summary>
public abstract class Interpreter
{
    internal class Context
    {
        public string? Input { get; set; }
        public int Output { get; set; }
    }

    internal interface IExpression
    {
        void Interpret(Context context);
    }

    internal class NumberExpression : IExpression
    {
        private readonly int _number;

        internal NumberExpression(int number)
        {
            this._number = number;
        }

        public void Interpret(Context context)
        {
            context.Output = _number;
        }
    }

    internal class AddExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly IExpression _right;

        internal AddExpression(IExpression left, IExpression right)
        {
            this._left = left;
            this._right = right;
        }

        public void Interpret(Context context)
        {
            _left.Interpret(context);
            var leftValue = context.Output;

            _right.Interpret(context);
            var rightValue = context.Output;

            context.Output = leftValue + rightValue;
        }
    }
}