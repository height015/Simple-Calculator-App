using System;
using AppCore;

namespace AppData.Repository;

public interface IGenericRepository<T> where T: class
{
    Task<T> Get(Guid Id);
    Task<IReadOnlyList<T>> GetAll();
    Task<T> Add(T entity);
    Task Delete(Guid Id);
    Task<T> ClearAllRecords();
}

