using MindCare.DAL.Entities;

namespace MindCare.DAL.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(Guid id);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        void Update(User user);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
