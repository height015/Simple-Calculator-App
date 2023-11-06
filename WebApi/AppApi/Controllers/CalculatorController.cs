
using System.Net;
using AppCore;
using AppCore.Domain.History;
using AppData.Contracts;
using AppData.Infrastructure.Route;
using ApplicationApi.Mappers;
using ApplicationApi.Models;
using Factory;
using Microsoft.AspNetCore.Mvc;
using Strategy;

namespace ApplicationApi.Controllers;
[Route(CalculatorRoute.Calculator)]
public class CalculatorController : ControllerBase
{
    private readonly CalculatorOperationFactory _calculatorOperationFactory;
    private readonly ICalculationHistoryService _calculationHistoryService;

    public CalculatorController(CalculatorOperationFactory calculatorOperationFactory, ICalculationHistoryService calculationHistory)
    {
        _calculatorOperationFactory = calculatorOperationFactory;
        _calculationHistoryService = calculationHistory;
    }

    [HttpPost("calculate")]
    [ProducesResponseType(typeof(AppApiResponse<CalculatorRequestDTO>), 200)]
    [ProducesResponseType(typeof(AppApiResponse<List<string>>), 400)]
    
    public IActionResult Calculate([FromBody] CalculatorRequestDTO request)
    {
        var operation = _calculatorOperationFactory.CreateOperation(request.Operator);
        var result = operation.Calculate(request.Opt1, request.Opt2);
        var calculation = new CalculationHistory
        {
            Operand1 = request.Opt1,
            Operand2 = request.Opt2,
            Operator = request.Operator,
            Result = result.Data,
            Timestamp = DateTime.UtcNow
        };
        _calculationHistoryService.Add(calculation);
        return result.StatusCode == HttpStatusCode.OK? Ok(result) : BadRequest(result);
    }

    [HttpGet("calculations")]
    [ProducesResponseType(typeof(AppApiResponse<IEnumerable<CalculationHistoryDetailsDTO>>), 200)]
    [ProducesResponseType(typeof(AppApiResponse<List<string>>), 400)]
    [ProducesResponseType(typeof(AppApiResponse<List<string>>), 404)]
    public IActionResult CalculationHistory()
    {
        var operation =  _calculationHistoryService.GetAll().Result;
        var retVal = operation.Select(z => z.AsDTO());
        var result = new AppApiResponse<IEnumerable<CalculationHistoryDetailsDTO>>(
                     HttpStatusCode.OK,
                     "successful",
                     retVal);
        return Ok(result);
    }
}

