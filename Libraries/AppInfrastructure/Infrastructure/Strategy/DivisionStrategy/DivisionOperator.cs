using System;
using AppCore;
using System.Net;

namespace Strategy.DivisionStrategy;

public class DivisionStrategy : ICalculatorOperator
{
    public AppApiResponse<double> Calculate(double operand1, double operand2)
    {
        if (operand2 == 0)
        {
            throw new ArgumentException($" Maths Error! Division by {operand2} not allowed.");
        }
        try
        {
            var result = operand1 / operand2;
            return AppApiResponse<double>.Create(HttpStatusCode.OK, "Successful", result);
        }
        catch (Exception)
        {
            return AppApiResponse<double>.Create(HttpStatusCode.InternalServerError, "An error occurred while calculating", 0.0);
        }
    }
}

