using Strategy;
using Strategy.AdditionStrategy;
using Strategy.DivisionStrategy;
using Strategy.MultiplicationStrategy;
using Strategy.RemainderStrategy;
using Strategy.SubtractionStrategy;

namespace Factory;

public class CalculatorOperationFactory
{
    public ICalculatorOperator CreateOperation(string operation)
    {
        switch (operation)
        {
            case "+":
                return new AdditionStrategy();
            case "-":
                return new SubtractionStrategy();
            case "*":
                return new MultiplicationStrategy();
            case "/":
                return new DivisionStrategy();
            case "%":
                return new RemaindeStrategy();
            default:
                throw new ArgumentException($"No Defined Strategy for {operation} operation");
        }
    }
}

