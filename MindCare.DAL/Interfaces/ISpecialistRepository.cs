using MindCare.DAL.Entities;

namespace MindCare.DAL.Interfaces
{
    public interface ISpecialistRepository
    {
        Task<Specialist> GetByIdAsync(Guid id);
        Task<IEnumerable<Specialist>> GetAllAsync();
        Task AddAsync(Specialist specialist);
        void Update(Specialist specialist);
        Task DeleteAsync(Guid id);
        Task<int> SaveChangesAsync();
    }
}
