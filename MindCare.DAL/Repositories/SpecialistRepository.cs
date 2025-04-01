using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.DAL.Repositories
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly MindCareDbContext _context;

        public SpecialistRepository(MindCareDbContext context)
        {
            _context = context;
        }

        public async Task<Specialist> GetByIdAsync(Guid id)
        {
            return await _context.Specialists.FindAsync(id);
        }

        public async Task<IEnumerable<Specialist>> GetAllAsync()
        {
            return await _context.Specialists.ToListAsync();
        }

        public async Task AddAsync(Specialist specialist)
        {
            await _context.Specialists.AddAsync(specialist);
        }

        public void Update(Specialist specialist)
        {
            _context.Specialists.Update(specialist);
        }

        public async Task DeleteAsync(Guid id)
        {
            var specialist = await GetByIdAsync(id);
            if (specialist != null)
            {
                _context.Specialists.Remove(specialist);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
