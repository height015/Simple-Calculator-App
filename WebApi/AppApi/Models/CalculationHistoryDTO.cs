using System;
using AppCore;

namespace ApplicationApi.Models;

public class CreateCalculationHistoryDTO
{
    public double Opt1 { get; set; }
    public double Opt2 { get; set; }
    public string Operator { get; set; }
    public double Result { get; set; }
}
public class CalculationHistoryDetailsDTO
{
    public double Opt1 { get; set; }
    public double Opt2 { get; set; }
    public string Operator { get; set; }
    public double Result { get; set; }
    public DateTime Timestamp { get; set; }
}

