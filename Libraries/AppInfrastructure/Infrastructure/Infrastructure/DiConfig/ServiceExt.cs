using System;
using AppData.Contracts;
using AppData.Repository;
using AppData.Services;
using Factory;
using Infrastructure.AppData.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AppData.DiConfig;

public static class ServiceExt
{
	public static IServiceCollection ServiceConfigurationExt(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnections")));
		services.AddScoped(typeof(IGenericRepository<>),typeof(GenericRepository<>));
        services.AddScoped<ICalculationHistoryService, CalculationHistoryRepository>();
        services.AddSingleton<CalculatorOperationFactory>();

        return services;
	}
}

