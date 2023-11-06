using System;
using AppCore.Domain.History;
using AppData.Repository;

namespace AppData.Contracts;

public interface ICalculationHistoryService : IGenericRepository<CalculationHistory>
{
}

