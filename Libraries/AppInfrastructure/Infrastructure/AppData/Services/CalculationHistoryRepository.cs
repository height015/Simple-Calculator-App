using System;
using AppCore.Domain.History;
using AppData.Contracts;
using AppData.Repository;
using Infrastructure.AppData.Context;

namespace AppData.Services;

public class CalculationHistoryRepository : GenericRepository<CalculationHistory>, ICalculationHistoryService
{
    public CalculationHistoryRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}

