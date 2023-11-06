﻿
using System.Net;
using AppCore.Domain.History;
using AppData.Contracts;
using AppData.Infrastructure.Route;
using ApplicationApi.Mappers;
using ApplicationApi.Models;
using Factory;
using Microsoft.AspNetCore.Mvc;

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
    public IActionResult Calculated()
    {
        var operation =  _calculationHistoryService.GetAll().Result;
        var retVal = operation.Select(z => z.AsDTO());
        return Ok(retVal);
    }
}
