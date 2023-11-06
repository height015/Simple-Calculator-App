using System;
namespace AppCore.Domain.History;

public class CalculationHistory : BaseEntity
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    public string Operator { get; set; }
    public double Result { get; set; }
    public DateTime Timestamp { get; set; }
}

