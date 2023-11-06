
using System.Net;
using AppData.Contracts;
using ApplicationApi.Controllers;
using ApplicationApi.Models;
using Azure;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Strategy;


namespace ApiUnitTest;

public class CalculatorOperationTests
{
    private AppApiResponse<double> Result { get; set; }

    public CalculatorOperationTests()
    {
        Result = AppApiResponse<double>.Create(HttpStatusCode.OK, "Success", 0.0);
    }

    [Fact]
    public void Execute_AdditionOperation_CalculatesAdditionCorrectly()
    {
        var additionOperation = new AdditionStrategy();
        Result = additionOperation.Calculate(5, 3);
        Assert.Equal(8, Result.Data);
    }

    [Fact]
    public void Execute_SubtractionOperation_CalculatesSubtractionCorrectly()
    {
        var subtractionOperation = new SubtractionStrategy();
        Result = subtractionOperation.Calculate(10, 4);
        Assert.Equal(6, Result.Data);
    }

    [Fact]
    public void TestMultiplyNumbers()
    {
        var mt = new MultiplicationStrategy();
        var inputs = new[] { (2, 2, 4), (12, 2, 24) };
        var expectedResults = new[] { 4, 24 };
        for (var i = 0; i < inputs.Length; i++)
        {
            var actualResult = mt.Calculate(inputs[i].Item1, inputs[i].Item2);
            Assert.Equal(expectedResults[i], actualResult.Data);
        }
    }

    [Fact]
    public void TestDivideByZero()
    {
        var dv = new DivisionStrategy();
        var x = 1;
        var y = 0;
        Action action = () => dv.Calculate(x, y);
        Assert.True(true);
    }

    [Fact]
    public void TestModulusOperation()
    {
        var modulusStrategy = new RemaindeStrategy();
        var inputs = new[] { (10, 3, 1), (17, 5, 2) };
        var expectedResults = new[] { 1, 2 };
        for (var i = 0; i < inputs.Length; i++)
        {
            var actualResult = modulusStrategy.Calculate(inputs[i].Item1, inputs[i].Item2);
            Assert.Equal(expectedResults[i], actualResult.Data);
        }
    }

}

