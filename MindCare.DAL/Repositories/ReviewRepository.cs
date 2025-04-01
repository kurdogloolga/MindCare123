using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.DAL.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly MindCareDbContext _context;

        public ReviewRepository(MindCareDbContext context)
        {
            _context = context;
        }

        public async Task<Review> GetByIdAsync(Guid id)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Specialist)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Specialist)
                .ToListAsync();
        }

        public async Task<IEnumerable<Review>> GetReviewsForSpecialistAsync(Guid specialistId)
        {
            return await _context.Reviews
                .Include(r => r.User)
                .Include(r => r.Specialist)
                .Where(r => r.SpecialistId == specialistId)
                .ToListAsync();
        }

        public async Task AddAsync(Review review)
        {
            await _context.Reviews.AddAsync(review);
        }

        public void Update(Review review)
        {
            _context.Reviews.Update(review);
        }

        public async Task DeleteAsync(Guid id)
        {
            var review = await GetByIdAsync(id);
            if (review != null)
            {
                _context.Reviews.Remove(review);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
