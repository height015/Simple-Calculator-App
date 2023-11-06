using Strategy.AdditionStrategy;
using Strategy.DivisionStrategy;
using Strategy.MultiplicationStrategy;
using Strategy.RemainderStrategy;
using Strategy.SubtractionStrategy;

namespace ApiUnitTest;

public class CalculatorFactoryTests
{
    [Fact]
    public void Create_AdditionOperation_ReturnsAdditionOperation()
    {
        // Arrange
        var factory = new CalculatorOperationFactory();

        // Act
        ICalculatorOperator operation = factory.CreateOperation("+");

        // Assert
        Assert.IsType<AdditionStrategy>(operation);
    }

    [Fact]
    public void Create_SubtractionOperation_ReturnsSubtractionOperation()
    {
        var factory = new CalculatorOperationFactory();

        ICalculatorOperator operation = factory.CreateOperation("-");

        Assert.IsType<SubtractionStrategy>(operation);
    }

    [Fact]
    public void Create_DivisionOperation_ReturnsDivisionOperation()
    {
        var factory = new CalculatorOperationFactory();

        ICalculatorOperator operation = factory.CreateOperation("/");

        Assert.IsType<DivisionStrategy>(operation);
    }

    [Fact]
    public void Create_MultiplicationOperation_ReturnsMultiplicationOperation()
    {
        var factory = new CalculatorOperationFactory();

        ICalculatorOperator operation = factory.CreateOperation("*");

        Assert.IsType<MultiplicationStrategy>(operation);
    }

    [Fact]
    public void Create_RemainderOperation_ReturnsRemainderOperation()
    {
        var factory = new CalculatorOperationFactory();

        ICalculatorOperator operation = factory.CreateOperation("%");

        Assert.IsType<RemaindeStrategy>(operation);
    }

}
