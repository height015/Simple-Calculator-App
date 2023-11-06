using System;
using AppCore;

namespace Strategy;

public interface ICalculatorOperator
{
   AppApiResponse<double> Calculate(double operand1, double operand2);
}

