using AppCore.Domain.Calculator;
using AppCore.Domain.History;
using ApplicationApi.Models;

namespace ApplicationApi.Mappers;

public static class MappingExtention
{
	public static CalculatorRequestDTO ToDTO(this CalculatorRequest calculatorRequest)
	{
        return new CalculatorRequestDTO
        {
            Opt1 = calculatorRequest.Operand1,
            Opt2 = calculatorRequest.Operand2,
            Operator = calculatorRequest.Operator,
        };

    }
    public static CreateCalculationHistoryDTO ToDTO(this CalculationHistory calculationHistory)
    {
        return new CreateCalculationHistoryDTO
        {
            Opt1 = calculationHistory.Operand1,
            Opt2 = calculationHistory.Operand2,
            Operator = calculationHistory.Operator,
            Result = calculationHistory.Result,
        };

    }
    public static CalculationHistoryDetailsDTO AsDTO(this CalculationHistory calculationHistory)
    {
        return new CalculationHistoryDetailsDTO
        {
            Opt1 = calculationHistory.Operand1,
            Opt2 = calculationHistory.Operand2,
            Operator = calculationHistory.Operator,
            Result = calculationHistory.Result,
            Timestamp = calculationHistory.Timestamp
        };

    }
}

