using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;

namespace MindCare.DAL.Repositories;
public class AvailabilityRepository : IRepository<Availability>
{
    private readonly MindCareDbContext _dbContext;

    public AvailabilityRepository(MindCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Availability entity)
    {
        await _dbContext.Availabilities.AddAsync(entity);
    }

    public IQueryable<Availability> GetAll()
    {
        return _dbContext.Availabilities.AsNoTracking();
    }

    public async Task<Availability?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Availabilities.FindAsync(id);
    }

    public void Remove(Availability entity)
    {
        _dbContext.Availabilities.Remove(entity);
    }

    public void Update(Availability entity)
    {
        _dbContext.Availabilities.Update(entity);
    }
}
