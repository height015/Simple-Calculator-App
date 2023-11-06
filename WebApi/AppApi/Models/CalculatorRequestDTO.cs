using System;
namespace ApplicationApi.Models;

public class CalculatorRequestDTO
{
    public double Opt1 { get; set; }
    public double Opt2 { get; set; }
    public string Operator { get; set; }
}

