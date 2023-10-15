using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Teach.Data;
using Teach.Entities;

namespace Teach.Services.Generics;

public class GenericRepository<TEntity, TContext> : IGenericRepository<TEntity> where TEntity : class, IEntity where TContext : DbContext
{
    private readonly TContext _context;

    public GenericRepository(TContext context) => _context = context;
    

    public async Task<IEnumerable<TEntity>> GetAllAsync() => await _context.Set<TEntity>().ToListAsync();

    public async Task<IEnumerable<TEntity>> GetAllIncludingAsync(params Expression<Func<TEntity, object>>[] includeProperties)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
        return await query.ToListAsync();
    }

    public async Task<List<TEntity>> GetAll() => await _context.Set<TEntity>().ToListAsync();

    public async Task<TEntity?> Get(int id) => await _context.Set<TEntity>().FindAsync(id);

    public async Task<TEntity> Add(TEntity entity)
    {
        _context.Set<TEntity>().Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> Delete(int id)
    {
        var entity = await _context.Set<TEntity>().FindAsync(id);
        if (entity == null) return entity;

        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();

        return entity;
    }

    public async Task SaveAsync()
    {
        await _context.SaveChangesAsync();
    }
}