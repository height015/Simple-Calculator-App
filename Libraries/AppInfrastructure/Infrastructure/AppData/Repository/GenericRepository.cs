using System;
using AppCore;
using Infrastructure.AppData.Context;
using Microsoft.EntityFrameworkCore;

namespace AppData.Repository;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    private readonly AppDbContext _appDbContext;
	public GenericRepository(AppDbContext appDbContext)
	{
        _appDbContext = appDbContext;
    }

    public async Task<T> Add(T entity)
    {
        await _appDbContext.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
        return entity;
    }

    public Task<T> ClearAllRecords()
    {
        throw new NotImplementedException();
    }

    public async Task Delete(Guid Id)
    {
       var entity = await _appDbContext.Set<T>().FindAsync(Id);
        if (entity != null)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
        }
    }

    public async Task<T> Get(Guid Id)
    {
        return await _appDbContext.Set<T>().FindAsync(Id);
    }

    public async Task<IReadOnlyList<T>> GetAll()
    {
        return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
    }
}

