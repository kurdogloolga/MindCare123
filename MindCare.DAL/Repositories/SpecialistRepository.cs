using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;

namespace MindCare.DAL.Repositories;
public class SpecialistRepository : IRepository<Specialist>
{
    private readonly MindCareDbContext _dbContext;

    public SpecialistRepository(MindCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Specialist entity)
    {
        await _dbContext.Specialists.AddAsync(entity);
    }

    public IQueryable<Specialist> GetAll()
    {
        return _dbContext.Specialists.AsNoTracking();
    }

    public async Task<Specialist?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Specialists.FindAsync(id);
    }

    public void Remove(Specialist entity)
    {
        _dbContext.Specialists.Remove(entity);
    }

    public void Update(Specialist entity)
    {
        _dbContext.Specialists.Update(entity);
    }
}
