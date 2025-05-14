using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Abstraction;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;

namespace MindCare.DAL.Repositories;
public class ReviewRepository : IRepository<Review>
{
    private readonly MindCareDbContext _dbContext;

    public ReviewRepository(MindCareDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Review entity)
    {
        await _dbContext.Reviews.AddAsync(entity);
    }

    public IQueryable<Review> GetAll()
    {
        return _dbContext.Reviews.AsNoTracking();
    }

    public async Task<Review?> GetByIdAsync(Guid id)
    {
        return await _dbContext.Reviews.FindAsync(id);
    }

    public void Remove(Review entity)
    {
        _dbContext.Reviews.Remove(entity);
    }

    public void Update(Review entity)
    {
        _dbContext.Reviews.Update(entity);
    }
}
