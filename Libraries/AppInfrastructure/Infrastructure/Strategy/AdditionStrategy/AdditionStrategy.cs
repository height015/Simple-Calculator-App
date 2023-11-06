using System;
using System.Net;
using AppCore;

namespace Strategy.AdditionStrategy;

public class AdditionStrategy : ICalculatorOperator
{
   public AppApiResponse<double> Calculate(double operand1, double operand2)
    {
		try
		{
            var result = operand1 + operand2;
            return AppApiResponse<double>.Create(HttpStatusCode.OK, "Successful", result);
        }
		catch (Exception)
		{
            return AppApiResponse<double>.Create(HttpStatusCode.InternalServerError, "An error occurred while calculating", 0.0);
        }

    }
}

