using CarLeasing.Data.Models.Base;
using Microsoft.EntityFrameworkCore;

namespace CarLeasing.Data;

/// <summary>
/// Общий репозиторий для приложения CarLeasing.
/// </summary>
public class CarLeasingRepository : ICarLeasingRepository
{
    private readonly CarLeasingContext _context;

    public CarLeasingRepository(CarLeasingContext context) => _context = context;

    public async Task<TEntity?> GetAsync<TEntity>(uint id) where TEntity : Entity => await _context.Set<TEntity>().FindAsync(id);

    public async Task<TResult?> GetAsync<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : Entity =>
        await specification.AppendQuery(_context.Set<TEntity>()).FirstOrDefaultAsync();

    public IQueryable<TEntity> Find<TEntity>() where TEntity : Entity => _context.Set<TEntity>();

    public IQueryable<TResult> Find<TEntity, TResult>(ISpecification<TEntity, TResult> specification) where TEntity : Entity =>
        specification.AppendQuery(_context.Set<TEntity>());

    public async Task<TEntity> AddAsync<TEntity>(TEntity entity) where TEntity : Entity
    {
        _ = await _context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync<TEntity>(IEnumerable<TEntity> entities) where TEntity : Entity =>
        await _context.Set<TEntity>().AddRangeAsync(entities);

    public void Update<TEntity>(TEntity entity) where TEntity : Entity => _context.Set<TEntity>().Update(entity);

    public async Task DeleteAsync<TEntity>(uint id) where TEntity : Entity
    {
        var entity = await GetAsync<TEntity>(id);
        if (entity is not null) _ = _context.Set<TEntity>().Remove(entity);
    }

    public async Task<int> SaveChangesAsync() => await _context.SaveChangesAsync();
}
