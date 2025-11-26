using HotelListing.API.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.ObjectModel;

namespace HotelListing.API.Repository;

public class BaseRepository<T>(HotelListingDb context) : IBaseRepository<T> where T : class
{
    protected readonly HotelListingDb context = context;
    protected readonly DbSet<T> dbSet = context.Set<T>();

    public async Task<T> AddAsync(T entity)
    {
        await dbSet.AddAsync(entity);
        return entity;
    }

    public async Task DeleteAsync(int id)
    {
        var entity = await dbSet.FindAsync(id);
        if(entity != null) 
        {  
            dbSet.Remove(entity); 
        }
    
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await dbSet.FindAsync(id);
    }

    public async Task UpdateAsync(T entity)
    {
        dbSet.Update(entity);
    }
}
