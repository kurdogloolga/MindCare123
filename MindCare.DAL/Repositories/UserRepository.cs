using Microsoft.EntityFrameworkCore;
using MindCare.DAL.Context;
using MindCare.DAL.Entities;
using MindCare.DAL.Interfaces;

namespace MindCare.DAL.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly MindCareDbContext _context;

        public UserRepository(MindCareDbContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(Guid id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task AddAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public void Update(User user)
        {
            _context.Users.Update(user);
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await GetByIdAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
            }
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
