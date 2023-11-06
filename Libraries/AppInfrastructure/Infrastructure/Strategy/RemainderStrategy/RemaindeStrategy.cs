using System;
using System.Net;
using AppCore;

namespace Strategy.RemainderStrategy;

public class RemaindeStrategy : ICalculatorOperator
{
   public AppApiResponse<double> Calculate(double operand1, double operand2)
    {
		try
		{
            var result = operand1 % operand2;
            return AppApiResponse<double>.Create(HttpStatusCode.OK, "Successful", result);
        }
		catch (Exception)
		{
            return AppApiResponse<double>.Create(HttpStatusCode.InternalServerError, "An error occurred while calculating", 0.0);

        }
    }
}

