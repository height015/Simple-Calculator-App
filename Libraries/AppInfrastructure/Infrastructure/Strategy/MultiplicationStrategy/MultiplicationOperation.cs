using System;
using AppCore;
using System.Net;

namespace Strategy.MultiplicationStrategy;

public class MultiplicationStrategy : ICalculatorOperator
{
    public AppApiResponse<double> Calculate(double operand1, double operand2)
    {
		try
		{
            var result = operand1 * operand2;
            return AppApiResponse<double>.Create(HttpStatusCode.OK, "Successful", result);
        }
		catch (Exception)
		{
            return AppApiResponse<double>.Create(HttpStatusCode.InternalServerError, "An error occurred while calculating", 0.0);
        }
    }
}

