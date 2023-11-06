using System;
using System.ComponentModel.DataAnnotations;

namespace AppCore.Domain.History;

public class CalculationHistory : BaseEntity
{
    public double Operand1 { get; set; }
    public double Operand2 { get; set; }
    [StringLength(3, MinimumLength = 1, ErrorMessage = "Operator contains fewer or more characters than expected. (1 to 3 characters are expected)")]
    [Required(AllowEmptyStrings = false)]
    public string Operator { get; set; }
    public double Result { get; set; }
    public DateTime Timestamp { get; set; }
}

