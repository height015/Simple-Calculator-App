using System;
using AppCore.Domain.History;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.AppData.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
    }

    public DbSet<CalculationHistory> CalculationHistory { get; set; }
}

