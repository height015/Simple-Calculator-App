using System;
namespace AppCore.Domain.Calculator;

public class CalculatorRequest : BaseEntity
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    public string Operator { get; set; }
}

